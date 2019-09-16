using ifsc.tcc.Portal.Domain.GroupModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.GroupModule
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(IFSCContext context)
            : base(context)
        { }
    }
}
