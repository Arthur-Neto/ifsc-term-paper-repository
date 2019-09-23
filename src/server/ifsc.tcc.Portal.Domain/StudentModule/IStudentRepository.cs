using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.StudentModule
{
    public interface IStudentRepository
        : IGetRepository<Student>,
        IAddRepository<Student>
    { }
}
