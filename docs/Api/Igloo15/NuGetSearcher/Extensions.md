# [Extensions](./Extensions.md)

Namespace: [Igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll


## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)>> | SearchById ( [`NuGetServer`](./NuGetServer.md) server, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) id ) | Search by the id | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)>> | SearchContainsAllTags ( [`NuGetServer`](./NuGetServer.md) server, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] TagNames ) | Search the server for all Tags. Only OR Search is possible NuGet Api | 


