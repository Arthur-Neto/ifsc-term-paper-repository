using System;
using System.IO;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using Nest;

namespace ifsc.tcc.Portal.Application.ElasticModule
{
    public interface IIndexAppService
    {
        Task<CreateIndexResponse> CreateTermPaperIndexAsync();
        Task<bool> IsIndexCreatedAsync(string indexName);
        Task<IndexResponse> IndexTermPaperFileAsync(string filePath);
    }

    public class IndexAppService : IIndexAppService
    {
        private readonly IElasticClient _esClient;

        public IndexAppService(IElasticClient esClient)
        {
            _esClient = esClient;
        }

        public async Task<CreateIndexResponse> CreateTermPaperIndexAsync()
        {
            var indexResponse = await _esClient.Indices.CreateAsync("termPaper_index", c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(ad => ad
                            .Custom("windows_path_hierarchy_analyzer", ca => ca
                                .Tokenizer("windows_path_hierarchy_tokenizer")
                            )
                        )
                        .Tokenizers(t => t
                            .PathHierarchy("windows_path_hierarchy_tokenizer", ph => ph
                                .Delimiter('\\')
                            )
                        )
                    )
                )
                .Map<TermPaperElasticModel>(mp => mp
                    .AutoMap()
                    .Properties(ps => ps
                        .Text(s => s
                            .Name(n => n.Path)
                            .Analyzer("windows_path_hierarchy_analyzer")
                        )
                        .Object<Attachment>(a => a
                            .Name(n => n.Attachment)
                            .AutoMap()
                        )
                    )
                )
            );


            await _esClient.Ingest.PutPipelineAsync("termPaper_pipeline", p => p
                .Processors(pr => pr
                    .Attachment<TermPaperElasticModel>(a => a
                      .Field(f => f.Content)
                      .TargetField(f => f.Attachment)
                    )
                )
            );

            return indexResponse;
        }

        public async Task<bool> IsIndexCreatedAsync(string indexName)
        {
            var index = await _esClient.Indices.ExistsAsync(indexName);

            return index.Exists;
        }

        public async Task<IndexResponse> IndexTermPaperFileAsync(string filePath)
        {
            var base64File = Convert.ToBase64String(File.ReadAllBytes(filePath));
            var indexReturn = await _esClient.IndexAsync(new TermPaperElasticModel
            {
                Path = filePath,
                Content = base64File
            }, i => i
                .Index("termPaper_index")
                .Pipeline("termPaper_pipeline")
                .Timeout("5m")
            );

            return indexReturn;
        }
    }
}
