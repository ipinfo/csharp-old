using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task GetCurrentIpInfoTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var cancellationToken = source.Token;

            await ApiTestAsync(async api =>
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

        private static async Task ApiTestAsync(Func<IpInfoApi, Task> action)
        {
            var token = Environment.GetEnvironmentVariable("IPINFO_TOKEN") ??
                        throw new InvalidOperationException("token is null.");

            using var client = new HttpClient();
            var api = new IpInfoApi(token, client);

            await action(api).ConfigureAwait(false);
        }
    }
}
