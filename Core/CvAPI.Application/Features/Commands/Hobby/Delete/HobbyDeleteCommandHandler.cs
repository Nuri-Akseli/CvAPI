using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Delete
{
    public class HobbyDeleteCommandHandler:IRequestHandler<HobbyDeleteCommandRequest, HobbyDeleteCommandResponse>
    {
        private readonly IHobbyReadRepository _hobbyReadRepository;
        private readonly IHobbyWriteRepository _hobbyWriteRepository;
        public HobbyDeleteCommandHandler(IHobbyReadRepository hobbyReadRepository,IHobbyWriteRepository hobbyWriteRepository)
        {
            _hobbyReadRepository = hobbyReadRepository;
            _hobbyWriteRepository= hobbyWriteRepository;

        }

        public async Task<HobbyDeleteCommandResponse> Handle(HobbyDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Hobby hobby = await _hobbyReadRepository.GetByIdAsync(request.Id, false);

            if (hobby == null)
                throw new BadRequestException("Hobi Bulunamadı");

            bool result = _hobbyWriteRepository.Remove(hobby);
            await _hobbyWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
