using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class GoodsList
    {
        public IEnumerable<GoodViewModel> Goods { get; set; }
        public IEnumerable<IGoodFilter> Filters { get; set; }
    }
}