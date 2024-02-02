using CvAPI.Application.Repositories.CvPartRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.UpdateActivity
{
    public class CvPartUpdateActivityCommandHandler : IRequestHandler<CvPartUpdateActivityCommandRequest, CvPartUpdateActivityCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ICvPartWriteRepository _cvPartWriteRepository;
        public CvPartUpdateActivityCommandHandler(
            ICvPartReadRepository cvPartReadRepository,
            ICvPartWriteRepository cvPartWriteRepository
            )
        {
            _cvPartReadRepository = cvPartReadRepository;
            _cvPartWriteRepository = cvPartWriteRepository;

        }
        public async Task<CvPartUpdateActivityCommandResponse> Handle(CvPartUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.Id == request.Id, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            cvPart.IsActive = request.IsActive;
            bool result= _cvPartWriteRepository.Update(cvPart);

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lüften daha Sonra Tekrar Deneyiniz");
        }
    }
}
