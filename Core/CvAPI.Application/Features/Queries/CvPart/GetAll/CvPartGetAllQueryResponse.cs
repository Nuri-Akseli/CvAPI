﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.CvPart.GetAll
{
    public class CvPartGetAllQueryResponse
    {
        public List<Domain.Entities.CvPart> CvParts { get; set; }
    }
}
