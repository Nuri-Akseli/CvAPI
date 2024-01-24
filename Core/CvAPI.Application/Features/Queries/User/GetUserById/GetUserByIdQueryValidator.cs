using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.User.GetUserById
{
    public class GetUserByIdQueryValidator:AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(data => data.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
