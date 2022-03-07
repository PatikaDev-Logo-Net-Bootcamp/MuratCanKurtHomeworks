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
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", 
            ErrorMessage = "Şifre en az 8 karakter olmalı ve en az 1 büyük harf, 1 küçük harf ve 1 sayı içermelidir.")]
        [Required (ErrorMessage ="Bu alan zorunludur.")]
        public string Password { get; set; }
    }
}
