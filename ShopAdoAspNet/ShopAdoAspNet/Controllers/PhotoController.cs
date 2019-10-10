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
    public class PhotoController : Controller
    {
        private readonly IService<PhotoDTO> _photoService;

        public PhotoController(IService<PhotoDTO> photoService)
        {
            _photoService = photoService;
        }

        public ActionResult Delete(int id)
        {
            var photo = _photoService.Get(id);
            if (System.IO.File.Exists(photo.PhotoPath))
                System.IO.File.Delete(photo.PhotoPath);

            _photoService.Delete(photo);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}