using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieSample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public double Price { get; set; }
    }
}