using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using assignment2.Models;

namespace assignment2.Data
{
    public class AutoServiceDbContext : DbContext
    {
        public AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<assignment2.Models.Appointment> Appointment { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.id);
        }

    }
}
