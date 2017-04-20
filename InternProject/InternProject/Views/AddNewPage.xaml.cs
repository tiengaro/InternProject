using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPage : ContentPage
    {
        public AddNewPage()
        {
            ViewModel = new AddNewPageViewModel(new PageService());
            InitializeComponent();
        }

        public AddNewPageViewModel ViewModel
        {
            get => BindingContext as AddNewPageViewModel;
            private set => BindingContext = value;
        }
    }
}