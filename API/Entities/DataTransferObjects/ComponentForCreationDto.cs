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

        public int value { get; set; } = 0;

        public string ip_adress { get; set; }

        public int arduino_id { get; set; }

        public bool status { get; set; }
    }
}
