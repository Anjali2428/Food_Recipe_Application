using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookingAppMVC.Models;

namespace CookingAppMVC.Data
{
    public class gdshDbContext : DbContext
    {
        public gdshDbContext (DbContextOptions<gdshDbContext> options)
            : base(options)
        {
        }

        public DbSet<CookingAppMVC.Models.Admin> Admin { get; set; } = default!;
    }
}
