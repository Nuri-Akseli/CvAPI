using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.Update
{
    public class ProjectUpdateCommandValidator:AbstractValidator<ProjectUpdateCommandRequest>
    {
        public ProjectUpdateCommandValidator()
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

            RuleFor(project => project.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Proje Id");
        }
    }
}
