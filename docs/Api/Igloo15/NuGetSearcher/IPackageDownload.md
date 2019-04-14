# [IPackageDownload](./IPackageDownload.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
A package downloaded

## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | CopyFiles ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) dest, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Copy the entire contents of the package to destination folder | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | CopyFiles ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) dest, [`Func`](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2)\<[`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String), [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean)> filter, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Copy files from package to a new destination | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | CopyFiles ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) dest, [`NuGetCopySettings`](./NuGetCopySettings.md) settings, [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken) token ) | Copy the files from the package to a new destination with the given settings | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | GetFiles (  ) | Get all files from package | 
| [IPackageSourceMetadata](./IPackageSourceMetadata.md) | GetMetadata (  ) | The metadata that this was downloaded from | 
| [NuGetVersion](./IPackageDownload.md) | GetVersion (  ) | Get the version of this package downloaded | 


