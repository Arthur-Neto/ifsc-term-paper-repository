using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.GroupModule;

namespace ifsc.tcc.Portal.Domain.StudentModule
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int GroupID { get; private set; }

        public virtual Group Group { get; private set; }

        private Student()
        { }
    }
}
