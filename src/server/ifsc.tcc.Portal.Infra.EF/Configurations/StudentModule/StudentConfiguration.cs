using ifsc.tcc.Portal.Domain.StudentModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.StudentModule
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("StudentID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsUnicode(false)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.RegistrationNumber)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
