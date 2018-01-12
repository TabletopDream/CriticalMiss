using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.WebService.Data.Models;

namespace CriticalMiss.WebService.Data
{
    public class CriticalMissDbContext : DbContext
    {
        public CriticalMissDbContext() : base()
        {

        }
        public CriticalMissDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Possibly use Sqlite InMemory
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<TableTopGames> tabletopgames { get; set; }

    }
}
