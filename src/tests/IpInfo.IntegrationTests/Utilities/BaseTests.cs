using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests.Utilities
{
    internal static class BaseTests
    {
        public static async Task ApiTestWithTokenAsync(Func<IpInfoApi, CancellationToken, Task> action)
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            var cancellationToken = source.Token;

            var token = 
                Environment.GetEnvironmentVariable("IPINFO_TOKEN") ??
                throw new AssertInconclusiveException("IPINFO_TOKEN environment variable is not found.");

            using var client = new HttpClient();
            var api = new IpInfoApi(token, client);

            try
            {
                await action(api, cancellationToken).ConfigureAwait(false);
            }
            catch (ApiException exception)
            {
                if (exception.StatusCode != 403)
                {
                    throw;
                }
            }
        }

        public static async Task ApiTestAsync(Func<IpInfoApi, CancellationToken, Task> action)
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            var cancellationToken = source.Token;

            using var client = new HttpClient();
            var api = new IpInfoApi(client);

            try
            {
                await action(api, cancellationToken).ConfigureAwait(false);
            }
            catch (ApiException exception)
            {
                if (exception.StatusCode != 403)
                {
                    throw;
                }
            }
        }

        public static async Task GeneralApiTestAsync(Func<IpInfoApi, CancellationToken, Task<FullResponse>> action)
        {
            await ApiTestAsync(async (api, cancellationToken) =>
            {
                var response = await action(api, cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));
                Console.WriteLine(response.GetPropertiesText());
            });
        }

        public static async Task SingleApiTestAsync(Func<IpInfoApi, CancellationToken, Task<string>> action)
        {
            await ApiTestAsync(async (api, cancellationToken) =>
            {
                var response = await action(api, cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));
                Console.WriteLine(response);
            });
        }
    }
}
