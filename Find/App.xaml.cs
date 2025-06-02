using System;
using System.Windows;
using Find.Services;
using Find.Services.Interfaces;
using Find.Services.Models;
using Find.ViewModels;
using FluentValidation;
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
                DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
            };
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<AboutViewModel>();

            // Services
            services.AddSingleton<IWindowService, WindowService>();

            services.AddSingleton<IShapeCalculator, ShapeCalculator>();
            services.AddSingleton<IShapeParser, ShapeParser>();
            services.AddSingleton<IShapeTextGenerator, ShapeTextGenerator>();

            services.AddTransient<IFileDialogService, FileDialogService>();
            services.AddTransient<IValidator<FileDialogOptions>, FileDialogOptionsValidator>();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFolderService, FolderService>();
        }
    }
}
