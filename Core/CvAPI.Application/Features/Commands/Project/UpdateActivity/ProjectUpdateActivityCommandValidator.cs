using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.UpdateActivity
{
    public class ProjectUpdateActivityCommandValidator:AbstractValidator<ProjectUpdateActivityCommandRequest>
    {
        public ProjectUpdateActivityCommandValidator()
        {
            RuleFor(project => project.IsActive)
                .NotNull()
                .WithName("Aktiflik");

            RuleFor(project => project.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Proje ID");
        }
    }
}
