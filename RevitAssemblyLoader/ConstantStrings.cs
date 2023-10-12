using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAssemblyLoader
{
    internal static class ConstantStrings
    {
        public static readonly string InternalFilesFolder =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ShirinkinV",
                "RevitAssemblyLoader"
            );

        public static readonly string SettingsFile = Path.Combine(InternalFilesFolder, "Settings.json");

        public static readonly string PluginsListFile = Path.Combine(InternalFilesFolder, "plugins.json");

        public static readonly string PluginsCasheFolder = Path.Combine(InternalFilesFolder, "Plugins");
    }
}
