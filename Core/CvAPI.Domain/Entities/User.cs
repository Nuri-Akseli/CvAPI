﻿using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class User :BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
