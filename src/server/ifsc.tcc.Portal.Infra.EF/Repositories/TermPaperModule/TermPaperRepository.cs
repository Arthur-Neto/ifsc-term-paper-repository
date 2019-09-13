using ifsc.tcc.Portal.Domain.TermPaperModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.TermPaperModule
{
    public class TermPaperRepository : GenericRepository<TermPaper>, ITermPaperRepository
    {
        public TermPaperRepository(IFSCContext context)
            : base(context)
        { }
    }
}
