using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(user => user.UserName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(255)
                .WithName("Kullanıcı Adı");

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(255)
                .WithName("Şifre");
        }
    }
}
