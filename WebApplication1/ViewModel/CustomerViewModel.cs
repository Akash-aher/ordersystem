using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class CustomerViewModel
    {
        
            public int Id { get; set; }
            [DisplayName("Customer First Name")]
            public string First_Name { get; set; }
            [DisplayName("Customer Last Name")] 
            public string Last_name { get; set; }
            [DisplayName("Customer Contact No")] 
            public string Contact_No { get; set; }
            [DisplayName("PinCode")]
            public Nullable<int> pin { get; set; }
        
    }
}