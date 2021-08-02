using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidebooksController : ControllerBase
    {
        private readonly IGuidebookService _guidebookService;

        public GuidebooksController(IGuidebookService guidebookService)
        {
            _guidebookService = guidebookService;
        }

        [HttpPost("AddGuidebook")]
        public async Task<IActionResult> AddGuidebookType(CreateGuidebookRequest request)
        {
            return Ok(await _guidebookService.AddGuidebook(request));
        }

        [HttpGet("GetAllGuidebook")]
        public async Task<IActionResult> GetAllGuidebook()
        {
            return Ok(await _guidebookService.GetAllGuidebook());
        }

        [HttpGet("GetGuidebookBy/{Id}")]
        public async Task<IActionResult> GetGuidebookById(string Id)
        {
            return Ok(await _guidebookService.GetGuidebookById(Id));
        }

        [HttpGet("GetGuidebookByType/{typeId}")]
        public async Task<IActionResult> GetGuidebookByTypeId(int typeId)
        {
            return Ok(await _guidebookService.GetGuidebookByTypeId(typeId));
        }

        [HttpPut("UpdateGuidebook/{Id}")]
        public async Task<IActionResult> UpdateGuidebook(string Id, UpdateGuidebookRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _guidebookService.UpdateGuidebookRequest(request));
        }

        [HttpPut("DeleteGuidebook/{Id}")]
        public async Task<IActionResult> DeleteGuidebook(string Id)
        {
            return Ok(await _guidebookService.DeleteGuidebook(Id));
        }
    }
}
