using System;
using System.Collections.Generic;
using AgencyPepsi.ViewModels;
using Xamarin.Forms;
using AgencyPepsi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using AgencyPepsi.Services;
using System.Threading.Tasks;
using AgencyPepsi.Helpers;

namespace AgencyPepsi.Views
{
    public partial class HomePage : ContentPage
    { //public IList<Employee> employees;
        private readonly ApiServices _apiServices = new ApiServices();
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(Navigation);


        }
    

        //public async void Getstudents()
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetStringAsync("http://10.168.13.8/api/Employee");
        //    var employees = JsonConvert.DeserializeObject<List<Employee>>(response);
        //    LV.ItemsSource = employees;

        //}
        //private void Column_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    var picker = columnIndexPiker.SelectedIndex.ToString();
        //    // columnIndexPiker.SelectedIndex = -1;
        //    //var columnIndexPiker = (Picker)sender;
        //    //int selectedIndex = columnIndexPiker.SelectedIndex;

        //}
       

        private async void Customer_View_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerPage());

        }
        private async void Customerall_View_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Allorder());

        }


    }

}

