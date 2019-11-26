using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ComponentContext : DbContext
    {
        public ComponentContext(DbContextOptions<ComponentContext> options) : base(options){}

        public DbSet<ComponentItem> ComponentItems { get; set; }
    }
}
