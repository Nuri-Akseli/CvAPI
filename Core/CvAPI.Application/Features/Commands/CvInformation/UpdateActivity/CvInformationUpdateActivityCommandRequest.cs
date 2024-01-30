﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.CvInformation.UpdateActivity
{
    public class CvInformationUpdateActivityCommandRequest:IRequest<CvInformationUpdateActivityCommandResponse>
    {
        public int Id { get; set; } = 0;
        public bool Activity { get; set; }=false;
    }
}
