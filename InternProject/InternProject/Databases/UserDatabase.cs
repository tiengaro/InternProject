using System;
using System.Linq;
using InternProject.Models;
using InternProject.ViewModels;
using Realms;
using Realms.Exceptions;

namespace InternProject.Databases
{
    internal class UserDatabase
    {
        private readonly Realm _realm;

        public UserDatabase()
        {
            _realm = Realm.GetInstance();
        }

        public bool InsertUser(User user)
        {
            try
            {
                _realm.Write(() => { _realm.Add(user); });
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                return false;
            }
            return true;
        }

        public UserViewModel GetUser(string username, string password)
        {
            try
            {
                var userViewModel = new UserViewModel
                {
                    Model = _realm.All<User>().Single(u => u.Username == username && u.Password == password)
                };
                return userViewModel;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}