using Microsoft.Extensions.DependencyInjection;
using RevitAssemblyLoader.Abstractions;
using RevitAssemblyLoader.Abstractions.VM.Fragments;
using RevitAssemblyLoader.Model;
using RevitAssemblyLoader.UI;
using RevitAssemblyLoader.UI.VM;
using System.Windows;

namespace RevitAssemblyLoader.DI;

public class Services
{
    readonly ServiceProvider services;

    private static Services instance;
    public static Services Instance => instance ??= new Services();

    public static void InitManualy()
    {
        instance?.ServiceProvider.Dispose();
        instance = new Services();
    }

    public static void KillServices()
    {
        instance?.services.Dispose();
        instance = null;
    }

    Services()
    {
        var serviceCollection = new ServiceCollection();

        //Logger
        serviceCollection.AddSingleton<Ilogger, Logger>((s) => new Logger());

        //handlers
        serviceCollection.AddSingleton<IThreadsHandler, ThreadsHandler>(); 
            
        //VMs
        serviceCollection.AddSingleton<IPluginsVM, PluginsVM>();
        serviceCollection.AddSingleton<IPluginPreferencesVM, PluginPreferencesVM>();
        serviceCollection.AddSingleton<IContainerVM, MainVM>();

        //create vindow in ui thread
        serviceCollection.AddSingleton<Window, MainWindow>((s) =>
        {
            var threadsHandler = s.GetRequiredService<IThreadsHandler>();
            var uiDispatcher = threadsHandler.UIDispatcher;
            while (uiDispatcher is null)
            {
                uiDispatcher = threadsHandler.UIDispatcher;
                Thread.Sleep(100);//костылик
            }
            MainWindow window = null;
            uiDispatcher.Invoke(() =>
            {
                window = new MainWindow(s.GetRequiredService<IContainerVM>());
            });
            return window;
        });

        services = serviceCollection.BuildServiceProvider();

        //bind fragments to list in container

        services.GetRequiredService<IContainerVM>().PosibleFragments.AddRange(
        [
            services.GetRequiredService<IPluginsVM>(),
            services.GetRequiredService<IPluginPreferencesVM>()
        ]);
    }

    public ServiceProvider ServiceProvider => services;
}
