using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class AbuseTests
    {
        [TestMethod]
        public async Task AbuseTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetAbuseAsync("8.8.8.8", cancellationToken);

            Assert.IsNotNull(response, nameof(response));
            Console.WriteLine(response.GetPropertiesText());
        });
    }
}
