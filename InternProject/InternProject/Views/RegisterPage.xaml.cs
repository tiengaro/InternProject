using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            BindingContext = new RegisterViewModel(new PageService());
            InitializeComponent();
        }
    }
}