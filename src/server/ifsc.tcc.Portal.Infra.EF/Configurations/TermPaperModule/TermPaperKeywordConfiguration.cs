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

            builder.HasOne(x => x.TermPaper)
                .WithMany(x => x.TermPaperKeywords)
                .HasForeignKey(x => x.TermPaperID);

            builder.HasOne(x => x.Keyword)
                .WithMany(x => x.TermPaperKeywords)
                .HasForeignKey(x => x.KeywordID);
        }
    }
}
