using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevitAssemblyLoader.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PluginAssembly
    {
        [JsonIgnore]
        public AssemblyName AssemblyName { get; set; }

        [JsonProperty]
        public string Location { get; set; }

        [JsonProperty]
        public List<PluginAssembly> Dependencies { get; set; }


    }
}
