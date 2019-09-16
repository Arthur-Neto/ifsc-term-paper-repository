using ifsc.tcc.Portal.Domain.AdvisorModule;

namespace ifsc.tcc.Portal.Domain.GroupModule
{
    public class GroupAdvisor
    {
        public int GroupID { get; private set; }
        public int AdvisorID { get; private set; }

        public Group Group { get; private set; }
        public Advisor Advisor { get; private set; }

        private GroupAdvisor()
        { }
    }
}
