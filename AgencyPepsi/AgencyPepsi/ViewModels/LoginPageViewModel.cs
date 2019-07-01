using System.Threading.Tasks;
using System.Windows.Input;
using AgencyPepsi.Helpers;
using AgencyPepsi.Services;
using AgencyPepsi.ViewModels;
using AgencyPepsi.Views;
using Xamarin.Forms;


namespace AgencyPepsi.ViewModels
{
    public class LoginPageViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var token = await _apiServices.LoginAsync(Username, Password);

                    //await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                    //LoginCommand = new Command(() => UpdateUserInfo());
                    
                    Settings.AccessToken = token;
                    if (token != null)
                    {

                        await Application.Current.MainPage.Navigation.PushAsync(new HomePage());

                    }
                    //else await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    else await Application.Current.MainPage.DisplayAlert("Alert", "Invalid user or Password", "Ok");
                });

            }
        }
        public LoginPageViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;

        }

       
    }
}
