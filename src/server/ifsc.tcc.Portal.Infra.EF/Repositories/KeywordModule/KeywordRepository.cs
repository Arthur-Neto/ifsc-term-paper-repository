using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.KeywordModule
{
    public class KeywordRepository : GenericRepository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(IFSCContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Keyword>> GetKeywordsByValueListAsync(IEnumerable<string> values)
        {
            return await _entities.Where(kwd => values.Contains(kwd.Value)).ToListAsync();
        }
    }
}
