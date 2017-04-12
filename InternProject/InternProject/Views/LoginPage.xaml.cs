using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel(new PageService());
            InitializeComponent();
        }
    }
}