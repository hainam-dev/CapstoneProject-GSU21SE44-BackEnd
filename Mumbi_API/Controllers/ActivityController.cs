using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Activity;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("AddActivity")]
        public async Task<IActionResult> AddActivity(CreateActivityRequest request)
        {
            return Ok(await _activityService.AddActivity(request));
        }

        [HttpGet("GetActivity")]
        public async Task<IActionResult> GetActivity([FromQuery] ActivityRequest request)
        {
            return Ok(await _activityService.GetActivity(request));
        }

        [HttpGet("GetAllActivity")]
        public async Task<IActionResult> GetAllActivity()
        {
            return Ok(await _activityService.GetAllActivity());
        }

        [HttpGet("GetActivityBy/{Id}")]
        public async Task<IActionResult> GetActivityById(int Id)
        {
            return Ok(await _activityService.GetActivityById(Id));
        }

        [HttpGet("GetActivityByType")]
        public async Task<IActionResult> GetActivityByTypeId([FromQuery] ActivityRequest request)
        {
            return Ok(await _activityService.GetActivityByTypeId(request));
        }

        [HttpPut("UpdateActivity/{Id}")]
        public async Task<IActionResult> UpdateActivity(int Id, UpdateActivityRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _activityService.UpdateActivityRequest(request));
        }

        [HttpPut("DeleteActivity/{Id}")]
        public async Task<IActionResult> DeleteActivity(int Id)
        {
            return Ok(await _activityService.DeleteActivity(Id));
        }
    }
}