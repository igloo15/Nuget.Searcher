# [NuGetSearcherUtility](./NuGetSearcherUtility.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
Utility functions for NuGetSearch

## Static Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [NuGetServer](./NuGetServer.md) | GlobalPackagesFeed | The local global packages feed | 
| [NuGetServer](./NuGetServer.md) | NuGetStandardFeedV2 | The standard nuget.org feed V2 api | 
| [NuGetServer](./NuGetServer.md) | NuGetStandardFeedV3 | The standard nuget.org feed V3 api | 


## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [NuGetServer](./NuGetServer.md) | CreateServer ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) location, [`ILoggerFactory`](./NuGetSearcherUtility.md) factory ) | Create a server with a custom location | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetTagQuery ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] TagNames ) | Convert your tags into a NuGet Search Query. NuGet only Supports OR searching not AND | 


