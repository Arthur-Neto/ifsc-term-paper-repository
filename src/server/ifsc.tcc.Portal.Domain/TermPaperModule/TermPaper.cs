using System;
using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaper : Entity
    {
        public string Title { get; private set; }
        public DateTime DateBegin { get; private set; }
        public DateTime DateEnd { get; private set; }
        public string StudentAName { get; private set; }
        public string StudentBName { get; private set; }
        public string AdvisorName { get; private set; }
        public string CoAdvisorName { get; private set; }
        public string AreaName { get; private set; }
        public string CourseName { get; private set; }

        public IEnumerable<TermPaperKeyword> TermPaperKeywords { get; private set; }

        private TermPaper()
        { }

        public TermPaper(
            string title,
            DateTime dateBegin,
            DateTime dateEnd,
            string studentAName,
            string studentBName,
            string advisorName,
            string coAdvisorName,
            string areaName,
            string courseName,
            IEnumerable<TermPaperKeyword> keywords)
        {
            Title = title;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            StudentAName = studentAName;
            StudentBName = studentBName;
            AdvisorName = advisorName;
            CoAdvisorName = coAdvisorName;
            AreaName = areaName;
            CourseName = courseName;
            TermPaperKeywords = keywords;
        }
    }
}
