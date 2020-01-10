﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CategoryForUpdateDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public string icon { get; set; }
    }
}
