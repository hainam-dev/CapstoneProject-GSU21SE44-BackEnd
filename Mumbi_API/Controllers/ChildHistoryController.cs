using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildHistoryController : ControllerBase
    {
        private readonly IChildHistoryService _childHistoryService;

        public ChildHistoryController(IChildHistoryService childHistoryService)
        {
            _childHistoryService = childHistoryService;
        }

        [HttpPut("GetChildHistoryByChildId")]
        public async Task<IActionResult> GetChildHistoryByChildId(ChildHistoryRequest request)
        {
            return Ok(await _childHistoryService.GetChildHistoryByChildId(request));
        }
        [HttpPut("UpdateChildHistory")]
        public async Task<IActionResult> UpdateChildHistory(UpdateChildHistoryRequest request)
        {
            return Ok(await _childHistoryService.UpdateChildHistory(request));
        }
    }
}
