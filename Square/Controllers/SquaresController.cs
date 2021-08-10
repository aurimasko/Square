using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Square.Extensions;
using Square.Models;
using Square.Services.Square;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FileResult = Microsoft.AspNetCore.Mvc.FileResult;

namespace Square.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private readonly ISquareService _service;
        private readonly IMapper _mapper;

        public SquaresController(ISquareService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]IEnumerable<DTO.PointDTO> points)
        {
            var unMappedPoints = _mapper.Map<IEnumerable<DTO.PointDTO>, IEnumerable<Models.SquarePoint>>(points);
            var result = _service.FindSquares(unMappedPoints);
            //var mappedResult = _mapper.MapDTO<IEnumeraModels.Point[], DTO.SQ]>(result);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}