using Microsoft.AspNetCore.Http;
using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.File
{
    public interface IFileService
    {
        Task<Response<Models.FileResult>> ReadFileAsync(IFormFile file);
    }
}
