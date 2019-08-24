using FluentValidation;
using ifsc.tcc.Portal.Domain.FeatureExampleModule;

namespace ifsc.tcc.Portal.Application.FeatureExampleModule.Models.Commands
{
    public class FeatureExampleAddCommand
    {
        public FeatureExampleEnum FeatureExampleType { get; set; }
    }

    public class FeatureExampleAddCommandCommandValidator : AbstractValidator<FeatureExampleAddCommand>
    {
        public FeatureExampleAddCommandCommandValidator()
        {
            RuleFor(x => x.FeatureExampleType)
                .IsInEnum();
        }
    }
}
