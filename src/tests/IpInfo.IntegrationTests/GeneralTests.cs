using System;
using System.Threading.Tasks;
using FluentAssertions;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public async Task GetCurrentInformationTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) => 
        { 
            var response = await api.GetCurrentInformationAsync(cancellationToken)
                .ConfigureAwait(false);

            response.Should().NotBeNull();
        });

        [TestMethod]
        public async Task GetInformationByIpTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetInformationByIpAsync("8.8.8.8", cancellationToken)
                .ConfigureAwait(false);

            response.Should().NotBeNull();
        });

        [TestMethod]
        public async Task BatchTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var dictionary = await api.BatchAsync(new []
            {
                "8.8.8.8",
                "8.8.8.8/city",
            }, cancellationToken);

            dictionary.Should().NotBeNull();

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

            dictionary.Should().NotBeNull();

            foreach (var pair in dictionary)
            {
                pair.Value.Should().NotBeNull();

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
