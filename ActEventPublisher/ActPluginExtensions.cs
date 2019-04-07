using ActEventPublisher.Domain.Entities;
using Advanced_Combat_Tracker;
using System.Linq;

namespace ActEventPublisher
{
    public static class ActPluginExtensions
    {
        public static string FindCurrentPluginDirectory(this IActPluginV1 currentPlugin)
        {
            var plugin = ActGlobals.oFormActMain.ActPlugins.First(p => p.pluginObj == currentPlugin);
            if (plugin == null)
                return string.Empty;

            return plugin.pluginFile.DirectoryName;
        }

        public static string ConfigFullPath(string fileName)
        {
            return $@"{ActGlobals.oFormActMain.AppDataFolder.FullName}\Config\{fileName}";
        }

        public static void AddLogLineEventHandler(LogLineEventDelegate handler)
        {
            ActGlobals.oFormActMain.OnLogLineRead += handler;
        }

        public static void RemoveLogLineEventHandler(LogLineEventDelegate handler)
        {
            ActGlobals.oFormActMain.OnLogLineRead -= handler;
        }

        public static LogLine ToLogLine(this LogLineEventArgs e)
        {
            var logLine = new LogLine()
            {
                DetectedTime = e.detectedTime,
                DetectedZone = e.detectedZone,
                Content = e.logLine,
                InCombat = e.inCombat,
                DetectedType = e.detectedType,
            };

            return logLine;
        }
    }
}
