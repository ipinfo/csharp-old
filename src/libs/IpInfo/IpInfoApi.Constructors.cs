using System.Net.Http.Headers;

namespace IpInfo;

/// <summary>
/// Class providing methods for API access.
/// </summary>
public partial class IpInfoApi
{
    /// <summary>
    /// Sets the selected token as a default header for the HttpClient.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="httpClient"></param>
    public IpInfoApi(string token, HttpClient httpClient) : this(httpClient)
    {
        token = token ?? throw new ArgumentNullException(nameof(token));
        httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
