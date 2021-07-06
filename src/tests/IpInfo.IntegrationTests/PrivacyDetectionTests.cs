using System;
using System.Threading.Tasks;
using FluentAssertions;
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

            response.Should().NotBeNull();

            Console.WriteLine(response.GetPropertiesText());
        });
    }
}
