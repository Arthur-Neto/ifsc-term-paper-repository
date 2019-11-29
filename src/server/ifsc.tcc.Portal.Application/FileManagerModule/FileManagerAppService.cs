using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.ElasticModule;
using ifsc.tcc.Portal.Application.FileManagerModule.Models;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.AspNetCore.Http;
using Nest;

namespace ifsc.tcc.Portal.Application.FileManagerModule
{
    public interface IFileManagerAppService
    {
        Task<IndexResponse> UploadTermPaperAsync(IFormFile file);
        Task<IndexResponse> DownloadTermPaperAsync(string fileName);
        Task<IEnumerable<TermPaperFileModel>> GetAllTermPapersAsync();
        Task<IEnumerable<TermPaperFileModel>> SearchTermPaperAsync(string query);
    }

    public class FileManagerAppService : IFileManagerAppService
    {
        private readonly string TERM_PAPERS_FOLDER = "TermPapers";

        private readonly Lazy<ITermPaperRepository> _termPaperRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IIndexAppService> _indexAppService;

        public FileManagerAppService(
            Lazy<IIndexAppService> indexAppService,
            Lazy<ITermPaperRepository> termPaperRepository,
            Lazy<IStudentRepository> studentRepository)
        {
            _termPaperRepository = termPaperRepository;
            _studentRepository = studentRepository;
            _indexAppService = indexAppService;
        }

        public Task<IndexResponse> DownloadTermPaperAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TermPaperFileModel>> GetAllTermPapersAsync()
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

        public Task<IEnumerable<TermPaperFileModel>> SearchTermPaperAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<IndexResponse> UploadTermPaperAsync(IFormFile file)
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

                var indexReturn = await _indexAppService.Value.IndexTermPaperFileAsync(fullPath);

                return indexReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
