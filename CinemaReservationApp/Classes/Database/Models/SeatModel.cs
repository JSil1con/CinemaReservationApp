using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class SeatModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column ("Row")]
        public int Row { get; set; }

        [Column ("Column")]
        public int Column { get; set; }

        [Column ("CinemaId")]
        public int CinemaId { get; set; }

        [Column("SeatStatusId")]
        public int SeatStatusId { get; set; }
    }
}
