using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Extensions
{
    public class FileValidation : ValidationAttribute
    {
        public string[] Extensions { get; set; }

        public FileValidation()
        { }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!Extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("File extension is not allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
