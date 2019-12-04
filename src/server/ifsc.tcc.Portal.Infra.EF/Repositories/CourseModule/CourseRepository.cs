using System.Linq;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.CourseModule
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(IFSCContext context)
            : base(context)
        { }

        public async Task<Course> GetByNameAsync(string name)
        {
            return await _entities
                .Include(x => x.Area)
                .Where(x => x.Name.Equals(name))
                .FirstOrDefaultAsync();
        }
    }
}
