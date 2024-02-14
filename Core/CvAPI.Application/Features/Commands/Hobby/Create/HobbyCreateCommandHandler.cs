using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Create
{
    public class HobbyCreateCommandHandler:IRequestHandler<HobbyCreateCommandRequest, HobbyCreateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IHobbyWriteRepository _hobbyWriteRepository;

        public HobbyCreateCommandHandler(ICvPartReadRepository cvPartReadRepository,IHobbyWriteRepository hobbyWriteRepository)
        {
            _cvPartReadRepository=cvPartReadRepository;
            _hobbyWriteRepository=hobbyWriteRepository;

        }

        public async Task<HobbyCreateCommandResponse> Handle(HobbyCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart==null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            bool result = await _hobbyWriteRepository.AddAsync(new()
            {
                CvPartId = request.CvPartId,
                Name = request.Name,
                Order = request.Order
            });
            await _hobbyWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sorna Tekrar Deneyiniz");

        }
    }
}
