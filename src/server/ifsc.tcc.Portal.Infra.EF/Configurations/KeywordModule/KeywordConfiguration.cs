using ifsc.tcc.Portal.Domain.KeywordModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.KeywordModule
{
    public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.ToTable("Keywords");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("KeywordID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Value)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.TermPaperKeywords)
                .WithOne(x => x.Keyword)
                .HasForeignKey(x => x.KeywordID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
