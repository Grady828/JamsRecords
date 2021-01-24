using System;
using JamsRecords.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace JamsRecords
{
    public class JamsRecordsContext : DbContext
    {
        public DbSet<Bands> Bands { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Songs> Songs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=JamsRecords");


        }
    }
}