using ifsc.tcc.Portal.Domain.GroupModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.GroupModule
{
    public class GroupFileConfiguration : IEntityTypeConfiguration<GroupFile>
    {
        public void Configure(EntityTypeBuilder<GroupFile> builder)
        {
            builder.ToTable("GroupFiles", "dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("GroupFileID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FileData)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.FileName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TermPaper)
                .WithMany()
                .HasForeignKey(x => x.TermPaperID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
