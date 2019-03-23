using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.ViewModels;
using System.Windows.Controls;

namespace Lab04Tyshchenko.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(Storage storage)
        {
            InitializeComponent();

            MainViewModel viewModel = new MainViewModel(storage);
            DataContext = viewModel;
        }
    }
}
