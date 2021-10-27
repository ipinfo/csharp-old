namespace IpInfo.IntegrationTests;

[TestClass]
public class AbuseTests
{
    [TestMethod]
    public async Task AbuseTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
    {
        var response = await api.GetAbuseAsync("8.8.8.8", cancellationToken);

        response.Should().NotBeNull();

        Console.WriteLine(response.GetPropertiesText());
    });
}
