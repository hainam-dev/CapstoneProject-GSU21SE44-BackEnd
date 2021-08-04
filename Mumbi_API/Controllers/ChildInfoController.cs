using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildInfoController : ControllerBase
    {
        private readonly IChildInfoService _childInfoService;

        public ChildInfoController(IChildInfoService childInfoService)
        {
            _childInfoService = childInfoService;
        }

        [HttpPost("AddChildInfo")]
        public async Task<IActionResult> AddChildInfo(CreateChildInfoRequest request)
        {
            return Ok(await _childInfoService.AddChildInfo(request));
        }

        //[Authorize(Roles = "user")]
        [HttpGet("GetAllChildInfo")]
        public async Task<IActionResult> GetAllChildInfo()
        {
            return Ok(await _childInfoService.GetAllChildInfo());
        }

        [HttpGet("GetChildInfoById/{Id}")]
        public async Task<IActionResult> GetChildInfoById(string Id)
        {
            return Ok(await _childInfoService.GetChildInfoById(Id));
        }

        [HttpGet("GetChildInfoByMomId/{momId}")]
        public async Task<IActionResult> GetChildInfoByMomId(string momId)
        {
            return Ok(await _childInfoService.GetChildInfoByMomId(momId));
        }

        [HttpPut("UpdateChildInfo/{Id}")]
        public async Task<IActionResult> UpdateChildInfo(string Id, UpdateChildInfoRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _childInfoService.UpdateChildInfo(request));
        }

        [HttpPut("DeleteChildInfo/{Id}")]
        public async Task<IActionResult> Delete (string Id)
        {
            return Ok(await _childInfoService.DeleteChildInfo(Id));
        }
    }
}
