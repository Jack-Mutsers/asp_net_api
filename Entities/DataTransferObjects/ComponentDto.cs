using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ComponentDto
    {
        public int comp_id { get; set; }

        public string comp_name { get; set; }

        public int cat_id { get; set; }

        public bool alarm_status { get; set; }

        public string cat_name { get; set; }


    }
}
