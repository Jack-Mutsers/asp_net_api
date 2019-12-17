using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ComponentForCreationDto
    {
        public string name { get; set; }

        public int Categoryid { get; set; }

        public bool status { get; set; }
    }
}
