using CvAPI.Application.Abstractions.Storage;
using CvAPI.Application.Repositories.CvInformationRepositories;
using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvPart.Update
{
    public class CvPartUpdateCommandHandler : IRequestHandler<CvPartUpdateCommandRequest, CvPartUpdateCommandResponse>
    {
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly ICvPartWriteRepository _cvPartWriteRepository;
        private readonly IStorageService _storageService;
        private readonly ICvInformationReadRepository _cvInformationReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        public CvPartUpdateCommandHandler(
            ICvPartReadRepository cvPartReadRepository,
            ICvPartWriteRepository cvPartWriteRepository,
            IStorageService storageService,
            ICvInformationReadRepository cvInformationReadRepository,
            IPartCategoryReadRepository partCategoryReadRepository)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _cvPartWriteRepository = cvPartWriteRepository;
            _storageService = storageService;
            _cvInformationReadRepository = cvInformationReadRepository;
            _partCategoryReadRepository= partCategoryReadRepository;
        }
        public async Task<CvPartUpdateCommandResponse> Handle(CvPartUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvInformation cvInformation = await _cvInformationReadRepository.GetSingleAsync(info => info.Id == request.CvInformationId, false);

            if (cvInformation == null)
                throw new BadRequestException("Geçersiz Cv Bilgisi");

            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetByIdAsync(request.PartCategoryId, false);
            if(partCategory==null)
                throw new BadRequestException("Geçersiz Bölüm Kategorisi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.CvInformationId == request.CvInformationId && part.Name == request.Name && part.Id!=request.Id && part.PartCategoryId==request.PartCategoryId,false);
            if (cvPart != null)
                throw new BadRequestException("Bu Cv için Bu İsimde Bölüm Mevcut");

            cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.Id == request.Id);
            (string fileName, string path) icon = new();
            if (request.Icon != null)
            {
                if (cvPart.IconName != null)
                    _storageService.Delete(cvPart.IconPath, cvPart.IconName);
                icon = await _storageService.UploadSingleAsync("images\\icons", request.Icon);
            }
            cvPart.IsContactInfo = request.IsContactInfo;
            cvPart.Name = request.Name;
            cvPart.IconPath=icon.path!=null?icon.path:null;
            cvPart.IconName=icon.fileName!=null?icon.fileName:null;
            cvPart.CvInformationId = request.CvInformationId;
            cvPart.Order=request.Order;
            bool result= _cvPartWriteRepository.Update(cvPart);

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
               
        }
    }
}
