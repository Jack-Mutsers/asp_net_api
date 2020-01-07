using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ComponentDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public int Categoryid { get; set; }

        public int value { get; set; }

        public string ip_adress { get; set; }

        public int arduino_id { get; set; }

        public bool status { get; set; }


    }
}
