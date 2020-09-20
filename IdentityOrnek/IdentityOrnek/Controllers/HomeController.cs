﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityOrnek.Context;
using IdentityOrnek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityOrnek.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(UserSignInViewModel model)
        {


            if (ModelState.IsValid)
            {


                var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (identityResult.Succeeded) {

                    return RedirectToAction("Index","Panel");
                }
                ModelState.AddModelError("","Kullanıcı adı  veya şifre hatalı   ");
            }

            return View("Index", model);

        }
        public IActionResult KayıtOl()
        {
            return View(new UserSignUpViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> KayıtOl(UserSignUpViewModel model)
        {

            if (ModelState.IsValid)
            {


                AppUser user = new AppUser()
                {


                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.SurName,
                    UserName = model.UserName,

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
            return View(model);
        }
    }
}
