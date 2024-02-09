using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.UpdateActivity
{
    public class SocialMediaUpdateActivityCommandValidator:AbstractValidator<SocialMediaUpdateActivityCommandRequest>
    {
        public SocialMediaUpdateActivityCommandValidator()
        {
            RuleFor(socialMedia => socialMedia.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(socialMedia => socialMedia.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
