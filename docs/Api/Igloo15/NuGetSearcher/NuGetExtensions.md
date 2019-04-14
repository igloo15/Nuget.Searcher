# [NuGetExtensions](./NuGetExtensions.md)

Namespace: [Igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
Extensions for NuGet Stuff

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [IPackageSourceMetadata](./IPackageSourceMetadata.md) | ConvertToProxy ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data, [`NuGetServer`](./NuGetServer.md) server ) | Convert to Internal Proxy | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[NuGetVersion](./NuGetExtensions.md)> | GetAbsoluteLatestVersion ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get absolute latest version | 
| [DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime) | GetDate ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the Date this package was published | 
| [Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) | GetDownloadCount ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the DownloadCount | 
| [IPackageDownloadStream](./IPackageDownloadStream.md) | GetDownloadStream ( [`IPackageSourceMetadata`](./IPackageSourceMetadata.md) data, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) folder, [`NuGetVersion`](./NuGetExtensions.md) version ) | Download the package | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetIconUrl ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | The icon url | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetId ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the id of the package | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[NuGetVersion](./NuGetExtensions.md)> | GetLatestVersion ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get the latest package of this IPackageSearchMetadata that is not pre release | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] | GetTags ( [`IPackageSearchMetadata`](./NuGetExtensions.md) data ) | Get tags separated into an array | 


