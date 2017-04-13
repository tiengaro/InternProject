using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPage : ContentPage
    {
        public AddNewPageViewModel ViewModel
        {
            get => BindingContext as AddNewPageViewModel;
            set => BindingContext = value;
        }
        public AddNewPage()
        {
            ViewModel = new AddNewPageViewModel(new PageService());
            InitializeComponent();
        }
    }
}