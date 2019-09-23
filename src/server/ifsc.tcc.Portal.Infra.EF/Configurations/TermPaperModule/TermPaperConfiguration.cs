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

            builder.Property(x => x.FileName)
                .IsUnicode(true)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TermPaperKeywords)
                .WithOne(x => x.TermPaper)
                .HasForeignKey(x => x.TermPaperID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
