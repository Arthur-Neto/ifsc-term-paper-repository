using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.AdvisorModule
{
    public class AdvisorRepository : GenericRepository<Advisor>, IAdvisorRepository
    {
        public AdvisorRepository(IFSCContext context)
            : base(context)
        { }

        public async Task<Advisor> GetByUsernameAndPasswordAsync(string login, string password)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Login == login && x.Password == password);
        }
    }
}
