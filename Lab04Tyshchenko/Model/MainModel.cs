using Lab04Tyshchenko.Navigation;
using System;

namespace Lab04Tyshchenko.Model
{
    public class MainModel
    {
        private Storage _storage;

        public event Action<User> UIUserAdded;
        public event Action<User> UIUserDeleted;

        public MainModel(Storage storage)
        {
            _storage = storage;
            storage.UserAdded += OnUserAdded;
            storage.UserDeleted += OnUserDeleted;
        }

        private void OnUserAdded(User user)
        {
            UIUserAdded?.Invoke(user);
        }

        private void OnUserDeleted(User user)
        {
            UIUserDeleted?.Invoke(user);
        }

        public void GoToAddUser()
        {
            NavigationManager.Instance.Navigate(ModesEnum.AddUser);
        }

        internal void DeleteUser(User user)
        {
            _storage.DeleteUser(user);
        }
    }
}
