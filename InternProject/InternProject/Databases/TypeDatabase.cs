using System;
using System.Collections.Generic;
using System.Linq;
using InternProject.Models;
using InternProject.ViewModels;
using Realms;
using Realms.Exceptions;

namespace InternProject.Databases
{
    public class TypeDatabase
    {
        private readonly Realm _realm;

        public TypeDatabase()
        {
            _realm = Realm.GetInstance();
        }

        public bool IsHasDatabase()
        {
            try
            {
                var type = _realm.All<TypeTransaction>().Single(id => id.IdType == 1);
                return type != null ? true : false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public bool InsertType(TypeTransaction type)
        {
            try
            {
                _realm.Write(() => { _realm.Add(type); });
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                return false;
            }
            return true;
        }

        public TypeViewModel GetType(int idType)
        {
            try
            {
                var typeViewModel = new TypeViewModel
                {
                    Model = _realm.All<TypeTransaction>().Single(id => id.IdType == idType)
                };
                return typeViewModel;
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

        public List<TypeViewModel> GetTypes()
        {
            try
            {
                var types = new List<TypeViewModel>();
                foreach (var var in _realm.All<TypeTransaction>().ToList())
                {
                    var type = new TypeViewModel();
                    type.Model = var;
                    types.Add(type);
                }
                return types;
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