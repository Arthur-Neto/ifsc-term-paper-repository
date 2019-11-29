using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands
{
    public class TermPaperAddCommand
    {
        public string Title { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string Student1 { get; set; }
        public string Student2 { get; set; }
        public string Advisor { get; set; }
        public string CoAdvisor { get; set; }
        public string Area { get; set; }
        public string Course { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
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

            RuleFor(x => x.Student1)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.Student2)
                .NotEmpty()
                .Length(4, 50)
                .When(x => x.Student2 != null);

            RuleFor(x => x.Advisor)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.CoAdvisor)
                .NotEmpty()
                .Length(4, 50)
                .When(x => x.CoAdvisor != null);

            RuleFor(x => x.Area)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.Course)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.FileName)
                .NotEmpty()
                .Length(4, 50);

            RuleFor(x => x.Keywords)
                .NotEmpty();
        }
    }
}
