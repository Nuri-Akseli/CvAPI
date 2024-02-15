using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Create
{
    public class PersonalInformationCreateCommandValidator:AbstractValidator<PersonalInformationCreateCommandRequest>
    {
        public PersonalInformationCreateCommandValidator()
        {
            RuleFor(personalInformation => personalInformation.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            RuleFor(personalInformation => personalInformation.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(190)
                .WithName("Tanım");

            RuleFor(personalInformation => personalInformation.CvPartId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölüm Id");
        }
    }
}
