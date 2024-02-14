using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Update
{
    public class HobbyUpdateCommandValidator:AbstractValidator<HobbyUpdateCommandRequest>
    {
        public HobbyUpdateCommandValidator()
        {
            RuleFor(hobby => hobby.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(hobby => hobby.CvPartId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölümü");

            RuleFor(hobby => hobby.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithName("Hobi İsmi");

            RuleFor(hobby => hobby.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");
        }
    }
}
