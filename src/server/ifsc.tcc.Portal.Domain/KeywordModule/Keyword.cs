using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.KeywordModule
{
    public class Keyword : Entity
    {
        public string Value { get; private set; }

        private Keyword()
        { }
    }
}
