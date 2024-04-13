using System.Windows;

namespace RevitAssemblyLoader.UI.Theme;
public class MainTheme : ResourceDictionary
{
    public MainTheme()
    {
        Application.LoadComponent(this, new Uri($"/RevitAssemblyLoader.UI;component/Theme/Theme.xaml", UriKind.Relative));
        //MergedDictionaries.Add(new MaterialDesignThemes.Wpf.BundledTheme()
        //{
        //    BaseTheme = MaterialDesignThemes.Wpf.BaseTheme.Light,
        //    PrimaryColor = MaterialDesignColors.PrimaryColor.LightBlue,
        //    SecondaryColor = MaterialDesignColors.SecondaryColor.Amber
        //});
        //TODO Cut materialDesign and put to referenced project for release mode
        //MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml", UriKind.Absolute) });
        //#if TEST || DESIGN
        //MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri($"/RevitAssemblyLoader.UI;component/Theme/Theme.xaml", UriKind.Relative) });
        //#else
        //        MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri($"/RevitAssemblyLoader;component/RevitAssemblyLoader.UI/Theme/Theme.xaml", UriKind.Relative) });
        //#endif
    }
}
