using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.FileManagerModule.Models;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.AspNetCore.Http;
using Nest;

namespace ifsc.tcc.Portal.Application.FileManagerModule
{
    public interface IFileManagerAppService
    {
        Task<IndexResponse> UploadTermPaper(IFormFile file);
        Task<IndexResponse> DownloadTermPaper(string fileName);
        Task<IEnumerable<TermPaperFileModel>> GetAllTermPapers();
        Task<IEnumerable<TermPaperFileModel>> SearchTermPaper(string query);
    }

    public class FileManagerAppService : IFileManagerAppService
    {
        private readonly string TERM_PAPERS_FOLDER = "TermPapers";

        private readonly IElasticClient _esClient;
        private readonly Lazy<ITermPaperRepository> _termPaperRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;

        public FileManagerAppService(
            IElasticClient esClient,
            Lazy<ITermPaperRepository> termPaperRepository,
            Lazy<IStudentRepository> studentRepository)
        {
            _esClient = esClient;
            _termPaperRepository = termPaperRepository;
            _studentRepository = studentRepository;
        }

        public Task<IndexResponse> DownloadTermPaper(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TermPaperFileModel>> GetAllTermPapers()
        {
            var fileNames = Directory.GetFiles(TERM_PAPERS_FOLDER, "*.pdf", SearchOption.TopDirectoryOnly);
            var listModel = new List<TermPaperFileModel>();

            foreach (var fileName in fileNames)
            {
                var termPaper = await _termPaperRepository.Value.GetByFileName(fileName);
                var students = await _studentRepository.Value.GetByTermPaperID(termPaper.ID);

                var model = new TermPaperFileModel()
                {
                    Title = termPaper.Title,
                    SubTitle = termPaper.Course.Name,
                };

                foreach (var advisor in termPaper.TermPaperAdvisors)
                {
                    if (advisor.AdvisorType == AdvisorType.Leader)
                    {
                        model.Advisor = advisor.Advisor.Name;
                    }
                    else
                    {
                        model.CoAdvisor = advisor.Advisor.Name;
                    }
                }

                model.StudentA = students[0].Name;
                model.StudentB = students[1]?.Name ?? "-";

                listModel.Add(model);
            }

            return listModel;
        }

        public Task<IEnumerable<TermPaperFileModel>> SearchTermPaper(string query)
        {
            throw new NotImplementedException();
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
