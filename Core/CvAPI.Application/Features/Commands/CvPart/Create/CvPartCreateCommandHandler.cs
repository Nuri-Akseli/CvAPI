using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Create
{
    public class CvPartCreateCommandHandler : IRequestHandler<CvPartCreateCommandRequest, CvPartCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ICvPartWriteRepository _cvPartWriteRepository;
        private readonly IStorageService _storageService;
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        public CvPartCreateCommandHandler(
            ICvPartReadRepository cvPartReadRepository,
            ICvPartWriteRepository cvPartWriteRepository,
            IStorageService storageService,
            ICvInformationReadRepository cvInformationReadRepository
            )
        {
            _cvPartReadRepository=cvPartReadRepository;
            _cvPartWriteRepository=cvPartWriteRepository;
            _storageService=storageService;
            _cvInformationReadRepository=cvInformationReadRepository;

        }
        public async Task<CvPartCreateCommandResponse> Handle(CvPartCreateCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.CvInformation cvInformation = await _cvInformationReadRepository.GetSingleAsync(info => info.Id == request.CvInformationId,false);

            if (cvInformation == null)
                throw new BadRequestException("Geçersiz Cv Bilgisi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.CvInformationId == request.CvInformationId && part.Name==request.Name);
            if (cvPart != null)
                throw new BadRequestException("Bu Cv için Bu İsimde Bölüm Mevcut");


            (string fileName, string path) icon = new();
            if (request.Icon != null)
                icon = await _storageService.UploadSingleAsync("images\\icons", request.Icon);

            bool result = await _cvPartWriteRepository.AddAsync(new()
            {
                CvInformationId = request.CvInformationId,
                IconName = icon.fileName != null ? icon.fileName : null,
                IconPath = icon.path != null ? icon.path : null,
                IsContactInfo = request.IsContactInfo,
                Name = request.Name,
                Order = request.Order
            });

            await _cvPartWriteRepository.SaveAsync();

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
