using Igloo15.NuGetSearcher;
using System;
using System.Linq;

namespace NuGetSearcher.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Test");


            var results = NuGetSearcherUtility.NuGetStandardFeedV2.Search("test").Where(p => p.Tags.Split(' ').Contains("Microsoft"));


            foreach(var result in results)
            {
                Console.WriteLine($"Package : {result.Identity.Id}, Total Downloads : {result.DownloadCount}");
            }


            Console.WriteLine();

            Console.WriteLine("Hit Enter to Close");

            Console.ReadLine();
        }
    }
}
