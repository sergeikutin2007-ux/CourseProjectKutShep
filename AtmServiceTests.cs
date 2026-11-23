using System;
using System.IO;
using AtmSystem;
using Microsoft.Data.Sqlite;
using Xunit;

namespace AtmSystem.Tests
{
    // все проверки с базой в одном классе, чтобы они шли по очереди: путь к базе общий
    public class AtmServiceTests : IDisposable
    {
        const string CardOk = "2202200000000016";
        const int AtmId = 1;
        readonly string file;

        public AtmServiceTests()
        {
            file = Path.Combine(Path.GetTempPath(), "atm_test_" + Guid.NewGuid().ToString("N") + ".db");
            Db.FilePath = file;
            Db.Init();
        }

        public void Dispose()
        {
            SqliteConnection.ClearAllPools();
            try { File.Delete(file); } catch (IOException) { }
        }

        Card Login()
        {
            string err;
            Card c = AtmService.Authorize(CardOk, "1234", out err);
            Assert.NotNull(c);
            return c;
        }

        decimal Balance()
        {
            return Db.Dec(Db.Scalar("SELECT Balance FROM Accounts WHERE Id=1"));
        }

        [Fact]
        public void Authorize_CorrectPin_ReturnsCard()
        {
            Card c = Login();
            Assert.Equal(CardOk, c.CardNumber);
        }

        [Fact]
        public void Authorize_UnknownCard_Fails()
        {
            string err;
            Assert.Null(AtmService.Authorize("2202200000000099", "1234", out err));
            Assert.NotNull(err);
        }

        [Fact]
        public void Authorize_ThreeWrongPins_BlocksCard()
        {
            string err;
            AtmService.Authorize(CardOk, "0000", out err);
            AtmService.Authorize(CardOk, "0000", out err);
            AtmService.Authorize(CardOk, "0000", out err);
            Assert.Null(AtmService.Authorize(CardOk, "1234", out err));
            Assert.Contains("заблокирована", err);
        }

        [Fact]
        public void Authorize_SuccessResetsFailedAttempts()
        {
            string err;
            AtmService.Authorize(CardOk, "0000", out err);
            Login();
            Assert.Equal(0, Db.Count("SELECT FailedAttempts FROM Cards WHERE CardNumber=@p0", CardOk));
        }

        [Fact]
        public void Withdraw_Success_ChangesBalanceAndAtmCash()
        {
            Card c = Login();
            decimal before = Balance();
            OpResult r = AtmService.Withdraw(AtmId, c, 5000m);
            Assert.True(r.Ok);
            Assert.Equal(before - 5000m, Balance());
            Assert.Equal(495000m, Db.Dec(Db.Scalar("SELECT CashBalance FROM Atms WHERE Id=1")));
        }

        [Fact]
        public void Withdraw_MoreThanBalance_FailsAndBalanceStays()
        {
            Card c = Login();
            decimal before = Balance();
            OpResult r = AtmService.Withdraw(AtmId, c, before + 100m);
            Assert.False(r.Ok);
            Assert.Equal(before, Balance());
        }

        [Fact]
        public void Withdraw_Failure_IsLoggedInOperations()
        {
            Card c = Login();
            int before = Db.Count("SELECT COUNT(*) FROM Operations WHERE Success=0");
            AtmService.Withdraw(AtmId, c, 150m);
            Assert.Equal(before + 1, Db.Count("SELECT COUNT(*) FROM Operations WHERE Success=0"));
        }

        [Fact]
        public void Withdraw_NotMultipleOfNote_Fails()
        {
            Card c = Login();
            OpResult r = AtmService.Withdraw(AtmId, c, 150m);
            Assert.False(r.Ok);
        }

        [Fact]
        public void Withdraw_NegativeOrZero_Fails()
        {
            Card c = Login();
            Assert.False(AtmService.Withdraw(AtmId, c, 0m).Ok);
            Assert.False(AtmService.Withdraw(AtmId, c, -500m).Ok);
        }

        [Fact]
        public void Withdraw_DailyLimit_IsEnforced()
        {
            Db.NonQuery("UPDATE Accounts SET DailyLimit=2000 WHERE Id=1");
            Card c = Login();
            Assert.True(AtmService.Withdraw(AtmId, c, 1500m).Ok);
            OpResult r = AtmService.Withdraw(AtmId, c, 1000m);
            Assert.False(r.Ok);
            Assert.Contains("лимит", r.Message);
        }

        [Fact]
        public void Withdraw_AtmWithoutCash_Fails()
        {
            Db.NonQuery("UPDATE Atms SET CashBalance=1000 WHERE Id=1");
            Card c = Login();
            OpResult r = AtmService.Withdraw(AtmId, c, 5000m);
            Assert.False(r.Ok);
            Assert.Contains("наличных", r.Message);
        }

