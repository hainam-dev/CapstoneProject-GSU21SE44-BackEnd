using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet("GetStaffInfoBy/{Id}")]
        public async Task<IActionResult> GetStaffInfoById(string Id)
        {
            return Ok(await _userInfoService.GetStaffInfoById(Id));
        }

        [HttpPut("UpdateStaffInfo/{Id}")]
        public async Task<IActionResult> UpdateStaffInfo(string Id, UpdateStaffInfoRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _userInfoService.UpdateStaffInfoRequest(request));
        }
    }
}