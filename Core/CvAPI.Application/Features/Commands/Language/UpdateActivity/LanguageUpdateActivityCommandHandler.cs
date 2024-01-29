using CvAPI.Application.Repositories.LanguageRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Language.UpdateActivity
{
    public class LanguageUpdateActivityCommandHandler : IRequestHandler<LanguageUpdateActivityCommandRequest, LanguageUpdateActivityCommandResponse>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        public LanguageUpdateActivityCommandHandler(ILanguageReadRepository languageReadRepository, ILanguageWriteRepository languageWriteRepository)
        {
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
        }
        public async Task<LanguageUpdateActivityCommandResponse> Handle(LanguageUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var language = await _languageReadRepository.GetSingleAsync(lang => lang.Id == request.Id, false);
            if (language == null)
                throw new BadRequestException("Dil Bulunamadı");

            language.IsActive = request.Activity;

            bool result= _languageWriteRepository.Update(language);

            if (result)
                return new() { };

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
