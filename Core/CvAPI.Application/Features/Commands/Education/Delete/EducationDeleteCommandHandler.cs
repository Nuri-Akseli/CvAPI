using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.Delete
{
    public class EducationDeleteCommandHandler : IRequestHandler<EducationDeleteCommandRequest, EducationDeleteCommandResponse>
    {
        private readonly IEducationReadRepository _educationReadRepository;
        private readonly IEducationWriteRepository _educationWriteRepository;
        public EducationDeleteCommandHandler(IEducationReadRepository educationReadRepository,IEducationWriteRepository educationWriteRepository)
        {
            _educationReadRepository= educationReadRepository;
            _educationWriteRepository= educationWriteRepository;

        }
        public async Task<EducationDeleteCommandResponse> Handle(EducationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Education education = await _educationReadRepository.GetByIdAsync(request.Id, false);

            if (education == null)
                throw new BadRequestException("Eğitim Bulunamadı");

            bool result = await _educationWriteRepository.RemoveAsync(request.Id);
            await _educationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
