using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LogItem
    {
        [Key]
        public long log_id { get; set; }

        public string comp_Name { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
    }
}
