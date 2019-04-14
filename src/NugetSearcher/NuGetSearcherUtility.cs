﻿using NuGet.Packaging;
using System;
using System.Collections.Generic;
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
        public static NuGetServer NuGetStandardFeedV2 => new NuGetServer("https://www.nuget.org/api/v2");

        /// <summary>
        /// The standard nuget.org feed V3 api
        /// </summary>
        public static NuGetServer NuGetStandardFeedV3 => new NuGetServer("https://api.nuget.org/v3/index.json");

        /// <summary>
        /// Convert your tags into a NuGet Search Query. NuGet only Supports OR searching not AND
        /// </summary>
        /// <param name="TagNames">The tags you are searching on</param>
        /// <returns>A query string for the tags</returns>
        public static string GetTagQuery(params string[] TagNames)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var tag in TagNames)
            {
                sb.Append($"tags: {tag} ");
            }

            return sb.ToString();
        }
    }
}
