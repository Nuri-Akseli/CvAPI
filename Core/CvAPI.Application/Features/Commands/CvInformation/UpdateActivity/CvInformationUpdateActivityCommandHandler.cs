using CvAPI.Application.Repositories.CvInformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.UpdateActivity
{
    public class CvInformationUpdateActivityCommandHandler:IRequestHandler<CvInformationUpdateActivityCommandRequest, CvInformationUpdateActivityCommandResponse>
    {
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly ICvInformationWriteRepository _cvInformationWriteRepository;
        public CvInformationUpdateActivityCommandHandler(ICvInformationReadRepository cvInformationReadRepository, ICvInformationWriteRepository cvInformationWriteRepository)
        {
            _cvInformationReadRepository= cvInformationReadRepository;
            _cvInformationWriteRepository= cvInformationWriteRepository;
        }

        public async Task<CvInformationUpdateActivityCommandResponse> Handle(CvInformationUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvInformation cvInfo =await _cvInformationReadRepository.GetSingleAsync(info=>info.Id==request.Id);

            if (cvInfo == null)
                throw new BadRequestException("Cv Bilgisi Bulunamadı");

            cvInfo.IsActive = request.Activity;

            bool result = _cvInformationWriteRepository.Update(cvInfo);
            await _cvInformationWriteRepository.SaveAsync();

            if (!result)
                throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

            return new() { };
        }
    }
}
