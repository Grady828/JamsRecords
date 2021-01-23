using System;
using JamsRecords.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using JamsRecords;

namespace Jamsrecords
{
    public class JamRecordsContext : DbContext
    {
        public DbSet<Bands> Bands { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=JamsRecords");
        }
    }
}