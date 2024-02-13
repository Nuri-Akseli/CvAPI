using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Create
{
    public class WorkExperienceCreateCommandValidator:AbstractValidator<WorkExperienceCreateCommandRequest>
    {
        public WorkExperienceCreateCommandValidator()
        {
            RuleFor(workExperience => workExperience.Company)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .WithName("Şirket");

            RuleFor(workExperience => workExperience.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .WithName("Ünvan");

            RuleFor(workExperience => workExperience.City)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .WithName("Şehir");

            RuleFor(workExperience => workExperience.StartDate)
                .NotNull()
                .NotEmpty()
                .WithName("Başlangıç Tarihi");

            RuleFor(workExperience => workExperience.CvPartId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölümü");

            RuleFor(workExperience => workExperience.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            
        }
    }
}
