using System;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.FileManagerModule;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
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
                await _fileManagerAppService.UploadTermPaper(file);

                return Ok(true);
            }
            catch (Exception ex)
            {
                BadRequest(ex);

                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTermPaper([FromBody]string fileName)
        {
            return Ok(null);
        }
    }
}
