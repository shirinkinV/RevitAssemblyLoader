using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAssemblyLoader.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ListOfPlugins
    {
        [JsonProperty]
        public List<PluginExternalCommand> Plugins { get; set; }
    }
}
