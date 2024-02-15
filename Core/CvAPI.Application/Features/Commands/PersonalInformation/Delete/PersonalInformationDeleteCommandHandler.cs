using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Delete
{
    public class PersonalInformationDeleteCommandHandler:IRequestHandler<PersonalInformationDeleteCommandRequest,PersonalInformationDeleteCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;
        private readonly IPersonalInformationWriteRepository _personalInformationWriteRepository;

        public PersonalInformationDeleteCommandHandler(IStorageService storageService,IPersonalInformationReadRespository personalInformationReadRespository, IPersonalInformationWriteRepository personalInformationWriteRepository)
        {
            _storageService= storageService;
            _personalInformationReadRespository= personalInformationReadRespository;
            _personalInformationWriteRepository= personalInformationWriteRepository;
        }

        public async Task<PersonalInformationDeleteCommandResponse> Handle(PersonalInformationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.PersonalInformation personalInformation = await _personalInformationReadRespository.GetByIdAsync(request.Id, false);

            if (personalInformation == null)
                throw new BadRequestException("Kişisel Bilgi Bulunamadı");

            if (personalInformation.IconName != null)
                _storageService.Delete(personalInformation.IconPath, personalInformation.IconName);

            bool result = _personalInformationWriteRepository.Remove(personalInformation);
            await _personalInformationWriteRepository.SaveAsync();

            if (result)
                return new();
            throw new BadRequestException("Bir Hata Oluştu Lüften Daha Sonra Tekrar Deneyiniz");
        }
    }
}
