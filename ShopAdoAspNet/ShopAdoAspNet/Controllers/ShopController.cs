using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using ShopAdoAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class ShopController : Controller
    {
        private readonly IRepository<Good> _goodRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Photo> _photoRepository;

        public ShopController(IRepository<Good> goodRepository, IRepository<Category> categoryRepository, IRepository<Photo> photoRepository)
        {
            _goodRepository = goodRepository;
            _categoryRepository = categoryRepository;
            _photoRepository = photoRepository;
        }

        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public ActionResult Goods(int id)
        {
            var goods = new List<GoodViewModel>();
            foreach (var i in _goodRepository.GetAll().Where(x => x.CategoryId == id))
            {
                goods.Add(new GoodViewModel
                {
                    GoodName = i.GoodName,
                    GoodCount = (int)i.GoodCount,
                    Price = i.Price,
                    Photos = _photoRepository.GetAll().Where(p => p.GoodId == i.GoodId).ToList()
                });
            }
            return PartialView(goods);
        }
    }
}