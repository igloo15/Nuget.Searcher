using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Igloo15.NuGetSearcher
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
        public ILogger Logger { get; set; } = new NuGetLogger(null);

        private SourceRepository _source;

        /// <summary>
        /// The base constructor for a feed
        /// </summary>
        /// <param name="feedLocation">The feed location</param>
        /// <param name="feedType">The type of feed</param>
        public NuGetServer(string feedLocation, FeedType feedType)
        {
            FeedLocation = feedLocation;

            _source = Repository.Factory.GetCoreV3(feedLocation, feedType);
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
        public async Task<IEnumerable<IPackageSearchMetadata>> SearchAsync(string searchTerm, bool includePrerelease = false, CancellationToken cancelToken = default(CancellationToken), int skip = 0, int take = 100)
        {
            if (IncludePrelease.HasValue)
                includePrerelease = IncludePrelease.Value;

            if (SkipAmount.HasValue)
                skip = SkipAmount.Value;

            if (TakeAmount.HasValue)
                take = TakeAmount.Value;
            
            return await _source.GetResource<PackageSearchResource>().SearchAsync(searchTerm, new SearchFilter(includePrerelease), skip, take, Logger, cancelToken);
        }

        /// <summary>
        /// The search term used to search the server synchronously
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="includePrerelease">Optional prerelease flag</param>
        /// <param name="cancelToken">Optional cancellation token</param>
        /// <param name="skip">Optional amount of results to skip</param>
        /// <param name="take">Optional amount of results to take</param>
        /// <returns>The results of search</returns>
        public IEnumerable<IPackageSearchMetadata> Search(string searchTerm, bool includePrerelease = false, CancellationToken cancelToken = default(CancellationToken), int skip = 0, int take = 100)
        {
            return SearchAsync(searchTerm, includePrerelease, cancelToken).Result;
        }

    }
}
