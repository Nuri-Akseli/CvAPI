﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Certificate.Delete
{
    public class CertificateDeleteCommandRequest:IRequest<CertificateDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
