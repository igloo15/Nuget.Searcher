using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igloo15.NuGetSearcher
{
    public static class Extensions
    {
        /// <summary>
        /// Search the server for all Tags. Only OR Search is possible NuGet Api
        /// </summary>
        /// <param name="server">The server being extended</param>
        /// <param name="TagNames">The tags to search on</param>
        /// <returns>Search Results</returns>
        public static Task<IEnumerable<IPackageSearchMetadata>> SearchContainsAllTags(this NuGetServer server, params string[] TagNames)
        {
            var tagQuery = NuGetSearcherUtility.GetTagQuery(TagNames);

            return server.SearchAsync(tagQuery);
        }

        public static Task<IEnumerable<IPackageSearchMetadata>> SearchById(this NuGetServer server, string id)
        {
            return server.SearchAsync($"id:{id}");
        }

    }
}
