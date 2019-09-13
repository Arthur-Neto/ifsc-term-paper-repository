using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperFileConfiguration : IEntityTypeConfiguration<TermPaperFile>
    {
        public void Configure(EntityTypeBuilder<TermPaperFile> builder)
        {
            builder.ToTable("TermPaperFiles", "dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("TermPaperFileID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FileName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.TermPaperData)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.TermPaperFileType)
                .HasColumnName("TermPaperFileTypeID")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(x => x.TermPaper)
                .WithMany()
                .HasForeignKey(x => x.TermPaperID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
