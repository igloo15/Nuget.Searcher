using NuGet.Common;
using NuGet.PackageManagement;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Igloo15.NuGetSearcher
{
    /// <summary>
    /// Stream to get package
    /// </summary>
    public interface IPackageDownloadStream
    {
        /// <summary>
        /// Syncronously get a package
        /// </summary>
        /// <returns>The NuGetPackage</returns>
        IPackageCoreReader GetPackage();

        /// <summary>
        /// Async get a package
        /// </summary>
        /// <returns>The task of NuGetPackage</returns>
        Task<IPackageCoreReader> GetPackageAsync();
    }

    internal class DownloadStream : IPackageDownloadStream
    {
        private NuGetServer server;
        private PackageIdentity packageIdentity;
        private string folder;

        internal DownloadStream(NuGetServer server, PackageIdentity packageIdentity, string folder)
        {
            this.packageIdentity = packageIdentity;
            this.folder = folder;
            this.server = server;
        }

        public IPackageCoreReader GetPackage()
        {
            return GetPackageAsync().Result;
        }

        public async Task<IPackageCoreReader> GetPackageAsync()
        {
            var result = await PackageDownloader.GetDownloadResourceResultAsync(server.Source, packageIdentity, new PackageDownloadContext(new SourceCacheContext()), folder, NullLogger.Instance, CancellationToken.None);
           
            if (result.Status != DownloadResourceResultStatus.Available)
            {
                throw new Exception("Failed to download");
            }

            return result.PackageReader;
        }
    }
}
