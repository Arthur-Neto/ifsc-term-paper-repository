using ifsc.tcc.Portal.Domain.CourseModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.CoursesModule
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("CourseID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
