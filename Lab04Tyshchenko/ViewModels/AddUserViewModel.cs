using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.Tools;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab04Tyshchenko.ViewModels
{
    class AddUserViewModel : INotifyPropertyChanged
    {
        #region Private fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private ICommand _proceedCommand;

        private AddUserModel Model { get; }

        #endregion

        public AddUserViewModel(Storage storage)
        {
            Model = new AddUserModel(storage);
            _date = DateTime.Today.Date;
        }

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    InvokePropertyChanged(nameof(Name));
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    InvokePropertyChanged(nameof(Surname));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    InvokePropertyChanged(nameof(Email));
                }
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    InvokePropertyChanged(nameof(Date));
                }
            }
        }
        #endregion

        #region ProceedCommand
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
            return !(string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Surname) ||
                string.IsNullOrWhiteSpace(Email));
        }

        private void ProceedExecute(object obj)
        {
            try
            {
                Model.AddUser(Name, Surname, Email, Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
        #endregion

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
