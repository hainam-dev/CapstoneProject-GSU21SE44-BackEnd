using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.News;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost("AddNews")]
        public async Task<IActionResult> AddNews(CreateNewsRequest request)
        {
            return Ok(await _newsService.AddNews(request));
        }

        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            return Ok(await _newsService.GetAllNews());
        }

        [HttpGet("GetNewsBy/{Id}")]
        public async Task<IActionResult> GetNewsById(string Id)
        {
            return Ok(await _newsService.GetNewsById(Id));
        }

        [HttpGet("GetNews")]
        public async Task<IActionResult> GetNews([FromQuery] NewsRequest request)
        {
            return Ok(await _newsService.GetNews(request));
        }

        [HttpPut("UpdateNews/{Id}")]
        public async Task<IActionResult> UpdateNews(string Id, UpdateNewsRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _newsService.UpdateNewsRequest(request));
        }

        [HttpPut("DeleteNews/{Id}")]
        public async Task<IActionResult> DeleteNews(string Id)
        {
            return Ok(await _newsService.DeleteNews(Id));
        }
    }
}