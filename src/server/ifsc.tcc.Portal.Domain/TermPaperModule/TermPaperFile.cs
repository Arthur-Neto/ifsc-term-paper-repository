using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaperFile : Entity
    {
        public string TermPaperData { get; private set; }
        public string FileName { get; private set; }
        public TermPaperFileType TermPaperFileType { get; private set; }
        public int TermPaperID { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }

        private TermPaperFile()
        { }
    }
}
