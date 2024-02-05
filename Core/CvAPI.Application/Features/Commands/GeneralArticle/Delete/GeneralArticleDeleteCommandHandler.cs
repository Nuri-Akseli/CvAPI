using CvAPI.Application.Repositories.GeneralArticleRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Delete
{
    public class GeneralArticleDeleteCommandHandler : IRequestHandler<GeneralArticleDeleteCommandRequest, GeneralArticleDeleteCommandResponse>
    {
        private readonly IGeneralArticleReadRepository _generalArticleReadRepository;
        private readonly IGeneralArticleWriteRepository _generalArticleWriteRepository;
        public GeneralArticleDeleteCommandHandler(IGeneralArticleReadRepository generalArticleReadRepository,IGeneralArticleWriteRepository generalArticleWriteRepository)
        {
            _generalArticleReadRepository = generalArticleReadRepository;
            _generalArticleWriteRepository = generalArticleWriteRepository;

        }
        public async Task<GeneralArticleDeleteCommandResponse> Handle(GeneralArticleDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.GeneralArticle article =await _generalArticleReadRepository.GetByIdAsync(request.Id,false);
            if (article == null)
                throw new BadRequestException("Yazı Bulunamadı");

            bool result = await _generalArticleWriteRepository.RemoveAsync(request.Id);
            await _generalArticleWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");

        }
    }
}
