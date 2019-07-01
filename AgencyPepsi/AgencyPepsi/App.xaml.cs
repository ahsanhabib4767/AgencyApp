using AgencyPepsi.Helpers;
using AgencyPepsi.ViewModels;
using AgencyPepsi.Views;
using System;
using Xamarin.Forms;

namespace AgencyPepsi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        
        }

        //public void OnAppStart()
        //{
        //    if (string.IsNullOrEmpty(Settings.Username) && string.IsNullOrEmpty(Settings.Password))
        //    {
        //        MainPage = new NavigationPage(new LoginPage());
        //    }
        //    else
        //    {
        //        MainPage = new NavigationPage(new HomePage());
        //    }

        //}
        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if (Settings.AccessTokenExpirationDate < DateTime.UtcNow.AddHours(1))
                {
                    var loginViewModel = new LoginPageViewModel();
                    loginViewModel.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new HomePage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                  && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
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
