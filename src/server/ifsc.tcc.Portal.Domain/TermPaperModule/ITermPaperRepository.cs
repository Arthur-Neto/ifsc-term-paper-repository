using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public interface ITermPaperRepository
        : IAddRepository<TermPaper>,
        IGetRepository<TermPaper>
    {
        Task<TermPaper> GetByFileName(string fileName);
    }
}
