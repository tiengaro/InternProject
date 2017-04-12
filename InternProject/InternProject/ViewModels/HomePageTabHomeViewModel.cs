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

        private IPageService PageService { get; }
        public List<TransactionViewModel> Transactions { get; set; }
        public HomePageTabHomeViewModel(IPageService pageService)
        {
            PageService = pageService;
            var transactionDatabase = new TransactionDatabase();

            Transactions = transactionDatabase.GetTransactions();
            ClickAddNewCommand = new Command(() => PageService.PushAsync(new AddNewPage()));
        }
    }
}