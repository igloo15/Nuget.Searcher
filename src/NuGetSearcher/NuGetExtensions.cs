using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Extensions for NuGet Stuff
    /// </summary>
    public static class NuGetExtensions
    {
        /// <summary>
        /// Get the latest package of this IPackageSearchMetadata that is not pre release
        /// </summary>
        /// <param name="data">The data to get latest version of package that is not pre release</param>
        /// <returns>The latest version</returns>
        public static async Task<NuGetVersion> GetLatestVersion(this IPackageSearchMetadata data)
        {
            var result = await data.GetVersionsAsync().ConfigureAwait(false);
            return result.OrderByDescending(vi => vi.Version).Where(vi => !vi.Version.IsPrerelease).Select(vi => vi.Version).FirstOrDefault();
        }

        /// <summary>
        /// Get absolute latest version
        /// </summary>
        /// <param name="data">The data to find absolute version</param>
        /// <returns>The latest version regardless of pre-release</returns>
        public static async Task<NuGetVersion> GetAbsoluteLatestVersion(this IPackageSearchMetadata data)
        {
            var result = await data.GetVersionsAsync().ConfigureAwait(false);
            return result.OrderByDescending(vi => vi.Version).Select(vi => vi.Version).FirstOrDefault();
        }

        /// <summary>
        /// Get the Date this package was published
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The date</returns>
        public static DateTime GetDate(this IPackageSearchMetadata data)
        {
            return data.Published.Value.DateTime;
        }

        /// <summary>
        /// Get the DownloadCount
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The download count</returns>
        public static int GetDownloadCount(this IPackageSearchMetadata data)
        {
            return Convert.ToInt32(data.DownloadCount.Value);
        }

        /// <summary>
        /// The icon url
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The url to the icon</returns>
        public static string GetIconUrl(this IPackageSearchMetadata data)
        {
            return data.IconUrl.ToString();
        }

        /// <summary>
        /// Get the id of the package
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The id</returns>
        public static string GetId(this IPackageSearchMetadata data)
        {
            return data.Identity.Id;
        }

        /// <summary>
        /// Get the id of the package
        /// </summary>
        /// <param name="data">The package download extending</param>
        /// <returns>The id</returns>
        public static string GetId(this IPackageDownload data)
        {
            return data.GetIdentity().Id;
        }

        /// <summary>
        /// Get the PackageIdentity
        /// </summary>
        /// <param name="data">The package download extending</param>
        /// <returns>The package identity</returns>
        public static PackageIdentity GetIdentity(this IPackageDownload data)
        {
            return data.GetMetadata().Identity;
        }

        /// <summary>
        /// Get tags separated into an array
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The tags</returns>
        public static string[] GetTags(this IPackageSearchMetadata data)
        {
            return data.Tags.Split(' ');
        }

        /// <summary>
        /// Convert to Internal Proxy
        /// </summary>
        /// <param name="data">The package</param>
        /// <param name="server">The NuGet Server</param>
        /// <returns>The package as a proxy containing server</returns>
        public static IPackageSourceMetadata ConvertToProxy(this IPackageSearchMetadata data, NuGetServer server)
        {
            return new PackageSearchSourceProxy(data, server);
        }

        /// <summary>
        /// Downloads the specific version of the package and returns the result
        /// </summary>
        /// <param name="package">The package being extended</param>
        /// <param name="version">The version to download</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>The Package Downloaded</returns>
        public static IPackageDownload Download(this IPackageSourceMetadata package, NuGetVersion version, CancellationToken token = default(CancellationToken))
        {
            return Extensions.RunSync(() => package.DownloadAsync(version, token));
        }

        /// <summary>
        /// Downloads the specific version of the package and returns the result
        /// </summary>
        /// <param name="package">The package being extended</param>
        /// <param name="includePrerelease">Determines if prerelease packages should be included</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>The Package Downloaded</returns>
        public static IPackageDownload DownloadLatest(this IPackageSourceMetadata package, bool includePrerelease = false, CancellationToken token = default(CancellationToken))
        {
            return Extensions.RunSync(() => package.DownloadLatestAsync(includePrerelease, token));
        }

        /// <summary>
        /// Search the server for all Tags. Only OR Search is possible NuGet Api
        /// </summary>
        /// <param name="server">The server being extended</param>
        /// <param name="TagNames">The tags to search on</param>
        /// <returns>Search Results</returns>
        public static async Task<IEnumerable<IPackageSourceMetadata>> SearchContainsAllTagsAsync(this NuGetServer server, params string[] TagNames)
        {
            var tagQuery = NuGetSearcherUtility.GetTagQuery(TagNames);

            return await server.SearchAsync(tagQuery).ConfigureAwait(false);
        }

        /// <summary>
        /// Search by the id
        /// </summary>
        /// <param name="server">Server to search</param>
        /// <param name="id">The id to search</param>
        /// <returns>Task of the results</returns>
        public static async Task<IEnumerable<IPackageSourceMetadata>> SearchByIdAsync(this NuGetServer server, string id)
        {
            return await server.SearchAsync($"id:{id}").ConfigureAwait(false);
        }
    }
}