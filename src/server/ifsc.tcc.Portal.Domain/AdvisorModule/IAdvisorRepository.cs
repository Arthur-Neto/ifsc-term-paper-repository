using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.AdvisorModule
{
    public interface IAdvisorRepository
        : IGetRepository<Advisor>,
        IAddRepository<Advisor>
    {
        Task<Advisor> GetByUsernameAndPasswordAsync(string login, string password);
    }
}
