using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Budget.Models
{
    
        public class UserContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Saving> Savings { get; set; }
            public DbSet<Cash> Cashs { get; set; }
            public DbSet<Cost> Costs { get; set; }
            public DbSet<Category> Categorys { get; set; }
            public UserContext(DbContextOptions<UserContext> options)
                : base(options)
            {
            }
        }
    
}
