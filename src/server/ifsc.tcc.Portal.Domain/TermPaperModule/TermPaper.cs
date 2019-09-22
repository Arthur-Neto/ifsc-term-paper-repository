using System;
using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.CourseModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaper : Entity
    {
        public string Title { get; private set; }
        public DateTime DateBegin { get; private set; }
        public DateTime DateEnd { get; private set; }
        public string FileName { get; private set; }
        public int CourseID { get; private set; }

        public virtual Course Course { get; private set; }
        public virtual IEnumerable<TermPaperKeyword> TermPaperKeywords { get; private set; }
        public virtual IEnumerable<TermPaperAdvisors> TermPaperAdvisors { get; private set; }

        private TermPaper()
        { }

        public void AddKeyword(TermPaperKeyword keyword)
        {
            TermPaperKeywords = new List<TermPaperKeyword>()
            {
                keyword
            };
        }
    }
}
