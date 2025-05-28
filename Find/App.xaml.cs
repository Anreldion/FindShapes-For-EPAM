using System;
using System.Windows;
using Find.Services;
using Find.Services.Interfaces;
using Find.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ShapeLib.Calculators;
using ShapeLib.Generators;
using ShapeLib.Parsers;

namespace Find
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<FindViewModel>()
            };
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<FindViewModel>();
            services.AddTransient<AboutViewModel>();

            // Windows
            //services.AddSingleton<MainWindow>();
            //services.AddTransient<MainWindow>();

            // Services
            services.AddSingleton<IWindowService, WindowService>();

            services.AddSingleton<IShapeCalculator, ShapeCalculator>();
            services.AddSingleton<IShapeParser, ShapeParser>();
            services.AddSingleton<IShapeTextGenerator, ShapeTextGenerator>();

            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFolderService, FolderService>();
        }
    }
}
