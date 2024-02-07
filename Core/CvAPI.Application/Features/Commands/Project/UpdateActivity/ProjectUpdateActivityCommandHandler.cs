using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace CvAPI.Application.Features.Commands.Project.UpdateActivity
{
    public class ProjectUpdateActivityCommandHandler:IRequestHandler<ProjectUpdateActivityCommandRequest, ProjectUpdateActivityCommandResponse>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        private readonly IProjectWriteRepository _projectWriteRepository;
        public ProjectUpdateActivityCommandHandler(IProjectReadRepository projectReadRepository,IProjectWriteRepository projectWriteRepository)
        {
            _projectReadRepository = projectReadRepository;
            _projectWriteRepository= projectWriteRepository;

        }

        public async Task<ProjectUpdateActivityCommandResponse> Handle(ProjectUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Project project = await _projectReadRepository.GetByIdAsync(request.Id,false);

            if (project == null)
                throw new BadRequestException("Proje Bulunamadı");

            project.IsActive = request.IsActive;

            bool result=_projectWriteRepository.Update(project);
            await _projectWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");


        }
    }
}
