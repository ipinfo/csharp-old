using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class PrivacyDetectionTests
    {
        [TestMethod]
        public async Task GetPrivacyInformationByIpTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetPrivacyInformationByIpAsync("8.8.8.8", cancellationToken);

            Assert.IsNotNull(response, nameof(response));
            Console.WriteLine(response.GetPropertiesText());
        });
    }
}
