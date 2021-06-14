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
    public class DadsController : ControllerBase
    {
        private readonly IDadService _dadService;

        public DadsController(IDadService dadService)
        {
            _dadService = dadService;
        }

        [HttpPut("DeleteDad/{Id}")]
        public async Task<IActionResult> DeleteDad(int Id)
        {
            //return Ok(await _dadService.DeleteDad(Id));
            return Ok();
        }
    }
}
