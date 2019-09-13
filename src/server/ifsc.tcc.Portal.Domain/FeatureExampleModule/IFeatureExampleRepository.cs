using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.FeatureExampleModule
{
    public interface IFeatureExampleRepository :
        IGetRepository<FeatureExample>,
        IAddRepository<FeatureExample>,
        IRemoveRepository<FeatureExample>,
        IUpdateRepository<FeatureExample>
    { }
}
