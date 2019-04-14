using NuGet.Common;
using NuGet.PackageManagement;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace igloo15.NuGetSearcher
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
        IPackageDownload GetPackage();

        /// <summary>
        /// Async get a package
        /// </summary>
        /// <returns>The task of NuGetPackage</returns>
        Task<IPackageDownload> GetPackageAsync(CancellationToken token = default(CancellationToken));
    }

    internal class DownloadStream : IPackageDownloadStream
    {
        private NuGetServer server;
        private PackageIdentity packageIdentity;

        private IPackageSourceMetadata _metadata;
        private string folder;

        internal DownloadStream(NuGetServer server, PackageIdentity packageIdentity, string folder, IPackageSourceMetadata metadata)
        {
            this.packageIdentity = packageIdentity;
            this.folder = folder;
            this.server = server;
            _metadata = metadata;
        }

        public IPackageDownload GetPackage()
        {
            return GetPackageAsync().Result;
        }

        public async Task<IPackageDownload> GetPackageAsync(CancellationToken token = default(CancellationToken))
        {
            var result = await PackageDownloader.GetDownloadResourceResultAsync(server.Source, packageIdentity, new PackageDownloadContext(new SourceCacheContext()), folder, server.Logger, token);
           
            if (result.Status != DownloadResourceResultStatus.Available)
            {
                throw new Exception("Failed to download");
            }

            return new PackageCoreReaderProxy(result.PackageReader, _metadata, packageIdentity.Version);
        }
    }
}
