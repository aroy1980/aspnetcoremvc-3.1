using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Service;

namespace WebGentle.BookStore.Controllers
{
    public class HomeController:Controller
    {
       
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public HomeController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        public ViewResult Index()
        {
            // Get logged UserID in any Controller Using HTTPContextAccessor Class//
            var isLogged = _userService.IsLogged();
            if (isLogged)
            {
                var userID = _userService.GetUserID();
            }
           
            //var result = _configuration.GetValue<bool>("DisplayNewBookAlert");
          //  var result = _configuration["AppName"];
            return View();
        }
      
       // [Route("about-us/{name:alpha:minlength(3)}") ]
        public ViewResult About()
        {
            return View();
        }

       // [Route("Please Contact us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
