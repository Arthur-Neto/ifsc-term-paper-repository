using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.FileManagerModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/file-manager")]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileManagerAppService _fileManagerAppService;

        public FileManagerController(
            IFileManagerAppService fileManagerAppService)
        {
            _fileManagerAppService = fileManagerAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> DownloadTermPaper([FromQuery]string fileName)
        {
            return Ok(await _fileManagerAppService.DownloadTermPaperAsync(fileName));
        }
    }
}
