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
        public virtual IEnumerable<TermPaperAdvisor> TermPaperAdvisors { get; private set; }

        private TermPaper()
        {
            TermPaperKeywords = new List<TermPaperKeyword>();
            TermPaperAdvisors = new List<TermPaperAdvisor>();
        }

        public TermPaper(string title, DateTime dateBegin, DateTime dateEnd, string fileName)
            : this()
        {
            Title = title;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            FileName = fileName;
        }

        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        public void SetCourse(Course course)
        {
            Course = course;
        }

        public void AddAdvisor(TermPaperAdvisor advisor)
        {
            (TermPaperAdvisors as List<TermPaperAdvisor>).Add(advisor);
        }

        public void AddKeyword(TermPaperKeyword keyword)
        {
            (TermPaperKeywords as List<TermPaperKeyword>).Add(keyword);
        }
    }
}
