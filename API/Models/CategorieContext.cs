using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class CategorieContext : DbContext
    {
        public CategorieContext(DbContextOptions<CategorieContext> options) : base(options){}

        public DbSet<CategorieItem> CategorieItems { get; set; }
    }
}
