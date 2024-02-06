using CvAPI.Application.Repositories.EducationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Education.UpdateActivity
{
    public class EducationUpdateActivityCommandHandler : IRequestHandler<EducationUpdateActivityCommandRequest, EducationUpdateActivityCommandResponse>
    {
        private readonly IEducationReadRepository _educationReadRepository;
        private readonly IEducationWriteRepository _educationWriteRepository;
        public EducationUpdateActivityCommandHandler(IEducationReadRepository educationReadRepository,IEducationWriteRepository educationWriteRepository)
        {
            _educationReadRepository=educationReadRepository;
            _educationWriteRepository=educationWriteRepository;

        }
        public async Task<EducationUpdateActivityCommandResponse> Handle(EducationUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Education education = await _educationReadRepository.GetByIdAsync(request.Id,false);

            if (education == null)
                throw new BadRequestException("Eğitim Bulunamadı");

            education.IsActive = request.IsActive;

            bool result = _educationWriteRepository.Update(education);
            await _educationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar deneyiniz");


        }
    }
}
