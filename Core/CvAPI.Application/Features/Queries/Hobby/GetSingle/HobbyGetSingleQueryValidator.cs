using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetSingle
{
    public class HobbyGetSingleQueryValidator:AbstractValidator<HobbyGetSingleQueryRequest>
    {
        public HobbyGetSingleQueryValidator()
        {
            RuleFor(hobby => hobby.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
