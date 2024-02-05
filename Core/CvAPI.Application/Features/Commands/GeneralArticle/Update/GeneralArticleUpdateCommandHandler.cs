using CvAPI.Application.Repositories.CvPartRepositories;
using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Update
{
    public class GeneralArticleUpdateCommandHandler : IRequestHandler<GeneralArticleUpdateCommandRequest, GeneralArticleUpdateCommandResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        private readonly IGeneralArticleWriteRepository _generalArticleWriteRepository;
        private readonly ICvPartReadRepository _cvPartReadRepository;
        public GeneralArticleUpdateCommandHandler(IGeneralArticleReadRepository generalArticleReadRepository,IGeneralArticleWriteRepository generalArticleWriteRepository,ICvPartReadRepository cvPartReadRepository)
        {
            _generalArticleReadRepository= generalArticleReadRepository;
            _generalArticleWriteRepository= generalArticleWriteRepository;
            _cvPartReadRepository= cvPartReadRepository;

        }
        public async Task<GeneralArticleUpdateCommandResponse> Handle(GeneralArticleUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.GeneralArticle article = await _generalArticleReadRepository.GetSingleAsync(article=>article.CvPartId==request.CvPartId && article.Id!=request.Id,false);
            if (article != null)
                throw new BadRequestException("Bu Bölüme Daha Önceden Yazı Tanımlanmış");

            Domain.Entities.CvPart cvPart = await _cvPartReadRepository.GetSingleAsync(cp => cp.Id == request.CvPartId,false);
            if (cvPart == null)
                throw new BadRequestException("Cv Bölümü Bulunamadı");

            article=await _generalArticleReadRepository.GetByIdAsync(request.Id,false);
            if (article == null)
                throw new BadRequestException("Yazı Bulunamadı");

            article.CvPartId=request.CvPartId;
            article.Article = request.Article;

            bool result = _generalArticleWriteRepository.Update(article);
            await _generalArticleWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
