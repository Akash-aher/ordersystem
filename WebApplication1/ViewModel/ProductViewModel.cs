using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class ProductViewModel
    {
        public int id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
    }
}