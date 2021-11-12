using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _91app.Models
{
    public class DbContext : DbContext
    {
        public DbContext(DbContextOptions<DbContext> op) : base(op) { }
    }
}
