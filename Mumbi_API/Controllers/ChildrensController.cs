using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ChildrensController : ControllerBase
    {
        private readonly IChildrenService _childrenService;

        public ChildrensController(IChildrenService childrenService)
        {
            _childrenService = childrenService;
        }

        [HttpPost("AddChildren")]
        public async Task<IActionResult> Add(CreateChildrenRequest request)
        {
            return Ok(await _childrenService.AddChildren(request));
        }

        [Authorize(Roles = "user")]
        [HttpGet("GetAllChildren")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _childrenService.GetAllChildren());
        }

        [HttpGet("GetChildrenBy/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _childrenService.GetChildrenById(id));
        }

        [HttpPut("updateChildrenInfo/{Id}")]
        public async Task<IActionResult> UpdateChildren(string Id, UpdateChildrenInfoResquest request)
        {
            if(Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _childrenService.UpdateChildrenInformation(request));
        }
        [HttpPut("updatePregnancyInfo/{Id}")]
        public async Task<IActionResult> UpdatePregnancy(string Id, UpdatePregnancyInfoRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _childrenService.UpdatePregnancyInformation(request));
        }

        [HttpPut("DeleteChildren/{Id}")]
        public async Task<IActionResult> Delete (string Id)
        {
            return Ok(await _childrenService.DeleteChildren(Id));
        }
    }
}
