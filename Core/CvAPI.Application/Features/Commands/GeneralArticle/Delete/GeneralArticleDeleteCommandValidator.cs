using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.Delete
{
    public class GeneralArticleDeleteCommandValidator:AbstractValidator<GeneralArticleDeleteCommandRequest>
    {
        public GeneralArticleDeleteCommandValidator()
        {
            RuleFor(article => article.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
