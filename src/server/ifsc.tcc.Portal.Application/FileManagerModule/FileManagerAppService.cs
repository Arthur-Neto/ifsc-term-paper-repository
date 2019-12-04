using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Infra.Data.Crosscutting.Extensions;
using Microsoft.AspNetCore.Http;
using Nest;

namespace ifsc.tcc.Portal.Application.FileManagerModule
{
    public interface IFileManagerAppService
    {
        Task<string> UploadTermPaperAsync(IFormFile file);
        Task<IndexResponse> DownloadTermPaperAsync(string fileName);
        IEnumerable<string> GetAllTermPapers();
    }

    public class FileManagerAppService : IFileManagerAppService
    {
        private readonly string TERM_PAPERS_FOLDER = "TermPapers";

        public Task<IndexResponse> DownloadTermPaperAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllTermPapers()
        {
            var fileNames = Directory.GetFiles(TERM_PAPERS_FOLDER, "*.pdf", SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            return fileNames;
        }

        public async Task<string> UploadTermPaperAsync(IFormFile file)
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
                var fullPath = "";
                if (file.Length > 0)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = fileName.RemoveDiacritics().ToLowerInvariant().Trim();

                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                return fullPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
