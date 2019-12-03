using FluentValidation;

namespace ifsc.tcc.Portal.Application.AdvisorModule.Models.Commands
{
    public class AuthenticateCommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .Length(4, 100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(4, 100);
        }
    }
}
