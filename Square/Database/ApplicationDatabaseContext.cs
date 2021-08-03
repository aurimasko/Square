using Microsoft.EntityFrameworkCore;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Database
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<List> Lists { get; set; }
        public DbSet<Point> Points {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>().HasMany(p => p.Points).WithOne(l => l.List).HasForeignKey(l => l.ListId).OnDelete(DeleteBehavior.Cascade);
 
            base.OnModelCreating(modelBuilder);

        }
    }
}
