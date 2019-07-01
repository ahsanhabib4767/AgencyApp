using System;
using System.Collections.Generic;
using System.Text;

namespace AgencyPepsi.Models
{
    
    
        public class Order
        {
            
            public int OrderId { get; set; }
            public string OrderCase { get; set; }
            public DateTime OrderDate { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        }
 
}
