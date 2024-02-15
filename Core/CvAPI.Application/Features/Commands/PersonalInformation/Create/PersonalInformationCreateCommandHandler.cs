using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Create
{
    public class PersonalInformationCreateCommandHandler:IRequestHandler<PersonalInformationCreateCommandRequest, PersonalInformationCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IStorageService _storageService;
        private readonly IPersonalInformationWriteRepository _personalInformationWriteRepository;

        public PersonalInformationCreateCommandHandler(ICvPartReadRepository cvPartReadRepository,IStorageService storageService,IPersonalInformationWriteRepository personalInformationWriteRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _personalInformationWriteRepository=personalInformationWriteRepository;
            _storageService=storageService;

        }

        public async Task<PersonalInformationCreateCommandResponse> Handle(PersonalInformationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            (string fileName, string path) icon = new();
            if (request.Icon != null)
            {
                icon = await _storageService.UploadSingleAsync("images\\personalinformation", request.Icon);
            }

            bool result = await _personalInformationWriteRepository.AddAsync(new()
            {
                CvPartId = request.CvPartId,
                IconName = icon.fileName != null ? icon.fileName : null,
                IconPath= icon.path != null ? icon.path : null,
                Name=request.Name,
                Order=request.Order
            });

            await _personalInformationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
