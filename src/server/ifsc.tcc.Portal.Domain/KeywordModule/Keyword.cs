using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.KeywordModule
{
    public class Keyword : Entity
    {
        public string Value { get; private set; }

        public virtual IEnumerable<KeywordTermPaper> KeywordTermPaper { get; private set; }

        private Keyword()
        { }

        public Keyword(string value)
        {
            Value = value;
        }
    }
}
