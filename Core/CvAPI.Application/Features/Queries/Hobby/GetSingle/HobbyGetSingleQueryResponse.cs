﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Hobby.GetSingle
{
    public class HobbyGetSingleQueryResponse
    {
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
