using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
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
