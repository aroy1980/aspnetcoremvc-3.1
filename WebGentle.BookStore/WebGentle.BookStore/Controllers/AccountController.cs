﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUserModel signUserModel)
        {
            if (ModelState.IsValid)
            {
               var result =await _accountRepository.CreateUserAsync(signUserModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessages in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessages.Description);
                    }
                    return View(signUserModel);
                }
                ModelState.Clear();
            }
            return View();
        }
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }
        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result=  await _accountRepository.PasswordSignIn(signInModel);
                if(result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credential");
            }
            return View(signInModel);
        }

        [Route("SignOut")]
        public async Task<IActionResult> Logout()
        {
           await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("ChangePassword")]
        public  IActionResult ChangePassword()
        {
            //await _accountRepository.SignOutAsync();
            return View();
        }
        [Route("ChangePassword")]
        [HttpPost]
        public async  Task<IActionResult> ChangePassword(ChangePasswordModel changePassword)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(changePassword);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(changePassword);
        }
    }
}
