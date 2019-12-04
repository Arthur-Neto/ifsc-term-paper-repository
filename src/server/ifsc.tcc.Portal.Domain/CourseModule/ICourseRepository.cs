using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.CourseModule
{
    public interface ICourseRepository
        : IGetRepository<Course>,
        IAddRepository<Course>
    {
        Task<Course> GetByNameAsync(string name);
    }
}
