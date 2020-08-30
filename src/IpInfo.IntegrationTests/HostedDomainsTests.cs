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
            var domains = await api.GetDomainsAsync("1.1.1.1", cancellationToken);

            Assert.IsNotNull(domains, nameof(domains));

            foreach (var property in domains.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(domains)}");
            }
        });
    }
}
