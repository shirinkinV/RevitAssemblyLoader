namespace RevitAssemblyLoader.Model
{
    public class PluginExternalCommand
    {
        /// <summary>
        /// The main plugin assembly containing entry point to start any action
        /// (show plugin UI or start background operation). IExternalCommand
        /// implementation class is most commonly used.
        /// </summary>
        public PluginAssembly PluginAssembly { get; set; }

        /// <summary>
        /// The full class name in PluginAssembly that implements IExternalCommand
        /// </summary>
        public string CommandClassName { get; set; }
    }
}
