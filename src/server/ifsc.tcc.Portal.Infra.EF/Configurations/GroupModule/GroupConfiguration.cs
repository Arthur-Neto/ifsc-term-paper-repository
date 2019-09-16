using ifsc.tcc.Portal.Domain.GroupModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.GroupModule
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("GroupID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
