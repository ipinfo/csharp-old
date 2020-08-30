using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class HostedDomainsTests
    {
        [TestMethod]
        public async Task HostedDomainsTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetDomainsAsync("1.1.1.1", cancellationToken);

            Assert.IsNotNull(response, nameof(response));

            foreach (var property in response.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(response)}");
            }
        });
    }
}
