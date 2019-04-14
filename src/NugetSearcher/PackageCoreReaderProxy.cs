

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Versioning;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// A package downloaded
    /// </summary>
    public interface IPackageDownload
    {
        /// <summary>
        /// The metadata that this was downloaded from
        /// </summary>
        /// <returns>The metadata</returns>
        IPackageSourceMetadata GetMetadata();

        /// <summary>
        /// Get the version of this package downloaded
        /// </summary>
        /// <returns>The version</returns>
        NuGetVersion GetVersion();

        /// <summary>
        /// Get all files from package
        /// </summary>
        /// <returns>The files in package</returns>
        IEnumerable<string> GetFiles();

        /// <summary>
        /// Copy files from package to a new destination
        /// </summary>
        /// <param name="dest">The destination to copy files too</param>
        /// <param name="filter">Optional function to filter what packages go to destination and which don't</param>
        /// <param name="token">Optional cancellation token</param>
        void CopyFiles(string dest, Func<string, bool> filter = null, CancellationToken token = default(CancellationToken));
    }

    internal class PackageCoreReaderProxy : IPackageDownload, IPackageCoreReader
    {
        private IPackageCoreReader _reader;
        private IPackageSourceMetadata _metadata;
        private NuGetVersion _version;

        public PackageCoreReaderProxy(IPackageCoreReader reader, IPackageSourceMetadata metadata, NuGetVersion version)
        {
            _reader = reader;
            _metadata = metadata;
            _version = version;
        }

        public IPackageSourceMetadata GetMetadata() => _metadata;

        public NuGetVersion GetVersion() => _version;

        public IEnumerable<string> CopyFiles(string destination, IEnumerable<string> packageFiles, ExtractPackageFileDelegate extractFile, ILogger logger, CancellationToken token) => _reader.CopyFiles(destination, packageFiles, extractFile, logger, token);

        public IEnumerable<string> GetFiles() => _reader.GetFiles();

        public IEnumerable<string> GetFiles(string folder) => _reader.GetFiles(folder);

        public PackageIdentity GetIdentity() => _reader.GetIdentity();

        public NuGetVersion GetMinClientVersion() => _reader.GetMinClientVersion();

        public Stream GetNuspec() => _reader.GetNuspec();

        public string GetNuspecFile() => _reader.GetNuspecFile();

        public IReadOnlyList<PackageType> GetPackageTypes() => _reader.GetPackageTypes();

        public Stream GetStream(string path) => _reader.GetStream(path);

        public void CopyFiles(string dest, Func<string, bool> filter = null, CancellationToken token = default(CancellationToken))
        {
            var files = filter != null ? GetFiles().Where(filter) : GetFiles();
            CopyFiles(dest, files, ExtractFile, _metadata.GetServer().Logger, token);
        }

        private string ExtractFile(string source, string target, Stream readStream)
        {
            if (Path.IsPathRooted(source))
            {
                File.Copy(source, target, true);
            }
            else
            {
                using (var fileStream = new FileStream(target, FileMode.OpenOrCreate))
                {
                    readStream.CopyTo(fileStream);
                }
            }
            return target;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PackageCoreReaderProxy()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}