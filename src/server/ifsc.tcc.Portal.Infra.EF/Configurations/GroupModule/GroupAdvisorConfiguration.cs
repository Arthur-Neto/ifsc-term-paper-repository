using ifsc.tcc.Portal.Domain.GroupModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.GroupModule
{
    public class GroupAdvisorConfiguration : IEntityTypeConfiguration<GroupAdvisor>
    {
        public void Configure(EntityTypeBuilder<GroupAdvisor> builder)
        {
            builder.ToTable("Groups_Advisors");
            builder.HasKey(x => new { x.AdvisorID, x.GroupID, x.AdvisorType });

            builder.Property(x => x.AdvisorType)
                .HasColumnName("AdvisorTypeID")
                .IsRequired();

            builder.HasOne(x => x.Advisor)
                .WithMany()
                .HasForeignKey(x => x.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupAdvisors)
                .HasForeignKey(x => x.GroupID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
