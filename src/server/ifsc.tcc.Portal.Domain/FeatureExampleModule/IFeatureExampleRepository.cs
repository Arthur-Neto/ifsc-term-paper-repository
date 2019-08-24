using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.FeatureExampleModule
{
    public interface IFeatureExampleRepository :
        GetRepository<FeatureExample>,
        AddRepository<FeatureExample>,
        RemoveRepository<FeatureExample>,
        UpdateRepository<FeatureExample>
    { }
}
