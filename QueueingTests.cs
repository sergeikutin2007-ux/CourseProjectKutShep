using System.Collections.Generic;
using AtmSystem;
using Xunit;

namespace AtmSystem.Tests
{
    public class QueueingTests
    {
        [Fact]
        public void OneServer_WaitMatchesMM1Formula()
        {
            // M/M/1: Wq = rho / (mu - lambda) = 0.6 / 4 ч = 9 минут
            QueueRow r = Queueing.Calc(6, 10, 1);
            Assert.Equal(0.6, r.Utilization, 6);
            Assert.Equal(0.6, r.WaitProbability, 6);
            Assert.Equal(9.0, r.AvgWaitMin, 6);
        }

        [Fact]
        public void TwoServers_MatchesErlangC()
        {
            QueueRow r = Queueing.Calc(10, 6, 2);
            Assert.Equal(0.757576, r.WaitProbability, 5);
            Assert.Equal(22.7272, r.AvgWaitMin, 3);
        }

        [Fact]
        public void Overload_GivesInfiniteWait()
        {
            QueueRow r = Queueing.Calc(20, 10, 2);
            Assert.True(double.IsPositiveInfinity(r.AvgWaitMin));
        }

        [Fact]
        public void FindMin_ReturnsSmallestSuitableNumber()
        {
            var table = new List<QueueRow>();
            int best = Queueing.FindMin(30, 40, 2, 20, table);
            Assert.Equal(2, best);
        }

        [Fact]
        public void FindMin_NotFound_ReturnsZero()
        {
            var table = new List<QueueRow>();
            Assert.Equal(0, Queueing.FindMin(1000, 10, 0.001, 5, table));
        }

        [Fact]
        public void MoreServers_NeverIncreaseWait()
        {
            double prev = double.MaxValue;
            for (int c = 3; c <= 8; c++)
            {
                double w = Queueing.Calc(100, 40, c).AvgWaitMin;
                Assert.True(w <= prev);
                prev = w;
            }
        }
    }
}
