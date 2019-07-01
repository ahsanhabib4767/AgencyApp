using System.Threading.Tasks;
using System.Windows.Input;
using AgencyPepsi.Helpers;
using AgencyPepsi.Services;
using AgencyPepsi.Views;
using Xamarin.Forms;

namespace AgencyPepsi.ViewModels
{
    public class CustomerViewModel : BasePageViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public ICommand LogoutCommand { get; private set; }

        public CustomerViewModel(INavigation navigation)
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

