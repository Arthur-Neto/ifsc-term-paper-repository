using System;
using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Models
{
    public class TermPaperModelMapper
    {
        public string Title { get; set; }
        public Area Area { get; set; }
        public Course Course { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public virtual IEnumerable<KeywordTermPaper> KeywordTermPapers { get; set; }
        public virtual IEnumerable<TermPaperAdvisor> TermPaperAdvisors { get; set; }
    }
}
