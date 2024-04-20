using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class SeatModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int CinemaId { get; set; }
        public int SeatStatusId { get; set; }
    }
}
