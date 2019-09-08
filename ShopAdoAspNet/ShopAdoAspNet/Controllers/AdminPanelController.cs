using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class AdminPanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetIndex(string controllerName)
        {
            return RedirectToAction("Index", controllerName);
        }
    }
}