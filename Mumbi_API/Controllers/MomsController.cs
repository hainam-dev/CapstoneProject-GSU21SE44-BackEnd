using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomsController : ControllerBase
    {
        private readonly IMomService _momService;

        public MomsController(IMomService momService)
        {
            _momService = momService;
        }

        [HttpGet("GetAllMom")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _momService.GetAllMom());
        }

        [HttpGet("GetMomBy/{id}")]
        public async Task<IActionResult> GetMomById(string id)
        {
            return Ok(await _momService.GetMomById(id));
        }

        [HttpPut("UpdateMom/{AccountId}")]
        public async Task<IActionResult> UpdateMom(string AccountId, UpdateMomRequest request)
        {
            if (AccountId != request.AccountId)
            {
                return BadRequest();
            }

            return Ok(await _momService.UpdateMomRequest(request));
        }

        [HttpPut("DeleteMom/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            return Ok(await _momService.DeleteMom(Id));
        }

    }
}
