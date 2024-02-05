using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Create
{
    public class GeneralArticleCreateCommandHandler : IRequestHandler<GeneralArticleCreateCommandRequest, GeneralArticleCreateCommandResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        private readonly IGeneralArticleWriteRepository _generalArticleWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public GeneralArticleCreateCommandHandler(IGeneralArticleReadRepository generalArticleReadRepository, IGeneralArticleWriteRepository generalArticleWriteRepository, ICvPartReadRepository cvPartReadRepository)
        {
            _generalArticleReadRepository = generalArticleReadRepository;
            _generalArticleWriteRepository= generalArticleWriteRepository;
            _cvPartReadRepository = cvPartReadRepository;
        }
        public async Task<GeneralArticleCreateCommandResponse> Handle(GeneralArticleCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetByIdAsync(request.CvPartId, false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            Domain.Entities.GeneralArticle article =await _generalArticleReadRepository.GetSingleAsync(article=>article.CvPartId== request.CvPartId,false);

            if (article != null)
                throw new BadRequestException("Bu bölüme Daha Önce Genel Yazı Tanımlanmış");

            bool result = await _generalArticleWriteRepository.AddAsync(new()
            {
                Article=request.Article,
                CvPartId=request.CvPartId
            });
            await _generalArticleWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Sorun Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
