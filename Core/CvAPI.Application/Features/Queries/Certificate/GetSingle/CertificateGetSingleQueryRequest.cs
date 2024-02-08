﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetSingle
{
    public class CertificateGetSingleQueryRequest:IRequest<CertificateGetSingleQueryResponse>
    {
        public int Id { get; set; }
    }
}
