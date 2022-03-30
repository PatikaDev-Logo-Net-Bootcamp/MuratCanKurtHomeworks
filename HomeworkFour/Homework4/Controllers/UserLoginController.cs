using Homework4.Business.Abstracts;
using Homework4.Business.DTOs;
using Homework4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Homework4.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public UserLoginController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = new List<string>
            {
                "Nikola Tesla",
                "Elon Musk",
                "Murat Can Kurt"
            };
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLoginModel model)
        {
            var token = this.jwtService.Authenticate(new UserDTO { UserName = model.UserName, Password = model.Password });
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
