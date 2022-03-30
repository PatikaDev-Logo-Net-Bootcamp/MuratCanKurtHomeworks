using Homework4.Business.Abstracts;
using Homework4.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IEmailService emailService;

        public HomeController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        // GET: api/<HomeController>
        [HttpGet]
        public IActionResult Index()
        {
            this.emailService.Send();
            return Ok();
        }

        // POST api/<HomeController>
        [Route("Register")]
        [HttpPost]
        public IActionResult Register([FromForm] UserRegisterModel model)
        {
            var userRegisterModel = new UserRegisterModel
            {
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName.ToUpper(),
                UserName = model.UserName,
                Password = model.Password,
                Image = model.Image
            };
            return Ok(userRegisterModel);
        }

        // DELETE api/<HomeController>/5
        [HttpDelete]
        public IActionResult Delete()
        {
            return Json(new { success = true, data = "Hello World" });
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
    }
}
