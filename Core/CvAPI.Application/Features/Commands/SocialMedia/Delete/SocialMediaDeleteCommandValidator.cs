using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Delete
{
    public class SocialMediaDeleteCommandValidator:AbstractValidator<SocialMediaDeleteCommandRequest>
    {
        public SocialMediaDeleteCommandValidator()
        {
            RuleFor(socialMedia => socialMedia.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
