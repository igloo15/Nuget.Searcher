﻿using System;
using Microsoft.Extensions.Logging;
using NC = NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NuGet.Configuration;
using System.IO;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// The base server class which you can search against
    /// </summary>
    public class NuGetServer
    {
        /// <summary>
        /// The location of the feed for this server
        /// </summary>
        public string FeedLocation { get; private set; }

        /// <summary>
        /// Overrides the method input if given
        /// </summary>
        public bool? IncludePrelease { get; set; }

        /// <summary>
        /// Overrides the method input if given
        /// </summary>
        public int? SkipAmount { get; set; }

        /// <summary>
        /// Overrides the method input if given
        /// </summary>
        public int? TakeAmount { get; set; }

        /// <summary>
        /// The NuGet Logger for this server
        /// </summary>
        public NC.ILogger Logger { get; set; }

        /// <summary>
        /// The location where packages are temporarily downloaded too
        /// </summary>
        public string TempDownloadLocation { get; set; }

        internal SourceRepository Source { get; set; }

        internal ISettings NuGetSettings { get; set; }

        /// <summary>
        /// The base constructor for a feed
        /// </summary>
        /// <param name="feedLocation">The feed location</param>
        /// <param name="factory">Add a loggerfactory for logging stuff</param>
        internal NuGetServer(string feedLocation, ILoggerFactory factory = null)
        {
            FeedLocation = feedLocation;

            Source = Repository.Factory.GetCoreV3(feedLocation);

            Logger = new NuGetLogger(factory?.CreateLogger<NuGetLogger>());

            NuGetSettings = Settings.LoadDefaultSettings(Directory.GetCurrentDirectory());
            TempDownloadLocation = NuGetPathContext.Create(NuGetSettings).UserPackageFolder;
        }

        /// <summary>
        /// Load a LoggerFactory for the server
        /// </summary>
        /// <param name="factory">The loggerfactory server</param>
        /// <returns>This NuGetServer</returns>
        public NuGetServer LoadLogger(ILoggerFactory factory)
        {
            Logger = new NuGetLogger(factory?.CreateLogger<NuGetLogger>());
            return this;
        }

        /// <summary>
        /// Set the temporary location to download packages and extract
        /// </summary>
        /// <param name="path">The location if it doesn't exist it will be created</param>
        /// <returns>The NuGetServer</returns>
        public NuGetServer SetTemp(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            TempDownloadLocation = path;
            return this;
        }

        /// <summary>
        /// Search using search term asyncly
        /// </summary>
        /// <param name="searchTerm">Your search term</param>
        /// <param name="includePrerelease">Optional prerelease flag</param>
        /// <param name="cancelToken">Optional cancellation token</param>
        /// <param name="skip">Optional amount of results to skip</param>
        /// <param name="take">Optional amount of results to take</param>
        /// <returns>The task with your results</returns>
        public async Task<IEnumerable<IPackageSourceMetadata>> SearchAsync(string searchTerm, bool includePrerelease = false, CancellationToken cancelToken = default(CancellationToken), int skip = 0, int take = 100)
        {
            if (IncludePrelease.HasValue)
                includePrerelease = IncludePrelease.Value;

            if (SkipAmount.HasValue)
                skip = SkipAmount.Value;

            if (TakeAmount.HasValue)
                take = TakeAmount.Value;

            var resource = Source.GetResource<PackageSearchResource>();

            if (resource == null)
            {
                Logger.LogError("Failed to acquire search resource for server");
                return Enumerable.Empty<IPackageSourceMetadata>();
            }

            var results = await resource.SearchAsync(searchTerm, new SearchFilter(includePrerelease), skip, take, Logger, cancelToken).ConfigureAwait(false);

            return results.Select(p => p.ConvertToProxy(this));
        }

        /// <summary>
        /// Get all packages in a specific feed. Be care with setting you take too high
        /// </summary>
        /// <param name="includePrerelease">Include prerelease packages</param>
        /// <param name="cancelToken">A Cancellation token</param>
        /// <param name="skip">The amount of packages to skip</param>
        /// <param name="take">The amount of packages to take</param>
        /// <returns>The task containing all the IPackageSearchMetadata</returns>
        public async Task<IEnumerable<IPackageSourceMetadata>> GetAllPackagesAsync(bool includePrerelease = false, CancellationToken cancelToken = default(CancellationToken), int skip = 0, int take = 100)
        {
            return await SearchAsync("", includePrerelease, cancelToken, skip, take).ConfigureAwait(false);
        }
    }
}