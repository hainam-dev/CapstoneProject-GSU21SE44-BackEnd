using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Accounts;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateWithGoogle(AuthenticationRequest request)
        {
            var response = await _accountService.Authenticate(request);
            return Ok(response);
        }
    }
}
