using ShopAdoAspNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace ShopAdoAspNet.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Username.Equals("admin") && model.Password.Equals("admin"))
            {
                var identity = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Email, model.Username)
                }, "CookieAuth");

                var owinContext = Request.GetOwinContext();
                owinContext.Authentication.SignIn(identity);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Logout()
        {
            var owinContext = Request.GetOwinContext();
            owinContext.Authentication.SignOut("CookieAuth");
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}