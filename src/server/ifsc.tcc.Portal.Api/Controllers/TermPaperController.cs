using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.TermPaperModule;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _termPaperAppService.GetAsync());
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchAsync([FromQuery]string query)
        {
            return Ok(await _termPaperAppService.SearchAsync(query));
        }

        [HttpGet]
        [Route("check")]
        public async Task<IActionResult> Check()
        {
            return Ok(await _termPaperAppService.Check());
        }
    }
}
