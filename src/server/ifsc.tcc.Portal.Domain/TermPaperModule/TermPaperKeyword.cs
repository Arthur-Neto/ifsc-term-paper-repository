using ifsc.tcc.Portal.Domain.KeywordModule;

namespace ifsc.tcc.Portal.Domain.TermPaperModule
{
    public class TermPaperKeyword
    {
        public int TermPaperID { get; private set; }
        public int KeywordID { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }
        public virtual Keyword Keyword { get; private set; }

        private TermPaperKeyword()
        { }

        public TermPaperKeyword(Keyword keyword)
        {
            Keyword = keyword;
        }
    }
}
