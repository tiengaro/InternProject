using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public string RememberUsername
        {
            get
            {
                if (Properties.ContainsKey(UsernameKey))
                {
                    return Properties[UsernameKey].ToString();
                }
                return "";
            }
            set => Properties[UsernameKey] = value;
        }
        public string RememberPassword
        {
            get
            {
                if (Properties.ContainsKey(PasswordKey))
                {
                    return Properties[PasswordKey].ToString();
                }
                return "";
            }
            set => Properties[PasswordKey] = value;
        }
        public bool IsRemember
        {
            get
            {
                if (Properties.ContainsKey(IsRememberKey))
                {
                    return (bool)Properties[IsRememberKey];
                }
                return false;
            }
            set => Properties[IsRememberKey] = value;
        }
    }
}
