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

namespace CvAPI.Application.Features.Commands.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;
        readonly ITokenHandler _tokenHandler;
        public RefreshTokenLoginCommandHandler(IUserReadRepository userReadRepository, ITokenHandler tokenHandler, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _tokenHandler = tokenHandler;
            _userWriteRepository = userWriteRepository;

        }
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user=await _userReadRepository.GetSingleAsync(u=>u.RefreshToken==request.RefreshToken);

            if (user != null && user.RefreshTokenEndDate > DateTime.Now)
            {


                (string Token, DateTime Expires) accessToken = _tokenHandler.CreateAccessToken(30);
                (string Token, DateTime Expires) refreshToken = _tokenHandler.CreateRefreshToken(accessToken.Expires,15);


                _userWriteRepository.UpdateRefreshToken(refreshToken.Token, user, refreshToken.Expires);
                await _userWriteRepository.SaveAsync();
                return new()
                {
                    AccessToken = accessToken.Token,
                    Expires=accessToken.Expires,
                    RefreshToken = refreshToken.Token
                };
            }
            throw new BadRequestException("Geçersiz Token");


        }
    }
}
