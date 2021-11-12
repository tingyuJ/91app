using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _91app.Models
{
    public class DB91app : DbContext
    {
        public DB91app(DbContextOptions<DB91app> op) : base(op)
        {
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orders>()
                .HasOne(o => o.Products)
                .WithOne(p => p.Orders);
        }
    }
}
