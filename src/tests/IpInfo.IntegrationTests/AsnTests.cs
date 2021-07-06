using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class AsnTests
    {
        [TestMethod]
        public async Task AsnTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetAsnAsync(7922, cancellationToken);

            Assert.IsNotNull(response, nameof(response));
            Console.WriteLine(response.GetPropertiesText());
        });
    }
}
