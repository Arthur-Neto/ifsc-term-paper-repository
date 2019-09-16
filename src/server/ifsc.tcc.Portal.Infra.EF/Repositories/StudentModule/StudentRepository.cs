using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.StudentModule
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IFSCContext context)
            : base(context)
        { }

        public async Task<Student> GetByName(string name)
        {
            return await _entities
                .Include(x => x.Group)
                .SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
