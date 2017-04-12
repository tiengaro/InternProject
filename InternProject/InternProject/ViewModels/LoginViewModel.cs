using System.Windows.Input;
using InternProject.Databases;
using InternProject.Services;
using InternProject.Views;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly UserDatabase _userDatabase;

        public LoginViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _userDatabase = new UserDatabase();

            ClickRegisterNowCommand = new Command(() => _pageService.PushAsync(new RegisterPage()));
            ClickLoginCommand = new Command(OnClickLogin);

            User.UsernameModel = App.RememberUsername;
            User.PasswordModel = App.RememberPassword;
        }

        public UserViewModel User { get; set; } = new UserViewModel();
        public App App { get; set; } = Application.Current as App;

        public ICommand ClickRegisterNowCommand { get; private set; }
        public ICommand ClickLoginCommand { get; private set; }

        private void OnClickLogin()
        {
            if (!IsEmptyUser())
                return;

            if (App.IsRemember)
            {
                App.RememberUsername = User.UsernameModel;
                App.RememberPassword = User.PasswordModel;
            }
            else
            {
                App.RememberUsername = "";
                App.RememberPassword = "";
            }

            if (_userDatabase.GetUser(User.UsernameModel, User.PasswordModel) != null)
                _pageService.PushAsync(new HomePage());
            else
                _pageService.DisplayAlert("Information", "Login unsuccess!", "ok");
        }

        private bool IsEmptyUser()
        {
            var isValid = true;
            if (string.IsNullOrEmpty(User.UsernameModel))
            {
                _pageService.DisplayAlert("Information", "Username isn't empty", "ok");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(User.PasswordModel))
            {
                _pageService.DisplayAlert("Information", "Password isn't empty", "ok");
                isValid = false;
            }
            return isValid;
        }
    }
}