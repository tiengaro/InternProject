using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            Transactions = new ObservableCollection<TransactionViewModel>();
            Transactions = transactionDatabase.GetTransactions(LoginViewModel.GetUser().Model.Username);
            Transactions = new ObservableCollection<TransactionViewModel>(Transactions.OrderByDescending(t => t.Date).ToList());
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