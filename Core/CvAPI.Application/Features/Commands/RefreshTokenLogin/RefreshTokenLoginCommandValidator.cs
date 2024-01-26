using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandValidator:AbstractValidator<RefreshTokenLoginCommandRequest>
    {
        public RefreshTokenLoginCommandValidator()
        {
            RuleFor(token => token.RefreshToken)
                .NotNull()
                .NotEmpty()
                .WithName("Refresh Token");
        }
    }
}
