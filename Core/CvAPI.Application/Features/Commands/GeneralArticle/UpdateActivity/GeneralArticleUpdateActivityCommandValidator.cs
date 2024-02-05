using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.UpdateActivity
{
    public class GeneralArticleUpdateActivityCommandValidator:AbstractValidator<GeneralArticleUpdateActivityCommandRequest>
    {
        public GeneralArticleUpdateActivityCommandValidator()
        {
            RuleFor(article => article.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(article => article.IsActive)
                .NotNull()
                .WithName("Aktiflik");

        }
    }
}
