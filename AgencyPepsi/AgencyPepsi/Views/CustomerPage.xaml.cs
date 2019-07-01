using AgencyPepsi.Helpers;
using AgencyPepsi.Models;
using AgencyPepsi.Services;
using AgencyPepsi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgencyPepsi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerPage : ContentPage
	{
        private readonly ApiServices _apiServices = new ApiServices();
        public CustomerPage ()
		{
			InitializeComponent ();
            CustomerListBinding();
        }
        private async void CustomerListBinding()
        {

            var agencies = await _apiServices.GetAgencyAsync(user: Settings.Username, accessToken: Settings.AccessToken);
            customerPiker.ItemsSource = agencies.ToList();
           
        }
        private void View_Clicked(object sender, EventArgs e)
        {
            int AgencyId = 0;
            var picker = columnDatePickerOne.Date;
            var pickertwo = columnDatePickerTwo.Date;
            try
            {

                //decimal amount = 0;

                if (customerPiker.SelectedItem is Agency cust)
                {
                    AgencyId = cust.AgencyId;
                }

                var mobs = Task.Run(() => { return _apiServices.GetOrderAsync(AgencyId, picker, pickertwo, Settings.AccessToken); }).Result;
                if (mobs != null)
                {
                    OrderSummaryList.ItemsSource = mobs;
                }
                else
                {
                    DisplayAlert("Info!!", "No record found, with selected date range", "Ok");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Sorry!!", ex.Message, "Ok");
            }
        }
    }
}