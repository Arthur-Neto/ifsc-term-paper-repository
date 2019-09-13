using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.KeywordModule
{
    public class KeywordTermPaper
    {
        public int TermPaperID { get; private set; }
        public int KeywordID { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }
        public virtual Keyword Keyword { get; private set; }

        private KeywordTermPaper()
        { }
    }
}
