using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Controllers
{
    public class CustomerQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
