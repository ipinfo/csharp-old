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
        public async Task GetPrivacyInformationByIpTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var privacy = await api.GetPrivacyInformationByIpAsync("8.8.8.8", cancellationToken);

            Assert.IsNotNull(privacy, nameof(privacy));

            Console.WriteLine($"Vpn: {privacy.Vpn}");
            Console.WriteLine($"Proxy: {privacy.Proxy}");
            Console.WriteLine($"Tor: {privacy.Tor}");
            Console.WriteLine($"Hosting: {privacy.Hosting}");
        });
    }
}
