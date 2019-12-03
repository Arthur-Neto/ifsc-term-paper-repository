using System;
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

        [HttpPost]
        public async Task<IActionResult> UploadTermPaper()
        {
            var file = Request.Form.Files[0];

            try
            {
                await _fileManagerAppService.UploadTermPaperAsync(file);

                return Ok(true);
            }
            catch (Exception ex)
            {
                BadRequest(ex);

                return null;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> DownloadTermPaper([FromQuery]string fileName)
        {
            return Ok(await _fileManagerAppService.DownloadTermPaperAsync(fileName));
        }
    }
}
