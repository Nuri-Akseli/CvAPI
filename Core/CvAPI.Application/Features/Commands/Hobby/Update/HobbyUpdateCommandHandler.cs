using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Update
{
    public class HobbyUpdateCommandHandler:IRequestHandler<HobbyUpdateCommandRequest, HobbyUpdateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IHobbyReadRepository _hobbyReadRepository;
        private readonly IHobbyWriteRepository _hobbyWriteRepository;

        public HobbyUpdateCommandHandler(ICvPartReadRepository cvPartReadRepository,IHobbyReadRepository hobbyReadRepository,IHobbyWriteRepository hobbyWriteRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _hobbyReadRepository=hobbyReadRepository;
            _hobbyWriteRepository=hobbyWriteRepository;
        }

        public async Task<HobbyUpdateCommandResponse> Handle(HobbyUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.Hobby hobby = await _hobbyReadRepository.GetByIdAsync(request.Id, false);

            if (hobby == null)
                throw new BadRequestException("Hobi Bulunamadı");


            hobby.CvPartId = request.CvPartId;
            hobby.Order = request.Order;
            hobby.Name = request.Name;

            bool result = _hobbyWriteRepository.Update(hobby);
            await _hobbyWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
