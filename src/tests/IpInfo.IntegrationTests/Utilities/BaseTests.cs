namespace IpInfo.IntegrationTests;

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

        await action(api, cancellationToken).ConfigureAwait(false);
    }

    public static async Task ApiTestAsync(Func<IpInfoApi, CancellationToken, Task> action)
    {
        using var source = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var cancellationToken = source.Token;

        using var client = new HttpClient();
        var api = new IpInfoApi(client);

        await action(api, cancellationToken).ConfigureAwait(false);
    }

    public static async Task SingleApiTestAsync(Func<IpInfoApi, CancellationToken, Task<string>> action)
    {
        await ApiTestAsync(async (api, cancellationToken) =>
        {
            var response = await action(api, cancellationToken)
                .ConfigureAwait(false);

            response.Should().NotBeNull();

            Console.WriteLine(response);
        });
    }
}
