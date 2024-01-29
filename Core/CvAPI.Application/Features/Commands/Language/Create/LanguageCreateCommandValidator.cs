using FluentValidation;

namespace CvAPI.Application.Features.Commands.Language.Create
{
    public class LanguageCreateCommandValidator:AbstractValidator<LanguageCreateCommandRequest>
    {
        public LanguageCreateCommandValidator()
        {
            RuleFor(language => language.Code)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Kod");
            RuleFor(language => language.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithName("İsim");

        }
    }
}
