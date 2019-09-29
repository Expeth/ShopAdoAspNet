using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.BLL.DTO
{
    public class GoodDTO
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public double Price { get; set; }
        public int GoodCount { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
    }
}
