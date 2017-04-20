using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InternProject.Databases;
using InternProject.Services;
using InternProject.Views;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    public class HomePageTabHomeViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly TransactionDatabase _transactionDatabase;
        private readonly string _username;
        private ObservableCollection<TransactionViewModel> _transactions;

        public HomePageTabHomeViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _transactionDatabase = new TransactionDatabase();

            _username = LoginViewModel.GetUser().Model.Username;

            _transactions = _transactionDatabase.GetTransactions(LoginViewModel.GetUser().Model.Username);

            ClickAddNewCommand = new Command(OnAddedTransaction);
            SearchTransactionCommand = new Command<string>(SearchTransaction);

            MessagingCenter.Subscribe<AddNewPageViewModel>(this, "AddTransaction",
                sender => { LoadData(_transactionDatabase.GetTransactions(_username)); });
        }

        public ICommand ClickAddNewCommand { get; }
        public ICommand SearchTransactionCommand { get; }

        public ObservableCollection<TransactionViewModel> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged();
            }
        }

        private void OnAddedTransaction()
        {
            var page = new AddNewPage();

            _pageService.PushAsync(page);
        }

        private void SearchTransaction(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                LoadData(_transactionDatabase.GetTransactions(_username));
                return;
            }
            LoadData(_transactionDatabase.GetTransactions(_username, filter));
        }

        private void LoadData(IEnumerable<TransactionViewModel> transactionsList)
        {
            _transactions.Clear();
            foreach (var transaction in transactionsList)
                _transactions.Add(transaction);
        }
    }
}