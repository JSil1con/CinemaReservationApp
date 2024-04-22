using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class CinemaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column ("Name")]
        public string Name { get; set; }

        [Column ("Rows")]
        public int Rows { get; set; }

        [Column("Columns")]
        public int Columns { get; set; }

        [Ignore]
        public Dictionary<int, SeatModel> Seats { get; set; } = new Dictionary<int, SeatModel>();

        [Ignore]
        public List<MovieModel> Movies { get; set; } = new List<MovieModel>();
    }
}
