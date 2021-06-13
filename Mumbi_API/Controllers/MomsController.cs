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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _momService.GetAllMom());
        }

        [HttpPut("{AccountId}")]
        public async Task<IActionResult> UpdatePregnancy(string AccountId, UpdateMomRequest request)
        {
            if (AccountId != request.AccountId)
            {
                return BadRequest();
            }

            return Ok(await _momService.UpdateMomRequest(request));
        }

        
    }
}
