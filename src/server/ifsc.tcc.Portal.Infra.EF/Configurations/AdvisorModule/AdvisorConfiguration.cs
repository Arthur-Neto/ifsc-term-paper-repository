using ifsc.tcc.Portal.Domain.AdvisorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.AdvisorModule
{
    public class AdvisorConfiguration : IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {
            builder.ToTable("Advisors", "dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("AdvisorID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Login)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
