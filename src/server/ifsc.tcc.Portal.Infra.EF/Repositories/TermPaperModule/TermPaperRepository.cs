using System.Linq;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.TermPaperModule
{
    public class TermPaperRepository : GenericRepository<TermPaper>, ITermPaperRepository
    {
        public TermPaperRepository(IFSCContext context)
            : base(context)
        { }

        public async Task<TermPaper> GetByFileName(string fileName)
        {
            return await _entities
                .Include(x => x.TermPaperAdvisors)
                    .ThenInclude(x => x.Advisor)
                .Include(x => x.Course)
                .Where(x => x.FileName == fileName).FirstOrDefaultAsync();
        }
    }
}
