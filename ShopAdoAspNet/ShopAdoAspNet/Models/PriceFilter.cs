using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopAdo.DAL;

namespace ShopAdoAspNet.Models
{
    public class PriceFilter : IGoodFilter
    {
        public bool IsChecked { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }

        public bool Equals(Good obj)
        {
            return IsChecked
                && obj.Price >= From
                && obj.Price <= To;
        }
    }
}