using ShopAdo.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class GoodFilter
    {
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public IList<CheckBoxFor<CategoryDTO>> Categories { get; set; }
        public IList<CheckBoxFor<ManufacturerDTO>> Manufacturers { get; set; }
    }
}