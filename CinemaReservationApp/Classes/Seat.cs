using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaReservationApp.Classes
{
    internal class Seat
    {
        public int Id { get; }
        public bool isEnabled { get; set; }
        private string _status;
        public string Status
        {
            get
            { 
                return _status; 
            }
            set
            {
                string[] allowedStatus = { "Free", "Reservation", "Sold", "Unavailable"};
                if (allowedStatus.Contains(value))
                {
                    if (value != "Free")
                    {
                        isEnabled = false;
                    }
                    _status = value;
                }
            }
        }

        public Seat(int id)
        {
            Id = id;
            Status = "Free";
            isEnabled = true;
        }
    }
}
