NuGet.Searcher
===

NuGet Package API allows you to search and download NuGet Packages. Support for Local Package Repos, V2, and V3 NuGet Feeds. Checkout our Full [API Documentation](./docs/Api)

### Master Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/xxgnr7i820m57i57/branch/master?svg=true)](https://ci.appveyor.com/project/igloo15/nuget-searcher)

### NuGet Package

[![Nuget](https://img.shields.io/nuget/vpre/Igloo15.NuGetSearcher.svg?label=Igloo15.NuGetSearcher)](https://www.nuget.org/packages/Igloo15.NuGetSearcher/)

## Build

```
.\build.ps1
```

## Usage

Query the Official NuGet Feed using the v2 api or v3 api
```csharp
using igloo15.NuGetSearcher;
using Microsoft.Extensions.Logging;

var factory = new LoggerFactory().AddConsole();
var results = NuGetSearcherUtility.NuGetStandardFeedV2
                .LoadLogger(factory)
                .SetTemp("./testcache")
                .Search("test", true)
                .Where(p => p.GetTags().Contains("Microsoft"));

foreach (var result in results)
{
    Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
    var package = result.DownloadLatest();
    Console.WriteLine(package.GetIdentity().Version.ToFullString());
    var settings = new NuGetCopySettings()
    {
        Filter = f =>
        {
            var dirName = Path.GetDirectoryName(f);
            var filterResult = dirName == "lib\\net45";
            return filterResult;
        },
        PathAlter = t => Path.GetFileName(t)
    };

    package.CopyFiles($"../{package.GetId()}", settings);
}
```

Hook into your local Global Packages Feed Cache on your machine
```csharp
using igloo15.NuGetSearcher;

var results = NuGetSearcherUtility.GlobalPackagesFeed.GetAllPackages();

foreach (var result in results)
{
    Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
    var publishData = result.GetDate();
    var licenseUrl = result.LicenseUrl;
    var projectUrl = result.ProjectUrl;
    var summary = result.Summary;
    var owners = result.Owners;
    string[] tags = result.GetTags();
}
```

Custom package feeds using the V3 package folder structure
```csharp
using igloo15.NuGetSearcher;
using Microsoft.Extensions.Logging;

var factory = new LoggerFactory().AddConsole();
var server = NuGetSearcherUtility.CreateServer("C:\mynugetfeed", factory);

var result = server.GetAllPackages();

foreach (var result in results)
{
    Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
    var publishData = result.GetDate();
    var licenseUrl = result.LicenseUrl;
    var projectUrl = result.ProjectUrl;
    var summary = result.Summary;
    var owners = result.Owners;
    string[] tags = result.GetTags();
}
```
