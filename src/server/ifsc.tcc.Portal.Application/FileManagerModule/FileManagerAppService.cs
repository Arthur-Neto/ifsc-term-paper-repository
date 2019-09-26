using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using Microsoft.AspNetCore.Http;
using Nest;

namespace ifsc.tcc.Portal.Application.FileManagerModule
{
    public interface IFileManagerAppService
    {
        Task<IndexResponse> UploadTermPaper(IFormFile file);
    }

    public class FileManagerAppService : IFileManagerAppService
    {
        private readonly string TERM_PAPERS_FOLDER = "TermPapers";

        private readonly IElasticClient _esClient;

        public FileManagerAppService(IElasticClient esClient)
        {
            _esClient = esClient;
        }

        public async Task<IndexResponse> UploadTermPaper(IFormFile file)
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

                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                var base64File = Convert.ToBase64String(File.ReadAllBytes(fullPath));
                var indexReturn = await _esClient.IndexAsync(new TermPaperElasticModel
                {
                    Path = fullPath,
                    Content = base64File
                }, i => i
                    .Index("termPaper_index")
                    .Pipeline("termPaper_pipeline")
                    .Timeout("5m")
                );

                return indexReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
