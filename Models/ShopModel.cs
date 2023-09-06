using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce_Website.Models
{
    public class ShopModel
    {
        public List<Category> cat { get; set; }
        public List<Product> pro { get; set; }
    }
}