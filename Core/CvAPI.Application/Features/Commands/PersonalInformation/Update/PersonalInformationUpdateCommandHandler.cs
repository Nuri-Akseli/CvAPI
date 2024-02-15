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

namespace CvAPI.Application.Features.Commands.PersonalInformation.Update
{
    public class PersonalInformationUpdateCommandHandler:IRequestHandler<PersonalInformationUpdateCommandRequest,PersonalInformationUpdateCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;
        private readonly IPersonalInformationWriteRepository _personalInformationWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public PersonalInformationUpdateCommandHandler(IStorageService storageService,IPersonalInformationReadRespository personalInformationReadRespository,IPersonalInformationWriteRepository personalInformationWriteRepository, ICvPartReadRepository cvPartReadRepository)
        {
            _storageService= storageService;
            _personalInformationReadRespository= personalInformationReadRespository;
            _personalInformationWriteRepository= personalInformationWriteRepository;
            _cvPartReadRepository= cvPartReadRepository;
        }

        public async Task<PersonalInformationUpdateCommandResponse> Handle(PersonalInformationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.PersonalInformation personalInformation = await _personalInformationReadRespository.GetByIdAsync(request.Id, false);

            if (personalInformation == null)
                throw new BadRequestException("Kişisel Bilgi Bulunamadı");


            (string fileName, string path) icon = new();
            if (request.Icon != null)
            {
                if(personalInformation.IconName != null)
                    _storageService.Delete(personalInformation.IconPath, personalInformation.IconName);
                icon = await _storageService.UploadSingleAsync("images\\personalinformation", request.Icon);

                personalInformation.IconPath = icon.path;
                personalInformation.IconName = icon.fileName;
            }

            personalInformation.CvPartId = request.CvPartId;
            personalInformation.Order = request.Order;
            personalInformation.Name = request.Name;

            bool result = _personalInformationWriteRepository.Update(personalInformation);
            await _personalInformationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
                     
        }
    }

}
