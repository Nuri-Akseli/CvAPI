﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.Hobby.Delete
{
    public class HobbyDeleteCommandRequest:IRequest<HobbyDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
