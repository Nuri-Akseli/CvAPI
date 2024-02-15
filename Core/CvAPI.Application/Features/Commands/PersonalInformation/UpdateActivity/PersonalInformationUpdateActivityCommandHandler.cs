using CvAPI.Application.Repositories.PersonalnformationRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.UpdateActivity
{
    public class PersonalInformationUpdateActivityCommandHandler:IRequestHandler<PersonalInformationUpdateActivityCommandRequest,PersonalInformationUpdateActivityCommandResponse>
    {
        private readonly IPersonalInformationReadRespository _personalInformationReadRespository;
        private readonly IPersonalInformationWriteRepository _personalInformationWriteRepository;

        public PersonalInformationUpdateActivityCommandHandler(IPersonalInformationReadRespository personalInformationReadRespository,IPersonalInformationWriteRepository personalInformationWriteRepository)
        {
            _personalInformationReadRespository= personalInformationReadRespository;
            _personalInformationWriteRepository= personalInformationWriteRepository;

        }

        public async Task<PersonalInformationUpdateActivityCommandResponse> Handle(PersonalInformationUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.PersonalInformation personalInformation = await _personalInformationReadRespository.GetByIdAsync(request.Id, false);

            if (personalInformation == null)
                throw new BadRequestException("Kişisel Bilgi Bulunamadı");

            personalInformation.IsActive = request.IsActive;

            bool result = _personalInformationWriteRepository.Update(personalInformation);
            await _personalInformationWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
