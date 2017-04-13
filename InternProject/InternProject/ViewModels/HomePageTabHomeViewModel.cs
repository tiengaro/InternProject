using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InternProject.Databases;
using InternProject.Services;
using InternProject.Views;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    public class HomePageTabHomeViewModel
    {
        public ICommand ClickAddNewCommand { get; private set; }

        private readonly IPageService _pageService;
        public ObservableCollection<TransactionViewModel> Transactions { get; set; }
        public HomePageTabHomeViewModel(IPageService pageService)
        {
            _pageService = pageService;
            var transactionDatabase = new TransactionDatabase();

            Transactions = transactionDatabase.GetTransactions();
            ClickAddNewCommand = new Command(OnAddedTransaction);
        }

        public async void OnAddedTransaction()
        {
            var page = new AddNewPage();

            page.ViewModel.TransactionAdded += (source, transactionView) =>
            {
                Transactions.Add(transactionView);
            };
            await _pageService.PushAsync(page);
        }
    }
}