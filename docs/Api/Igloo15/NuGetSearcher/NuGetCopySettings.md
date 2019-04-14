# [NuGetCopySettings](./NuGetCopySettings.md)

Namespace: [igloo15]() > [NuGetSearcher](./README.md)

Assembly: igloo15.NuGetSearcher.dll

## Summary
Settings for copying files from download to final resting place

## Constructors

| Name | Summary | 
| --- | --- | 
| NuGetCopySettings (  ) |  | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [Func](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String), [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean)> | Filter | Filters which files are copied | 
| [Func](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String), [String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | PathAlter | Alters the path being created | 
| [Func](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String), [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean)> | RemoveEmptyFilter | Provides a list of folders that are empty and if true is returned it will delete if a parent folder is marked for deletion but not a sub folder the parent folder will not be deleted | 


