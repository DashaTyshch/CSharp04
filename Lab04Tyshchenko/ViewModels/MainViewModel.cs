using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Lab04Tyshchenko.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Private fields

        private string _filterQuery;
        private SortingEnum _selectedItem;

        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;

        private User _selectedUser;
        private ObservableCollection<User> _userInfo;

        private MainModel Model { get; }

        #endregion

        public MainViewModel(Storage storage)
        {
            Model = new MainModel(storage);
            Model.UIUsersChanged += UIOnUserChanged;

            UserInfo = new ObservableCollection<User>(storage.Users);
            SelectedItem = SortingEnum.Default;
        }

        public string FilterQuery
        {
            get { return _filterQuery; }
            set
            {
                _filterQuery = value.ToLower();
                InvokePropertyChanged(nameof(FilterQuery));

                UserInfo = Model.FilteredAndSortedUsers(FilterQuery, SelectedItem);
            }
        }

        public SortingEnum SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                InvokePropertyChanged(nameof(SelectedItem));

                UserInfo = Model.FilteredAndSortedUsers(FilterQuery, SelectedItem);
            }
        }

        public List<DescriptionValueBinder> SortingList
        {
            get
            {
                return Enum.GetValues(typeof(SortingEnum)).Cast<Enum>().Select(value => new
                DescriptionValueBinder {
                    Description = (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute))
                    as DescriptionAttribute).Description,
                    Value = (SortingEnum)value
                }).ToList();
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

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand<User>(EditExecute, EditCanExecute);
                }
                return _editCommand;
            }
            set
            {
                _editCommand = value;
                InvokePropertyChanged(nameof(EditCommand));
            }
        }

        private bool EditCanExecute(User obj)
        {
            return SelectedUser != null;
        }

        private void EditExecute(User user)
        {
            Model.GoToEditUser(user);
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
            return SelectedUser != null;
        }

        private void DeleteExecute(User user)
        {
            Model.DeleteUser(user);
        }
        #endregion

        private void UIOnUserChanged(List<User> users)
        {
            UserInfo = Model.FilteredAndSortedUsers(FilterQuery, SelectedItem);
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
