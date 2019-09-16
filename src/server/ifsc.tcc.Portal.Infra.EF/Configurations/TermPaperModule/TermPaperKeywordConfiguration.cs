using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperKeywordConfiguration : IEntityTypeConfiguration<TermPaperKeyword>
    {
        public void Configure(EntityTypeBuilder<TermPaperKeyword> builder)
        {
            builder.ToTable("TermPapers_Keywords");
            builder.HasKey(x => new { x.TermPaperID, x.KeywordID });
        }
    }
}
