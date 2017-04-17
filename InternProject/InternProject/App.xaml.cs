using InternProject.Views;
using Xamarin.Forms;

namespace InternProject
{
    public partial class App : Application
    {
        private const string UsernameKey = "User";
        private const string PasswordKey = "Password";
        private const string IsRememberKey = "IsRemember";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public string RememberUsername
        {
            get => Properties.ContainsKey(UsernameKey) ? Properties[UsernameKey].ToString() : "";
            set => Properties[UsernameKey] = value;
        }

        public string RememberPassword
        {
            get => Properties.ContainsKey(PasswordKey) ? Properties[PasswordKey].ToString() : "";
            set => Properties[PasswordKey] = value;
        }

        public bool IsRemember
        {
            get
            {
                if (Properties.ContainsKey(IsRememberKey))
                    return (bool) Properties[IsRememberKey];
                return false;
            }
            set => Properties[IsRememberKey] = value;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}