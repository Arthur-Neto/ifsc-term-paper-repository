using System;
using System.Threading.Tasks;

namespace ifsc.tcc.Portal.Domain.CommonModule
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
