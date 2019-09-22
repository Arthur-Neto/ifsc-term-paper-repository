using ifsc.tcc.Portal.Domain.AdvisorModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaperAdvisor
    {
        public int TermPaperID { get; private set; }
        public int AdvisorID { get; private set; }
        public AdvisorType AdvisorType { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }
        public virtual Advisor Advisor { get; private set; }
    }
}
