using System.IO;
using System.Threading;
using igloo15.NuGetSearcher;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace NuGetSearcher.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Test");

            var factory = new LoggerFactory().AddConsole();
            var results = NuGetSearcherUtility.NuGetStandardFeedV2.LoadLogger(factory).Search("test").Where(p => p.GetTags().Contains("Microsoft"));


            foreach(var result in results)
            {
                Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
                var package = result.DownloadLatestAsync().Result;
                Console.WriteLine(package.GetIdentity().Version.ToFullString());
                Console.WriteLine(package.GetIdentity().Version.ToNormalizedString());
                Console.WriteLine(package.GetIdentity().Version.ToString());
                foreach(var file in package.GetFiles())
                {
                    Console.WriteLine(file);
                }
                package.CopyFiles("./test", f => f.StartsWith("lib/net45"));
            }


            Console.WriteLine();

            Console.WriteLine("Hit Enter to Close");

            factory.Dispose();

            Console.ReadLine();
        }
    }
}

