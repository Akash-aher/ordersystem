using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class OrderViewModel
    {
        public int id { get; set; }
        [DisplayName("Customer Name")]
        public string First_Name { get; set; }
        public Nullable<int> Customer_id { get; set; }

        public Nullable<int> product_id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }
        
        [DisplayName("Remarks")]
        public string Remarks { get; set; }
    }
}