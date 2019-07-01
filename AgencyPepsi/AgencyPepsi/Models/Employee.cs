using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyPepsi.Models
{

    public class Employee
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
        public DateTime joinDate { get; set;}
        public ObservableCollection<Employee> employees { get; set; }
       // public List<Employee> Getstudents();


    }
}