        [Fact]
        public void Withdraw_AtmOnService_Fails()
        {
            Db.NonQuery("UPDATE Atms SET Status='Service' WHERE Id=1");
            Card c = Login();
            Assert.False(AtmService.Withdraw(AtmId, c, 1000m).Ok);
        }

        [Fact]
        public void Deposit_Success_IncreasesBalanceAndCash()
        {
            Card c = Login();
            decimal before = Balance();
            OpResult r = AtmService.Deposit(AtmId, c, 3000m);
            Assert.True(r.Ok);
            Assert.Equal(before + 3000m, Balance());
            Assert.Equal(503000m, Db.Dec(Db.Scalar("SELECT CashBalance FROM Atms WHERE Id=1")));
        }

        [Fact]
        public void Deposit_OverLimit_Fails()
        {
            Card c = Login();
            Assert.False(AtmService.Deposit(AtmId, c, 200000m).Ok);
        }

        [Fact]
        public void GetBalance_ReturnsCurrentBalance()
        {
            Card c = Login();
            OpResult r = AtmService.GetBalance(AtmId, c);
            Assert.True(r.Ok);
            Assert.Equal(Balance(), r.Balance);
        }

        [Fact]
        public void ChangePin_WorksAndOldPinStopsWorking()
        {
            Card c = Login();
            Assert.Null(AtmService.ChangePin(c, "1234", "4321"));
            string err;
            Assert.Null(AtmService.Authorize(CardOk, "1234", out err));
            Assert.NotNull(AtmService.Authorize(CardOk, "4321", out err));
        }

        [Fact]
        public void ChangePin_WrongOldPin_Fails()
        {
            Card c = Login();
            Assert.NotNull(AtmService.ChangePin(c, "9999", "4321"));
        }

        [Fact]
        public void DeleteAccount_WithCards_IsForbidden()
        {
            Assert.NotNull(AccountRepo.Delete(1));
            Assert.Equal(1, Db.Count("SELECT COUNT(*) FROM Accounts WHERE Id=1"));
        }

        [Fact]
        public void DeleteCard_WithOperations_IsForbidden()
        {
            Assert.NotNull(CardRepo.Delete(1));
        }

        [Fact]
        public void DeleteEmptyAccount_Works()
        {
            var a = new Account { AccountNumber = "40817810500000000099", OwnerName = "Тестов Тест Тестович", Balance = 0, DailyLimit = 1000 };
            Assert.Null(AccountRepo.Add(a));
            int id = Db.Count("SELECT Id FROM Accounts WHERE AccountNumber=@p0", a.AccountNumber);
            Assert.Null(AccountRepo.Delete(id));
        }

        [Fact]
        public void DuplicateAccountNumber_IsRejected()
        {
            var a = new Account { AccountNumber = "40817810500000000011", OwnerName = "Дубль Дубль Дублевич", Balance = 0, DailyLimit = 1000 };
            Assert.NotNull(AccountRepo.Add(a));
        }

        [Fact]
        public void Statistics_UsesHistoryFromDatabase()
        {
            PeriodStats s = Stats.ForPeriod(0, 14);
            Assert.True(s.TotalOps > 1000);
            Assert.True(s.PeakLambda > 0);
            Assert.InRange(s.PeakHour, 8, 20);
        }

        [Fact]
        public void Report_FiltersByType()
        {
            var rows = ReportService.Query(DateTime.Today.AddDays(-14), DateTime.Today, null, "Deposit", -1, 0);
            Assert.NotEmpty(rows);
            Assert.All(rows, r => Assert.Equal("Внесение", r.OpType));
        }

        [Fact]
        public void ExportXlsx_CreatesFile()
        {
            var rows = ReportService.Query(DateTime.Today.AddDays(-3), DateTime.Today, null, null, -1, 0);
            string path = Path.Combine(Path.GetTempPath(), "atm_test_" + Guid.NewGuid().ToString("N") + ".xlsx");
            try
            {
                ReportService.ExportXlsx(path, rows);
                Assert.True(new FileInfo(path).Length > 500);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Backup_CopiesAllData()
        {
            string copy = Path.Combine(Path.GetTempPath(), "atm_copy_" + Guid.NewGuid().ToString("N") + ".db");
            try
            {
                Db.Backup(copy);
                using (var c = new SqliteConnection("Data Source=" + copy))
                {
                    c.Open();
                    var cmd = c.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM Accounts";
                    long inCopy = (long)cmd.ExecuteScalar();
                    Assert.Equal(Db.Count("SELECT COUNT(*) FROM Accounts"), (int)inCopy);
                }
            }
            finally
            {
                SqliteConnection.ClearAllPools();
                try { File.Delete(copy); } catch (IOException) { }
            }
        }

        [Fact]
        public void Backup_ToWorkingFile_IsRejected()
        {
            Assert.Throws<ArgumentException>(() => Db.Backup(Db.FilePath));
        }
    }
}
