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

namespace CvAPI.Application.Features.Commands.CvPart.Delete
{
    public class CvPartDeleteCommandHandler : IRequestHandler<CvPartDeleteCommandRequest, CvPartDeleteCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ICvPartWriteRepository _cvPartWriteRepository;
        private readonly IStorageService _storageService;
        public CvPartDeleteCommandHandler(
            ICvPartReadRepository cvPartReadRepository,
            ICvPartWriteRepository cvPartWriteRepository,
            IStorageService storageService)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _cvPartWriteRepository = cvPartWriteRepository;
            _storageService = storageService;

        }
        public async Task<CvPartDeleteCommandResponse> Handle(CvPartDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart =await _cvPartReadRepository.GetSingleAsync(part=>part.Id==request.Id,false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            if(cvPart.IconName!=null)
                _storageService.Delete(cvPart.IconPath,cvPart.IconName);

            var result= _cvPartWriteRepository.Remove(cvPart);

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lütfen Tekrar Deneyiniz");
        }

    }
}
