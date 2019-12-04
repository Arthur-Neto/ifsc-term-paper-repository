using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ifsc.tcc.Portal.Application.ElasticModule;
using ifsc.tcc.Portal.Application.FileManagerModule;
using ifsc.tcc.Portal.Application.FileManagerModule.Models;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using ifsc.tcc.Portal.Infra.Data.Crosscutting.Extensions;

namespace ifsc.tcc.Portal.Application.TermPaperModule
{
    public interface ITermPaperAppService
    {
        Task<bool> AddAsync(TermPaperAddCommand command);
        Task<IEnumerable<TermPaperFileModel>> GetAsync();
        Task<IEnumerable<TermPaperFileModel>> SearchAsync(string query);
    }

    public class TermPaperAppService : BaseAppService<ITermPaperRepository>, ITermPaperAppService
    {
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IKeywordRepository> _keywordRepository;
        private readonly Lazy<IAdvisorRepository> _advisorRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IAreaRepository> _areaRepository;
        private readonly Lazy<IIndexAppService> _indexAppService;
        private readonly Lazy<ISearchAppService> _searchAppService;
        private readonly Lazy<IFileManagerAppService> _fileManagerAppService;

        public TermPaperAppService(
            Lazy<IIndexAppService> indexAppService,
            Lazy<IFileManagerAppService> fileManagerAppService,
            Lazy<ISearchAppService> searchAppService,
            Lazy<IStudentRepository> studentRepository,
            Lazy<IKeywordRepository> keywordRepository,
            Lazy<IAdvisorRepository> advisorRepository,
            Lazy<ICourseRepository> courseRepository,
            Lazy<IAreaRepository> areaRepository,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper,
            ITermPaperRepository repository)
            : base(unitOfWork, mapper, repository)
        {
            _studentRepository = studentRepository;
            _keywordRepository = keywordRepository;
            _advisorRepository = advisorRepository;
            _courseRepository = courseRepository;
            _areaRepository = areaRepository;

            _searchAppService = searchAppService;
            _indexAppService = indexAppService;
            _fileManagerAppService = fileManagerAppService;
        }

        public async Task<bool> AddAsync(TermPaperAddCommand command)
        {
            var termPaper = Mapper.Value.Map<TermPaper>(command);

            var fileName = command.File.FileName.RemoveDiacritics().ToLowerInvariant().Trim();
            termPaper.SetFileName(fileName);

            await HandleCourseAsync(command, termPaper);

            await HandleKeywordsAsync(command, termPaper);

            await Repository.AddAsync(termPaper);

            await HandleAdvisorsAsync(command, termPaper);

            await HandleStudentsAsync(command, termPaper);

            var isIndexed = await _indexAppService.Value.IsIndexCreatedAsync("term-paper_index");
            if (!isIndexed)
            {
                await _indexAppService.Value.CreateTermPaperIndexAsync();
            }

            var fullPath = await _fileManagerAppService.Value.UploadTermPaperAsync(command.File);
            await _indexAppService.Value.IndexTermPaperFileAsync(fullPath);

            return await UnitOfWork.Value.CommitAsync() > 0;
        }

        public async Task<IEnumerable<TermPaperFileModel>> GetAsync()
        {
            var fileNames = _fileManagerAppService.Value.GetAllTermPapers();
            var listModel = await GetModelByFileNamesAsync(fileNames);

            return listModel;
        }

        public async Task<IEnumerable<TermPaperFileModel>> SearchAsync(string query)
        {
            var results = await _searchAppService.Value.SearchAsync(query);

            var fileNames = new List<string>();
            foreach (var hit in results.Hits)
            {
                fileNames.Add(hit.Source.Path);
            }

            fileNames = fileNames.Select(Path.GetFileName).ToList();
            var listModel = await GetModelByFileNamesAsync(fileNames);

            return listModel;
        }

        private async Task<IEnumerable<TermPaperFileModel>> GetModelByFileNamesAsync(IEnumerable<string> fileNames)
        {
            var listModel = new List<TermPaperFileModel>();

            foreach (var fileName in fileNames)
            {
                var termPaper = await Repository.GetByFileNameAsync(fileName);
                var students = await _studentRepository.Value.GetByTermPaperIDAsync(termPaper.ID);

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

                model.StudentB = "-";

                foreach (var student in students)
                {
                    if (string.IsNullOrWhiteSpace(model.StudentA))
                    {
                        model.StudentA = student.Name;
                    }
                    else
                    {
                        model.StudentB = student.Name;
                    }
                }

                listModel.Add(model);
            }

            return listModel;
        }

        private async Task HandleCourseAsync(TermPaperAddCommand command, TermPaper termPaper)
        {
            var course = await _courseRepository.Value.GetByNameAsync(command.Course);

            if (course == null)
            {
                var area = new Area(command.Area);
                await _areaRepository.Value.AddAsync(area);

                course = new Course(area, command.Course);
                await _courseRepository.Value.AddAsync(course);
            }

            termPaper.SetCourse(course);
        }

        private async Task HandleAdvisorsAsync(TermPaperAddCommand command, TermPaper termPaper)
        {
            var advisor = new Advisor(command.Advisor.ToLower().Trim().Replace(" ", "."), "123", command.Advisor);
            await _advisorRepository.Value.AddAsync(advisor);

            var termPaperAdvisor = new TermPaperAdvisor(AdvisorType.Leader, termPaper, advisor);
            termPaper.AddAdvisor(termPaperAdvisor);

            if (!string.IsNullOrWhiteSpace(command.CoAdvisor))
            {
                var coAdvisor = new Advisor(command.Advisor.ToLower().Trim(), "123", command.Advisor);
                await _advisorRepository.Value.AddAsync(coAdvisor);

                var termPaperCoAdvisor = new TermPaperAdvisor(AdvisorType.CoLeader, termPaper, coAdvisor);
                termPaper.AddAdvisor(termPaperCoAdvisor);
            }
        }

        private async Task HandleKeywordsAsync(TermPaperAddCommand command, TermPaper termPaper)
        {
            var existingKeywords = await _keywordRepository.Value.GetKeywordsByValueListAsync(command.Keywords);
            var newKeywords = command.Keywords.Except(existingKeywords.Select(ek => ek.Value));

            foreach (var keyword in existingKeywords)
            {
                termPaper.AddKeyword(new TermPaperKeyword(keyword));
            }
            foreach (var keyword in newKeywords)
            {
                termPaper.AddKeyword(new TermPaperKeyword(new Keyword(keyword)));
            }
        }

        private async Task HandleStudentsAsync(TermPaperAddCommand command, TermPaper termPaper)
        {
            var studentA = new Student(command.Student1);
            studentA.SetTermPaper(termPaper);

            await _studentRepository.Value.AddAsync(studentA);

            if (!string.IsNullOrWhiteSpace(command.Student2))
            {
                var studentB = new Student(command.Student2);
                studentB.SetTermPaper(termPaper);

                await _studentRepository.Value.AddAsync(studentB);
            }
        }
    }
}
