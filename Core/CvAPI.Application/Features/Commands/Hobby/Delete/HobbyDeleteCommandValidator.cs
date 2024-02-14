using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Delete
{
    public class HobbyDeleteCommandValidator:AbstractValidator<HobbyDeleteCommandRequest>
    {
        public HobbyDeleteCommandValidator()
        {
            RuleFor(hobby => hobby.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Hobi Id");
        }
    }
}
