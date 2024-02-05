using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Create
{
    public class GeneralArticleCreateCommandValidator:AbstractValidator<GeneralArticleCreateCommandRequest>
    {
        public GeneralArticleCreateCommandValidator()
        {
            RuleFor(article => article.Article)
                .NotEmpty()
                .NotNull()
                .WithName("Yazı");

            RuleFor(article => article.CvPartId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölüm Id");
        }
    }
}
