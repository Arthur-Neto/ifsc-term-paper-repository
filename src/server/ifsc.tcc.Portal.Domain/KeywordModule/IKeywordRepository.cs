using System.Collections.Generic;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.KeywordModule
{
    public interface IKeywordRepository
        : IGetRepository<Keyword>,
        IAddRepository<Keyword>
    {
        Task<IEnumerable<Keyword>> GetKeywordsByValueList(IEnumerable<string> values);
    }
}
