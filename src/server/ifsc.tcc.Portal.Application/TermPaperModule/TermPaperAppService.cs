using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.GroupModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.StudentModule;
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
        private readonly Lazy<IGroupFileRepository> _groupFileRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IKeywordRepository> _keywordRepository;

        public TermPaperAppService(
            Lazy<IGroupFileRepository> groupFileRepository,
            Lazy<IStudentRepository> studentRepository,
            Lazy<IKeywordRepository> keywordRepository,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper,
            ITermPaperRepository repository)
            : base(unitOfWork, mapper, repository)
        {
            _groupFileRepository = groupFileRepository;
            _studentRepository = studentRepository;
            _keywordRepository = keywordRepository;
        }

        public async Task<bool> AddAsync(TermPaperAddCommand command)
        {
            var student = await _studentRepository.Value.GetByName(command.Student1);
            Guard.AgainstNull(student, ExceptionArguments.NotFound);

            var existingKeywords = await _keywordRepository.Value.GetKeywordsByValueList(command.Keywords);
            var newKeywords = command.Keywords.Except(existingKeywords.Select(ek => ek.Value));

            var termPaper = Mapper.Value.Map<TermPaper>(command);
            foreach (var keyword in existingKeywords)
            {
                termPaper.AddKeyword(new TermPaperKeyword(keyword));
            }
            foreach (var keyword in newKeywords)
            {
                termPaper.AddKeyword(new TermPaperKeyword(new Keyword(keyword)));
            }
            await Repository.AddAsync(termPaper);

            var groupFile = new GroupFile(command.FileName, student.Group, termPaper);
            await _groupFileRepository.Value.AddAsync(groupFile);

            return await UnitOfWork.Value.CommitAsync() > 0;
        }
    }
}
