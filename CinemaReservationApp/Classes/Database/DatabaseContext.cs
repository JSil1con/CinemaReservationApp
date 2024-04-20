using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaReservationApp.Classes.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<MovieModel> Films { get; set; }
        public DbSet<CinemaModel> Cinemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFilePath = "your_database_file_path.sqlite"; // Změňte cestu k vaší SQLite databázi
            optionsBuilder.UseSqlite($"Data Source={dbFilePath}");
        }
    }
}
