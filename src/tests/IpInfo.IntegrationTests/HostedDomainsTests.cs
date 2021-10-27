namespace IpInfo.IntegrationTests;

[TestClass]
public class HostedDomainsTests
{
    [TestMethod]
    public async Task HostedDomainsTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
    {
        var response = await api.GetDomainsAsync("1.1.1.1", cancellationToken: cancellationToken);

        response.Should().NotBeNull();

        Console.WriteLine(response.GetPropertiesText());
    });
}
