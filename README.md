# [<img src="https://ipinfo.io/static/ipinfo-small.svg" alt="IPinfo" width="24"/>](https://ipinfo.io/) IPinfo C# Client Library

[![Language](https://img.shields.io/badge/language-C%23-blue.svg?style=flat-square)](https://github.com/ipinfo/csharp/search?l=C%23&o=desc&s=&type=Code) 
[![License](https://img.shields.io/github/license/ipinfo/csharp.svg?label=License&maxAge=86400)](LICENSE) 
[![Requirements](https://img.shields.io/badge/Requirements-.NET%20Standard%202.0-blue.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) 
[![Requirements](https://img.shields.io/badge/Requirements-.NET%20Framework%204.5-blue.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) 
[![Build Status](https://github.com/ipinfo/csharp/workflows/.NET%20Core/badge.svg?branch=master)](https://github.com/ipinfo/csharp/actions?query=workflow%3A%22.NET+Core%22)

This is the official Python client library for the IPinfo.io IP address API, allowing you to lookup your own IP address, or get any of the following details for an IP:

 - [IP geolocation / geoIP data](https://ipinfo.io/ip-geolocation-api) (city, region, country, postal code, latitude and longitude)
 - [ASN details](https://ipinfo.io/asn-api) (ISP or network operator, associated domain name, and type, such as business, hosting or company)
 - [Firmographics data](https://ipinfo.io/ip-company-api) (the name and domain of the business that uses the IP address)
 - [Carrier information](https://ipinfo.io/ip-carrier-api) (the name of the mobile carrier and MNC and MCC for that carrier if the IP is used exclusively for mobile traffic)

## Getting Started

You'll need an IPinfo API access token, which you can get by singing up for a free account at [https://ipinfo.io/signup](https://ipinfo.io/signup).

The free plan is limited to 50,000 requests per month, and doesn't include some of the data fields such as IP type and company data. To enable all the data fields and additional request volumes see [https://ipinfo.io/pricing](https://ipinfo.io/pricing)

### Nuget

[![NuGet](https://img.shields.io/nuget/dt/IpInfo.svg?style=flat-square&label=IpInfo)](https://www.nuget.org/packages/IpInfo/)

```
Install-Package IpInfo
```

### Usage

```cs
using IpInfo;

using var client = new HttpClient();
var api = new IpInfoApi(client);

var response = await api.GetCurrentIpInfoAsync();

Console.WriteLine($"City: {response.City}");
```

### Live Example

C# .NET Fiddle - https://dotnetfiddle.net/i5MmNp  
VB.NET .NET Fiddle - https://dotnetfiddle.net/EUszSY  

### Contacts
* [mail](mailto:havendv@gmail.com)
