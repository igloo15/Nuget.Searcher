using System.IO;
using System.Threading;
using igloo15.NuGetSearcher;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NuGet.Configuration;

namespace NuGetSearcher.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Test");

            var factory = new LoggerFactory().AddConsole();
            var results = NuGetSearcherUtility.NuGetStandardFeedV2.LoadLogger(factory).SetTemp("./testcache").Search("test", true).Where(p => p.GetTags().Contains("Microsoft"));
            var folders = NuGetSearcherUtility.NuGetPaths.FallbackPackageFolders.ToList();

            foreach (var folder in folders)
                Console.WriteLine(folder);

            foreach (var result in results)
            {
                Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
                var package = result.DownloadLatest();
                Console.WriteLine(package.GetIdentity().Version.ToFullString());
                var settings = new NuGetCopySettings()
                {
                    Filter = f =>
                    {
                        var dirName = Path.GetDirectoryName(f);
                        var filterResult = dirName == "lib\\net45";
                        return filterResult;
                    },
                    PathAlter = t => Path.GetFileName(t)
                };

                package.CopyFiles("../../test/bill", settings);
                package.CopyFiles("../test/otter", settings);
            }

            Console.WriteLine();

            Console.WriteLine("Hit Enter to Close");

            factory.Dispose();

            Console.ReadLine();
        }
    }
}