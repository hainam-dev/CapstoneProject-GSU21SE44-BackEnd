using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("GetTokenBy/{Id}")]
        public async Task<IActionResult> GetTokenById(int Id)
        {
            return Ok(await _tokenService.GetTokenById(Id));
        }
        [HttpDelete("DeleteToken/{Id}")]
        public async Task<IActionResult> DeleteToken(int Id)
        {
            return Ok(await _tokenService.DeleteToken(Id));
        }
    }

}
