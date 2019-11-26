using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CategorieItem
    {
        [Key]
        public long cat_id { get; set; }
        public string cat_name { get; set; }
    }
}
