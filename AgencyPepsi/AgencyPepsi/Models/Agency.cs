using AgencyPepsi.ViewModels;
using AgencyPepsi.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AgencyPepsi.Models
{
   public class Agency
    {
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
       public IEnumerable<Order> Order { get; set; }
        public ObservableCollection<Agency> agencies { get; set; }
        public int eid { get; set; }
        public string username { get; set; }


        //public List<OrderVM> Order { get; set; }


    }
   

}
