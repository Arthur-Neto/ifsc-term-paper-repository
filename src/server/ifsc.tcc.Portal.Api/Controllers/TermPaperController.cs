using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.TermPaperModule;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/term-paper")]
    public class TermPaperController : ControllerBase
    {
        private readonly ITermPaperAppService _termPaperAppService;

        public TermPaperController(
            ITermPaperAppService termPaperAppService)
        {
            _termPaperAppService = termPaperAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm]TermPaperAddCommand command)
        {
            return Ok(await _termPaperAppService.AddAsync(command));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _termPaperAppService.GetAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchAsync([FromQuery]string query)
        {
            return Ok(await _termPaperAppService.SearchAsync(query));
        }
    }
}
