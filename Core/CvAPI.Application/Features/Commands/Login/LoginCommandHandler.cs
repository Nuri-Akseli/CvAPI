using CvAPI.Application.Abstractions.AccessToken;
using CvAPI.Application.Repositories.UserRepositories;
using CvAPI.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;
        readonly ITokenHandler _tokenHandler;
        public LoginCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, ITokenHandler tokenHandler)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userReadRepository.GetSingleAsync(user => user.UserName == request.UserName && user.Password == request.Password && user.IsActive == true, false);

            if (user == null)
            {
                throw new BadRequestException("Kullanıcı Adı veya Şifre Hatalı");
            }
            (string Token, DateTime Expires) accessToken = _tokenHandler.CreateAccessToken(30);

            (string Token, DateTime Expires) refreshToken = _tokenHandler.CreateRefreshToken(accessToken.Expires, 15);

            _userWriteRepository.UpdateRefreshToken(refreshToken.Token, user, refreshToken.Expires);
            await _userWriteRepository.SaveAsync();

            return new()
            {
                Token = accessToken.Token,
                Expires=accessToken.Expires,
                RefreshToken = refreshToken.Token
            };

        }
    }
}
