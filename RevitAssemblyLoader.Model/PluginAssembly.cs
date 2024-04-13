using System.Reflection;

namespace RevitAssemblyLoader.Model
{
    public class PluginAssembly
    {
        /// <summary>
        /// The name of an assembly
        /// </summary>
        public AssemblyName AssemblyName { get; set; }

        /// <summary>
        /// Where the assembly is located in file system (we're using only LoadFile context)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The set of another assemblies being used as dependency for this assembly
        /// </summary>
        public List<PluginAssembly> Dependencies { get; set; }


    }
}
