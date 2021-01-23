using System;
using JamsRecords.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JamsRecords
{
    class Bands
    {
        public int Id { get; set; }
        public string Bandname { get; set; }
        public string CountryOfOrigin { get; set; }
        public string NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public string IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
    }
    class JamsRecordsContext : DatabaseContext
    {
        public DbSet<Band> Bands { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=JamsRecords");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");

        }
    }
}
