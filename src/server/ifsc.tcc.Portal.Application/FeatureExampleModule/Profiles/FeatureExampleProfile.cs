using AutoMapper;
using ifsc.tcc.Portal.Application.FeatureExampleModule.Models.Commands;
using ifsc.tcc.Portal.Domain.FeatureExampleModule;

namespace ifsc.tcc.Portal.Application.FeatureExampleModule.Profiles
{
    public class FeatureExampleProfile : Profile
    {
        public FeatureExampleProfile()
        {
            CreateMap<FeatureExampleAddCommand, FeatureExample>()
                .ForMember(fe => fe.FeatureExampleType, fe => fe.MapFrom(cmd => cmd.FeatureExampleType));

            CreateMap<FeatureExampleUpdateCommand, FeatureExample>()
                .ForMember(fe => fe.ID, fe => fe.MapFrom(cmd => cmd.ID))
                .ForMember(fe => fe.FeatureExampleType, fe => fe.MapFrom(cmd => cmd.FeatureExampleType));

            CreateMap<int, FeatureExample>()
                .ForMember(fe => fe.ID, fe => fe.MapFrom(id => id));
        }
    }
}
