using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igloo15.NuGetSearcher
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

        public Task<IEnumerable<VersionInfo>> GetVersionsAsync() => _data.GetVersionsAsync();

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
    }
}
