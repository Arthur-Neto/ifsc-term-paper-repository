using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.FeatureExampleModule
{
    public class FeatureExample : Entity
    {
        public FeatureExampleEnum FeatureExampleType { get; private set; }

        public FeatureExample()
        { }

        public FeatureExample(FeatureExampleEnum featureExampleType)
        {
            FeatureExampleType = featureExampleType;
        }
    }
}
