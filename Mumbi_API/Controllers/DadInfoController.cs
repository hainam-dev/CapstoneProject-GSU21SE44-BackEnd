using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadInfoController : ControllerBase
    {
        private readonly IDadInfoService _dadInfoService;

        public DadInfoController(IDadInfoService dadInfoService)
        {
            _dadInfoService = dadInfoService;
        }

        [HttpPost("AddDadInfo")]
        public async Task<IActionResult> AddDadInfo(CreateDadInfoRequest request)
        {
            return Ok(await _dadInfoService.AddDadInfo(request));
        }

        [HttpGet("GetDadInfoBy/{momId}")]
        public async Task<IActionResult> GetDadInfoByMomId(string momId)
        {
            return Ok(await _dadInfoService.GetDadInfoByMomId(momId));
        }

        [HttpPut("UpdateDadInfo/{Id}")]
        public async Task<IActionResult> UpdateDadInfo(string Id, UpdateDadInfoRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _dadInfoService.UpdateDadInfoRequest(request));
        }

        [HttpPut("DeleteDadInfo/{Id}")]
        public async Task<IActionResult> DeleteDadInfo(string Id)
        {
            return Ok(await _dadInfoService.DeleteDadInfo(Id));
        }
    }
}
