using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace igloo15.NuGetSearcher
{
    internal static class Extensions
    {
        public static void CleanDirectory(this string path, Func<string, bool> filter = null)
        {
            if (!Directory.Exists(path))
                return;

            foreach (var dir in Directory.GetDirectories(path))
            {
                dir.CleanDirectory(filter);
                if (filter != null && filter(dir))
                {
                    if (!Directory.EnumerateFileSystemEntries(dir).Any())
                    {
                        Directory.Delete(dir, false);
                    }
                }
            }
        }

        private static readonly TaskFactory _taskFactory = new
        TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}