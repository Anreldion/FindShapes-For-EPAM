using System;
using System.Windows;
using System.Windows.Threading;
using Find.Services;
using Find.Services.Interfaces;
using Find.Services.Models;
using Find.Services.Models.Validators;
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

            DispatcherUnhandledException += OnDispatcherUnhandledException;

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
            };
            mainWindow.Show();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var dialogService = ServiceProvider.GetService<IDialogService>();

                dialogService?.ShowError(
                    $"An unexpected error has occurred:\n{e.Exception.Message}",
                    "Critical error");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"A critical application error. Contact the developer. Error info: {exception.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<AboutViewModel>();

            services.AddSingleton<IWindowService, WindowService>();
            services.AddSingleton<IDialogService, DialogService>();

            services.AddSingleton<IShapeCalculator, ShapeCalculator>();
            services.AddSingleton<IShapeParser, ShapeParser>();
            services.AddSingleton<IShapeTextGenerator, ShapeTextGenerator>();

            services.AddTransient<IFileDialogService, FileDialogService>();
            services.AddTransient<IValidator<FileDialogOptions>, FileDialogOptionsValidator>();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFolderService, FolderService>();
            services.AddSingleton<IAppCloser, AppCloser>();
        }
    }
}
