using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopAdo.DAL;

namespace ShopAdoAspNet.Models
{
    public class CategoryFilter : IGoodFilter
    {
        public IDictionary<Category, bool> CheckBoxes { get; set; }

        public bool Equals(Good obj)
        {
            return CheckBoxes.Where(x => x.Value).Select(x => x.Key).Contains(obj.Category);
        }
    }
}