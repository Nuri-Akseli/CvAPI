using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Create
{
    public class SocialMediaCreateCommandHandler:IRequestHandler<SocialMediaCreateCommandRequest, SocialMediaCreateCommandResponse>
    {
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IStorageService _storageService;
        public SocialMediaCreateCommandHandler(ISocialMediaWriteRepository socialMediaWriteRepository,ICvPartReadRepository cvPartReadRepository, IStorageService storageService)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _socialMediaWriteRepository=socialMediaWriteRepository;
            _storageService=storageService;
        }

        public async Task<SocialMediaCreateCommandResponse> Handle(SocialMediaCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);

            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            (string fileName, string path) icon = new();

            if (request.Icon != null)
            {
                icon = await _storageService.UploadSingleAsync("images\\socialmedias", request.Icon);
            }

            bool result = await _socialMediaWriteRepository.AddAsync(new()
            {
                CvPartId=request.CvPartId,
                IconName=icon.fileName,
                IconPath=icon.path,
                Order=request.Order,
                Url=request.Url
            });

            await _socialMediaWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
