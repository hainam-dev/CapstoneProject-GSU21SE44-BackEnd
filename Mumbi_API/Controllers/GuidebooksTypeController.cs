using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.GuidebookTypes;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidebooksTypeController : ControllerBase
    {
        private readonly IGuidebookTypeService _guidebookTypeService;

        public GuidebooksTypeController(IGuidebookTypeService guidebookTypeService)
        {
            _guidebookTypeService = guidebookTypeService;
        }

        [HttpPost("AddGuidebookType")]
        public async Task<IActionResult> AddGuidebookType(CreateGuidebookTypeRequest request)
        {
            return Ok(await _guidebookTypeService.AddGuidebookType(request));
        }

        [HttpGet("GetAllGuidebookType")]
        public async Task<IActionResult> GetAllGuidebookType()
        {
            return Ok(await _guidebookTypeService.GetAllGuidebookType());
        }

        [HttpGet("GetGuidebookTypeBy/{Id}")]
        public async Task<IActionResult> GetGuidebookTypeById(int Id)
        {
            return Ok(await _guidebookTypeService.GetGuidebookTypeById(Id));
        }

        [HttpPut("UpdateGuidebookType/{Id}")]
        public async Task<IActionResult> UpdateGuidebookType(int Id, UpdateGuidebookTypeRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _guidebookTypeService.UpdateGuidebookTypeRequest(request));
        }

        [HttpPut("DeleteGuidebookType/{Id}")]
        public async Task<IActionResult> DeleteGuidebookType(int Id)
        {
            return Ok(await _guidebookTypeService.DeleteGuidebookType(Id));
        }
    }
}