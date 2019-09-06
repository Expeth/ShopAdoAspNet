using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
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
        private readonly IRepository<Manufacturer> _manufacturerRepository;

        public ShopController(IRepository<Good> goodRepository, IRepository<Category> categoryRepository, IRepository<Manufacturer> manufacturerRepository)
        {
            _goodRepository = goodRepository;
            _categoryRepository = categoryRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public ActionResult Goods(int id)
        {
            return PartialView(_goodRepository.GetAll().Where(x => x.CategoryId == id));
        }
    }
}