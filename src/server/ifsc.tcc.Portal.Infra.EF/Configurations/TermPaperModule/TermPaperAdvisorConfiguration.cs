using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.TermPaperModule
{
    public class TermPaperAdvisorConfiguration : IEntityTypeConfiguration<TermPaperAdvisor>
    {
        public void Configure(EntityTypeBuilder<TermPaperAdvisor> builder)
        {
            builder.ToTable("TermPapers_Advisors", "dbo");
            builder.HasKey(x => new { x.TermPaperID, x.AdvisorID });

            builder.HasOne(x => x.Advisor)
                .WithMany(x => x.TermPaperAdvisors)
                .HasForeignKey(x => x.AdvisorID);

            builder.HasOne(x => x.TermPaper)
                .WithMany(x => x.TermPaperAdvisors)
                .HasForeignKey(x => x.TermPaperID);
        }
    }
}
