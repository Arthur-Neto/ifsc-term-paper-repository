using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperConfiguration : IEntityTypeConfiguration<TermPaper>
    {
        public void Configure(EntityTypeBuilder<TermPaper> builder)
        {
            builder.ToTable("TermPapers", "dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("TermPaperID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DateBegin)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.DateEnd)
                .HasColumnType("DATETIME");

            builder.Property(x => x.StudentAName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.StudentBName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.AdvisorName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CoAdvisorName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.AreaName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CourseName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.TermPaperKeywords)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
