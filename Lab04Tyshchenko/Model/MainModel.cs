using Lab04Tyshchenko.Navigation;
using Lab04Tyshchenko.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public void DeleteUser(User user)
        {
            _storage.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _storage.Users;
        }

        //internal void EditUser(User user)
        //{
        //    _storage
        //}

        public ObservableCollection<User> FilteredAndSortedUsers(string filterQuery, SortingEnum sortingEnum)
        {
            IEnumerable<User> users = GetAllUsers();

            if (!string.IsNullOrEmpty(filterQuery))
            {
                users = users.Where(x => x.Name.ToLower().Contains(filterQuery)
                                                || x.Surname.ToLower().Contains(filterQuery)
                                                || x.ChineseSign.ToLower().GetDescription().Contains(filterQuery)
                                                || x.SunSign.GetDescription().ToLower().Contains(filterQuery)
                                                || x.Email.ToLower().Contains(filterQuery));
            }

            switch (sortingEnum)
            {
                case SortingEnum.Default:
                    break;
                case SortingEnum.Name:
                    users = users.OrderBy(u => u.Name);
                    break;
                case SortingEnum.Surname:
                    users = users.OrderBy(u => u.Surname);
                    break;
                case SortingEnum.Email:
                    users = users.OrderBy(u => u.Email);
                    break;
                case SortingEnum.SunSign:
                    users = users.OrderBy(u => u.SunSign);
                    break;
                case SortingEnum.ChineseSign:
                    users = users.OrderBy(u => u.ChineseSign);
                    break;
            }

            return new ObservableCollection<User>(users);
        }
    }
}
