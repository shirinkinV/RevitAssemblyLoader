using RevitAssemblyLoader.UI.VM;
using System.Windows;
using System.Windows.Controls;

namespace RevitAssemblyLoader.UI.Theme;
public class MainTemplateSelector:DataTemplateSelector
{
    public DataTemplate PluginsDataTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        return item switch
        {
            PluginsVM => PluginsDataTemplate!,
            _ => null!
        };
    }
}
