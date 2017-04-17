using System.Text.RegularExpressions;
using System.Windows.Input;
using InternProject.Databases;
using InternProject.Services;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    internal class RegisterViewModel
    {
        private readonly IPageService _pageService;
        private readonly UserDatabase _userDatabase;

        public string ConfirmPassword { get; set; }
        public UserViewModel User { get; set; } = new UserViewModel();
        public ICommand ClickHaveAccountCommand { get; }
        public ICommand ClickRegisterCommand { get; }

        public RegisterViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _userDatabase = new UserDatabase();

            ClickHaveAccountCommand = new Command(() => _pageService.BackButtonPressed());
            ClickRegisterCommand = new Command(OnClickRegister);
        }

        public async void OnClickRegister()
        {
            if (!ValidUser())
                return;

            if (_userDatabase.InsertUser(User.Model))
            {
                await _pageService.DisplayAlert("Information", "Create Account Success", "OK");
                _pageService.BackButtonPressed();
            }
            else
            {
                await _pageService.DisplayAlert("Error", "The Account have been created", "OK");
            }
        }

        private bool ValidUser()
        {
            var isValid = true;
            if (string.IsNullOrEmpty(User.UsernameModel))
            {
                _pageService.DisplayAlert("Information", "Username isn't empty", "OK");
                isValid = false;
            }
            else if (!Regex.Match(User.UsernameModel, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                _pageService.DisplayAlert("Information", "Username must be Email", "OK");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(User.PasswordModel))
            {
                _pageService.DisplayAlert("Information", "Password isn't empty", "OK");
                isValid = false;
            }
            else if (!string.Equals(ConfirmPassword, User.PasswordModel))
            {
                _pageService.DisplayAlert("Information", "ConfirmPassword must ", "OK");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(User.PhoneModel))
            {
                _pageService.DisplayAlert("Information", "Phone isn't empty", "OK");
                isValid = false;
            }
            return isValid;
        }
    }
}