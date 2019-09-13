using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.CourseModule
{
    public class Course : Entity
    {
        public string Name { get; private set; }

        private Course()
        { }
    }
}
