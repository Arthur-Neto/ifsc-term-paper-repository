using ifsc.tcc.Portal.Domain.FeatureExampleModule;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Context
{
    public class IFSCContext : DbContext
    {
        public IFSCContext(DbContextOptions<IFSCContext> options)
            : base(options)
        { }

        public DbSet<FeatureExample> FeaturesExamples { get; set; }
    }
}
