using System;
using System.Threading.Tasks;
using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.GroupModule;
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

        public TermPaperAppService(
            Lazy<IGroupFileRepository> groupFileRepository,
            Lazy<IStudentRepository> studentRepository,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper,
            ITermPaperRepository repository)
            : base(unitOfWork, mapper, repository)
        {
            _groupFileRepository = groupFileRepository;
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddAsync(TermPaperAddCommand command)
        {
            var student = await _studentRepository.Value.GetByName(command.StudentAName);
            Guard.AgainstNull(student, ExceptionArguments.NotFound);

            var termPaper = Mapper.Value.Map<TermPaper>(command);
            await Repository.AddAsync(termPaper);

            var groupFile = new GroupFile(command.FileData, command.FileData, student.Group, termPaper);
            await _groupFileRepository.Value.AddAsync(groupFile);

            return await UnitOfWork.Value.CommitAsync() > 0;
        }
    }
}
