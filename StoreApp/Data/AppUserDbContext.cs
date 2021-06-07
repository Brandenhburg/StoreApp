using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data
{
    public class AppUSerDbContext : IdentityDbContext<AppUser>
    {
        public AppUSerDbContext(DbContextOptions<AppUSerDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
