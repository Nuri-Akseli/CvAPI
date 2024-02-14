using CvAPI.Application.Repositories.HobbyRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.UpdateActivity
{
    public class HobbyUpdateActivityCommandHandler:IRequestHandler<HobbyUpdateActivityCommandRequest,HobbyUpdateActivityCommandResponse>
    {
        private readonly IHobbyReadRepository _hobbyReadRepository;
        private readonly IHobbyWriteRepository _hobbyWriteRepository;

        public HobbyUpdateActivityCommandHandler(IHobbyReadRepository hobbyReadRepository,IHobbyWriteRepository hobbyWriteRepository)
        {
            _hobbyReadRepository= hobbyReadRepository;
            _hobbyWriteRepository= hobbyWriteRepository;
        }

        public async Task<HobbyUpdateActivityCommandResponse> Handle(HobbyUpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Hobby hobby = await _hobbyReadRepository.GetByIdAsync(request.Id, false);

            if (hobby == null)
                throw new BadRequestException("Hobi Bulunamadı");

            hobby.IsActive = request.IsActive;

            bool result = _hobbyWriteRepository.Update(hobby);
            await _hobbyWriteRepository.SaveAsync();

            if (result)
                return new();

            throw new BadRequestException("Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz");
        }
    }
}
