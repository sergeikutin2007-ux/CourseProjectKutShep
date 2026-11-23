using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace AtmSystem
{
    public static class AccountRepo
    {
        static Account Read(SqliteDataReader r)
        {
            return new Account
            {
                Id = r.GetInt32(0),
                AccountNumber = r.GetString(1),
                OwnerName = r.GetString(2),
                Balance = Db.Dec(r.GetValue(3)),
                DailyLimit = Db.Dec(r.GetValue(4))
            };
        }

        public static List<Account> GetAll(string search)
        {
            var list = new List<Account>();
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, "SELECT Id,AccountNumber,OwnerName,Balance,DailyLimit FROM Accounts ORDER BY OwnerName"))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Account a = Read(r);
                    if (string.IsNullOrEmpty(search)
                        || a.OwnerName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.AccountNumber.Contains(search))
                        list.Add(a);
                }
            }
            return list;
        }

        public static string Add(Account a)
        {
            if (Db.Count("SELECT COUNT(*) FROM Accounts WHERE AccountNumber=@p0", a.AccountNumber) > 0)
                return "Счет с таким номером уже есть";
            Db.NonQuery("INSERT INTO Accounts(AccountNumber,OwnerName,Balance,DailyLimit) VALUES(@p0,@p1,@p2,@p3)",
                a.AccountNumber, a.OwnerName, a.Balance, a.DailyLimit);
            return null;
        }

        public static string Update(Account a)
        {
            if (Db.Count("SELECT COUNT(*) FROM Accounts WHERE AccountNumber=@p0 AND Id<>@p1", a.AccountNumber, a.Id) > 0)
                return "Счет с таким номером уже есть";
            // баланс здесь не трогаем: он меняется только операциями
            Db.NonQuery("UPDATE Accounts SET AccountNumber=@p0, OwnerName=@p1, DailyLimit=@p2 WHERE Id=@p3",
                a.AccountNumber, a.OwnerName, a.DailyLimit, a.Id);
            return null;
        }

        public static string Delete(int id)
        {
            if (Db.Count("SELECT COUNT(*) FROM Cards WHERE AccountId=@p0", id) > 0)
                return "Нельзя удалить счет: к нему выпущены карты";
            if (Db.Count("SELECT COUNT(*) FROM Operations WHERE AccountId=@p0", id) > 0)
                return "Нельзя удалить счет: по нему есть операции";
            Db.NonQuery("DELETE FROM Accounts WHERE Id=@p0", id);
            return null;
        }
    }

    public static class CardRepo
    {
        const string Select = "SELECT c.Id,c.CardNumber,c.AccountId,a.AccountNumber,a.OwnerName,c.Expiry,c.Status,c.FailedAttempts " +
                              "FROM Cards c JOIN Accounts a ON a.Id=c.AccountId ";

        public static Card Read(SqliteDataReader r)
        {
            return new Card
            {
                Id = r.GetInt32(0),
                CardNumber = r.GetString(1),
                AccountId = r.GetInt32(2),
                AccountNumber = r.GetString(3),
                OwnerName = r.GetString(4),
                Expiry = r.GetString(5),
                Status = r.GetString(6),
                FailedAttempts = r.GetInt32(7)
            };
        }

        public static List<Card> GetAll(string search)
        {
            var list = new List<Card>();
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, Select + "ORDER BY a.OwnerName, c.CardNumber"))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Card k = Read(r);
                    if (string.IsNullOrEmpty(search)
                        || k.CardNumber.Contains(search)
                        || k.OwnerName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        list.Add(k);
                }
            }
            return list;
        }

        public static string Add(Card k, string pin)
        {
            if (Db.Count("SELECT COUNT(*) FROM Cards WHERE CardNumber=@p0", k.CardNumber) > 0)
                return "Карта с таким номером уже есть";
            string salt = Security.NewSalt();
            Db.NonQuery("INSERT INTO Cards(CardNumber,AccountId,PinHash,Salt,Expiry,Status,FailedAttempts) VALUES(@p0,@p1,@p2,@p3,@p4,@p5,0)",
                k.CardNumber, k.AccountId, Security.Hash(pin, salt), salt, k.Expiry, k.Status);
            return null;
        }

        public static string Update(Card k, string newPin)
        {
            if (Db.Count("SELECT COUNT(*) FROM Cards WHERE CardNumber=@p0 AND Id<>@p1", k.CardNumber, k.Id) > 0)
                return "Карта с таким номером уже есть";
            Db.NonQuery("UPDATE Cards SET CardNumber=@p0, AccountId=@p1, Expiry=@p2, Status=@p3, " +
                        "FailedAttempts = CASE WHEN @p3='Active' THEN 0 ELSE FailedAttempts END WHERE Id=@p4",
                k.CardNumber, k.AccountId, k.Expiry, k.Status, k.Id);
            if (!string.IsNullOrEmpty(newPin))
            {
                string salt = Security.NewSalt();
                Db.NonQuery("UPDATE Cards SET PinHash=@p0, Salt=@p1 WHERE Id=@p2", Security.Hash(newPin, salt), salt, k.Id);
            }
            return null;
        }

        public static string Delete(int id)
        {
            if (Db.Count("SELECT COUNT(*) FROM Operations WHERE CardId=@p0", id) > 0)
                return "Нельзя удалить карту: по ней есть операции. Заблокируйте ее";
            Db.NonQuery("DELETE FROM Cards WHERE Id=@p0", id);
            return null;
        }
    }

    public static class AtmRepo
    {
        public static List<Atm> GetAll()
        {
            var list = new List<Atm>();
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, "SELECT Id,Address,CashBalance,Status FROM Atms ORDER BY Id"))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    list.Add(new Atm
                    {
                        Id = r.GetInt32(0),
                        Address = r.GetString(1),
                        CashBalance = Db.Dec(r.GetValue(2)),
                        Status = r.GetString(3)
                    });
                }
            }
            return list;
        }

        public static void Add(Atm a)
        {
            Db.NonQuery("INSERT INTO Atms(Address,CashBalance,Status) VALUES(@p0,@p1,@p2)", a.Address, a.CashBalance, a.Status);
        }

        public static void Update(Atm a)
        {
            Db.NonQuery("UPDATE Atms SET Address=@p0, Status=@p1 WHERE Id=@p2", a.Address, a.Status, a.Id);
        }

        public static void AddCash(int id, decimal amount)
        {
            Db.NonQuery("UPDATE Atms SET CashBalance = CashBalance + @p0 WHERE Id=@p1", amount, id);
        }

        public static string Delete(int id)
        {
            if (Db.Count("SELECT COUNT(*) FROM Operations WHERE AtmId=@p0", id) > 0)
                return "Нельзя удалить банкомат: по нему есть операции. Переведите его в статус обслуживания";
            Db.NonQuery("DELETE FROM Atms WHERE Id=@p0", id);
            return null;
        }
    }

    public static class UserRepo
    {
        public static User Login(string login, string password)
        {
            using (var c = Db.Open())
            using (var cmd = Db.Cmd(c, null, "SELECT Id,Login,PasswordHash,Salt,Role FROM Users WHERE Login=@p0", login))
            using (var r = cmd.ExecuteReader())
            {
                if (!r.Read()) return null;
                string hash = r.GetString(2);
                string salt = r.GetString(3);
                if (Security.Hash(password, salt) != hash) return null;
                return new User { Id = r.GetInt32(0), Login = r.GetString(1), Role = r.GetString(4) };
            }
        }
    }
}
