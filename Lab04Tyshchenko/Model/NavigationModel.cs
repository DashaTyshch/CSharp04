using Lab04Tyshchenko.Views;
using Lab04Tyshchenko.Windows;
using System;

namespace Lab04Tyshchenko.Model
{
    public enum ModesEnum
    {
        Main,
        AddUser,
        EditUser
    }

    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private MainView _mainView;
        private AddUserView _addUserView;
        private EditUserView _editUserView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _mainView = new MainView(storage);
            _addUserView = new AddUserView(storage);
            _editUserView = new EditUserView(storage);
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                case ModesEnum.AddUser:
                    _contentWindow.ContentControl.Content = _addUserView;
                    break;
                case ModesEnum.EditUser:
                    _contentWindow.ContentControl.Content = _editUserView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
