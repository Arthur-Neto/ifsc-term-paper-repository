using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using ifsc.tcc.Portal.Infra.Data.Crosscutting.Guard;

namespace ifsc.tcc.Portal.Application.TermPaperModule
{
    public interface ITermPaperAppService
    {
        Task<bool> AddAsync(TermPaperAddCommand command);
    }

    public class TermPaperAppService : BaseAppService<ITermPaperRepository>, ITermPaperAppService
    {
        private readonly Lazy<IAreaRepository> _areaRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IKeywordRepository> _keywordRepository;
        private readonly Lazy<IAdvisorRepository> _advisorRepository;

        public TermPaperAppService(
            Lazy<IAreaRepository> areaRepository,
            Lazy<ICourseRepository> courseRepository,
            Lazy<IKeywordRepository> keywordRepository,
            Lazy<IAdvisorRepository> advisorRepository,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper,
            ITermPaperRepository repository)
            : base(unitOfWork, mapper, repository)
        {
            _areaRepository = areaRepository;
            _courseRepository = courseRepository;
            _keywordRepository = keywordRepository;
            _advisorRepository = advisorRepository;
        }

        public async Task<bool> AddAsync(TermPaperAddCommand command)
        {
            var area = await _areaRepository.Value.GetByIDAsync(command.AreaID);
            Guard.AgainstNull(area, ExceptionArguments.NotFound);

            var course = await _courseRepository.Value.GetByIDAsync(command.CourseID);
            Guard.AgainstNull(course, ExceptionArguments.NotFound);

            var advisor = await _advisorRepository.Value.GetByIDAsync(command.AdvisorID);
            Guard.AgainstNull(advisor, ExceptionArguments.NotFound);

            var advisorList = new List<TermPaperAdvisor>()
            {
                new TermPaperAdvisor(advisor)
            };

            Advisor coAdvisor;
            if (command.CoAdvisorID > 0)
            {
                coAdvisor = await _advisorRepository.Value.GetByIDAsync(command.CoAdvisorID);
                Guard.AgainstNull(coAdvisor, ExceptionArguments.NotFound);
                advisorList.Add(new TermPaperAdvisor(coAdvisor));
            }

            var keywordList = new List<KeywordTermPaper>();
            foreach (var item in command.Keywords)
            {
                var keyword = new Keyword(item);
                await _keywordRepository.Value.AddAsync(keyword);
                keywordList.Add(new KeywordTermPaper(keyword));
            }

            var model = new TermPaperModelMapper()
            {
                Area = area,
                Course = course,
                DateBegin = command.DateBegin,
                DateEnd = command.DateEnd,
                Title = command.Title,
                KeywordTermPapers = keywordList,
                TermPaperAdvisors = advisorList,
            };

            var termPaper = Mapper.Value.Map<TermPaper>(model);

            await Repository.AddAsync(termPaper);

            return await UnitOfWork.Value.CommitAsync() > 0;
        }
    }
}
