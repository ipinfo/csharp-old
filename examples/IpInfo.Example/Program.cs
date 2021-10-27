using IpInfo;

using var client = new HttpClient();
var api = new IpInfoApi(client);

var response = await api.GetCurrentInformationAsync();

Console.WriteLine($"City: {response.City}");
