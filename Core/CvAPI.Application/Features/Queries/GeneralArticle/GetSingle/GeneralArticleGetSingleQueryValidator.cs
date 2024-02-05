using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.GeneralArticle.GetSingle
{
    public class GeneralArticleGetSingleQueryValidator:AbstractValidator<GeneralArticleGetSingleQueryRequest>
    {
        public GeneralArticleGetSingleQueryValidator()
        {
            RuleFor(article => article.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id");


        }
    }
}
