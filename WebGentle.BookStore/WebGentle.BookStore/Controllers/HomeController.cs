using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Controllers
{
    public class HomeController:Controller
    {
       
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ViewResult Index()
        {
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
