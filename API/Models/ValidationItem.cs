using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ValidationItem
    {
        [Key]
        public string access_token { get; set; }

        public long user_id { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
