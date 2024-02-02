using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.UpdateActivity
{
    public class CvPartUpdateActivityCommandValidator:AbstractValidator<CvPartUpdateActivityCommandRequest>
    {
        public CvPartUpdateActivityCommandValidator()
        {
            RuleFor(cvPart => cvPart.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölümü");

            RuleFor(cvPart => cvPart.IsActive)
                .NotEmpty()
                .NotNull()
                .WithName("Aktiflik");
        }
    }
}
