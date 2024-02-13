using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.WorkExperience.GetAll
{
    public class WorkExperienceGetAllQueryValidator:AbstractValidator<WorkExperienceGetAllQueryRequest>
    {
        public WorkExperienceGetAllQueryValidator()
        {
            
        }
    }
}
