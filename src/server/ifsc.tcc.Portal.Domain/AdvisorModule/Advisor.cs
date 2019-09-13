using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.AdvisorModule
{
    public class Advisor : Entity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public AdvisorType AdvisorType { get; private set; }

        public virtual IEnumerable<TermPaperAdvisor> TermPaperAdvisors { get; private set; }

        private Advisor()
        { }
    }
}
