using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;
using StreamBox.ViewModels;

namespace StreamBox.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _Context;

        public UserManager<IdentityUser> userManager { get; }
        public SignInManager<IdentityUser> signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager,
          SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            _Context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var User = await userManager.FindByNameAsync(userName);
            if (User == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"User name: {userName} is already in use ");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateResellerOrConsumer()
        {
            if (signInManager.IsSignedIn(User) && !(User.IsInRole("Admin")))
            {
                return RedirectToAction("AccessDenied");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateResellerOrConsumer(RegisterViewModel model)
        {           
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName ,
                    Email = model.UserName,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInViewModel model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager
                                   .PasswordSignInAsync(model.UserName,model.Password,model.RememberMe, false);
                if (result.Succeeded)
                {
                    //protect our site from OpenRedirect Vulnerability
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login ");
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}