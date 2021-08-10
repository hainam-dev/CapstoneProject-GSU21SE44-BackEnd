using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpDelete("DeleteToken/{UserId}/{FcmToken}")]
        public async Task<IActionResult> DeleteToken(string UserId, string FcmToken)
        {
            return Ok(await _tokenService.DeleteToken(UserId, FcmToken));
        }
    }
}