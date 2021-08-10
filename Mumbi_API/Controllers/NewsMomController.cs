using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.NewsMom;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsMomController : ControllerBase
    {
        private readonly INewsMomService _newsMomService;

        public NewsMomController(INewsMomService newsMomService)
        {
            _newsMomService = newsMomService;
        }

        [HttpPost("AddNewsMom")]
        public async Task<IActionResult> AddNewsType(CreateNewsMomRequest request)
        {
            return Ok(await _newsMomService.AddNewsMom(request));
        }

        [HttpGet("GetNewsMomBy/{momId}")]
        public async Task<IActionResult> GetNewsByTypeId(string momId)
        {
            return Ok(await _newsMomService.GetNewsMomByMomId(momId));
        }

        [HttpDelete("DeleteNewsMom/{Id}")]
        public async Task<IActionResult> DeleteNewsType(int Id)
        {
            return Ok(await _newsMomService.DeleteNewsMom(Id));
        }
    }
}