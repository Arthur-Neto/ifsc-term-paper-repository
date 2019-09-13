using System;
using System.Collections.Generic;
using FluentValidation;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands
{
    public class TermPaperAddCommand
    {
        public string Title { get; set; }
        public int AreaID { get; set; }
        public int CourseID { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int AdvisorID { get; set; }
        public int CoAdvisorID { get; set; }
        public int StudentAID { get; set; }
        public int StudentBID { get; set; }
        public IEnumerable<string> Keywords { get; set; }
        public string File { get; set; }
    }

    public class TermPaperAddCommandCommandValidator : AbstractValidator<TermPaperAddCommand>
    {
        public TermPaperAddCommandCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(4, 100);

            RuleFor(x => x.AreaID)
                .NotEmpty();

            RuleFor(x => x.CourseID)
                .NotEmpty();

            RuleFor(x => x.DateBegin)
                .NotEmpty();

            RuleFor(x => x.DateEnd)
                .NotEmpty();

            RuleFor(x => x.AdvisorID)
                .NotEmpty();

            RuleFor(x => x.CoAdvisorID)
                .NotEmpty()
                .When(x => x.CoAdvisorID > 0);

            RuleFor(x => x.StudentAID)
                .NotEmpty();

            RuleFor(x => x.StudentBID)
                .NotEmpty()
                .When(x => x.StudentBID > 0);

            RuleFor(x => x.Keywords)
                .NotEmpty();

            RuleFor(x => x.File)
                .NotEmpty();
        }
    }
}
