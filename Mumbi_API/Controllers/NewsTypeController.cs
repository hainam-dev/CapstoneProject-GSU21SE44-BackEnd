using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.NewsType;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsTypeController : ControllerBase
    {
        private readonly INewsTypeService _newsTypeService;

        public NewsTypeController(INewsTypeService newsTypeService)
        {
            _newsTypeService = newsTypeService;
        }
        [HttpPost("AddNewsType")]
        public async Task<IActionResult> AddNewsType(CreateNewsTypeRequest request)
        {
            return Ok(await _newsTypeService.AddNewsType(request));
        }

        [HttpGet("GetAllNewsType")]
        public async Task<IActionResult> GetAllNewsType()
        {
            return Ok(await _newsTypeService.GetAllNewsType());

        }

        [HttpGet("GetNewsTypeBy/{Id}")]
        public async Task<IActionResult> GetNewsTypeById(int Id)
        {
            return Ok(await _newsTypeService.GetNewsTypeById(Id));

        }
        [HttpPut("UpdateNewsType/{Id}")]
        public async Task<IActionResult> UpdateNewsType(int Id, UpdateNewsTypeRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }
            return Ok(await _newsTypeService.UpdateNewsTypeRequest(request));
        }

        [HttpPut("DeleteNewsType/{Id}")]
        public async Task<IActionResult> DeleteNewsType(int Id)
        {
            return Ok(await _newsTypeService.DeleteNewsType(Id));
        }
    }
}
