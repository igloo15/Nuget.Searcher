using System;
using System.Collections.Generic;
using System.Text;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Settings for copying files from download to final resting place
    /// </summary>
    public class NuGetCopySettings
    {
        /// <summary>
        /// Filters which files are copied
        /// </summary>
        public Func<string, bool> Filter { get; set; } = _ => true;

        /// <summary>
        /// Alters the path being created
        /// </summary>
        public Func<string, string> PathAlter { get; set; } = _ => _;

        /// <summary>
        /// Provides a list of folders that are empty and if true is returned it will delete if a parent folder is marked for deletion but not a sub folder the parent folder will not be deleted
        /// </summary>
        public Func<string, bool> RemoveEmptyFilter { get; set; } = _ => true;
    }
}