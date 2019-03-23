using Lab04Tyshchenko.Navigation;
using System;

namespace Lab04Tyshchenko.Model
{
    class AddUserModel
    {
        private Storage _storage;

        public AddUserModel(Storage storage)
        {
            _storage = storage;
        }

        public void AddUser(string name, string surname, string email, DateTime date)
        {
            var user = new User(name, surname, email, date);
            _storage.AddUser(user);

            NavigationManager.Instance.Navigate(ModesEnum.Main);
        }
    }
}
