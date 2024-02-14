using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.UpdateActivity
{
    public class HobbyUpdateActivityCommandValidator:AbstractValidator<HobbyUpdateActivityCommandRequest>
    {
        public HobbyUpdateActivityCommandValidator()
        {
            RuleFor(hobby => hobby.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(hobby => hobby.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
