using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetListByCategoryName
{
    public class CvPartGetListByCategoryNameQueryValidator:AbstractValidator<CvPartGetListByCategoryNameQueryRequest>
    {
        public CvPartGetListByCategoryNameQueryValidator()
        {
            RuleFor(cvPart => cvPart.CategoryName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(190)
                .WithName("Kategori İsmi");
        }
    }
}
