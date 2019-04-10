using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Igloo15.NuGetSearcher
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
            var result = await data.GetVersionsAsync();
            return result.OrderByDescending(vi => vi.Version).Where(vi => !vi.Version.IsPrerelease).Select(vi => vi.Version).FirstOrDefault();
        }

        /// <summary>
        /// Get absolute latest version
        /// </summary>
        /// <param name="data">The data to find absolute version</param>
        /// <returns>The latest version regardless of pre-release</returns>
        public static async Task<NuGetVersion> GetAbsoluteLatestVersion(this IPackageSearchMetadata data)
        {
            var result = await data.GetVersionsAsync();
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
        /// Get tags separated into an array
        /// </summary>
        /// <param name="data">The package</param>
        /// <returns>The tags</returns>
        public static string[] GetTags(this IPackageSearchMetadata data)
        {
            return data.Tags.Split(' ');
        }

        /// <summary>
        /// Download the package
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="folder">The folder to download too</param>
        /// <param name="version">The version to download</param>
        /// <returns>The stream to download</returns>
        public static IPackageDownloadStream GetDownloadStream(this IPackageSourceMetadata data, string folder, NuGetVersion version)
        {
            return new DownloadStream(data.GetServer(), new PackageIdentity(data.Identity.Id, version), folder);
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
    }
}
