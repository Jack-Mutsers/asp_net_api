﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class UserForTransferDto
    {
        public Guid id { get; set; }
        public string username { get; set; }
    }
}
