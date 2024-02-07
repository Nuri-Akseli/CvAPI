using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.Update
{
    public class ProjectUpdateCommandHandler:IRequestHandler<ProjectUpdateCommandRequest, ProjectUpdateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IProjectReadRepository _projectReadRepository;
        private readonly IProjectWriteRepository _projectWriteRepository;
        public ProjectUpdateCommandHandler(ICvPartReadRepository cvPartReadRepository,IProjectReadRepository projectReadRepository,IProjectWriteRepository projectWriteRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _projectReadRepository=projectReadRepository;
            _projectWriteRepository=projectWriteRepository;

        }

        public async Task<ProjectUpdateCommandResponse> Handle(ProjectUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.Project project = await _projectReadRepository.GetByIdAsync(request.Id,false);

            if (project == null)
                throw new BadRequestException("Proje Bulunamadı");

            project.CvPartId=request.CvPartId;
            project.Order = request.Order;
            project.ShortDescription = request.ShortDescription;
            project.Name = request.Name;
            project.Link = request.Link;

            bool result = _projectWriteRepository.Update(project);
            await _projectWriteRepository.SaveAsync();

            if (result)
                return new();
            
            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
