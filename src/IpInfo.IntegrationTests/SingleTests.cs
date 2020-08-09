using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public async Task GetCurrentCityTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentCityAsync(cancellationToken));

        [TestMethod]
        public async Task GetCityByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCityByIpAsync("8.8.8.8", cancellationToken));
    }
}
