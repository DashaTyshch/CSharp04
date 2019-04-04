using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.ViewModels;
using System.Windows.Controls;

namespace Lab04Tyshchenko.Views
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUserView : UserControl
    {
        public EditUserView(Storage storage)
        {
            InitializeComponent();

            EditUserViewModel viewModel = new EditUserViewModel(storage);
            DataContext = viewModel;
        }
    }
}
