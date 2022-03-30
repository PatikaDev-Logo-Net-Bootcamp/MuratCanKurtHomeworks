using Microsoft.AspNetCore.Http;
using System;

namespace Homework4.Models
{
    public class UserRegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile Image { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
