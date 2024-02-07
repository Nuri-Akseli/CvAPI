using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.Create
{
    public class ProjectCreateCommandValidator:AbstractValidator<ProjectCreateCommandRequest>
    {
        public ProjectCreateCommandValidator()
        {
            RuleFor(project => project.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");

            RuleFor(project => project.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(190)
                .WithName("Proje İsmi");

            RuleFor(project => project.CvPartId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Cv Bölümü");

            RuleFor(project => project.ShortDescription)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500)
                .WithName("Kısa Açıklama");

        }
    }
}
