using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.Delete
{
    public class ProjectDeleteCommandHandler:IRequestHandler<ProjectDeleteCommandRequest, ProjectDeleteCommandResponse>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        private readonly IProjectWriteRepository _projectWriteRepository;
        public ProjectDeleteCommandHandler(IProjectReadRepository projectReadRepository,IProjectWriteRepository projectWriteRepository)
        {
            _projectReadRepository = projectReadRepository;
            _projectWriteRepository = projectWriteRepository;

        }

        public async Task<ProjectDeleteCommandResponse> Handle(ProjectDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Project project = await _projectReadRepository.GetByIdAsync(request.Id,false);

            if (project == null)
                throw new BadRequestException("Proje Bulunamadı");

            bool result= await _projectWriteRepository.RemoveAsync(request.Id);
            await _projectWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
