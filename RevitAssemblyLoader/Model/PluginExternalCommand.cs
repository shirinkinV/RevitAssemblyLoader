using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAssemblyLoader.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PluginExternalCommand
    {
        [JsonProperty]
        public PluginAssembly PluginAssembly { get; set; }

        [JsonProperty]
        public string CommandClassName { get; set; }
    }
}
