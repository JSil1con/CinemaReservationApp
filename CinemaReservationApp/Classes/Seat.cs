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

        public Seat()
        {
            Status = "Free";
            isEnabled = true;
        }
    }
}
