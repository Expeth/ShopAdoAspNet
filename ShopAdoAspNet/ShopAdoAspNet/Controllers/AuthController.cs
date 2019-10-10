using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ShopAdo.Contracts.Models;
using ShopAdo.Identity.IdentityManagers;
using ShopAdo.Identity.IdentityModels;
using ShopAdoAspNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private SignInManager<AppUser, string> _signInManager => HttpContext.GetOwinContext().Get<SignInManager<AppUser, string>>();
        private AppUserManager<AppUser> _userManager => HttpContext.GetOwinContext().Get<AppUserManager<AppUser>>();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Shop");
                case SignInStatus.LockedOut:
                    break;
                case SignInStatus.RequiresVerification:
                    break;
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }

            ModelState.AddModelError("", "Internal Server Error");
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var isAlreadyExists = await _userManager.FindByNameAsync(model.Username) == null ? false : true;
            if (isAlreadyExists)
            {
                ModelState.AddModelError("", "User is already exists");
                return View(model);
            }

            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Address = new Address(),
                Birthday = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(model);
            }

            return RedirectToAction("Index", "Shop");
        }
    }
}