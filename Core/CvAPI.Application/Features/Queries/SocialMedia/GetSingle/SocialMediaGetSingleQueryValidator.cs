using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetSingle
{
    public class SocialMediaGetSingleQueryValidator:AbstractValidator<SocialMediaGetSingleQueryRequest>
    {
        public SocialMediaGetSingleQueryValidator()
        {
            RuleFor(socialMedia => socialMedia.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
