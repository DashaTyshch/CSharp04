using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.Tools;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab04Tyshchenko.ViewModels
{
    class EditUserViewModel : INotifyPropertyChanged
    {
        private User _user;

        private ICommand _proceedCommand;
        private ICommand _backCommand;

        private EditUserModel Model { get; }

        public EditUserViewModel(Storage storage)
        {
            Model = new EditUserModel(storage);
            Model.UIUserChanged += UIOnUserChanged;
        }

        #region Properties
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    InvokePropertyChanged(nameof(User));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand ProceedCommand
        {
            get
            {
                if (_proceedCommand == null)
                {
                    _proceedCommand = new RelayCommand<object>(ProceedExecute, ProceedCanExecute);
                }
                return _proceedCommand;
            }
            set
            {
                _proceedCommand = value;
                InvokePropertyChanged(nameof(ProceedCommand));
            }
        }

        private bool ProceedCanExecute(object obj)
        {
            return !(string.IsNullOrWhiteSpace(User?.Name) ||
                string.IsNullOrWhiteSpace(User?.Surname));
        }

        private void ProceedExecute(object obj)
        {
            try
            {
                Model.EditUser(User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand<object>(BackExecute, BackCanExecute);
                }
                return _backCommand;
            }
            set
            {
                _backCommand = value;
                InvokePropertyChanged(nameof(BackCommand));
            }
        }

        private bool BackCanExecute(object obj)
        {
            return true;
        }

        private void BackExecute(object obj)
        {
            Model.GoToMain();
        }
        #endregion

        private void UIOnUserChanged(User user)
        {
            User = user;
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
