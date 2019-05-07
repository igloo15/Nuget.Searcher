# Changelog
## Unreleased
### Summary


### Add
*  folder exist method on packagedownload to determine if folder exists in download
*  new NuGet Settings locator
*  Fallback Feeds
*  new copy files method to easily copy a folder of the nuget package


### Changes
*  N/A 


### Fixes
*  CopyFiles(string, string, token) now works correctly copying all folders and files in folder path given to destination
*  correct nuget package name on readme
*  fix casing of folders on api documentation




## v1.0.0
### Summary
first official release of NuGet.Searcher Api hopefully allows more people to easily use nuget package api.. 

### Add
*  async and sync methods to get all packages in a feed
*  NuGetServer now has TempDowloadLocation to determine where downloads should first be downloaded to before copied
*  NuGetCopy settings added to simplify the argument passing when Copying files
*  Async helper methods added
*  GlobalPackagesFeed and Custom Server creation
*  Can now download packages
*  Can now copy files to a specific location
*  downloading is now possible in api
*  NugetSearcher Client was added as a means to test the library
*  Create NuGetServer
*  NuGetSearcherUtility to provide utility methods and constants


### Changes
*  update package description
*  update readme documentation
*  move sync methods to extensions
*  update api documentation
*  update api documentation
*  move sync methods to extensions
*  update changelog configuration file
*  update to build scripts version 2.0.2
*  made async methods ConfigureAwait
*  cleaned up sync methods to use appropiate way of asyncing results
*  NuGetServer must be constructed by Utility class now
*  DownloadStream removed as not need anymore
*  update to latest build scripts
*  update documentation
*  update appveyor configuration
*  Renamed to NuGetSearcher to avoid namespace clash
*  Update Cake Scripts


### Fixes
*  create a directory if it doesn't exist already
*  NugetLogger has null checks to prevent logging to a null logger
*  Build scripts were fixed
*  Fixed Main solution's path to csproj




## v0.1.0
### Summary


### Add
*  N/A 


### Changes
*  N/A 


### Fixes
*  N/A 





