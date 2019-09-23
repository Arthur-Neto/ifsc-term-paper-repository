using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.StudentModule
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IFSCContext context)
            : base(context)
        { }
    }
}
