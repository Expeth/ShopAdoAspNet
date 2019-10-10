using ShopAdo.BLL.DTO;
using ShopAdo.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly GoodService _goodService;
        private IList<GoodDTO> _cart;
        
        public CartController(GoodService goodService)
        {
            _goodService = goodService;
        }

        public void AddToCart(int goodId)
        {
            _cart = (Session["Cart"] as List<GoodDTO>) ?? new List<GoodDTO>();
            _cart.Add(_goodService.Get(goodId));
            Session["Cart"] = _cart;
        }

        public List<GoodDTO> GetCart()
        {
            return (Session["Cart"] as List<GoodDTO>) ?? new List<GoodDTO>();
        }
    }
}