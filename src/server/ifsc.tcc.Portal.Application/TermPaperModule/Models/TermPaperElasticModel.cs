using Nest;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Models
{
    public class TermPaperElasticModel
    {
        public string Path { get; set; }
        public string Content { get; set; }
        public Attachment Attachment { get; set; }
    }
}
