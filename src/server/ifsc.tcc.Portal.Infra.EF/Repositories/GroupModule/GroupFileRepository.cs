using ifsc.tcc.Portal.Domain.GroupModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.GroupModule
{
    public class GroupFileRepository : GenericRepository<GroupFile>, IGroupFileRepository
    {
        public GroupFileRepository(IFSCContext context)
            : base(context)
        { }
    }
}
