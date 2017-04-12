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
            BindingContext = new HomePageTabHomeViewModel(new PageService());
            InitializeComponent();
        }
    }
}