using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageTabHome : ContentPage
    {
        public HomePageTabHome()
        {
            ViewModel = new HomePageTabHomeViewModel(new PageService());
            InitializeComponent();
        }

        public HomePageTabHomeViewModel ViewModel
        {
            get => BindingContext as HomePageTabHomeViewModel;
            private set => BindingContext = value;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchTransactionCommand.Execute(e.NewTextValue);
        }
    }
}