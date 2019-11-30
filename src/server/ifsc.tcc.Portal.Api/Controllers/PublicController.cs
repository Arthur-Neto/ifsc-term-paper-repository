using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
    [ApiController]
    [Route("api/public")]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}
