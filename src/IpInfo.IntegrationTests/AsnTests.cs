using System;
using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class AsnTests
    {
        [TestMethod]
        public async Task AsnTest() => await BaseTests.ApiTestAsync(async (api, cancellationToken) =>
        {
            var asn = await api.GetAsnAsync(7922, cancellationToken);

            Assert.IsNotNull(asn, nameof(asn));

            foreach (var property in asn.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(asn)}");
            }
        });
    }
}
