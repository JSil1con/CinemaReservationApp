using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class MovieModel
    {
        [PrimaryKey]
        public string Uuid { get; set; }

        [Column ("Name")]
        public string Name { get; set; }

        [Column ("Date")]
        public string Date { get; set; }

        [Column ("CinemaId")]
        public int CinemaId { get; set; }

        [Ignore]
        public CinemaModel Cinema { get; set; } = new CinemaModel ();
    }
}
