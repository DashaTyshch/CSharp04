using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.ViewModels;
using System.Windows.Controls;

namespace Lab04Tyshchenko.Views
{
    /// <summary>
    /// Логика взаимодействия для AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        public AddUserView(Storage storage)
        {
            InitializeComponent();

            AddUserViewModel viewModel = new AddUserViewModel(storage);
            DataContext = viewModel;
        }
    }
}
