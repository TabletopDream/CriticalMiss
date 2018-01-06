using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CriticalMiss.Data.Models;

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

        public DbSet<GameBoardDBO> GameBoards { get; set; }
        public DbSet<GameBoardItemDBO> BoardItems { get; set; }

        public DbSet<ImageAssetDBO> ImageAssets { get; set; }
        
        public DbSet<Games> games { get; set; }
    }
}
