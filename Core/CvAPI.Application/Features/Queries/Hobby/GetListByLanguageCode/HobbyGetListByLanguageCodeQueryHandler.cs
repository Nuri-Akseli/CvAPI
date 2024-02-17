using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.EducationRepositories;
using CvAPI.Application.Repositories.HobbyRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetListByLanguageCode
{
    public class HobbyGetListByLanguageCodeQueryHandler:IRequestHandler<HobbyGetListByLanguageCodeQueryRequest,HobbyGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly IHobbyReadRepository _hobbyReadRepository;
        public HobbyGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        IHobbyReadRepository hobbyReadRepository)
        {
            _languageReadRepository = languageReadRepository;
            _cvPartReadRepository = cvPartReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _hobbyReadRepository = hobbyReadRepository;

        }

        public async Task<HobbyGetListByLanguageCodeQueryResponse> Handle(HobbyGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "Hobi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _hobbyReadRepository.GetWhere(hobby => hobby.IsActive == true && hobby.CvPartId == cvPart.Id, false)
                .OrderBy(h => h.Order)
                .Select(h => new
                {
                    h.Name,
                }).ToList();

            return new()
            {
                Hobbies = data,
                IconName=cvPart.IconName,
                Name = cvPart.Name,
                IconPath = cvPart.IconPath
            };
        }
    }
}
