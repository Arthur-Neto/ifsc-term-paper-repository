using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.StudentModule
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public int TermPaperID { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }

        private Student()
        { }

        public Student(string name)
        {
            Name = name;
        }

        public void SetTermPaper(TermPaper termPaper)
        {
            TermPaper = termPaper;
        }
    }
}
