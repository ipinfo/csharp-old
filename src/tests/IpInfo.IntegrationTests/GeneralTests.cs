using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public async Task GetCurrentInformationTest() => await BaseTests.GeneralApiTestAsync(
            (api, cancellationToken) => api.GetCurrentInformationAsync(cancellationToken));

        [TestMethod]
        public async Task GetInformationByIpTest() => await BaseTests.GeneralApiTestAsync(
            (api, cancellationToken) => api.GetInformationByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task BatchTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var dictionary = await api.BatchAsync(new []
                {
                    "8.8.8.8",
                    "8.8.8.8/city",
                }, cancellationToken);

            Assert.IsNotNull(dictionary, nameof(dictionary));

            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        });

        [TestMethod]
        public async Task GetInformationByIpsTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
        {
            var dictionary = await api.GetInformationByIpsAsync(new[]
            {
                "8.8.8.8",
                "8.8.4.4",
            }, cancellationToken);

            Assert.IsNotNull(dictionary, nameof(dictionary));

            foreach (var pair in dictionary)
            {
                Assert.IsNotNull(pair.Value, nameof(pair.Value));

                Console.WriteLine($"{pair.Key}:");
                foreach (var property in pair.Value.GetType().GetProperties())
                {
                    Console.WriteLine($"  {property.Name}: {property.GetValue(pair.Value)}");
                }
                Console.WriteLine();
            }
        });
    }
}
