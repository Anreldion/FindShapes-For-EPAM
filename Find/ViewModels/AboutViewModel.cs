using System;
using System.Windows.Input;
using Find.Services.Interfaces;

namespace Find.ViewModels
{
    public class AboutViewModel : ViewModel, IClosable
    {
        private string _copyright;
        private string _version;
        private string _company;
        private string _product;
        private string _authors;
        private string _description;

        public event Action RequestClose;

        public string Copyright
        {
            get => _copyright;
            set
            {
                _copyright = value;
                OnPropertyChanged();
            }
        }

        public string Version
        {
            get => _version;
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public string Product
        {
            get=> _product;
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get => _authors;
            set
            {
                _authors = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description= value;
                OnPropertyChanged();
            }
        }


        public ICommand AcceptCommand { get; }

        public AboutViewModel()
        {
            Version = AppInfo.Version;
            Company = AppInfo.Company;
            Product = AppInfo.Product;
            Copyright = AppInfo.Copyright;
            Version = AppInfo.Version;
            Description = AppInfo.Description;

            AcceptCommand = new RelayCommand(_ => RequestClose?.Invoke());
        }
    }
}
