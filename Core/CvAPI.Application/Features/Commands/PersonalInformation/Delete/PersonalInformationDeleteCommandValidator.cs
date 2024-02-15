using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Delete
{
    public class PersonalInformationDeleteCommandValidator:AbstractValidator<PersonalInformationDeleteCommandRequest>
    {
        public PersonalInformationDeleteCommandValidator()
        {
            RuleFor(personalInformation => personalInformation.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");
        }
    }
}
