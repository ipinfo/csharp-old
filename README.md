# [<img src="https://ipinfo.io/static/ipinfo-small.svg" alt="IPinfo" width="24"/>](https://ipinfo.io/) IPinfo C# Client Library

[![Language](https://img.shields.io/badge/language-C%23-blue.svg?style=flat-square)](https://github.com/ipinfo/csharp/search?l=C%23&o=desc&s=&type=Code) 
[![License](https://img.shields.io/github/license/ipinfo/csharp.svg?label=License&maxAge=86400)](LICENSE) 
[![Requirements](https://img.shields.io/badge/Requirements-.NET%20Standard%202.0-blue.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) 
[![Requirements](https://img.shields.io/badge/Requirements-.NET%20Framework%204.5-blue.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) 
[![Build Status](https://github.com/ipinfo/csharp/workflows/.NET/badge.svg?branch=master)](https://github.com/ipinfo/csharp/actions?query=workflow%3A%22.NET%22)

This is the official C# client library for the IPinfo.io IP address API, allowing you to lookup your own IP address, or get any of the following details for an IP:

 - [IP geolocation / geoIP data](https://ipinfo.io/ip-geolocation-api) (city, region, country, postal code, latitude and longitude)
 - [ASN details](https://ipinfo.io/asn-api) (ISP or network operator, associated domain name, and type, such as business, hosting or company)
 - [Firmographics data](https://ipinfo.io/ip-company-api) (the name and domain of the business that uses the IP address)
 - [Carrier information](https://ipinfo.io/ip-carrier-api) (the name of the mobile carrier and MNC and MCC for that carrier if the IP is used exclusively for mobile traffic)

## Getting Started

You'll need an IPinfo API access token, which you can get by singing up for a free account at [https://ipinfo.io/signup](https://ipinfo.io/signup).

The free plan is limited to 50,000 requests per month, and doesn't include some of the data fields such as IP type and company data. To enable all the data fields and additional request volumes see [https://ipinfo.io/pricing](https://ipinfo.io/pricing)

## Nuget

[![NuGet](https://img.shields.io/nuget/dt/IpInfo.svg?style=flat-square&label=IpInfo)](https://www.nuget.org/packages/IpInfo/)

```
Install-Package IpInfo
```

## Usage

```cs
using IpInfo;

using var client = new HttpClient();
var api = new IpInfoApi("your-token", client); // Some methods work without a token, for this case there is a constructor without a token.

var response = await api.GetCurrentInformationAsync();

Console.WriteLine($"City: {response.City}");
```

## Batch API

```cs
// WARNING: Token required.
var dictionary = await api.GetInformationByIpsAsync(new[]
{
    "8.8.8.8",
    "8.8.4.4",
}, cancellationToken);

foreach (var pair in dictionary)
{
    Console.WriteLine($"{pair.Key} City: {pair.Value.City}");
}

// 8.8.4.4 City: Amstelveen
// 8.8.8.8 City: Mountain View


// WARNING: Token required.
var dictionary = await api.BatchAsync(new []
{
    "8.8.4.4/city",
    "8.8.8.8/city",
}, cancellationToken);

foreach (var pair in dictionary)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}

// 8.8.4.4: Amstelveen
// 8.8.8.8: Mountain View
```

## Privacy Detection API

```cs
// WARNING: Token required.
var privacy = await api.GetPrivacyInformationByIpAsync("8.8.8.8", cancellationToken);

Console.WriteLine($"Vpn: {privacy.Vpn}");
Console.WriteLine($"Proxy: {privacy.Proxy}");
Console.WriteLine($"Tor: {privacy.Tor}");
Console.WriteLine($"Hosting: {privacy.Hosting}");

// Vpn: False
// Proxy: False
// Tor: False
// Hosting: False
```

## Live Example

C# .NET Fiddle - https://dotnetfiddle.net/i5MmNp  
VB.NET .NET Fiddle - https://dotnetfiddle.net/EUszSY  

## Contacts
* [mail](mailto:havendv@gmail.com)

## Other Libraries

There are official [IPinfo client libraries](https://ipinfo.io/developers/libraries) available for many languages including PHP, Go, Java, Ruby, and many popular frameworks such as Django, Rails and Laravel. There are also many third party libraries and integrations available for our API.

## About IPinfo

Founded in 2013, IPinfo prides itself on being the most reliable, accurate, and in-depth source of IP address data available anywhere. We process terabytes of data to produce our custom IP geolocation, company, carrier, VPN detection, hosted domains, and IP type data sets. Our API handles over 40 billion requests a month for 100,000 businesses and developers.

[![image](https://avatars3.githubusercontent.com/u/15721521?s=128&u=7bb7dde5c4991335fb234e68a30971944abc6bf3&v=4)](https://ipinfo.io/)
