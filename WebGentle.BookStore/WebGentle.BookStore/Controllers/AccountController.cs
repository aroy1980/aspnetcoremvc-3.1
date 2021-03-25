using Microsoft.AspNetCore.Mvc;
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
    }
}
