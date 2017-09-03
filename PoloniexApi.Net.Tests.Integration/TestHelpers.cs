using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jojatekok.PoloniexAPI;
using Jojatekok.PoloniexAPI.Demo;

namespace PoloniexApi.Net.Tests.Integration
{
    public static class TestHelpers
    {
        public static IPoloniexClient CreateClient()
        {
            return new PoloniexClient(ApiKeys.PublicKey, ApiKeys.PrivateKey);
        }
    }
}
