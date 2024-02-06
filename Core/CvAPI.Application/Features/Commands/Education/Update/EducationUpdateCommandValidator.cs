using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.Update
{
    public class EducationUpdateCommandValidator:AbstractValidator<EducationUpdateCommandRequest>
    {
        public EducationUpdateCommandValidator()
        {
            RuleFor(education => education.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(education => education.StartDate)
                .NotEmpty()
                .NotNull()
                .WithName("Başlangıç Zamanı");

            RuleFor(education => education.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(190)
                .WithName("Ünvan");

            RuleFor(education => education.University)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(190)
                .WithName("Ünvan");

            RuleFor(education => education.City)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(190)
                .WithName("Ünvan");

            RuleFor(education => education.Department)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(190)
                .WithName("Ünvan");

            RuleFor(education => education.CvPartId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Cv Bölüm Id");
        }
    }
}
