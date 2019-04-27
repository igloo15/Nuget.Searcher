using Microsoft.Extensions.Logging;
using NuGet.Configuration;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Utility functions for NuGetSearch
    /// </summary>
    public static class NuGetSearcherUtility
    {
        /// <summary>
        /// The standard nuget.org feed V2 api
        /// </summary>
        public static NuGetServer NuGetStandardFeedV2 => new NuGetServer(NuGetConstants.V2FeedUrl);

        /// <summary>
        /// The standard nuget.org feed V3 api
        /// </summary>
        public static NuGetServer NuGetStandardFeedV3 => new NuGetServer(NuGetConstants.V3FeedUrl);

        /// <summary>
        /// The local global packages feed
        /// </summary>
        public static NuGetServer GlobalPackagesFeed => new NuGetServer(NuGetPaths.UserPackageFolder);

        /// <summary>
        /// Zero or More NuGet Fallback Feeds these are global feeds similar to the GAC from the past
        /// </summary>
        public static IEnumerable<NuGetServer> FallbackFeeds => NuGetPaths.FallbackPackageFolders.Select(f => new NuGetServer(f));

        /// <summary>
        /// The global machine settings in relation to current working directory
        /// </summary>
        public static ISettings NuGetSettings => Settings.LoadDefaultSettings(Directory.GetCurrentDirectory());

        /// <summary>
        /// The Global NuGetPaths based on settings loaded from current working directory
        /// </summary>
        public static NuGetPathContext NuGetPaths => NuGetPathContext.Create(NuGetSettings);

        /// <summary>
        /// Create a server with a custom location
        /// </summary>
        /// <param name="location">The location of the feed</param>
        /// <param name="factory">The logger factory to show logs</param>
        /// <returns>The created NuGetServer</returns>
        public static NuGetServer CreateServer(string location, ILoggerFactory factory = null) => new NuGetServer(location, factory);

        /// <summary>
        /// Convert your tags into a NuGet Search Query. NuGet only Supports OR searching not AND
        /// </summary>
        /// <param name="TagNames">The tags you are searching on</param>
        /// <returns>A query string for the tags</returns>
        public static string GetTagQuery(params string[] TagNames)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var tag in TagNames)
            {
                sb.Append($"tags: {tag} ");
            }

            return sb.ToString();
        }
    }
}