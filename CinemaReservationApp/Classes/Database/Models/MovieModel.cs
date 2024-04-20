using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes.Database.Models
{
    internal class MovieModel
    {
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int CinemaId { get; set; }
        public CinemaModel Cinema { get; set; }
    }
}
