using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.CourseModule
{
    public class Course : Entity
    {
        public string Name { get; private set; }
        public int AreaID { get; private set; }

        public virtual Area Area { get; private set; }

        private Course()
        { }

        public Course(Area area)
        {
            Area = area;
        }
    }
}
