using System.Threading.Tasks;
using IpInfo.IntegrationTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.IntegrationTests
{
    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public async Task GetCurrentIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentIpAsync(cancellationToken));

        [TestMethod]
        public async Task GetIpByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetIpByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentHostnameTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentHostnameAsync(cancellationToken));

        [TestMethod]
        public async Task GetHostnameByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetHostnameByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentCityTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentCityAsync(cancellationToken));

        [TestMethod]
        public async Task GetCityByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCityByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentRegionTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentRegionAsync(cancellationToken));

        [TestMethod]
        public async Task GetRegionByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetRegionByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentCountryTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentCountryAsync(cancellationToken));

        [TestMethod]
        public async Task GetCountryByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCountryByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentLocationTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentLocationAsync(cancellationToken));

        [TestMethod]
        public async Task GetLocationByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetLocationByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentPostalTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentPostalAsync(cancellationToken));

        [TestMethod]
        public async Task GetPostalByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetPostalByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentTimezoneTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentTimezoneAsync(cancellationToken));

        [TestMethod]
        public async Task GetTimezoneByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetTimezoneByIpAsync("8.8.8.8", cancellationToken));

        [TestMethod]
        public async Task GetCurrentOrganizationTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetCurrentOrganizationAsync(cancellationToken));

        [TestMethod]
        public async Task GetOrganizationByIpTest() => await BaseTests.SingleApiTestAsync(
            (api, cancellationToken) => api.GetOrganizationByIpAsync("8.8.8.8", cancellationToken));
    }
}
