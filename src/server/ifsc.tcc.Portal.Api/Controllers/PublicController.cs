using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.AdvisorModule;
using ifsc.tcc.Portal.Application.AdvisorModule.Models.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
    [ApiController]
    [Route("api/public")]
    public class PublicController : ControllerBase
    {
        private IAdvisorAppService _advisorAppService;

        public PublicController(IAdvisorAppService advisorAppService)
        {
            _advisorAppService = advisorAppService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateCommand command)
        {
            return Ok(await _advisorAppService.AuthenticateAsync(command));
        }
    }
}
