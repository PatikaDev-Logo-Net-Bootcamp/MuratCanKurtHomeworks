using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Homework4.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;
        public MaxFileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is IFormFile file))
                return ValidationResult.Success;
            return file.Length > _maxFileSize ? new ValidationResult($"Fotoğraf boyutu en fazla {_maxFileSize / 1024} KB olabilir.") : ValidationResult.Success;
        }

    }
}
