using System;
using System.Collections.Generic;
using AgencyPepsi.ViewModels;
using Xamarin.Forms;

namespace AgencyPepsi.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}
