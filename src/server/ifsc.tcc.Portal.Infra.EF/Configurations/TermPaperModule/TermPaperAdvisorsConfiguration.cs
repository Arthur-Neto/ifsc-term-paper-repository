using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperAdvisorsConfiguration : IEntityTypeConfiguration<TermPaperAdvisor>
    {
        public void Configure(EntityTypeBuilder<TermPaperAdvisor> builder)
        {
            builder.ToTable("TermPapers_Advisors");
            builder.HasKey(x => new { x.TermPaperID, x.AdvisorID });

            builder.Property(x => x.AdvisorType)
                .HasConversion<int>();

            builder.HasOne(x => x.TermPaper)
                .WithMany(x => x.TermPaperAdvisors)
                .HasForeignKey(x => x.TermPaperID);

            builder.HasOne(x => x.Advisor)
                .WithMany(x => x.TermPaperAdvisors)
                .HasForeignKey(x => x.AdvisorID);
        }
    }
}
