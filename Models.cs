using System;

namespace AtmSystem
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyLimit { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string Expiry { get; set; }
        public string Status { get; set; }
        public int FailedAttempts { get; set; }

        public string StatusRu
        {
            get { return Status == "Active" ? "Активна" : "Заблокирована"; }
        }

        public string ExpiryView
        {
            get { return Validator.ExpiryView(Expiry); }
        }
    }

    public class Atm
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal CashBalance { get; set; }
        public string Status { get; set; }

        public string StatusRu
        {
            get { return Status == "Working" ? "В работе" : "На обслуживании"; }
        }

        public override string ToString()
        {
            return Address;
        }
    }

    public class OperationRow
    {
        public int Id { get; set; }
        public string OpTime { get; set; }
        public string AtmAddress { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string OpType { get; set; }
        public decimal Amount { get; set; }
        public string Result { get; set; }
        public string Reason { get; set; }
    }

    public static class Session
    {
        public static User Current;

        public static bool IsGuest
        {
            get { return Current != null && Current.Role == "guest"; }
        }

        public static bool IsAdmin
        {
            get { return Current != null && Current.Role == "admin"; }
        }
    }
}
