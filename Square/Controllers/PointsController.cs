using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.DTO;
using Square.Extensions;
using Square.Models;
using Square.Services.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsController : ControllerBase
    {
        private readonly IPointService _service;
        private readonly IMapper _mapper;

        public PointsController(IPointService service, IMapper mapper) 
        { 
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid? id)
        {
            var result = await _service.GetAsync(id);
            var mappedResult = _mapper.MapDTO<PointDTO, Point>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }
   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]DTO.PointDTO point)
        {
            var unMappedPoint = _mapper.Map<PointDTO, Point>(point);

            var result = await _service.AddAsync(unMappedPoint);
            var mappedResult = _mapper.MapDTO<PointDTO, Point>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await _service.DeleteAsync(id);
            var mappedResult = _mapper.MapDTO<PointDTO, Point>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }
    }
}
