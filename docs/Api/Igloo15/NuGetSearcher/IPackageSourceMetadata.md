# [IPackageSourceMetadata](./IPackageSourceMetadata.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

Implements [IPackageSearchMetadata](./IPackageSourceMetadata.md)

## Summary
Combines IPackageSearchMetadata and NuGetServer to provide more functionality

## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IPackageDownload](./IPackageDownload.md)> | DownloadAsync ( [`NuGetVersion`](./IPackageSourceMetadata.md) version, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Download package with specific version | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IPackageDownload](./IPackageDownload.md)> | DownloadLatestAsync ( [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) includePrerelease, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) |  | 
| [NuGetServer](./NuGetServer.md) | GetServer (  ) | Get the server that provided this IPackageSearchMetadata | 


