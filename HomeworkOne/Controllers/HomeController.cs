using HomeworkOne.Models;
using HomeworkOne.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IResult Index(CreateUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                return new Result
                {
                    Success = true,
                    Data = "Giriş İşlemi Başarılı",
                    Error = null
                };
            }
            return new Result
            {
                Success = false,
                Data = null,
                Error = "Hatalı giriş."
            };
        }

        public IActionResult UserInfo(CreateUserViewModel user)
        {
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
