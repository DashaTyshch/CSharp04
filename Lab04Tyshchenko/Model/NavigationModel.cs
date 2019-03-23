using Lab04Tyshchenko.Views;
using Lab04Tyshchenko.Windows;
using System;

namespace Lab04Tyshchenko.Model
{
    public enum ModesEnum
    {
        Main,
        AddUser
    }

    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private MainView _mainView;
        private AddUserView _addUserView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _mainView = new MainView(storage);
            _addUserView = new AddUserView(storage);
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
