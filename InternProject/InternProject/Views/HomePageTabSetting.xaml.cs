using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageTabSetting : ContentPage
    {
        public HomePageTabSetting()
        {
            BindingContext = new HomePageTabSettingViewModel(new PageService());
            InitializeComponent();
        }
    }
}