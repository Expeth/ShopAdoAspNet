using ShopAdo.BLL.DTO;
using ShopAdo.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IService<CategoryDTO> _categoryService;

        public CategoryController(IService<CategoryDTO> categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_categoryService.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _categoryService.Delete(_categoryService.Get(id));
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Edit(int id)
        {
            return View(_categoryService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTO category)
        {
            _categoryService.AddOrUpdate(category);
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryDTO category)
        {
            _categoryService.AddOrUpdate(category);
            return RedirectToAction("Index", "Category");
        }
    }
}