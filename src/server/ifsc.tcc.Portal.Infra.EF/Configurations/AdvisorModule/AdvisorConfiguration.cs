using ifsc.tcc.Portal.Domain.AdvisorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.AdvisorModule
{
    public class AdvisorConfiguration : IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {
            builder.ToTable("Advisors");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("AdvisorID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Login)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsUnicode(false)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
