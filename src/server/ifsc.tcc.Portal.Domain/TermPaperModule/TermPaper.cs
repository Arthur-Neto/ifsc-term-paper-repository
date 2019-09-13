using System;
using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaper : Entity
    {
        public string Title { get; private set; }
        public DateTime DateBegin { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int AreaID { get; private set; }
        public int CourseID { get; private set; }

        public virtual Area Area { get; private set; }
        public virtual Course Course { get; private set; }
        public virtual IEnumerable<Keyword> Keywords { get; private set; }
        public virtual IEnumerable<Advisor> Advisors { get; private set; }

        private TermPaper()
        { }
    }
}
