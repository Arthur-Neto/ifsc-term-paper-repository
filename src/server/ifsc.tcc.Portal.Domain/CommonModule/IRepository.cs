using System.Collections.Generic;
using System.Threading.Tasks;

namespace ifsc.tcc.Portal.Domain.CommonModule
{
    public interface IAddRepository<T> where T : class
    {
        Task AddAsync(T entity);
    }

    public interface IGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
    }

    public interface IRemoveRepository<T> where T : class
    {
        void Remove(T entity);
    }

    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
