using System;
using System.Threading.Tasks;
using FluentAssertions;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class AsnTests
    {
        [TestMethod]
        public async Task AsnTest() => await BaseTests.ApiTestWithTokenAsync(async (api, cancellationToken) =>
        {
            var response = await api.GetAsnAsync(7922, cancellationToken);

            response.Should().NotBeNull();

            Console.WriteLine(response.GetPropertiesText());
        });
    }
}
