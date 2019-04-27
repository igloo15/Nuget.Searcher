using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

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
        /// Copy the entire contents of the package to destination folder
        /// </summary>
        /// <param name="dest">The destination folder</param>
        /// <param name="token">The optional cancellation token</param>
        IEnumerable<string> CopyFiles(string dest, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Copy files from package to a new destination
        /// </summary>
        /// <param name="dest">The destination to copy files too</param>
        /// <param name="filter">Optional function to filter what packages go to destination and which don't</param>
        /// <param name="token">Optional cancellation token</param>
        IEnumerable<string> CopyFiles(string dest, Func<string, bool> filter, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Copy the files from the package to a new destination with the given settings
        /// </summary>
        /// <param name="dest">The new destination</param>
        /// <param name="settings">The settings</param>
        /// <param name="token">The optional cancellation token</param>
        IEnumerable<string> CopyFiles(string dest, NuGetCopySettings settings, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Copy the files from the package to a new destination with the given settings
        /// </summary>
        /// <param name="dest">The new destination</param>
        /// <param name="nugetFolder">The folder in the nuget package to copy to destination</param>
        /// <param name="token">The optional cancellation token</param>
        IEnumerable<string> CopyFiles(string dest, string nugetFolder, CancellationToken token = default(CancellationToken));
    }

    internal class PackageCoreReaderProxy : IPackageDownload, IPackageCoreReader
    {
        private IPackageCoreReader _reader;
        private PackageSearchSourceProxy _metadata;
        private NuGetVersion _version;

        public PackageCoreReaderProxy(IPackageCoreReader reader, PackageSearchSourceProxy metadata, NuGetVersion version)
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

        public IEnumerable<string> CopyFiles(string dest, CancellationToken token = default(CancellationToken))
        {
            return CopyFiles(dest, new NuGetCopySettings(), token);
        }

        public IEnumerable<string> CopyFiles(string dest, Func<string, bool> filter, CancellationToken token = default(CancellationToken))
        {
            return CopyFiles(dest, new NuGetCopySettings() { Filter = filter }, token);
        }

        public IEnumerable<string> CopyFiles(string dest, NuGetCopySettings settings, CancellationToken token = default(CancellationToken))
        {
            var files = GetFiles().Where(settings.Filter);

            var resultFiles = CopyFiles(dest, files, (source, target, readStream) => ExtractFile(source, target, dest, readStream, settings), _metadata.GetServer().Logger, token);

            dest.CleanDirectory(settings.RemoveEmptyFilter);

            return resultFiles;
        }

        public IEnumerable<string> CopyFiles(string dest, string nugetFolder, CancellationToken token = default(CancellationToken))
        {
            return CopyFiles(dest, new NuGetCopySettings()
            {
                Filter = (f) => f.StartsWith(nugetFolder),
                PathAlter = (f) => f.Replace(nugetFolder, "")
            }, token);
        }

        private string ExtractFile(string source, string target, string dest, Stream readStream, NuGetCopySettings settings)
        {
            target = Path.Combine(dest, settings.PathAlter(target.Replace(dest, "")));

            if (Path.IsPathRooted(source))
            {
                File.Copy(source, target, true);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(target));
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

        #endregion IDisposable Support
    }
}