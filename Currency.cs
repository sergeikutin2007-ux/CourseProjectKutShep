using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;

namespace AtmSystem
{
    public class CurrencyRate
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Nominal { get; set; }
        public decimal Value { get; set; }      // рублей за Nominal единиц валюты

        public decimal PerUnit
        {
            get { return Nominal <= 0 ? Value : Value / Nominal; }
        }
    }

    public class CurrencyResult
    {
        public bool Ok;
        public bool FromCache;
        public string Message;
        public string Date;
        public List<CurrencyRate> Rates = new List<CurrencyRate>();
    }

    // курсы валют ЦБ РФ через HttpClient: таймаут, обработка ошибок, запасной вариант из кэша
    public static class CurrencyService
    {
        static readonly HttpClient http = new HttpClient();

        static string CachePath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "currency_cache.json"); }
        }

        public static async Task<CurrencyResult> LoadAsync()
        {
            string json = null;
            string error = null;
            try
            {
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(Config.ApiTimeoutSeconds)))
                {
                    json = await http.GetStringAsync(Config.CurrencyUrl, cts.Token).ConfigureAwait(false);
                }
                var res = Parse(json);
                if (res.Rates.Count == 0) throw new FormatException("в ответе сервера нет курсов");
                try { File.WriteAllText(CachePath, json); } catch { }
                Log.Write("INFO", "Курсы валют загружены, валют: " + res.Rates.Count);
                return res;
            }
            catch (TaskCanceledException)
            {
                error = "сервер не ответил за " + Config.ApiTimeoutSeconds + " с";
            }
            catch (HttpRequestException ex)
            {
                error = "нет связи с сервером (" + ex.Message + ")";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            Log.Write("WARN", "Курсы валют не загружены: " + error);
            try
            {
                if (File.Exists(CachePath))
                {
                    var cached = Parse(File.ReadAllText(CachePath));
                    if (cached.Rates.Count > 0)
                    {
                        cached.FromCache = true;
                        cached.Message = "Нет связи, показаны сохраненные курсы от " + cached.Date + ". Причина: " + error;
                        return cached;
                    }
                }
            }
            catch { }
            return new CurrencyResult { Ok = false, Message = "Не удалось получить курсы: " + error };
        }

        // формат ответа определяется по первому символу: XML начинается с '<', JSON с '{'
        public static CurrencyResult Parse(string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && text.TrimStart().StartsWith("<")) return ParseXml(text);
            return ParseJson(text);
        }

        // разбор XML-ответа ЦБ РФ (cbr.ru/scripts/XML_daily.asp): дата в формате дд.мм.гггг, дробная часть через запятую
        public static CurrencyResult ParseXml(string xml)
        {
            var res = new CurrencyResult { Ok = true };
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                string date = doc.DocumentElement.GetAttribute("Date");
                DateTime dt;
                res.Date = DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)
                    ? dt.ToString("yyyy-MM-dd") : "";
                foreach (XmlNode v in doc.DocumentElement.SelectNodes("Valute"))
                {
                    res.Rates.Add(new CurrencyRate
                    {
                        Code = v.SelectSingleNode("CharCode").InnerText,
                        Nominal = int.Parse(v.SelectSingleNode("Nominal").InnerText, CultureInfo.InvariantCulture),
                        Name = v.SelectSingleNode("Name").InnerText,
                        Value = decimal.Parse(v.SelectSingleNode("Value").InnerText.Replace(',', '.'), CultureInfo.InvariantCulture)
                    });
                }
            }
            catch (Exception ex)
            {
                // неверная структура ответа: курсов нет, вызывающий код покажет сообщение
                Log.Write("WARN", "Не удалось разобрать XML: " + ex.Message);
                res.Rates.Clear();
            }
            return res;
        }

        // разбор JSON-ответа в формате cbr-xml-daily
        static CurrencyResult ParseJson(string json)
        {
            var res = new CurrencyResult { Ok = true };
            if (string.IsNullOrWhiteSpace(json)) return res;

            Match d = Regex.Match(json, @"""Date""\s*:\s*""(\d{4}-\d{2}-\d{2})");
            res.Date = d.Success ? d.Groups[1].Value : "";

            var rx = new Regex(@"""CharCode""\s*:\s*""(\w+)""\s*,\s*""Nominal""\s*:\s*(\d+)\s*,\s*""Name""\s*:\s*""([^""]*)""\s*,\s*""Value""\s*:\s*([0-9]+(?:\.[0-9]+)?)");
            foreach (Match m in rx.Matches(json))
            {
                res.Rates.Add(new CurrencyRate
                {
                    Code = m.Groups[1].Value,
                    Nominal = int.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture),
                    Name = m.Groups[3].Value,
                    Value = decimal.Parse(m.Groups[4].Value, CultureInfo.InvariantCulture)
                });
            }
            return res;
        }

        public static decimal FromRub(decimal rub, CurrencyRate rate)
        {
            if (rate == null || rate.PerUnit <= 0) return 0;
            return Math.Round(rub / rate.PerUnit, 2);
        }
    }
}
