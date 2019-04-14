using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NuGetCommon = NuGet.Common;

namespace igloo15.NuGetSearcher
{
    /// <summary>
    /// Microsoft.Extensions.Logging adaptor to NuGet Logging
    /// </summary>
    public class NuGetLogger : NuGetCommon.ILogger
    {
        private ILogger _logger;

        /// <summary>
        /// Contructor of NuGetLogger with Microsoft Extensions Logging ILogger
        /// </summary>
        /// <param name="logger"></param>
        public NuGetLogger(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="data"></param>
        public void LogDebug(string data)
        {
            _logger?.LogDebug(data);
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="data"></param>
        public void LogVerbose(string data)
        {
            _logger?.LogDebug(data);
        }

        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="data"></param>
        public void LogInformation(string data)
        {
            _logger?.LogInformation(data);
        }

        /// <summary>
        /// Log Minimal
        /// </summary>
        /// <param name="data"></param>
        public void LogMinimal(string data)
        {
            _logger?.LogTrace(data);
        }

        /// <summary>
        /// Log Warning
        /// </summary>
        /// <param name="data"></param>
        public void LogWarning(string data)
        {
            _logger?.LogWarning(data);
        }

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="data"></param>
        public void LogError(string data)
        {
            _logger?.LogError(data);
        }

        /// <summary>
        /// Log Informational
        /// </summary>
        /// <param name="data"></param>
        public void LogInformationSummary(string data)
        {
            _logger?.LogInformation(data);
        }

        /// <summary>
        /// Genric log at level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="data"></param>
        public void Log(NuGetCommon.LogLevel level, string data)
        {
            switch(level)
            {
                case NuGetCommon.LogLevel.Debug:
                    LogDebug(data);
                    break;
                case NuGetCommon.LogLevel.Verbose:
                    LogVerbose(data);
                    break;
                case NuGetCommon.LogLevel.Information:
                    LogInformation(data);
                    break;
                case NuGetCommon.LogLevel.Warning:
                    LogWarning(data);
                    break;
                case NuGetCommon.LogLevel.Error:
                    LogError(data);
                    break;
                default:
                    LogMinimal(data);
                    break;
            }
        }

        /// <summary>
        /// Generic Log at Level Async
        /// </summary>
        /// <param name="level"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task LogAsync(NuGetCommon.LogLevel level, string data)
        {
            return Task.Run(() => Log(level, data));
        }

        /// <summary>
        /// Generic Logging of ILogMessage
        /// </summary>
        /// <param name="message"></param>
        public void Log(NuGetCommon.ILogMessage message)
        {
            Log(message.Level, message.Message);
        }

        /// <summary>
        /// Generic Logging of ILogMessage Async
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task LogAsync(NuGetCommon.ILogMessage message)
        {
            return Task.Run(() => Log(message));
        }
    }
}
