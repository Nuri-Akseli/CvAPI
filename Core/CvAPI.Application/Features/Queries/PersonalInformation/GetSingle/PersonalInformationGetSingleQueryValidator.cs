using CvAPI.Application.Repositories.PersonalnformationRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.PersonalInformation.GetSingle
{
    public class PersonalInformationGetSingleQueryValidator:AbstractValidator<PersonalInformationGetSingleQueryRequest>
    {
        public PersonalInformationGetSingleQueryValidator()
        {
            RuleFor(personalInformation => personalInformation.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");
        }

    }
}
