using Microsoft.AspNetCore.Http;
using Square.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class File
    {
        [Required]
        [FileValidation(Extensions = new string[] { ".txt" })]
        public IFormFile InputFile { get; set; }
    }
}
