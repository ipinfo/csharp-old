using System;
using System.Threading;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class FreeTests
    {
        [TestMethod]
        public async Task GetCurrentIpInfoTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var cancellationToken = source.Token;

            await BaseTests.ApiTestAsync(async api =>
            {
                var response = await api.GetCurrentIpInfoAsync(cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));

                foreach (var property in response.GetType().GetProperties())
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(response)}");
                }
            });
        }

        [TestMethod]
        public async Task GetIpInfoByIpTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var cancellationToken = source.Token;

            await BaseTests.ApiTestAsync(async api =>
            {
                var response = await api.GetIpInfoByIpAsync("8.8.8.8", cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));

                foreach (var property in response.GetType().GetProperties())
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(response)}");
                }
            });
        }

        [TestMethod]
        public async Task GetCurrentCityTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var cancellationToken = source.Token;

            await BaseTests.ApiTestAsync(async api =>
            {
                var response = await api.GetCurrentCityAsync(cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));

                Console.WriteLine(response);
            });
        }

        [TestMethod]
        public async Task GetCityByIpTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var cancellationToken = source.Token;

            await BaseTests.ApiTestAsync(async api =>
            {
                var response = await api.GetCityByIpAsync("8.8.8.8", cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));

                Console.WriteLine(response);
            });
        }
    }
}
