using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RevitAssemblyLoader.UI.VM
{
    internal class PluginListVM : ObservableObject
    {
        ObservableCollection<PluginVM> _pluginList;

        public ObservableCollection<PluginVM> PluginList
        {
            get => _pluginList;
            set => SetProperty(ref _pluginList, value);
        }

        public PluginListVM()
        {
            PluginList = new ObservableCollection<PluginVM>();
        }
    }
}
