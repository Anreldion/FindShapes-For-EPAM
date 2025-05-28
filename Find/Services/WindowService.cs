using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Find.Services.Interfaces;
using Find.ViewModels;
using Find.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Find.Services
{
    public class WindowService : IWindowService
    {
        private readonly IServiceProvider _provider;
        public WindowService(IServiceProvider provider)
        {
            _provider = provider;
        }

        private static readonly Dictionary<Type, Type> _viewMappings = new Dictionary<Type, Type>
        {
            { typeof(AboutViewModel), typeof(About) }
        };

        public void ShowDialog<TViewModel>() where TViewModel : class
        {
            var vm = _provider.GetRequiredService<TViewModel>();

            if (!_viewMappings.TryGetValue(typeof(TViewModel), out var windowType))
                throw new InvalidOperationException($"No mapping for {typeof(TViewModel)}");

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;

            window.Owner = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);

            if (vm is IClosable closable)
            {
                closable.RequestClose += () => window.Close();
            }

            window.ShowDialog();
        }

    }
}
