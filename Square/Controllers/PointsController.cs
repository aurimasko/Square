using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPointService service;

        public PointsController(IPointService _service) { service = _service; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid? id)
        {
            var result = await service.GetAsync(id);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]Point point)
        {
            var result = await service.AddAsync(point);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await service.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
