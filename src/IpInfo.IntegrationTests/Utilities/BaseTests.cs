using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests.Utilities
{
    internal static class BaseTests
    {
        public static async Task ApiTestAsync(Func<IpInfoApi, CancellationToken, Task> action)
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            var cancellationToken = source.Token;

            var token = Environment.GetEnvironmentVariable("IPINFO_TOKEN") ??
                        throw new InvalidOperationException("token is null.");

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

        public static async Task GeneralApiTestAsync(Func<IpInfoApi, CancellationToken, Task<FullResponse>> action)
        {
            await ApiTestAsync(async (api, cancellationToken) =>
            {
                var response = await action(api, cancellationToken)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response, nameof(response));

                foreach (var property in response.GetType().GetProperties())
                {
                    var value = property.GetValue(response);
                    Console.WriteLine($"{property.Name}: {value}");

                    if (value == null || !value.GetType().IsClass || value is string)
                    {
                        continue;
                    }

                    foreach (var objectProperty in value.GetType().GetProperties())
                    {
                        try
                        {
                            Console.WriteLine($"  {objectProperty.Name}: {objectProperty.GetValue(value)}");
                        }
                        catch (TargetParameterCountException)
                        {
                        }
                    }
                }
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
