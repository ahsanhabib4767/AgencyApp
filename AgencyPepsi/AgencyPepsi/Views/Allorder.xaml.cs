using AgencyPepsi.Helpers;
using AgencyPepsi.Services;
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
    public partial class Allorder : ContentPage
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public Allorder()
        {
            InitializeComponent();
        }
        private void View_Clicked(object sender, EventArgs e)
        {

            var picker = columnDatePickerOne.Date;

            try
            {

                //decimal amount = 0;



                var mobs = Task.Run(() => { return _apiServices.GetAllOrderAsync(Settings.Username,picker,Settings.AccessToken); }).Result;
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