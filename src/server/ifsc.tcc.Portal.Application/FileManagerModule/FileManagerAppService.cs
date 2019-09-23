using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ifsc.tcc.Portal.Application.FileManagerModule
{
    public interface IFileManagerAppService
    {
        Task UploadTermPaper(IFormFile file);
    }

    public class FileManagerAppService : IFileManagerAppService
    {
        private readonly string TERM_PAPERS_FOLDER = "TermPapers";

        public FileManagerAppService()
        { }

        public async Task UploadTermPaper(IFormFile file)
        {
            try
            {
                var webRootPath = Directory.GetCurrentDirectory();
                var newPath = Path.Combine(webRootPath, TERM_PAPERS_FOLDER);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                var fileName = "";
                if (file.Length > 0)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
