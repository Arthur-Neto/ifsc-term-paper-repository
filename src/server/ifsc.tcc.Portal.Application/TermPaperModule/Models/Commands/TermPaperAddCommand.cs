using System;
using System.Collections.Generic;
using FluentValidation;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands
{
    public class TermPaperAddCommand
    {
        public string Title { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string StudentAName { get; set; }
        public string StudentBName { get; set; }
        public string AdvisorName { get; set; }
        public string CoAdvisorName { get; set; }
        public string AreaName { get; set; }
        public string CourseName { get; set; }
        public string FileName { get; set; }
        public string FileData { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }

    public class TermPaperAddCommandCommandValidator : AbstractValidator<TermPaperAddCommand>
    {
        public TermPaperAddCommandCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(4, 100);

            RuleFor(x => x.DateBegin)
                .NotEmpty();

            RuleFor(x => x.DateEnd)
                .NotEmpty();

            RuleFor(x => x.StudentAName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.StudentBName)
                .NotEmpty()
                .Length(4, 50)
                .When(x => x.StudentBName.Length > 0);

            RuleFor(x => x.AdvisorName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.CoAdvisorName)
                .NotEmpty()
                .Length(4, 50)
                .When(x => x.CoAdvisorName.Length > 0);

            RuleFor(x => x.AreaName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.CourseName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.FileName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.FileData)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Keywords)
                .NotEmpty();
        }
    }
}
