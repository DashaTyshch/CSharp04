using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab04Tyshchenko.Model
{
    public class Storage
    {
        public event Action<User> UserAdded;
        public event Action<User> UserDeleted;

        public List<User> Users { get; private set; }

        private readonly FileInfo _fileInfo;

        public Storage()
        {
            _fileInfo = new FileInfo("users.json");

            if (_fileInfo.Exists)
            {
                string source;
                using (var stream = _fileInfo.OpenText())
                {
                    source = stream.ReadToEnd();
                };

                Users = JsonConvert.DeserializeObject<List<User>>(source);
            }
            else
            {
                Users = Create50Users();
            }
            
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
            UserAdded?.Invoke(user);
        }

        public void DeleteUser(User user)
        {
            Users.Remove(user);
            SaveChanges();
            UserDeleted?.Invoke(user);
        }

        public void EditUser(User user)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            var serializedUsers = JsonConvert.SerializeObject(Users);
            using (var stream = _fileInfo.CreateText())
            {
                stream.Write(serializedUsers);
            }
        }

        private List<User> Create50Users()
        {
            var users = new List<User>
            {
                new User("Даша", "Тищенко", "dasha@t", DateTime.Parse("15/10/1998")),
                new User("Наташа", "Рибак", "nata@rybak", DateTime.Parse("07/03/1999")),
                new User("Стас", "Теліженко", "ctel@t", DateTime.Parse("04/11/1998")),
                new User("Дмитро", "Хоменко", "dima@kh", DateTime.Parse("15/10/1998")),
                new User("Андрій", "Тищенко", "andrew@t", DateTime.Parse("10/12/1972")),
                new User("Наташа", "Бабіна", "babinata@gmail.com", DateTime.Parse("05/01/1975")),
                new User("Бла", "Бла", "bla@bla", DateTime.Parse("26/06/1996")),
            };
            SaveChanges();
            return users;
        }
    }
}
