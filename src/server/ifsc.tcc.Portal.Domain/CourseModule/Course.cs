using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.CourseModule
{
    public class Course : Entity
    {
        public string Name { get; private set; }
        public int AreaID { get; private set; }

        public virtual Area Area { get; private set; }

        public Course()
        { }

        public Course(Area area, string name)
        {
            Area = area;
            Name = name;
        }
    }
}
