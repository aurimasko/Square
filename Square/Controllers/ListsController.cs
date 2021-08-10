using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.DTO;
using Square.Extensions;
using Square.Models;
using Square.Services.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IListService _service;
        private readonly IMapper _mapper;

        public ListsController(IListService service, IMapper mapper)
        { 
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid? id)
        {
            var result = await _service.GetAsync(id);
            var mappedResult = _mapper.MapDTO<DTO.ListDTO, List>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAsync();
            var mappedResult = _mapper.MapDTO<IEnumerable<ListDTO>, IEnumerable<List>>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]DTO.ListDTO list)
        {
            var unMappedList = _mapper.Map<ListDTO, List>(list);

            var result = await _service.AddAsync(unMappedList);
            var mappedResult = _mapper.MapDTO<ListDTO, List>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await _service.DeleteAsync(id);
            var mappedResult = _mapper.MapDTO<ListDTO, List>(result);

            if (mappedResult.IsSuccess)
                return Ok(mappedResult);
            else
                return BadRequest(mappedResult);
        }
    }
}