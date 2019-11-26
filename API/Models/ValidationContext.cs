using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ValidationContext : DbContext
    {
        public ValidationContext(DbContextOptions<ValidationContext> options) : base(options){}

        public DbSet<ValidationItem> ValidationItems { get; set; }
    }
}
