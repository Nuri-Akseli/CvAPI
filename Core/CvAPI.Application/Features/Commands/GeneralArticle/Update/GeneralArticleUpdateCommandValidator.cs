using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Update
{
    public class GeneralArticleUpdateCommandValidator:AbstractValidator<GeneralArticleUpdateCommandRequest>
    {
        public GeneralArticleUpdateCommandValidator()
        {
            RuleFor(article => article.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Id");

            RuleFor(article => article.Article)
                .NotEmpty()
                .NotNull()
                .WithName("Yazı");

            RuleFor(article => article.CvPartId)
                .NotEmpty()
                .NotNull()
                .WithName("Cv Bölüm Id");
        }
    }
}
