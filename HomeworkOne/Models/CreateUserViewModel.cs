using System.ComponentModel.DataAnnotations;

namespace HomeworkOne.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Şifre En az 8 karakter uzunluğunda olmalı.")]
        [Required (ErrorMessage ="Şifre en az 8 karakter olmalı ve en az 1 büyük harf, 1 küçük harf, 1 sayı ve 1 özel karakter içermelidir.")]
        public string Password { get; set; }
    }
}
