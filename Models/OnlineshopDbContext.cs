using Microsoft.EntityFrameworkCore;
using SinglePageApplication.Models.DomainModels;
using System;

namespace SinglePageApplication.Models
{
    public class OnlineshopDbContext : DbContext
    {
        public OnlineshopDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
