using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Parameters;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly IDiaryService _diaryService;

        public DiariesController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpPost("AddDiary")]
        public async Task<IActionResult> AddDiary(CreateDiaryRequest request)
        {
            return Ok(await _diaryService.AddDiary(request));
        }

        [HttpGet("GetDiaryToApprove")]
        public async Task<IActionResult> GetDiaryToApprove()
        {
            return Ok(await _diaryService.GetDiaryToApprove());
        }

        [HttpGet("GetDiaryPublic")]
        public async Task<IActionResult> GetDiaryPublic([FromQuery] RequestParameter request)
        {
            return Ok(await _diaryService.GetDiaryPublic(request));
        }

        [HttpGet("GetDiaryOfChildren")]
        public async Task<IActionResult> GetDiaryOfChildren([FromQuery] DiaryRequest request)
        {
            return Ok(await _diaryService.GetDiaryOfChildren(request));
        }

        [HttpPut("UpdateDiary/{Id}")]
        public async Task<IActionResult> UpdateDiary(int Id, UpdateDiaryRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _diaryService.UpdateDiaryRequest(request));
        }

        [HttpPut("UpdateDiaryPublic/{Id}")]
        public async Task<IActionResult> UpdateDiaryPublic(string childID, int Id, UpdateDiaryPublicRequest request)
        {
            if (childID != request.ChildId || Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _diaryService.UpdateDiaryPublicRequest(request));
        }

        [HttpPut("DeleteDiary/{Id}")]
        public async Task<IActionResult> DeleteDiary(int Id)
        {
            return Ok(await _diaryService.DeleteDiary(Id));
        }
    }
}