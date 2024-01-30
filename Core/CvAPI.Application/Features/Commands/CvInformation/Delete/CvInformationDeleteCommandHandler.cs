using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvInformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.Delete
{
    public class CvInformationDeleteCommandHandler : IRequestHandler<CvInformationDeleteCommandRequest, CvInformationDeleteCommandResponse>
    {
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly ICvInformationWriteRepository _cvInformationWriteRepository;
        private readonly IStorageService _storageService;
        public CvInformationDeleteCommandHandler(
            ICvInformationReadRepository cvInformationReadRepository,
            ICvInformationWriteRepository cvInformationWriteRepository,
            IStorageService storageService)
        {
            _cvInformationReadRepository = cvInformationReadRepository;
            _cvInformationWriteRepository= cvInformationWriteRepository;
            _storageService= storageService;
        }
        public async Task<CvInformationDeleteCommandResponse> Handle(CvInformationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvInformation cvInfo = await _cvInformationReadRepository.GetSingleAsync(info => info.Id == request.Id,false);

            if (cvInfo == null)
                throw new BadRequestException("Cv Bilgisi Bulunamadı");

            if (cvInfo.ImageName != null)
                _storageService.Delete(cvInfo.ImagePath, cvInfo.ImageName);

            bool result= _cvInformationWriteRepository.Remove(cvInfo);
            await _cvInformationWriteRepository.SaveAsync();

            if (!result)
                throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

            return new() { };
        }
    }
}
