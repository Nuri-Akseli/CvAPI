using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Delete
{
    public class CvPartDeleteCommandValidator:AbstractValidator<CvPartDeleteCommandRequest>
    {
        public CvPartDeleteCommandValidator()
        {
            RuleFor(cvPart => cvPart.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölümü");
        }
    }
}
