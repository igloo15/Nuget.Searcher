NuGet.Searcher
===

NuGet Package API allows you to search and download NuGet Packages. Support for Local Package Repos, V2, and V3 NuGet Feeds. 

### Master Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/xxgnr7i820m57i57/branch/master?svg=true)](https://ci.appveyor.com/project/igloo15/nuget-searcher)

### NuGet Package

[![Nuget](https://img.shields.io/nuget/vpre/igloo15.NuGet.Searcher.svg?label=igloo15.NuGet.Searcher)](https://www.nuget.org/packages/igloo15.NuGet.Searcher/)

## Build

```
.\build.ps1
```

## Usage

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
