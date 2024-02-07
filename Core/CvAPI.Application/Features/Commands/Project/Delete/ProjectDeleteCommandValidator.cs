using FluentValidation;

namespace CvAPI.Application.Features.Commands.Project.Delete
{
    public class ProjectDeleteCommandValidator:AbstractValidator<ProjectDeleteCommandRequest>
    {
        public ProjectDeleteCommandValidator()
        {
            RuleFor(project => project.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Proje ID");
        }
    }
}
