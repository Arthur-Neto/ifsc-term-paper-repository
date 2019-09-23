using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.AdvisorModule
{
    public class AdvisorRepository : GenericRepository<Advisor>, IAdvisorRepository
    {
        public AdvisorRepository(IFSCContext context)
            : base(context)
        { }
    }
}
