using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Data
{
    public class CriticalMissDbContext : DbContext
    {
        public CriticalMissDbContext() : base()
        {

        }

        public CriticalMissDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Possibly use Sqlite InMemory
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(model =>
            {
                model.HasAlternateKey(c => c.UserName)
                .HasName("AlternateKey_UserName");
                     
            });
        }

        /** DbSets Go Below Here **/

        public DbSet<User> user { get; set; }
    }
}
