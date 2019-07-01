using System.Threading.Tasks;
using System.Windows.Input;
using AgencyPepsi.Helpers;
using AgencyPepsi.Services;
using AgencyPepsi.Views;
using Xamarin.Forms;

namespace AgencyPepsi.ViewModels
{
    public class HomePageViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public ICommand LogoutCommand { get; private set; }
        public INavigation _navigation;
        public HomePageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LogoutCommand = new Command(() => ResetUserInfo());
            
        }

        void ResetUserInfo()
        {
            _navigation.PushAsync(new LoginPage());
           Settings.ClearAllData();
        }
    }
}

