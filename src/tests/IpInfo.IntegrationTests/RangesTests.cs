namespace IpInfo.IntegrationTests;

[TestClass]
public class RangesTests
{
    [TestMethod]
    public async Task RangesTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
    {
        var response = await api.GetRangesAsync("comcast.net", cancellationToken);

        response.Should().NotBeNull();

        Console.WriteLine(response.GetPropertiesText());
    });
}
