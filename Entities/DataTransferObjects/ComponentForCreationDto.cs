﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ComponentForCreationDto
    {
        public string comp_name { get; set; }

        public int cat_id { get; set; }

        public bool alarm_status { get; set; }
    }
}
