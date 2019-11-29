using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using Nest;

namespace ifsc.tcc.Portal.Application.ElasticModule
{
    public interface ISearchAppService
    {
        Task<ISearchResponse<TermPaperElasticModel>> SearchAsync(string query);
    }

    public class SearchAppService : ISearchAppService
    {
        private readonly IElasticClient _esClient;

        public SearchAppService(IElasticClient esClient)
        {
            _esClient = esClient;
        }

        public async Task<ISearchResponse<TermPaperElasticModel>> SearchAsync(string query)
        {
            var searchResponse = await _esClient.SearchAsync<TermPaperElasticModel>(s => s
                .Index("term-paper_index")
                .Query(q => q
                    .Match(m => m
                        .Field(a => a.Attachment.Content)
                        .Query(query)
                    )
                )
            );

            return searchResponse;
        }
    }
}
