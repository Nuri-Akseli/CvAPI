using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.ProjectRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Project.Create
{
    public class ProjectCreateCommandHandler:IRequestHandler<ProjectCreateCommandRequest, ProjectCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IProjectWriteRepository _projectWriteRepository;
        public ProjectCreateCommandHandler(ICvPartReadRepository cvPartReadRepository, IProjectWriteRepository projectWriteRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _projectWriteRepository = projectWriteRepository;

        }

        public async Task<ProjectCreateCommandResponse> Handle(ProjectCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _projectWriteRepository.AddAsync(new()
            {
                CvPartId=request.CvPartId,
                Link=request.Link,
                Name=request.Name,
                Order=request.Order,
                ShortDescription=request.ShortDescription
            });
            await _projectWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
