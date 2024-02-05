﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.GeneralArticle.UpdateActivity
{
    public class GeneralArticleUpdateActivityCommandRequest:IRequest<GeneralArticleUpdateActivityCommandResponse>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
