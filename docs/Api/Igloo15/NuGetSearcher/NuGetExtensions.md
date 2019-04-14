# [NuGetExtensions](./NuGetExtensions.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
Extensions for NuGet Stuff

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [IPackageSourceMetadata](./IPackageSourceMetadata.md) | ConvertToProxy ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data, [`NuGetServer`](./NuGetServer.md) server ) | Convert to Internal Proxy | 
| [IPackageDownload](./IPackageDownload.md) | Download ( [`IPackageSourceMetadata`](./IPackageSourceMetadata.md) package, [`NuGetVersion`](./NuGetExtensions.md) version, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Downloads the specific version of the package and returns the result | 
| [IPackageDownload](./IPackageDownload.md) | DownloadLatest ( [`IPackageSourceMetadata`](./IPackageSourceMetadata.md) package, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) includePrerelease, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Downloads the specific version of the package and returns the result | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[NuGetVersion](./NuGetExtensions.md)> | GetAbsoluteLatestVersion ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get absolute latest version | 
| [DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime) | GetDate ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the Date this package was published | 
| [Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) | GetDownloadCount ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the DownloadCount | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetIconUrl ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | The icon url | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetId ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the id of the package | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetId ( [`IPackageDownload`](./IPackageDownload.md) data ) | Get the id of the package | 
| [PackageIdentity](./NuGetExtensions.md) | GetIdentity ( [`IPackageDownload`](./IPackageDownload.md) data ) | Get the PackageIdentity | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[NuGetVersion](./NuGetExtensions.md)> | GetLatestVersion ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the latest package of this IPackageSearchMetadata that is not pre release | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] | GetTags ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get tags separated into an array | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)>> | SearchByIdAsync ( [`NuGetServer`](./NuGetServer.md) server, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) id ) | Search by the id | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)>> | SearchContainsAllTagsAsync ( [`NuGetServer`](./NuGetServer.md) server, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] TagNames ) | Search the server for all Tags. Only OR Search is possible NuGet Api | 


