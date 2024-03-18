using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes
{
    internal class Film
    {
        public Guid Uuid { get; }
        public string Name { get; }
        public DateTime Date { get; }
        public Cinema Cinema { get; }

        public Film(Guid uuid, string name, DateTime date, Cinema cinema)
        {
            Uuid = uuid;
            Name = name;
            Date = date;
            Cinema = cinema;
        }
    }
}
