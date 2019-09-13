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
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DateBegin)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.DateEnd)
                .HasColumnType("DATETIME");

            builder.HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
