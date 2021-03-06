﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using InternProject.Databases;
using InternProject.Models;
using InternProject.Services;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    public class AddNewPageViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly TransactionDatabase _transactionDatabase;
        private readonly TypeDatabase _typeDatabase;

        private List<TypeViewModel> _types;
        //public event EventHandler<TransactionViewModel> TransactionAdded;

        public AddNewPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _typeDatabase = new TypeDatabase();
            _transactionDatabase = new TransactionDatabase();
            _types = new List<TypeViewModel>();

            GetTypeDatabase();
            ClickAddNewTransactionCommand = new Command(AddNewTransaction);
            ClickCancelCommand = new Command(() => _pageService.PopAsync());
        }

        public TransactionViewModel TransactionView { get; set; } = new TransactionViewModel();
        public List<string> Types { get; set; } = new List<string>();
        public ICommand ClickAddNewTransactionCommand { get; }
        public ICommand ClickCancelCommand { get; }

        private void GetTypeDatabase()
        {
            if (!_typeDatabase.IsHasDatabase())
            {
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 1, TypeName = "Shopping"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 2, TypeName = "Eating"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 3, TypeName = "Drinking"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 4, TypeName = "Fuel"}});
                _types.Add(new TypeViewModel {Model = new TypeTransaction {IdType = 5, TypeName = "Other"}});
                foreach (var type in _types)
                    _typeDatabase.InsertType(type.Model);
            }
            _types = _typeDatabase.GetTypes();
            foreach (var type in _types)
                Types.Add(type.TypeNameModel);
        }

        private void AddNewTransaction()
        {
            TransactionView.Id = DateTime.Now.Ticks;
            TransactionView.Username = LoginViewModel.GetUser().UsernameModel;
            _transactionDatabase.InsertTransaction(TransactionView.Model);

            MessagingCenter.Send(this, "AddTransaction");
            //TransactionAdded?.Invoke(this, TransactionView);

            //TransactionView = new TransactionViewModel();
            _pageService.PopAsync();
        }
    }
}