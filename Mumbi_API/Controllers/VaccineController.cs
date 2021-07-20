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
    public class VaccineController : Controller
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }
        [HttpGet("GetAllVaccine")]
        public async Task<IActionResult> GetAllVaccine()
        {
            return Ok(await _vaccineService.GetAllVaccine());

        }
        [HttpGet("GetVaccineBy/{antigen}")]
        public async Task<IActionResult> GetVaccineByAntigen(string antigen)
        {
            return Ok(await _vaccineService.GetVaccineByAntigen(antigen));

        }
    }
}
