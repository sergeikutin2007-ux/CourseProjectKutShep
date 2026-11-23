using AtmSystem;
using Xunit;

namespace AtmSystem.Tests
{
    public class StatsTests
    {
        [Fact]
        public void Describe_OddCount_MedianIsMiddle()
        {
            double mean, variance, median;
            Stats.Describe(new double[] { 1, 2, 9 }, out mean, out variance, out median);
            Assert.Equal(4.0, mean, 6);
            Assert.Equal(2.0, median, 6);
            Assert.Equal(12.6667, variance, 3);
        }

        [Fact]
        public void Describe_EvenCount_MedianIsAverageOfMiddle()
        {
            double mean, variance, median;
            Stats.Describe(new double[] { 4, 1, 3, 2 }, out mean, out variance, out median);
            Assert.Equal(2.5, mean, 6);
            Assert.Equal(2.5, median, 6);
            Assert.Equal(1.25, variance, 6);
        }

        [Fact]
        public void Describe_Empty_GivesZeros()
        {
            double mean, variance, median;
            Stats.Describe(new double[0], out mean, out variance, out median);
            Assert.Equal(0.0, mean);
            Assert.Equal(0.0, variance);
            Assert.Equal(0.0, median);
        }
    }

    public class CurrencyTests
    {
        const string Json = "{\"Date\":\"2026-11-09T11:30:00+03:00\",\"Valute\":{" +
            "\"USD\":{\"ID\":\"R01235\",\"NumCode\":\"840\",\"CharCode\":\"USD\",\"Nominal\":1,\"Name\":\"Доллар США\",\"Value\":80.5,\"Previous\":80.1}," +
            "\"JPY\":{\"ID\":\"R01820\",\"NumCode\":\"392\",\"CharCode\":\"JPY\",\"Nominal\":100,\"Name\":\"Японских иен\",\"Value\":52.4,\"Previous\":52.0}}}";

        [Fact]
        public void Parse_ReadsDateAndRates()
        {
            CurrencyResult r = CurrencyService.Parse(Json);
            Assert.Equal("2026-11-09", r.Date);
            Assert.Equal(2, r.Rates.Count);
            Assert.Equal("USD", r.Rates[0].Code);
            Assert.Equal(80.5m, r.Rates[0].Value);
        }

        const string Xml = "<?xml version=\"1.0\" encoding=\"windows-1251\"?><ValCurs Date=\"09.11.2026\" name=\"Foreign Currency Market\">" +
            "<Valute ID=\"R01235\"><NumCode>840</NumCode><CharCode>USD</CharCode><Nominal>1</Nominal><Name>Доллар США</Name><Value>80,5000</Value></Valute>" +
            "<Valute ID=\"R01820\"><NumCode>392</NumCode><CharCode>JPY</CharCode><Nominal>100</Nominal><Name>Японских иен</Name><Value>52,4000</Value></Valute></ValCurs>";

        [Fact]
        public void ParseXml_ReadsDateAndRates()
        {
            CurrencyResult r = CurrencyService.Parse(Xml);
            Assert.Equal("2026-11-09", r.Date);
            Assert.Equal(2, r.Rates.Count);
            Assert.Equal("JPY", r.Rates[1].Code);
            Assert.Equal(52.4m, r.Rates[1].Value);
        }

        [Fact]
        public void ParseXml_BrokenText_GivesNoRates()
        {
            CurrencyResult r = CurrencyService.Parse("<ValCurs><Valute>");
            Assert.Equal(0, r.Rates.Count);
        }

        [Fact]
        public void PerUnit_DividesByNominal()
        {
            CurrencyResult r = CurrencyService.Parse(Json);
            Assert.Equal(0.524m, r.Rates[1].PerUnit);
        }

        [Fact]
        public void FromRub_ConvertsAndRounds()
        {
            CurrencyResult r = CurrencyService.Parse(Json);
            Assert.Equal(124.22m, CurrencyService.FromRub(10000m, r.Rates[0]));
        }

        [Fact]
        public void Parse_Garbage_GivesEmptyList()
        {
            Assert.Equal(0, CurrencyService.Parse("not json").Rates.Count);
            Assert.Equal(0, CurrencyService.Parse("").Rates.Count);
        }
    }
}
