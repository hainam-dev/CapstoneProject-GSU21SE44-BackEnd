using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidebookMomController : ControllerBase
    {
        private readonly IGuidebookMomService _guidebookMomService;

        public GuidebookMomController(IGuidebookMomService guidebookMomService)
        {
            _guidebookMomService = guidebookMomService;
        }

        [HttpPost("AddGuidebookMom")]
        public async Task<IActionResult> AddGuidebookType(CreateGuidebookMomRequest request)
        {
            return Ok(await _guidebookMomService.AddGuidebookMom(request));
        }

        [HttpGet("GetGuidebookMomBy/{momId}")]
        public async Task<IActionResult> GetGuidebookByTypeId(string momId)
        {
            return Ok(await _guidebookMomService.GetGuidebookMomByMomId(momId));
        }

        [HttpDelete("DeleteGuidebookMom/{Id}")]
        public async Task<IActionResult> DeleteGuidebookType(int Id)
        {
            return Ok(await _guidebookMomService.DeleteGuidebookMom(Id));
        }
    }
}