using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Validation> validations { get; set; }
        public DbSet<Component> components { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
