using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Application.TermPaperModule
{
    public interface ITermPaperAppService
    {
        Task<bool> AddAsync(TermPaperAddCommand command);
    }

    public class TermPaperAppService : BaseAppService<ITermPaperRepository>, ITermPaperAppService
    {
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IKeywordRepository> _keywordRepository;
        private readonly Lazy<IAdvisorRepository> _advisorRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IAreaRepository> _areaRepository;

        public TermPaperAppService(
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
        }

        public async Task<bool> AddAsync(TermPaperAddCommand command)
        {
            var area = new Area(command.Area);
            await _areaRepository.Value.AddAsync(area);

            var course = new Course(area);
            await _courseRepository.Value.AddAsync(course);

            var termPaper = Mapper.Value.Map<TermPaper>(command);

            await HandleKeywords(command, termPaper);

            await Repository.AddAsync(termPaper);

            await HandleAdvisors(command, termPaper);

            await HandleStudents(command, termPaper);

            return await UnitOfWork.Value.CommitAsync() > 0;
        }

        private async Task HandleAdvisors(TermPaperAddCommand command, TermPaper termPaper)
        {
            var advisor = new Advisor(command.Advisor.ToLower().Trim(), "123", command.Advisor);
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

        private async Task HandleKeywords(TermPaperAddCommand command, TermPaper termPaper)
        {
            var existingKeywords = await _keywordRepository.Value.GetKeywordsByValueList(command.Keywords);
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

        private async Task HandleStudents(TermPaperAddCommand command, TermPaper termPaper)
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
