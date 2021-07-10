using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.ToothInfo;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToothInfoController : ControllerBase
    {
        private readonly IToothInfoService _toothInfoService;

        public ToothInfoController(IToothInfoService toothInfoService)
        {
            _toothInfoService = toothInfoService;
        }
        [HttpPost("AddToothInfo")]
        public async Task<IActionResult> AddToothInfo(CreateToothInfoRequest request)
        {
            return Ok(await _toothInfoService.AddToothInfo(request));
        }
        [HttpGet("GetToothInfoBy/{Index}")]
        public async Task<IActionResult> GetToothInfoByIndex(byte Index)
        {
            return Ok(await _toothInfoService.GetToothInfoByIndex(Index));

        }
    }
}
