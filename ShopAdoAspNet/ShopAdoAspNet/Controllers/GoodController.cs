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
    public class GoodController : Controller
    {
        private readonly IRepository<Good> _goodRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Manufacturer> _manufacturerRepository;

        public GoodController(IRepository<Good> goodRepository, IRepository<Category> categoryRepository, IRepository<Manufacturer> manufacturerRepository)
        {
            _goodRepository = goodRepository;
            _categoryRepository = categoryRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public ActionResult Index()
        {
            return PartialView(_goodRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_goodRepository.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _goodRepository.Delete(_goodRepository.Get(id));
            return RedirectToAction("Index", "AdminPanel");
        }

        public ActionResult Edit(int id)
        {
            var good = _goodRepository.Get(id);
            var viewModel = new GoodViewModel
            {
                GoodCount = good.GoodCount,
                GoodId = good.GoodId,
                GoodName = good.GoodName,
                Price = good.Price,
                CategoryId = good.CategoryId.Value,
                ManufacturerId = good.ManufacturerId.Value,
                Manufacturers = new SelectList(_manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName"),
                Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName")
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(GoodViewModel viewModel)
        {
            var good = new Good
            {
                GoodId = viewModel.GoodId,
                CategoryId = viewModel.CategoryId,
                ManufacturerId = viewModel.ManufacturerId,
                GoodCount = viewModel.GoodCount,
                GoodName = viewModel.GoodName,
                Price = viewModel.Price
            };

            _goodRepository.AddOrUpdate(good);
            return RedirectToAction("Index", "AdminPanel");
        }

        public ActionResult Add()
        {
            var viewModel = new GoodViewModel
            {
                Manufacturers = new SelectList(_manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName"),
                Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName")
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(GoodViewModel viewModel)
        {
            var good = new Good
            {
                GoodId = viewModel.GoodId,
                GoodCount = viewModel.GoodCount,
                GoodName = viewModel.GoodName,
                CategoryId = viewModel.CategoryId,
                ManufacturerId = viewModel.ManufacturerId,
                Price = viewModel.Price
            };

            _goodRepository.AddOrUpdate(good);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}