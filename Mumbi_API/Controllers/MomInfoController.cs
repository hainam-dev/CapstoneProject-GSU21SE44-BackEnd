using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomInfoController : ControllerBase
    {
        private readonly IMomInfoService _momInfoService;

        public MomInfoController(IMomInfoService momInfoService)
        {
            _momInfoService = momInfoService;
        }

        [HttpGet("GetListMomInfo")]
        public async Task<IActionResult> GetAll([FromQuery] MomInfoRequest request)
        {
            return Ok(await _momInfoService.GetListMomInfo(request));
        }

        [HttpGet("GetMomInfoBy/{Id}")]
        public async Task<IActionResult> GetMomInfoById(string Id)
        {
            return Ok(await _momInfoService.GetMomInfoById(Id));
        }

        [HttpPut("UpdateMomInfo/{Id}")]
        public async Task<IActionResult> UpdateMomInfo(string Id, UpdateMomInfoRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _momInfoService.UpdateMomInfoRequest(request));
        }

        [HttpPut("DeleteMomInfo/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            return Ok(await _momInfoService.DeleteMomInfo(Id));
        }
    }
}