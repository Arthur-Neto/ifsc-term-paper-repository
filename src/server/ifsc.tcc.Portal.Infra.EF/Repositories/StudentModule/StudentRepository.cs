using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<Student>> GetByTermPaperID(int id)
        {
            return await _entities
                .Where(x => x.TermPaperID == id).ToListAsync();
        }
    }
}
