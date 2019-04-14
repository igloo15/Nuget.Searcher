using NuGet.Configuration;
using NuGet.PackageManagement;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Combines IPackageSearchMetadata and NuGetServer to provide more functionality
    /// </summary>
    public interface IPackageSourceMetadata : IPackageSearchMetadata
    {
        /// <summary>
        /// Get the server that provided this IPackageSearchMetadata
        /// </summary>
        /// <returns>The NuGetServer</returns>
        NuGetServer GetServer();

        /// <summary>
        /// Download package with specific version
        /// </summary>
        /// <param name="version">The version of package to download</param>
        /// <param name="token">An optional cancellation token</param>
        Task<IPackageDownload> DownloadAsync(NuGetVersion version, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Download the newest version of the package
        /// </summary>
        Task<IPackageDownload> DownloadLatestAsync(bool includePrerelease = false, CancellationToken token = default(CancellationToken));
    }

    internal class PackageSearchSourceProxy : IPackageSourceMetadata
    {
        private IPackageSearchMetadata _data;
        private NuGetServer _server;

        public PackageSearchSourceProxy(IPackageSearchMetadata data, NuGetServer server)
        {
            _data = data;
            _server = server;
        }

        public async Task<IEnumerable<VersionInfo>> GetVersionsAsync() => await _data.GetVersionsAsync();

        public string Authors => _data.Authors;

        public IEnumerable<PackageDependencyGroup> DependencySets => _data.DependencySets;

        public string Description => _data.Description;

        public long? DownloadCount => _data.DownloadCount;

        public Uri IconUrl => _data.IconUrl;

        public PackageIdentity Identity => _data.Identity;

        public Uri LicenseUrl => _data.LicenseUrl;

        public Uri ProjectUrl => _data.ProjectUrl;

        public Uri ReportAbuseUrl => _data.ReportAbuseUrl;

        public DateTimeOffset? Published => _data.Published;

        public string Owners => _data.Owners;

        public bool RequireLicenseAcceptance => _data.RequireLicenseAcceptance;

        public string Summary => _data.Summary;

        public string Tags => _data.Tags;

        public string Title => _data.Title;

        public bool IsListed => _data.IsListed;

        public bool PrefixReserved => _data.PrefixReserved;

        public LicenseMetadata LicenseMetadata => _data.LicenseMetadata;

        public NuGetServer GetServer() => _server;

        public async Task<IPackageDownload> DownloadAsync(NuGetVersion version, CancellationToken token = default(CancellationToken))
        {
            var result = await PackageDownloader.GetDownloadResourceResultAsync(_server.Source, new PackageIdentity(Identity.Id, version), new PackageDownloadContext(new SourceCacheContext()), _server.TempDownloadLocation, _server.Logger, token).ConfigureAwait(false);

            if (result.Status != DownloadResourceResultStatus.Available)
            {
                throw new Exception("Failed to download");
            }

            return new PackageCoreReaderProxy(result.PackageReader, this, version);
        }

        public async Task<IPackageDownload> DownloadLatestAsync(bool includePrerelease = false, CancellationToken token = default(CancellationToken))
        {
            var version = await (includePrerelease ? this.GetAbsoluteLatestVersion().ConfigureAwait(false) : this.GetLatestVersion().ConfigureAwait(false));

            return await DownloadAsync(version, token).ConfigureAwait(false);
        }
    }
}