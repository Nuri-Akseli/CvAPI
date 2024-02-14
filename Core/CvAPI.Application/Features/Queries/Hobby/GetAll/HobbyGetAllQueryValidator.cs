using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetAll
{
    public class HobbyGetAllQueryValidator:AbstractValidator<HobbyGetAllQueryRequest>
    {
        public HobbyGetAllQueryValidator()
        {
            
        }
    }
}
