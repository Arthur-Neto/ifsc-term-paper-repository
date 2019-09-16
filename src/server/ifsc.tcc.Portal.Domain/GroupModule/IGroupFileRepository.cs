using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.GroupModule
{
    public interface IGroupFileRepository
        : IGetRepository<GroupFile>,
        IAddRepository<GroupFile>
    { }
}
