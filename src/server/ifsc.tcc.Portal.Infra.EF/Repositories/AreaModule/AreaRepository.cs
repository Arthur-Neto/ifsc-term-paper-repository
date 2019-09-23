using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.AreaModule
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(IFSCContext context)
            : base(context)
        { }
    }
}
