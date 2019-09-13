using ifsc.tcc.Portal.Domain.TermPaperModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.TermPaperModule
{
    public class TermPaperFileRepository : GenericRepository<TermPaperFile>, ITermPaperFileRepository
    {
        public TermPaperFileRepository(IFSCContext context)
            : base(context)
        { }
    }
}
