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

        //[Authorize(Roles = "user")]
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
        [HttpGet("GetChildrenByMom/{momId}")]
        public async Task<IActionResult> GetChildrenByMomId(string momId)
        {
            return Ok(await _childrenService.GetChildrenByMomId(momId));
        }
        [HttpPut("updateChildrenInformation/{Id}")]
        public async Task<IActionResult> UpdateChildrenInformation(string Id, UpdateChildrenInformationRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _childrenService.UpdateChildrenInformation(request));
        }
        [HttpPut("updateChildrenHealth/{Id}")]
        public async Task<IActionResult> UpdateChildrenHealth(string Id, UpdateChildrenHealthResquest request)
        {
            if(Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _childrenService.UpdateChildrenHealth(request));
        }

        [HttpPut("DeleteChildren/{Id}")]
        public async Task<IActionResult> Delete (string Id)
        {
            return Ok(await _childrenService.DeleteChildren(Id));
        }
    }
}
