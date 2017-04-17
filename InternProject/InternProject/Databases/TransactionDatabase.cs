using System;
using System.Collections.ObjectModel;
using System.Linq;
using InternProject.ViewModels;
using Realms;
using Realms.Exceptions;
using Transaction = InternProject.Models.Transaction;

namespace InternProject.Databases
{
    public class TransactionDatabase
    {
        private readonly Realm _realm;

        public TransactionDatabase()
        {
            _realm = Realm.GetInstance();
        }

        public bool InsertTransaction(Transaction transaction)
        {
            try
            {
                _realm.Write(() => { _realm.Add(transaction); });
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                return false;
            }
            return true;
        }

        public TransactionViewModel GetTransaction(int idTransaction)
        {
            try
            {
                var transactionViewModel = new TransactionViewModel
                {
                    Model = _realm.All<Transaction>().Single(t => t.Id == idTransaction)
                };
                return transactionViewModel;
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

        public ObservableCollection<TransactionViewModel> GetTransactions(string username)
        {
            try
            {
                //return new ObservableCollection<TransactionViewModel>(_realm.All<Transaction>().ToList().Select(var => new TransactionViewModel { Model = var }).ToList());
                return new ObservableCollection<TransactionViewModel>(_realm.All<Transaction>()
                    .Where(u => u.Username == username)
                    .ToList()
                    .Select(var => new TransactionViewModel {Model = var})
                    .ToList());
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