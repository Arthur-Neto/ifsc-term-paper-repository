using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;

namespace ifsc.tcc.Portal.Domain.GroupModule
{
    public class Group : Entity
    {
        public int CourseID { get; private set; }

        public virtual Course Course { get; private set; }
        public virtual IEnumerable<GroupAdvisor> GroupAdvisors { get; private set; }

        private Group()
        { }
    }
}
