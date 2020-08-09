using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public async Task GetCurrentIpInfoTest() => await BaseTests.GeneralApiTestAsync(
            (api, cancellationToken) => api.GetCurrentIpInfoAsync(cancellationToken));

        [TestMethod]
        public async Task GetIpInfoByIpTest() => await BaseTests.GeneralApiTestAsync(
            (api, cancellationToken) => api.GetIpInfoByIpAsync("8.8.8.8", cancellationToken));
    }
}
