using ifsc.tcc.Portal.Domain.AdvisorModule;

namespace ifsc.tcc.Portal.Domain.GroupModule
{
    public class GroupAdvisor
    {
        public AdvisorType AdvisorType { get; private set; }
        public int GroupID { get; private set; }
        public int AdvisorID { get; private set; }

        public virtual Group Group { get; private set; }
        public virtual Advisor Advisor { get; private set; }

        private GroupAdvisor()
        { }
    }
}
