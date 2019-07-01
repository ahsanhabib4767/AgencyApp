using System.ComponentModel;
using System.Runtime.CompilerServices;
using AgencyPepsi.Helpers;
using Xamarin.Forms;

namespace AgencyPepsi.ViewModels
{
    public class BasePageViewModel : INotifyPropertyChanged
    {

        public INavigation _navigation;
        public string Username
        {
            get => Settings.Username;
            set
            {
                Settings.Username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get => Settings.Password;
            set
            {
                Settings.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

      

        #region INotifyPropertyChanged    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
