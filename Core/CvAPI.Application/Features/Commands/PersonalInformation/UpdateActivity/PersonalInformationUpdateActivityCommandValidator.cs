using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.UpdateActivity
{
    public class PersonalInformationUpdateActivityCommandValidator:AbstractValidator<PersonalInformationUpdateActivityCommandRequest>
    {
        public PersonalInformationUpdateActivityCommandValidator()
        {
            RuleFor(personalInfromation => personalInfromation.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(personalInformation => personalInformation.IsActive)
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
