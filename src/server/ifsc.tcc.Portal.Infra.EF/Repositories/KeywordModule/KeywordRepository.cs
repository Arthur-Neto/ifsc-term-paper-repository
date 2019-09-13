using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.KeywordModule
{
    public class KeywordRepository : GenericRepository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(IFSCContext context)
            : base(context)
        { }
    }
}
