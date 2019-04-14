# [NuGetLogger](./NuGetLogger.md)

Namespace: [Igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

Implements [ILogger](./NuGetLogger.md)

## Summary
Microsoft.Extensions.Logging adaptor to NuGet Logging

## Constructors

| Name | Summary | 
| --- | --- | 
| NuGetLogger ( [`ILogger`](./NuGetLogger.md) logger ) | Contructor of NuGetLogger with Microsoft Extensions Logging ILogger | 


## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| void | Log ( [`LogLevel`](./NuGetLogger.md) level, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Genric log at level | 
| void | Log ( [`ILogMessage`](./NuGetLogger.md) message ) | Generic Logging of ILogMessage | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task) | LogAsync ( [`LogLevel`](./NuGetLogger.md) level, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Generic Log at Level Async | 
| [Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task) | LogAsync ( [`ILogMessage`](./NuGetLogger.md) message ) | Generic Logging of ILogMessage Async | 
| void | LogDebug ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log debug | 
| void | LogError ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log Error | 
| void | LogInformation ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log Information | 
| void | LogInformationSummary ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log Informational | 
| void | LogMinimal ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log Minimal | 
| void | LogVerbose ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log verbose | 
| void | LogWarning ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) data ) | Log Warning | 


