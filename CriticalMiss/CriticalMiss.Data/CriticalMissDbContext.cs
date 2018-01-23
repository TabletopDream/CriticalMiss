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
            modelBuilder.Entity<Boards>(entity =>
            {
                entity.HasOne(b => b.Game)
                      .WithMany(g => g.Boards)
                      .HasForeignKey(b => b.GameName)
                      .HasPrincipalKey(g => g.GameName);
            });
        }

        /** DbSets Go Below Here **/


        public DbSet<Boards> Boards { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<ImageAssetDBO> ImageAssets { get; set; }

    }
}
