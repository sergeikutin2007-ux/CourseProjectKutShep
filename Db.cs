using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace AtmSystem
{
    public static class Db
    {
        public static string FilePath = Config.DbFile;

        // резервная копия: средствами SQLite копируется вся база, даже если она открыта
        public static void Backup(string target)
        {
            if (string.IsNullOrWhiteSpace(target)) throw new ArgumentException("не указан файл копии");
            if (Path.GetFullPath(target) == Path.GetFullPath(FilePath)) throw new ArgumentException("копия не может совпадать с рабочей базой");
            using (var src = Open())
            using (var dst = new SqliteConnection("Data Source=" + target))
            {
                dst.Open();
                src.BackupDatabase(dst);
            }
        }

        public static SqliteConnection Open()
        {
            var c = new SqliteConnection("Data Source=" + FilePath);
            c.Open();
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON";
                cmd.ExecuteNonQuery();
            }
            return c;
        }

        public static SqliteCommand Cmd(SqliteConnection c, SqliteTransaction tx, string sql, params object[] args)
        {
            var cmd = c.CreateCommand();
            cmd.CommandText = sql;
            if (tx != null) cmd.Transaction = tx;
            for (int i = 0; i < args.Length; i++)
            {
                object v = args[i];
                if (v == null) v = DBNull.Value;
                else if (v is decimal) v = (double)(decimal)v;
                else if (v is DateTime) v = ((DateTime)v).ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@p" + i, v);
            }
            return cmd;
        }

        public static object Scalar(string sql, params object[] args)
        {
            using (var c = Open())
            using (var cmd = Cmd(c, null, sql, args))
                return cmd.ExecuteScalar();
        }

        public static int NonQuery(string sql, params object[] args)
        {
            using (var c = Open())
            using (var cmd = Cmd(c, null, sql, args))
                return cmd.ExecuteNonQuery();
        }

        public static int Count(string sql, params object[] args)
        {
            object o = Scalar(sql, args);
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToInt32(o);
        }

        public static decimal Dec(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToDecimal(Math.Round(Convert.ToDouble(o), 2));
        }

        public static void Init()
        {
            bool fresh = !File.Exists(FilePath);
            using (var c = Open())
            {
                string[] schema = new string[]
                {
                    "CREATE TABLE IF NOT EXISTS Users(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Login TEXT NOT NULL UNIQUE, " +
                    "PasswordHash TEXT NOT NULL, " +
                    "Salt TEXT NOT NULL, " +
                    "Role TEXT NOT NULL CHECK(Role IN ('admin','manager','client')))",

                    "CREATE TABLE IF NOT EXISTS Accounts(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "AccountNumber TEXT NOT NULL UNIQUE, " +
                    "OwnerName TEXT NOT NULL, " +
                    "Balance REAL NOT NULL DEFAULT 0 CHECK(Balance >= 0), " +
                    "DailyLimit REAL NOT NULL DEFAULT 100000 CHECK(DailyLimit > 0))",

                    "CREATE TABLE IF NOT EXISTS Cards(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "CardNumber TEXT NOT NULL UNIQUE, " +
                    "AccountId INTEGER NOT NULL REFERENCES Accounts(Id) ON DELETE RESTRICT, " +
                    "PinHash TEXT NOT NULL, " +
                    "Salt TEXT NOT NULL, " +
                    "Expiry TEXT NOT NULL, " +
                    "Status TEXT NOT NULL DEFAULT 'Active' CHECK(Status IN ('Active','Blocked')), " +
                    "FailedAttempts INTEGER NOT NULL DEFAULT 0)",

                    "CREATE TABLE IF NOT EXISTS Atms(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Address TEXT NOT NULL, " +
                    "CashBalance REAL NOT NULL DEFAULT 0 CHECK(CashBalance >= 0), " +
                    "Status TEXT NOT NULL DEFAULT 'Working' CHECK(Status IN ('Working','Service')))",

                    "CREATE TABLE IF NOT EXISTS Operations(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "OpTime TEXT NOT NULL, " +
                    "AtmId INTEGER NOT NULL REFERENCES Atms(Id) ON DELETE RESTRICT, " +
                    "CardId INTEGER NOT NULL REFERENCES Cards(Id) ON DELETE RESTRICT, " +
                    "AccountId INTEGER NOT NULL REFERENCES Accounts(Id) ON DELETE RESTRICT, " +
                    "OpType TEXT NOT NULL CHECK(OpType IN ('Withdraw','Deposit','Balance')), " +
                    "Amount REAL NOT NULL DEFAULT 0, " +
                    "Success INTEGER NOT NULL, " +
                    "Reason TEXT)",

                    "CREATE INDEX IF NOT EXISTS IdxOperationsTime ON Operations(OpTime)"
                };
                foreach (string sql in schema)
                {
                    using (var cmd = Cmd(c, null, sql)) cmd.ExecuteNonQuery();
                }
            }
            if (fresh) Seed();
        }

        static void Seed()
        {
            string[] logins = { "admin", "manager", "client" };
            string[] passwords = { "admin123", "manager123", "client123" };
            string[] roles = { "admin", "manager", "client" };

            string[] owners = { "Иванов Алексей Петрович", "Смирнова Ольга Игоревна", "Кузнецов Дмитрий Сергеевич",
                                "Попова Мария Андреевна", "Соколов Никита Олегович", "Лебедева Анна Викторовна" };
            string[] accNums = { "40817810500000000011", "40817810500000000022", "40817810500000000033",
                                 "40817810500000000044", "40817810500000000055", "40817810500000000066" };
            decimal[] balances = { 85000m, 120500m, 15300m, 240000m, 5200m, 67800m };
            string[] cards = { "2202200000000016", "2202200000000024", "2202200000000032",
                               "2202200000000040", "2202200000000057", "2202200000000065" };

            string[] atmAddr = { "ул. Ленина, 12 (ТЦ Центральный)", "ул. Гагарина, 5 (вокзал)", "пр. Мира, 40 (отделение банка)" };

            using (var c = Open())
            using (var tx = c.BeginTransaction())
            {
                for (int i = 0; i < logins.Length; i++)
                {
                    string salt = Security.NewSalt();
                    using (var cmd = Cmd(c, tx, "INSERT INTO Users(Login,PasswordHash,Salt,Role) VALUES(@p0,@p1,@p2,@p3)",
                        logins[i], Security.Hash(passwords[i], salt), salt, roles[i]))
                        cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < owners.Length; i++)
                {
                    using (var cmd = Cmd(c, tx, "INSERT INTO Accounts(AccountNumber,OwnerName,Balance,DailyLimit) VALUES(@p0,@p1,@p2,@p3)",
                        accNums[i], owners[i], balances[i], Config.DefaultDailyLimit))
                        cmd.ExecuteNonQuery();
                    string salt = Security.NewSalt();
                    using (var cmd = Cmd(c, tx, "INSERT INTO Cards(CardNumber,AccountId,PinHash,Salt,Expiry,Status,FailedAttempts) VALUES(@p0,@p1,@p2,@p3,@p4,'Active',0)",
                        cards[i], i + 1, Security.Hash("1234", salt), salt, "2029-12"))
                        cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < atmAddr.Length; i++)
                {
                    using (var cmd = Cmd(c, tx, "INSERT INTO Atms(Address,CashBalance,Status) VALUES(@p0,@p1,'Working')", atmAddr[i], 500000m))
                        cmd.ExecuteNonQuery();
                }

                // история операций за две недели, чтобы было на чем считать статистику
                var rnd = new Random(7);
                int[] hourWeight = { 0, 0, 0, 0, 0, 0, 1, 2, 4, 5, 6, 8, 10, 9, 7, 6, 8, 10, 9, 6, 3, 2, 1, 0 };
                int totalWeight = 0;
                foreach (int w in hourWeight) totalWeight += w;
                DateTime today = DateTime.Today;

                for (int d = 14; d >= 1; d--)
                {
                    DateTime day = today.AddDays(-d);
                    for (int atm = 1; atm <= atmAddr.Length; atm++)
                    {
                        int count = 55 + rnd.Next(25) + (atm == 1 ? 30 : 0);
                        for (int k = 0; k < count; k++)
                        {
                            int pick = rnd.Next(totalWeight);
                            int hour = 0;
                            while (pick >= hourWeight[hour]) { pick -= hourWeight[hour]; hour++; }
                            DateTime t = day.AddHours(hour).AddMinutes(rnd.Next(60)).AddSeconds(rnd.Next(60));

                            int idx = rnd.Next(owners.Length);
                            int r = rnd.Next(100);
                            string type = r < 60 ? "Withdraw" : (r < 85 ? "Balance" : "Deposit");
                            decimal amount = 0;
                            if (type == "Withdraw") amount = 500 * (1 + rnd.Next(12));
                            if (type == "Deposit") amount = 1000 * (1 + rnd.Next(20));
                            bool ok = rnd.Next(100) < 94;
                            string reason = null;
                            if (!ok)
                            {
                                if (type == "Balance") { ok = true; }
                                else reason = type == "Withdraw" ? "Недостаточно средств на счете" : "Банкомат не принял купюры";
                            }
                            using (var cmd = Cmd(c, tx, "INSERT INTO Operations(OpTime,AtmId,CardId,AccountId,OpType,Amount,Success,Reason) VALUES(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)",
                                t, atm, idx + 1, idx + 1, type, amount, ok ? 1 : 0, reason))
                                cmd.ExecuteNonQuery();
                        }
                    }
                }
                tx.Commit();
            }
        }
    }
}
