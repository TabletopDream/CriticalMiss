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
            
        }

        /** DbSets Go Below Here **/
    }
}
