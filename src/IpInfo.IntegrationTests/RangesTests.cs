using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class RangesTests
    {
        [TestMethod]
        public async Task RangesTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var ranges = await api.GetRangesAsync("comcast.net", cancellationToken);

            Assert.IsNotNull(ranges, nameof(ranges));

            foreach (var property in ranges.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(ranges)}");
            }
        });
    }
}
