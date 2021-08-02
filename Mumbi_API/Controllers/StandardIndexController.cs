using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardIndexController : Controller
    {
        private readonly IStandardIndexService _standardIndexService;

        public StandardIndexController(IStandardIndexService standardIndexService)
        {
            _standardIndexService = standardIndexService;
        }

        [HttpGet("GetStandardIndexBy/{gender}")]
        public async Task<IActionResult> GetStandardIndexByGender(byte gender)
        {
            return Ok(await _standardIndexService.GetStandardIndexByGender(gender));
        }
    }
}
