using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sol_MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("Error/{statusCode}")]
        public IActionResult StatusCodeHandler(int statusCode)
        {
            return View("Index", statusCode);
        }
    }
}