using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.UpdateActivity
{
    public class GeneralArticleUpdateActivityCommandHandler:IRequestHandler<GeneralArticleUpdateActivityCommandRequest, GeneralArticleUpdateActivityCommandResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        private readonly IGeneralArticleWriteRepository _generalArticleWriteRepository;
        public GeneralArticleUpdateActivityCommandHandler(IGeneralArticleReadRepository generalArticleReadRepository,IGeneralArticleWriteRepository generalArticleWriteRepository)
        {
            _generalArticleReadRepository = generalArticleReadRepository;
            _generalArticleWriteRepository= generalArticleWriteRepository;
        }

        public async Task<GeneralArticleUpdateActivityCommandResponse> Handle(GeneralArticleUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.GeneralArticle article =await _generalArticleReadRepository.GetByIdAsync(request.Id,false);
            if (article == null)
                throw new BadRequestException("Yazı Bulunamadı");

            article.IsActive = request.IsActive;

            bool result = _generalArticleWriteRepository.Update(article);
            await _generalArticleWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
