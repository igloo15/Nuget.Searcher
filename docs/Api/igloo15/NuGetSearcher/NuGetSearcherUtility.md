# [NuGetSearcherUtility](./NuGetSearcherUtility.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
Utility functions for NuGetSearch

## Static Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[NuGetServer](./NuGetServer.md)> | FallbackFeeds | Zero or More NuGet Fallback Feeds these are global feeds similar to the GAC from the past | 
| [NuGetServer](./NuGetServer.md) | GlobalPackagesFeed | The local global packages feed | 
| [NuGetPathContext](./NuGetSearcherUtility.md) | NuGetPaths | The Global NuGetPaths based on settings loaded from current working directory | 
| [ISettings](./NuGetSearcherUtility.md) | NuGetSettings | The global machine settings in relation to current working directory | 
| [NuGetServer](./NuGetServer.md) | NuGetStandardFeedV2 | The standard nuget.org feed V2 api | 
| [NuGetServer](./NuGetServer.md) | NuGetStandardFeedV3 | The standard nuget.org feed V3 api | 


## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [NuGetServer](./NuGetServer.md) | CreateServer ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) location, [`ILoggerFactory`](./NuGetSearcherUtility.md) factory ) | Create a server with a custom location | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetTagQuery ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] TagNames ) | Convert your tags into a NuGet Search Query. NuGet only Supports OR searching not AND | 


