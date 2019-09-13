using System;
using System.Collections.Generic;
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
        public virtual IEnumerable<KeywordTermPaper> KeywordTermPapers { get; private set; }
        public virtual IEnumerable<TermPaperAdvisor> TermPaperAdvisors { get; private set; }

        private TermPaper()
        { }

        public TermPaper(
            string title,
            DateTime dateBegin,
            DateTime dateEnd,
            Area area,
            Course course,
            IEnumerable<KeywordTermPaper> keywordTermPapers,
            IEnumerable<TermPaperAdvisor> termPaperAdvisors)
        {
            Title = title;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            Area = area;
            Course = course;
            KeywordTermPapers = keywordTermPapers;
            TermPaperAdvisors = termPaperAdvisors;
        }
    }
}
