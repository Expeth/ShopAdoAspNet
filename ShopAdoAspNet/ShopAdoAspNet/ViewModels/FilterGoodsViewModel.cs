using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class FilterGoodsViewModel
    {
        public GoodFilter Filter { get; set; }
        public IEnumerable<DisplayGoodViewModel> Goods { get; set; }
    }
}