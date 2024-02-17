using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.LanguageRepositories;
using CvAPI.Application.Repositories.PartCategoryRepositories;
using CvAPI.Application.Repositories.SocialMediaRepositories;
using CvAPI.Application.Repositories.WorkExperienceRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetListByLanguageCode
{
    public class WorkExperienceGetListByLanguageCodeQueryHandler:IRequestHandler<WorkExperienceGetListByLanguageCodeQueryRequest,WorkExperienceGetListByLanguageCodeQueryResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        private readonly IPartCategoryReadRepository _partCategoryReadRepository;
        private readonly IWorkExperienceReadRepositoy _workExperienceReadRepositoy;

        public WorkExperienceGetListByLanguageCodeQueryHandler(ILanguageReadRepository languageReadRepository,
        ICvPartReadRepository cvPartReadRepository,
        IPartCategoryReadRepository partCategoryReadRepository,
        IWorkExperienceReadRepositoy workExperienceReadRepositoy)
        {
            _cvPartReadRepository = cvPartReadRepository;
            _languageReadRepository = languageReadRepository;
            _partCategoryReadRepository = partCategoryReadRepository;
            _workExperienceReadRepositoy = workExperienceReadRepositoy;

        }

        public async Task<WorkExperienceGetListByLanguageCodeQueryResponse> Handle(WorkExperienceGetListByLanguageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Language language = await _languageReadRepository.GetSingleAsync(lang => lang.IsActive == true && lang.Code == request.LanguageCode, false);

            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");
            Domain.Entities.PartCategory partCategory = await _partCategoryReadRepository.GetSingleAsync(part => part.Name == "İş Tecrübesi");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(part => part.IsActive == true && part.CvInformation.LanguageId == language.Id && part.PartCategoryId == partCategory.Id, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            var data = _workExperienceReadRepositoy.GetWhere(workExperience => workExperience.IsActive == true && workExperience.CvPartId == cvPart.Id, false)
                .OrderBy(w => w.Order)
                .Select(w => new
                {
                    w.City,
                    w.Company,
                    w.EndDate,
                    w.StartDate,
                    w.ShortDescription,
                    w.Title
                }).ToList();

            return new()
            {
                WorkExperiences = data,
                IconName=cvPart.IconName,
                IconPath=cvPart.IconPath,
                Name = cvPart.Name
            };
        }
    }
}
