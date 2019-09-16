using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperConfiguration : IEntityTypeConfiguration<TermPaper>
    {
        public void Configure(EntityTypeBuilder<TermPaper> builder)
        {
            builder.ToTable("TermPapers");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("TermPaperID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsUnicode(true)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DateBegin)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.DateEnd)
                .HasColumnType("DATETIME");

            builder.Property(x => x.StudentAName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.StudentBName)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.AdvisorName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CoAdvisorName)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.AreaName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CourseName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.TermPaperKeywords)
                .WithOne(x => x.TermPaper)
                .HasForeignKey(x => x.TermPaperID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
