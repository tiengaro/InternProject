using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using InternProject.Databases;
using InternProject.Models;
using InternProject.Services;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    internal class AddNewPageViewModel
    {
        private readonly IPageService _pageService;
        private readonly TransactionDatabase _transactionDatabase;
        private readonly TypeDatabase _typeDatabase;
        private List<TypeViewModel> _types;
        public TransactionViewModel TransactionView { get; set; } = new TransactionViewModel();
        public ICommand ClickAddNewTransactionCommand { get; private set; }
        public ICommand ClickCancelCommand { get; private set; }
        public List<string> Types { get; set; } = new List<string>();
        public AddNewPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _typeDatabase = new TypeDatabase();
            _transactionDatabase = new TransactionDatabase();
            _types = new List<TypeViewModel>();

            GetTypeDatabase();
            ClickAddNewTransactionCommand = new Command(AddNewTransaction);
            ClickCancelCommand = new Command(() => _pageService.BackButtonPressed());
        }

        private void GetTypeDatabase()
        {
            if (!_typeDatabase.IsHasDatabase())
            {
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 1, TypeName = "Shopping"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 2, TypeName = "Eating"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 3, TypeName = "Drinking"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 4, TypeName = "Fuel"}});
                foreach (var type in _types)
                    _typeDatabase.InsertType(type.Model);
            }
            _types = _typeDatabase.GetTypes();
            foreach (var type in _types)
                Types.Add(type.TypeNameModel);
        }
/*
        private async Task AddNewTransaction()
        {
            _transactionDatabase.InsertTransaction(TransactionView.Model);
            await _pageService.DisplayAlert("Notification", "Add successful", "OK");
            TransactionView.Model = null;
        }
*/

        private void AddNewTransaction()
        {
            TransactionView.Id = DateTime.Now.Ticks;
            _transactionDatabase.InsertTransaction(TransactionView.Model);
            TransactionView = new TransactionViewModel();
        }
    }
}