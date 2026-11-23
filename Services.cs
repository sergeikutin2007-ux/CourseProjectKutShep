using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace AtmSystem
{
    public static class Security
    {
        public static string NewSalt()
        {
            byte[] b = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(b);
            return Convert.ToBase64String(b);
        }

        public static string Hash(string secret, string salt)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(salt + secret));
                return Convert.ToBase64String(bytes);
            }
        }
    }

    public static class Log
    {
        static readonly object Sync = new object();

        public static void Write(string level, string message)
        {
            // копия записи в окне Output среды разработки (только в Debug-сборке)
            Debug.WriteLine("[" + level + "] " + message);
            try
            {
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                Directory.CreateDirectory(dir);
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " [" + level + "] " + message + Environment.NewLine;
                lock (Sync) File.AppendAllText(Path.Combine(dir, "atm.log"), line, Encoding.UTF8);
            }
            catch
            {
                // лог не должен ронять программу
            }
        }
    }

    public static class Validator
    {
        public static bool Luhn(string number)
        {
            int sum = 0;
            bool alt = false;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int d = number[i] - '0';
                if (alt)
                {
                    d *= 2;
                    if (d > 9) d -= 9;
                }
                sum += d;
                alt = !alt;
            }
            return sum % 10 == 0;
        }

        public static string AccountNumber(string s)
        {
            if (!Regex.IsMatch(s ?? "", @"^\d{20}$")) return "Номер счета должен состоять из 20 цифр";
            return null;
        }

        public static string CardNumber(string s)
        {
            if (!Regex.IsMatch(s ?? "", @"^\d{16}$")) return "Номер карты должен состоять из 16 цифр";
            if (!Luhn(s)) return "Номер карты не прошел проверку контрольной суммы";
            return null;
        }

        public static string Owner(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Trim().Length < 3) return "Укажите владельца счета";
            if (!Regex.IsMatch(s, @"^[\p{L}\s\-\.]+$")) return "В имени владельца допустимы только буквы, пробел, точка и дефис";
            return null;
        }

        public static string Pin(string s)
        {
            if (!Regex.IsMatch(s ?? "", @"^\d{4}$")) return "Пин-код должен состоять из 4 цифр";
            return null;
        }

        // срок вводится как ММ/ГГ, хранится как гггг-мм
        public static string ExpiryInput(string s, out string stored)
        {
            stored = null;
            Match m = Regex.Match(s ?? "", @"^(0[1-9]|1[0-2])/(\d{2})$");
            if (!m.Success) return "Срок действия вводится в виде ММ/ГГ, например 12/29";
            stored = "20" + m.Groups[2].Value + "-" + m.Groups[1].Value;
            return null;
        }

        public static string ExpiryView(string stored)
        {
            if (stored == null || stored.Length != 7) return stored;
            return stored.Substring(5, 2) + "/" + stored.Substring(2, 2);
        }

        public static bool Expired(string stored)
        {
            int year = int.Parse(stored.Substring(0, 4));
            int month = int.Parse(stored.Substring(5, 2));
            DateTime last = new DateTime(year, month, 1).AddMonths(1);
            return DateTime.Today >= last;
        }

        public static bool ParseMoney(string s, out decimal value)
        {
            string t = (s ?? "").Trim().Replace(" ", "").Replace('.', ',');
            return decimal.TryParse(t, NumberStyles.Number, new CultureInfo("ru-RU"), out value);
        }
    }

    public class OpResult
    {
        public bool Ok;
        public string Message;
        public decimal Balance;
    }

    public static class AtmService
    {
        public static decimal MinNote { get { return Config.MinNote; } }
        public static decimal MaxDeposit { get { return Config.MaxDeposit; } }
        public static int MaxWrongPin { get { return Config.MaxWrongPin; } }

        public static Card Authorize(string cardNumber, string pin, out string error)
        {
            error = null;
            string pinHash = null, salt = null;
            Card card = null;
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null,
                "SELECT c.Id,c.CardNumber,c.AccountId,a.AccountNumber,a.OwnerName,c.Expiry,c.Status,c.FailedAttempts,c.PinHash,c.Salt " +
                "FROM Cards c JOIN Accounts a ON a.Id=c.AccountId WHERE c.CardNumber=@p0", cardNumber))
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    card = CardRepo.Read(r);
                    pinHash = r.GetString(8);
                    salt = r.GetString(9);
                }
            }

            if (card == null)
            {
                error = "Карта не найдена";
                Log.Write("WARN", "Попытка входа по неизвестной карте " + Mask(cardNumber));
                return null;
            }
            if (card.Status == "Blocked")
            {
                error = "Карта заблокирована. Обратитесь в банк";
                return null;
            }
            if (Validator.Expired(card.Expiry))
            {
                error = "Срок действия карты истек";
                return null;
            }

            if (Security.Hash(pin, salt) != pinHash)
            {
                int attempts = card.FailedAttempts + 1;
                string status = attempts >= MaxWrongPin ? "Blocked" : "Active";
                Db.NonQuery("UPDATE Cards SET FailedAttempts=@p0, Status=@p1 WHERE Id=@p2", attempts, status, card.Id);
                if (status == "Blocked")
                {
                    error = "Пин-код неверный. Карта заблокирована";
                    Log.Write("WARN", "Карта " + Mask(cardNumber) + " заблокирована после неверных пин-кодов");
                }
                else
                {
                    error = "Пин-код неверный. Осталось попыток: " + (MaxWrongPin - attempts);
                }
                return null;
            }

            if (card.FailedAttempts > 0)
                Db.NonQuery("UPDATE Cards SET FailedAttempts=0 WHERE Id=@p0", card.Id);
            return card;
        }

        public static string Mask(string number)
        {
            if (number == null || number.Length < 8) return number;
            return number.Substring(0, 4) + " **** **** " + number.Substring(number.Length - 4);
        }

        public static string ChangePin(Card card, string oldPin, string newPin)
        {
            string hash = null, salt = null;
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, "SELECT PinHash,Salt FROM Cards WHERE Id=@p0", card.Id))
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    hash = r.GetString(0);
                    salt = r.GetString(1);
                }
            }
            if (hash == null) return "Карта не найдена";
            if (Security.Hash(oldPin, salt) != hash) return "Текущий пин-код неверный";
            string err = Validator.Pin(newPin);
            if (err != null) return err;
            if (newPin == oldPin) return "Новый пин-код совпадает со старым";
            string newSalt = Security.NewSalt();
            Db.NonQuery("UPDATE Cards SET PinHash=@p0, Salt=@p1 WHERE Id=@p2", Security.Hash(newPin, newSalt), newSalt, card.Id);
            Log.Write("INFO", "Смена пин-кода, карта " + Mask(card.CardNumber));
            return null;
        }

        public static string Statement(int cardId, int count)
        {
            var sb = new StringBuilder();
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null,
                "SELECT OpTime,OpType,Amount,Success FROM Operations WHERE CardId=@p0 ORDER BY OpTime DESC, Id DESC LIMIT @p1", cardId, count))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    DateTime t = DateTime.Parse(r.GetString(0), CultureInfo.InvariantCulture);
                    string type = ReportService.TypeRu(r.GetString(1));
                    decimal amount = Db.Dec(r.GetValue(2));
                    string sum = r.GetString(1) == "Balance" ? "" : amount.ToString("N2");
                    sb.AppendLine(t.ToString("dd.MM HH:mm") + "  " + type.PadRight(9) + sum.PadLeft(12) + (r.GetInt32(3) == 1 ? "" : "  отказ"));
                }
            }
            if (sb.Length == 0) return "Операций по этой карте пока нет";
            return sb.ToString();
        }

        static void AddOperation(SqliteConnection c, SqliteTransaction tx, int atmId, Card card, string type, decimal amount, bool ok, string reason)
        {
            using (var cmd = Db.Cmd(c, tx,
                "INSERT INTO Operations(OpTime,AtmId,CardId,AccountId,OpType,Amount,Success,Reason) VALUES(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)",
                DateTime.Now, atmId, card.Id, card.AccountId, type, amount, ok ? 1 : 0, reason))
                cmd.ExecuteNonQuery();
        }

        static void ReadState(SqliteConnection c, SqliteTransaction tx, int atmId, Card card,
            out decimal balance, out decimal limit, out decimal cash, out string atmStatus)
        {
            balance = 0; limit = 0; cash = 0; atmStatus = null;
            using (var cmd = Db.Cmd(c, tx, "SELECT Balance,DailyLimit FROM Accounts WHERE Id=@p0", card.AccountId))
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    balance = Db.Dec(r.GetValue(0));
                    limit = Db.Dec(r.GetValue(1));
                }
            }
            using (var cmd = Db.Cmd(c, tx, "SELECT CashBalance,Status FROM Atms WHERE Id=@p0", atmId))
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    cash = Db.Dec(r.GetValue(0));
                    atmStatus = r.GetString(1);
                }
            }
        }

        static OpResult Fail(int atmId, Card card, string type, decimal amount, string reason)
        {
            using (var c = Db.Open())
                AddOperation(c, null, atmId, card, type, amount, false, reason);
            Log.Write("INFO", "Отказ: " + type + " " + amount + ", карта " + Mask(card.CardNumber) + ", причина: " + reason);
            return new OpResult { Ok = false, Message = reason };
        }

        public static OpResult GetBalance(int atmId, Card card)
        {
            using (var c = Db.Open())
            using (var tx = c.BeginTransaction())
            {
                decimal balance, limit, cash;
                string status;
                ReadState(c, tx, atmId, card, out balance, out limit, out cash, out status);
                AddOperation(c, tx, atmId, card, "Balance", 0, true, null);
                tx.Commit();
                return new OpResult { Ok = true, Balance = balance, Message = "Остаток на счете: " + balance.ToString("N2") + " руб." };
            }
        }

        public static OpResult Withdraw(int atmId, Card card, decimal amount)
        {
            using (var c = Db.Open())
            {
                string reason = null;
                decimal balance = 0;
                using (var tx = c.BeginTransaction())
                {
                    decimal limit, cash;
                    string status;
                    ReadState(c, tx, atmId, card, out balance, out limit, out cash, out status);

                    decimal spent = 0;
                    string dayStart = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                    using (var cmd = Db.Cmd(c, tx,
                        "SELECT COALESCE(SUM(Amount),0) FROM Operations WHERE AccountId=@p0 AND OpType='Withdraw' AND Success=1 AND OpTime>=@p1",
                        card.AccountId, dayStart))
                        spent = Db.Dec(cmd.ExecuteScalar());

                    if (status != "Working") reason = "Банкомат временно не работает";
                    else if (amount <= 0) reason = "Сумма должна быть больше нуля";
                    else if (amount % MinNote != 0) reason = "Сумма должна быть кратна " + MinNote.ToString("N0") + " руб.";
                    else if (amount > balance) reason = "Недостаточно средств на счете";
                    else if (spent + amount > limit) reason = "Превышен суточный лимит снятия";
                    else if (amount > cash) reason = "В банкомате недостаточно наличных";

                    if (reason == null)
                    {
                        using (var cmd = Db.Cmd(c, tx, "UPDATE Accounts SET Balance = Balance - @p0 WHERE Id=@p1", amount, card.AccountId))
                            cmd.ExecuteNonQuery();
                        using (var cmd = Db.Cmd(c, tx, "UPDATE Atms SET CashBalance = CashBalance - @p0 WHERE Id=@p1", amount, atmId))
                            cmd.ExecuteNonQuery();
                        AddOperation(c, tx, atmId, card, "Withdraw", amount, true, null);
                        tx.Commit();
                        balance -= amount;
                        Log.Write("INFO", "Снятие " + amount + ", карта " + Mask(card.CardNumber) + ", банкомат " + atmId);
                        return new OpResult { Ok = true, Balance = balance, Message = "Выдано " + amount.ToString("N2") + " руб. Остаток: " + balance.ToString("N2") + " руб." };
                    }
                }
                return Fail(atmId, card, "Withdraw", amount, reason);
            }
        }

        public static OpResult Deposit(int atmId, Card card, decimal amount)
        {
            using (var c = Db.Open())
            {
                string reason = null;
                decimal balance = 0;
                using (var tx = c.BeginTransaction())
                {
                    decimal limit, cash;
                    string status;
                    ReadState(c, tx, atmId, card, out balance, out limit, out cash, out status);

                    if (status != "Working") reason = "Банкомат временно не работает";
                    else if (amount <= 0) reason = "Сумма должна быть больше нуля";
                    else if (amount % MinNote != 0) reason = "Сумма должна быть кратна " + MinNote.ToString("N0") + " руб.";
                    else if (amount > MaxDeposit) reason = "За одну операцию можно внести не больше " + MaxDeposit.ToString("N0") + " руб.";

                    if (reason == null)
                    {
                        using (var cmd = Db.Cmd(c, tx, "UPDATE Accounts SET Balance = Balance + @p0 WHERE Id=@p1", amount, card.AccountId))
                            cmd.ExecuteNonQuery();
                        using (var cmd = Db.Cmd(c, tx, "UPDATE Atms SET CashBalance = CashBalance + @p0 WHERE Id=@p1", amount, atmId))
                            cmd.ExecuteNonQuery();
                        AddOperation(c, tx, atmId, card, "Deposit", amount, true, null);
                        tx.Commit();
                        balance += amount;
                        Log.Write("INFO", "Внесение " + amount + ", карта " + Mask(card.CardNumber) + ", банкомат " + atmId);
                        return new OpResult { Ok = true, Balance = balance, Message = "Внесено " + amount.ToString("N2") + " руб. Остаток: " + balance.ToString("N2") + " руб." };
                    }
                }
                return Fail(atmId, card, "Deposit", amount, reason);
            }
        }
    }

    public class PeriodStats
    {
        public int TotalOps;
        public int Days;
        public double AvgPerDay;
        public double Variance;
        public double Median;
        public int PeakHour;
        public double PeakLambda;
        public double StdDev;
        public double[] PerDay = new double[0];
        public double[] ByHour = new double[24];
    }

    public static class Stats
    {
        // среднее, дисперсия (генеральная, делим на n) и медиана набора значений
        public static void Describe(double[] values, out double mean, out double variance, out double median)
        {
            mean = 0; variance = 0; median = 0;
            if (values == null || values.Length == 0) return;
            int n = values.Length;
            double m = values.Average();
            mean = m;
            variance = values.Select(x => (x - m) * (x - m)).Sum() / n;
            double[] sorted = values.OrderBy(x => x).ToArray();
            median = n % 2 == 1 ? sorted[n / 2] : (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
        }

        // atmId = 0 означает все банкоматы
        public static PeriodStats ForPeriod(int atmId, int days)
        {
            DateTime from = DateTime.Today.AddDays(-days);
            DateTime to = DateTime.Today;
            var times = new List<DateTime>();

            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null,
                "SELECT OpTime FROM Operations WHERE OpTime>=@p0 AND OpTime<@p1 AND (@p2=0 OR AtmId=@p2)", from, to, atmId))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read()) times.Add(DateTime.Parse(r.GetString(0), CultureInfo.InvariantCulture));
            }

            var s = new PeriodStats();
            s.TotalOps = times.Count;
            s.Days = days;
            if (days <= 0 || times.Count == 0) return s;

            double[] perDay = new double[days];
            foreach (DateTime t in times)
            {
                int idx = (int)(t.Date - from).TotalDays;
                if (idx >= 0 && idx < days) perDay[idx]++;
            }
            double mean, variance, median;
            Describe(perDay, out mean, out variance, out median);
            s.PerDay = perDay;
            s.AvgPerDay = mean;
            s.Variance = variance;
            s.StdDev = Math.Sqrt(variance);
            s.Median = median;

            // средняя интенсивность по часам суток, берем самый загруженный час
            double[] byHour = new double[24];
            foreach (DateTime t in times) byHour[t.Hour]++;
            for (int h = 0; h < 24; h++)
            {
                double perHour = byHour[h] / days;
                s.ByHour[h] = perHour;
                if (perHour > s.PeakLambda)
                {
                    s.PeakLambda = perHour;
                    s.PeakHour = h;
                }
            }
            return s;
        }
    }

    public class QueueRow
    {
        public int Servers { get; set; }
        public double Utilization { get; set; }
        public double WaitProbability { get; set; }
        public double AvgQueue { get; set; }
        public double AvgWaitMin { get; set; }
    }

    // модель M/M/c: простейший поток, показательное обслуживание, c одинаковых каналов
    public static class Queueing
    {
        // lambda и mu в операциях в час
        public static QueueRow Calc(double lambda, double mu, int c)
        {
            double a = lambda / mu;
            double rho = a / c;
            var row = new QueueRow { Servers = c, Utilization = rho };
            if (rho >= 1)
            {
                row.WaitProbability = 1;
                row.AvgQueue = double.PositiveInfinity;
                row.AvgWaitMin = double.PositiveInfinity;
                return row;
            }

            double term = 1;
            double sum = 1;
            for (int k = 1; k < c; k++)
            {
                term *= a / k;
                sum += term;
            }
            double last = term * a / c;
            double top = last / (1 - rho);
            double pw = top / (sum + top);
            double wq = pw / (c * mu - lambda);

            row.WaitProbability = pw;
            row.AvgWaitMin = wq * 60;
            row.AvgQueue = lambda * wq;
            return row;
        }

        public static int FindMin(double lambda, double mu, double targetWaitMin, int maxServers, List<QueueRow> table)
        {
            int found = 0;
            for (int c = 1; c <= maxServers; c++)
            {
                QueueRow row = Calc(lambda, mu, c);
                if (found == 0 && row.Utilization < 1 && row.AvgWaitMin <= targetWaitMin) found = c;
                if (found == 0 || c <= found + 1) table.Add(row);
                if (found != 0 && c > found) break;
            }
            return found;
        }
    }

    public static class ReportService
    {
        public static string TypeRu(string t)
        {
            if (t == "Withdraw") return "Снятие";
            if (t == "Deposit") return "Внесение";
            return "Баланс";
        }

        public static string TypeDb(string ru)
        {
            if (ru == "Снятие") return "Withdraw";
            if (ru == "Внесение") return "Deposit";
            if (ru == "Баланс") return "Balance";
            return null;
        }

        // type: null = все; success: -1 все, 1 успешные, 0 отказы; atmId: 0 все
        public static List<OperationRow> Query(DateTime from, DateTime to, string accountNumber, string type, int success, int atmId)
        {
            var args = new List<object>();
            string sql = "SELECT o.Id,o.OpTime,a.Address,c.CardNumber,ac.AccountNumber,o.OpType,o.Amount,o.Success,o.Reason " +
                         "FROM Operations o JOIN Atms a ON a.Id=o.AtmId JOIN Cards c ON c.Id=o.CardId JOIN Accounts ac ON ac.Id=o.AccountId " +
                         "WHERE o.OpTime>=@p0 AND o.OpTime<@p1";
            args.Add(from.Date);
            args.Add(to.Date.AddDays(1));
            if (!string.IsNullOrWhiteSpace(accountNumber))
            {
                sql += " AND ac.AccountNumber=@p" + args.Count;
                args.Add(accountNumber.Trim());
            }
            if (type != null)
            {
                sql += " AND o.OpType=@p" + args.Count;
                args.Add(type);
            }
            if (success >= 0)
            {
                sql += " AND o.Success=@p" + args.Count;
                args.Add(success);
            }
            if (atmId > 0)
            {
                sql += " AND o.AtmId=@p" + args.Count;
                args.Add(atmId);
            }
            sql += " ORDER BY o.OpTime DESC";

            var list = new List<OperationRow>();
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, sql, args.ToArray()))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    list.Add(new OperationRow
                    {
                        Id = r.GetInt32(0),
                        OpTime = r.GetString(1),
                        AtmAddress = r.GetString(2),
                        CardNumber = AtmService.Mask(r.GetString(3)),
                        AccountNumber = r.GetString(4),
                        OpType = TypeRu(r.GetString(5)),
                        Amount = Db.Dec(r.GetValue(6)),
                        Result = r.GetInt32(7) == 1 ? "Успешно" : "Отказ",
                        Reason = r.IsDBNull(8) ? "" : r.GetString(8)
                    });
                }
            }
            return list;
        }

        public static void ExportXlsx(string path, List<OperationRow> rows)
        {
            string[] headers = { "№", "Дата и время", "Банкомат", "Карта", "Счет", "Операция", "Сумма", "Результат", "Причина отказа" };
            var data = new List<object[]>();
            foreach (OperationRow r in rows)
                data.Add(new object[] { r.Id, r.OpTime, r.AtmAddress, r.CardNumber, r.AccountNumber, r.OpType, r.Amount, r.Result, r.Reason });

            decimal withdrawn = rows.Where(r => r.OpType == "Снятие" && r.Result == "Успешно").Sum(r => r.Amount);
            decimal deposited = rows.Where(r => r.OpType == "Внесение" && r.Result == "Успешно").Sum(r => r.Amount);
            var footer = new List<object[]>();
            footer.Add(new object[] { "Всего операций", rows.Count });
            footer.Add(new object[] { "Снято, руб.", withdrawn });
            footer.Add(new object[] { "Внесено, руб.", deposited });
            footer.Add(new object[] { "Отказов", rows.Count(r => r.Result == "Отказ") });
            XlsxWriter.Write(path, "Операции", headers, data, footer);
        }

        public static void ExportCsv(string path, List<OperationRow> rows)
        {
            var sb = new StringBuilder();
            sb.AppendLine("№;Дата и время;Банкомат;Карта;Счет;Операция;Сумма;Результат;Причина отказа");
            foreach (OperationRow r in rows)
            {
                sb.AppendLine(string.Join(";", new string[]
                {
                    r.Id.ToString(), r.OpTime, Q(r.AtmAddress), r.CardNumber, "'" + r.AccountNumber,
                    r.OpType, r.Amount.ToString("0.00", new CultureInfo("ru-RU")), r.Result, Q(r.Reason)
                }));
            }
            File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
        }


        // экспорт в PDF через встроенный в Windows принтер «Microsoft Print to PDF»
        public static void ExportPdf(string path, List<OperationRow> rows)
        {
            var doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            if (!doc.PrinterSettings.IsValid)
                throw new InvalidOperationException("В системе нет принтера «Microsoft Print to PDF»");
            doc.PrinterSettings.PrintToFile = true;
            doc.PrinterSettings.PrintFileName = path;
            doc.DefaultPageSettings.Landscape = true;
            doc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            doc.DocumentName = "Отчет по операциям";

            int index = 0;
            int page = 0;
            float[] widths = { 40, 125, 230, 150, 150, 70, 80, 70, 150 };
            string[] heads = { "№", "Дата и время", "Банкомат", "Карта", "Счет", "Операция", "Сумма", "Результат", "Причина" };

            doc.PrintPage += (sender, e) =>
            {
                page++;
                using (var fTitle = new Font("Arial", 13, FontStyle.Bold))
                using (var fHead = new Font("Arial", 8, FontStyle.Bold))
                using (var fRow = new Font("Arial", 8))
                {
                    float x0 = e.MarginBounds.Left;
                    float y = e.MarginBounds.Top;
                    e.Graphics.DrawString("Отчет по операциям банкомата. Страница " + page, fTitle, Brushes.Black, x0, y);
                    y += 30;
                    float x = x0;
                    for (int i = 0; i < heads.Length; i++)
                    {
                        e.Graphics.DrawString(heads[i], fHead, Brushes.Black, x, y);
                        x += widths[i];
                    }
                    y += 16;
                    e.Graphics.DrawLine(Pens.Black, x0, y, x0 + widths.Sum(), y);
                    y += 3;
                    while (index < rows.Count && y + 14 < e.MarginBounds.Bottom)
                    {
                        OperationRow r = rows[index];
                        string[] cells =
                        {
                            r.Id.ToString(), r.OpTime, r.AtmAddress, r.CardNumber, r.AccountNumber,
                            r.OpType, r.Amount.ToString("N2"), r.Result, r.Reason ?? ""
                        };
                        x = x0;
                        for (int i = 0; i < cells.Length; i++)
                        {
                            var box = new RectangleF(x, y, widths[i] - 4, 14);
                            e.Graphics.DrawString(cells[i], fRow, Brushes.Black, box, new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap });
                            x += widths[i];
                        }
                        y += 15;
                        index++;
                    }
                    e.HasMorePages = index < rows.Count;
                }
            };
            doc.Print();
        }

        static string Q(string s)
        {
            if (s == null) return "";
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }
    }
}
