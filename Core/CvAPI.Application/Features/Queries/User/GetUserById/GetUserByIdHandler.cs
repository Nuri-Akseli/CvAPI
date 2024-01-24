using CvAPI.Application.Repositories.UserRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace CvAPI.Application.Features.Queries.User.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        IUserReadRepository _userReadRepository;
        public GetUserByIdHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {

            
           
            var data = await _userReadRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                throw new BadRequestException("User Bulunamadı");

            return new ()
            {
                Id = data.Id,
                IsActive = data.IsActive,
                Password = data.Password,
                UserName = data.UserName
            }; ;

        }
    }
}
