using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IpInfo.IntegrationTests.Utilities
{
    internal static class BaseTests
    {
        public static async Task ApiTestAsync(Func<IpInfoApi, Task> action)
        {
            var token = Environment.GetEnvironmentVariable("IPINFO_TOKEN") ??
                        throw new InvalidOperationException("token is null.");

            using var client = new HttpClient();
            var api = new IpInfoApi(token, client);

            await action(api).ConfigureAwait(false);
        }
    }
}
