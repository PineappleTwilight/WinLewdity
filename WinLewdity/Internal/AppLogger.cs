using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHtmlViewer.Internal
{
    public static class AppLogger
    {
        private static Logger logsink { get; set; }

        public static void InitializeLogger()
        {
            if (!Globals.DebugMode)
            {
                logsink = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("./logs/log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            }
            else
            {
                logsink = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("./logs/log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            }
        }

        public static void LogDebug(string message, string title = null)
        {
            if (title == null)
            {
                logsink.Debug(message);
            }
            else
            {
                logsink.Debug($"[{title}] {message}");
            }
        }

        public static void LogInfo(string message, string title = null)
        {
            if (title == null)
            {
                logsink.Information(message);
            }
            else
            {
                logsink.Information($"[{title}] {message}");
            }
        }

        public static void LogWarning(string message, string title = null)
        {
            if (title == null)
            {
                logsink.Warning(message);
            }
            else
            {
                logsink.Warning($"[{title}] {message}");
            }
        }

        public static void LogError(string message, string title = null)
        {
            if (title == null)
            {
                logsink.Error(message);
            }
            else
            {
                logsink.Error($"[{title}] {message}");
            }
        }
    }
}