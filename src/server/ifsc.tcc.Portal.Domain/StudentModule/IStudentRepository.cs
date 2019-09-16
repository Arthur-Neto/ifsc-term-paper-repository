using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.StudentModule
{
    public interface IStudentRepository
        : IGetRepository<Student>
    {
        Task<Student> GetByName(string name);
    }
}
