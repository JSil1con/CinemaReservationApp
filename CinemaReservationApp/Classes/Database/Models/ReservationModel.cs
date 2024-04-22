using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class ReservationModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        [Column("SeatId")]
        public int SeatId { get; set; }
    }
}
