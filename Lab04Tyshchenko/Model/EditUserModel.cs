using Lab04Tyshchenko.Exceptions;
using Lab04Tyshchenko.Navigation;
using System;

namespace Lab04Tyshchenko.Model
{
    class EditUserModel
    {
        private Storage _storage;
        public event Action<User> UIUserChanged;

        public EditUserModel(Storage storage)
        {
            _storage = storage;
            storage.CurrentUserChanged += OnUserChanged;
        }

        private void OnUserChanged(User user)
        {
            UIUserChanged?.Invoke(user);
        }

        public void EditUser(User user)
        {
            ValidateData(user.Email);
            _storage.EditUser(user);
            
            NavigationManager.Instance.Navigate(ModesEnum.Main);
        }

        private void ValidateData(string email)
        {
            try
            {
                var _ = new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                throw new InvalidEmailException(email);
            }
        }

        public void GoToMain()
        {
            NavigationManager.Instance.Navigate(ModesEnum.Main);
        }
    }
}
