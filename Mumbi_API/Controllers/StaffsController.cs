using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("GetStaffBy/{accountId}")]
        public async Task<IActionResult> GetStaffByAccountId(string accountId)
        {
            return Ok(await _staffService.GetStaffByAccountId(accountId));
        }

        [HttpPut("UpdateStaff/{accountId}")]
        public async Task<IActionResult> UpdateStaff(string accountId, UpdateStaffRequest request)
        {
            if (accountId != request.AccountId)
            {
                return BadRequest();
            }

            return Ok(await _staffService.UpdateStaffRequest(request));
        }
    }
}
