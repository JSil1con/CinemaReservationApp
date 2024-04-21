using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class SeatStatusModel
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [Column("Status")]
        public string Status { get; set; }
    }
}
