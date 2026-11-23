using AtmSystem;
using Xunit;

namespace AtmSystem.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("2202200000000016")]
        [InlineData("2202200000000065")]
        public void CardNumber_Correct_ReturnsNull(string number)
        {
            Assert.Null(Validator.CardNumber(number));
        }

        [Theory]
        [InlineData("2202200000000017")]
        [InlineData("22022000000000")]
        [InlineData("abcd200000000016")]
        [InlineData("")]
        public void CardNumber_Wrong_ReturnsMessage(string number)
        {
            Assert.NotNull(Validator.CardNumber(number));
        }

        [Fact]
        public void AccountNumber_Requires20Digits()
        {
            Assert.Null(Validator.AccountNumber("40817810500000000011"));
            Assert.NotNull(Validator.AccountNumber("4081781050000000001"));
            Assert.NotNull(Validator.AccountNumber("4081781050000000001A"));
        }

        [Fact]
        public void Pin_Requires4Digits()
        {
            Assert.Null(Validator.Pin("1234"));
            Assert.NotNull(Validator.Pin("123"));
            Assert.NotNull(Validator.Pin("12345"));
            Assert.NotNull(Validator.Pin("12a4"));
        }

        [Fact]
        public void Owner_RejectsDigitsAndEmpty()
        {
            Assert.Null(Validator.Owner("Иванов Алексей Петрович"));
            Assert.NotNull(Validator.Owner(""));
            Assert.NotNull(Validator.Owner("Иванов123"));
        }

        [Fact]
        public void Expiry_ConvertsToStoredFormat()
        {
            string stored;
            Assert.Null(Validator.ExpiryInput("12/29", out stored));
            Assert.Equal("2029-12", stored);
            Assert.Equal("12/29", Validator.ExpiryView(stored));
            Assert.NotNull(Validator.ExpiryInput("13/29", out stored));
            Assert.NotNull(Validator.ExpiryInput("1229", out stored));
        }

        [Fact]
        public void Expired_DetectsPastDates()
        {
            Assert.True(Validator.Expired("2020-01"));
            Assert.False(Validator.Expired("2099-12"));
        }

        [Fact]
        public void ParseMoney_AcceptsCommaAndDot()
        {
            decimal v;
            Assert.True(Validator.ParseMoney("1500,50", out v));
            Assert.Equal(1500.50m, v);
            Assert.True(Validator.ParseMoney("1500.50", out v));
            Assert.Equal(1500.50m, v);
            Assert.False(Validator.ParseMoney("abc", out v));
        }
    }
}
