using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab04Tyshchenko.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Private fields

        private string _filterQuery;
        private string _selectedComboBoxItem;

        private ICommand _addCommand;
        private ICommand _deleteCommand;

        private User _selectedUser;
        private ObservableCollection<User> _userInfo;

        private MainModel Model { get; }

        #endregion

        public MainViewModel(Storage storage)
        {
            Model = new MainModel(storage);
            Model.UIUserAdded += UIOnUserAdded;
            Model.UIUserDeleted += UIOnUserDeleted;

            UserInfo = new ObservableCollection<User>(storage.Users);
        }

        public string FilterQuery
        {
            get { return _filterQuery; }
            set
            {
                _filterQuery = value.ToLower();
                InvokePropertyChanged(nameof(FilterQuery));

                FilterUsers();
            }
        }

        public void ComboBoxSelected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            MessageBox.Show(selectedItem.Content.ToString());
        }

        public string SelectedComboBoxItem
        {
            get { return _selectedComboBoxItem; }
            set
            {
                _selectedComboBoxItem = value;
                InvokePropertyChanged(nameof(SelectedComboBoxItem));

                FilterUsers();
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                InvokePropertyChanged(nameof(SelectedUser));
            }
        }

        public ObservableCollection<User> UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;
                InvokePropertyChanged(nameof(UserInfo));
            }
        }

        #region Commands
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<object>(AddExecute, AddCanExecute);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
                InvokePropertyChanged(nameof(AddCommand));
            }
        }

        private bool AddCanExecute(object obj)
        {
            return true;
        }

        private void AddExecute(object obj)
        {
            Model.GoToAddUser();
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<User>(DeleteExecute, DeleteCanExecute);
                }
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
                InvokePropertyChanged(nameof(DeleteCommand));
            }
        }

        private bool DeleteCanExecute(object obj)
        {
            return true;
        }

        private void DeleteExecute(User user)
        {
            Model.DeleteUser(user);
        }
        #endregion

        private void FilterUsers()
        {
            IEnumerable<User> users = Model.GetAllUsers();

            if (!string.IsNullOrEmpty(FilterQuery))
            {
                users = users.Where(x => x.Name.ToLower().Contains(FilterQuery)
                                                || x.Surname.ToLower().Contains(FilterQuery)
                                                || x.ChineseSign.ToLower().GetDescription().Contains(FilterQuery)
                                                || x.SunSign.GetDescription().ToLower().Contains(FilterQuery)
                                                || x.Email.ToLower().Contains(FilterQuery));
            }

            UserInfo = new ObservableCollection<User>(users);
        }

        private void UIOnUserAdded(User user)
        {
            UserInfo.Add(user);
        }

        private void UIOnUserDeleted(User user)
        {
            UserInfo.Remove(user);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }
        #endregion
    }
}
