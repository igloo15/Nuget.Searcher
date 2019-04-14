# [NuGetServer](./NuGetServer.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
The base server class which you can search against

## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | FeedLocation | The location of the feed for this server | 
| [Nullable](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1)\<[Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean)> | IncludePrelease | Overrides the method input if given | 
| [ILogger](./NuGetServer.md) | Logger | The NuGet Logger for this server | 
| [Nullable](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1)\<[Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32)> | SkipAmount | Overrides the method input if given | 
| [Nullable](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1)\<[Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32)> | TakeAmount | Overrides the method input if given | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | TempDownloadLocation | The location where packages are temporarily downloaded too | 


## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [NuGetServer](./NuGetServer.md) | LoadLogger ( [`ILoggerFactory`](./NuGetServer.md) factory ) | Load a LoggerFactory for the server | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)> | Search ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) searchTerm, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) includePrerelease, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) cancelToken, [`Int32`](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) skip, [`Int32`](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) take ) | The search term used to search the server synchronously | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1)\<[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[IPackageSourceMetadata](./IPackageSourceMetadata.md)>> | SearchAsync ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) searchTerm, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) includePrerelease, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) cancelToken, [`Int32`](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) skip, [`Int32`](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) take ) | Search using search term asyncly | 
| [NuGetServer](./NuGetServer.md) | SetTemp ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) path ) | Set the temporary location to download packages and extract | 


