﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Project.GetAll
{
    public class ProjectGetAllQueryValidator:AbstractValidator<ProjectGetAllQueryRequest>
    {
        public ProjectGetAllQueryValidator()
        {
            
        }
    }
}
