﻿using FluentValidation;
using ifsc.tcc.Portal.Domain.FeatureExampleModule;

namespace ifsc.tcc.Portal.Application.FeatureExampleModule.Models.Commands
{
    public class FeatureExampleUpdateCommand
    {
        public int ID { get; set; }
        public FeatureExampleEnum FeatureExampleType { get; set; }
    }

    public class FeatureExampleUpdateCommandValidator : AbstractValidator<FeatureExampleUpdateCommand>
    {
        public FeatureExampleUpdateCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.FeatureExampleType)
                .IsInEnum();
        }
    }
}
