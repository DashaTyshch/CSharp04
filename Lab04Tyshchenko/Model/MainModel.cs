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

        public event Action<List<User>> UIUsersChanged;

        public MainModel(Storage storage)
        {
            _storage = storage;
            storage.UsersChanged += OnUsersChanged;
        }

        private void OnUsersChanged(List<User> users)
        {
            UIUsersChanged?.Invoke(users);
        }

        private void OnUserDeleted(List<User> users)
        {
            UIUsersChanged?.Invoke(users);
        }

        public void GoToAddUser()
        {
            NavigationManager.Instance.Navigate(ModesEnum.AddUser);
        }

        public void GoToEditUser(User user)
        {
            _storage.SetCurrentUser(user);
            NavigationManager.Instance.Navigate(ModesEnum.EditUser);
        }

        public void DeleteUser(User user)
        {
            _storage.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _storage.Users;
        }

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
                default:
                    break;
            }

            return new ObservableCollection<User>(users);
        }
    }
}
