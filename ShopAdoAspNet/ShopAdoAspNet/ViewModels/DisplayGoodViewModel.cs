using ShopAdo.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Models
{
    public class DisplayGoodViewModel
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int GoodCount { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public IEnumerable<PhotoDTO> Photos { get; set; }
    }
}