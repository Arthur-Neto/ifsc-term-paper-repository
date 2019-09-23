using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace ifsc.tcc.Portal.Api.Controllers
{
    [ApiController]
    [Route("api/file-manager")]
    public class FileManagerController : ControllerBase
    {
        public FileManagerController()
        { }

        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "TermPapers";
                string webRootPath = Directory.GetCurrentDirectory();
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                string fileName = "";
                if (file.Length > 0)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok(fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
