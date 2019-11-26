using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ComponentItem
    {
        [Key]
        public long comp_id { get; set; }

        public string comp_Name { get; set; }
        public long cat_id { get; set; }
        public bool alarm_status { get; set; }
    }
}
