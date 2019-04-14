using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Extensions for searching for more things on the nuget server
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Search the server for all Tags. Only OR Search is possible NuGet Api
        /// </summary>
        /// <param name="server">The server being extended</param>
        /// <param name="TagNames">The tags to search on</param>
        /// <returns>Search Results</returns>
        public static Task<IEnumerable<IPackageSourceMetadata>> SearchContainsAllTags(this NuGetServer server, params string[] TagNames)
        {
            var tagQuery = NuGetSearcherUtility.GetTagQuery(TagNames);

            return server.SearchAsync(tagQuery);
        }

        /// <summary>
        /// Search by the id
        /// </summary>
        /// <param name="server">Server to search</param>
        /// <param name="id">The id to search</param>
        /// <returns>Task of the results</returns>
        public static Task<IEnumerable<IPackageSourceMetadata>> SearchById(this NuGetServer server, string id)
        {
            return server.SearchAsync($"id:{id}");
        }

    }
}
