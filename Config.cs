using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AtmSystem
{
    public static class Config
    {
        static IConfiguration cfg;

        static Config()
        {
            try
            {
                cfg = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", true, false)
                    .Build();
            }
            catch (Exception ex)
            {
                cfg = null;
                Log.Write("WARN", "appsettings.json не прочитан, взяты значения по умолчанию: " + ex.Message);
            }
        }

        static string Get(string key)
        {
            return cfg == null ? null : cfg[key];
        }

        static decimal Dec(string key, decimal def)
        {
            decimal v;
            string s = Get(key);
            if (s != null && decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out v) && v > 0) return v;
            return def;
        }

        static int Int(string key, int def)
        {
            int v;
            string s = Get(key);
            if (s != null && int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out v) && v > 0) return v;
            return def;
        }

        public static string DbFile
        {
            get
            {
                string name = Get("Database:FileName");
                if (string.IsNullOrWhiteSpace(name)) name = "atm.db";
                return Path.IsPathRooted(name) ? name : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
            }
        }

        public static decimal MinNote { get { return Dec("Atm:MinNote", 100m); } }
        public static decimal MaxDeposit { get { return Dec("Atm:MaxDeposit", 100000m); } }
        public static int MaxWrongPin { get { return Int("Atm:MaxWrongPin", 3); } }
        public static decimal DefaultDailyLimit { get { return Dec("Atm:DefaultDailyLimit", 100000m); } }
        public static int ServiceSeconds { get { return Int("Queueing:ServiceSeconds", 90); } }
        public static decimal TargetWaitMinutes { get { return Dec("Queueing:TargetWaitMinutes", 2m); } }
        public static string CurrencyUrl
        {
            get
            {
                string u = Get("Api:CurrencyUrl");
                return string.IsNullOrWhiteSpace(u) ? "https://www.cbr-xml-daily.ru/daily_json.js" : u;
            }
        }
        public static int ApiTimeoutSeconds { get { return Int("Api:TimeoutSeconds", 5); } }
        public static int PageSize { get { return Int("Report:PageSize", 50); } }
        public static int PeriodDays { get { return Int("Queueing:PeriodDays", 14); } }
    }
}
