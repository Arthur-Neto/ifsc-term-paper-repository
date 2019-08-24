using ifsc.tcc.Portal.Domain.FeatureExampleModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories.FeaturesExamplesModule
{
    public class FeaturesExamplesRepository : GenericRepository<FeatureExample>, IFeatureExampleRepository
    {
        public FeaturesExamplesRepository(IFSCContext context)
            : base(context)
        { }
    }
}
