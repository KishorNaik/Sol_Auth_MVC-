using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pathoschild.Http.Client;

namespace Sol_MVC.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var result =
                    await
                    new FluentClient("http://localhost:51725/api/users")
                    .PostAsync("testapi")
                    .WithBearerAuthentication("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFiZTQ3MmRhLTczZjMtNDhhYy1hMWE5LWNiZDkwZGU5NjQ4ZiIsInJvbGUiOiJVc2VycyIsIm5iZiI6MTU3NTU1MTA3NywiZXhwIjoxNTc2MTU1ODc3LCJpYXQiOjE1NzU1NTEwNzd9.dLrF2c3BSrS0CJUr65oQeLtwFH-xSoRU5h_LATI_GYk")
                    .As<Object>();

                if (result is bool)
                {
                    return View();
                    //throw new Exception();
                }
            }
            catch(Exception ex) when (ex.Message.Contains("Unauthorized"))
            {
                return base.Unauthorized();
            }
            catch(Exception)
            {
                throw;
            }


            return null;
        }

        [HttpPost]
        public IActionResult TestPost()
        {
            throw new Exception();
        }
    }
}