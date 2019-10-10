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
    public class ManufacturerController : Controller
    {
        private readonly IService<ManufacturerDTO> _manufacturerService;

        public ManufacturerController(IService<ManufacturerDTO> manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public ActionResult Index()
        {
            return View(_manufacturerService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_manufacturerService.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _manufacturerService.Delete(_manufacturerService.Get(id));
            return RedirectToAction("Index", "Manufacturer");
        }

        public ActionResult Edit(int id)
        {
            return View(_manufacturerService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(ManufacturerDTO manufacturer)
        {
            _manufacturerService.AddOrUpdate(manufacturer);
            return RedirectToAction("Index", "Manufacturer");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ManufacturerDTO manufacturer)
        {
            _manufacturerService.AddOrUpdate(manufacturer);
            return RedirectToAction("Index", "Manufacturer");
        }
    }
}