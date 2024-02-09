using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.SocialMedia.GetAll
{
    public class SocialMediaGetAllQueryValidator:AbstractValidator<SocialMediaGetAllQueryRequest>
    {
        public SocialMediaGetAllQueryValidator()
        {
            
        }
    }
}
