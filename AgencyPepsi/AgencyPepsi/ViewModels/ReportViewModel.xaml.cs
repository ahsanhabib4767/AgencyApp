using AgencyPepsi.Models;
using AgencyPepsi.Services;
using ListMast.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

using AgencyPepsi.Views;
using AgencyPepsi.Helpers;

namespace AgencyPepsi.ViewModels
{

    public class ReportViewModel : INotifyPropertyChanged
    {
        // Agency _employee = new Agency();
        private readonly ApiServices _apiServices = new ApiServices();

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Agency> agencies { get; set; }

        private List<Agency> items;
        public List<Agency> Items
        {
            get { return items; }
            set
            {

                items = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Order> _order;
        public ObservableCollection<Order> Orders
        {
            get { return _order; }
            set
            {

                _order = value;
                OnPropertyChanged();
            }
        }
        //public ICommand GetAgencyCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var accessToken = Settings.AccessToken;
        //            Items = await _apiServices.GetAgencyAsync(ccessToken);
                    
        //        });
        //    }
        //}
       
        public Agency Agency { get; internal set; }

 
        //public ReportViewModel()
        //{

        //    MyHTTP.GetAgencyAsync(list =>
        //     {
        //         foreach (Agency item in list)
        //             Items.Add(item);



        //    });
        //}


        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}