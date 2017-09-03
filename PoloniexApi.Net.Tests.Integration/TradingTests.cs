using System;
using Jojatekok.PoloniexAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PoloniexApi.Net.Tests.Integration
{
    [TestClass]
    public class TradingTests
    {
        ITrading CreateTarget()
        {
            return TestHelpers.CreateClient().Trading;
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetAllMarginPositions_ReturnsValues()
        {
            var actual = CreateTarget().GetAllMarginPositionsAsync().Result;
            TestContext.WriteLine("Found {0} items", actual.Count);
        }
        [TestMethod]
        public void GetMarginPosition_ReturnsValues()
        {
            var actual = CreateTarget().GetMarginPositionAsync(CurrencyPair.Parse("BTC_ETH")).Result;
            TestContext.WriteLine("{0}", JsonConvert.SerializeObject(actual));
        }
        [TestMethod]
        public void GetMarginSummary_ReturnsValues()
        {
            var actual = CreateTarget().GetMarginAccountSummaryAsync().Result;
            TestContext.WriteLine("{0}", JsonConvert.SerializeObject(actual));
        }
    }
}
