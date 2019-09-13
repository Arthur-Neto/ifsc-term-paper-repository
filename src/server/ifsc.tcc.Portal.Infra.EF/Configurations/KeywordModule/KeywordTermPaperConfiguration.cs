using ifsc.tcc.Portal.Domain.KeywordModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.KeywordModule
{
    public class TermPaperKeywordConfiguration : IEntityTypeConfiguration<KeywordTermPaper>
    {
        public void Configure(EntityTypeBuilder<KeywordTermPaper> builder)
        {
            builder.ToTable("Keywords_TermPapers", "dbo");
            builder.HasKey(x => new { x.KeywordID, x.TermPaperID });

            builder.HasOne(x => x.Keyword)
                .WithMany(x => x.KeywordTermPaper)
                .HasForeignKey(x => x.KeywordID);

            builder.HasOne(x => x.TermPaper)
                .WithMany(x => x.KeywordTermPapers)
                .HasForeignKey(x => x.TermPaperID);
        }
    }
}
