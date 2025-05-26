using System.Windows;
using Find.ViewModels;

namespace Find
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FindViewModel();
        }
    }
}