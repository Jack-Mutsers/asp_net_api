using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginItem
    {
        [Key]
        public long user_id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
    }
}
