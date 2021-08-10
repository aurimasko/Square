using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.DTO;
using Square.Extensions;
using Square.Models;
using Square.Services.File;
using Square.Services.List;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _service;
        private readonly IMapper _mapper;

        public FilesController(IFileService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm]Models.File file)
        {
            var result = await _service.ReadFileAsync(file.InputFile);
            var mappedResult = _mapper.MapDTO<FileResultDTO, Models.FileResult>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }
    }
}