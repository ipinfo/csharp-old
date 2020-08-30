using System.Threading;
using System.Threading.Tasks;

namespace IpInfo
{
    public partial class IpInfoApi
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Our Hosted Domains, or Reverse IP API returns a list of all of the domains hosted on the provided IP address.</summary>
        /// <param name="ip">A single IPv4 or IPv6 IP address.</param>
        /// <param name="page">The page query parameter can be used to go through paginated records. page starts at 0 and the parameter is part of the response when included in request.</param>
        /// <returns>Domains response object.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<DomainsResponse> GetDomainsAsync(string ip, int? page, CancellationToken cancellationToken = default)
        {
            return GetDomainsAsync(ip, page, null, cancellationToken);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Our Hosted Domains, or Reverse IP API returns a list of all of the domains hosted on the provided IP address.</summary>
        /// <param name="ip">A single IPv4 or IPv6 IP address.</param>
        /// <returns>Domains response object.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<DomainsResponse> GetDomainsAsync(string ip, CancellationToken cancellationToken = default)
        {
            return GetDomainsAsync(ip, null, null, cancellationToken);
        }
    }
}