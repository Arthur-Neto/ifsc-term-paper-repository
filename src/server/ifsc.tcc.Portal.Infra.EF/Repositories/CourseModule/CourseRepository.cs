using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.CourseModule
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(IFSCContext context)
            : base(context)
        { }
    }
}
