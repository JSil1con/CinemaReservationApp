using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CinemaReservationApp.Classes.Database
{
    internal class Database
    {
        private SQLiteAsyncConnection _connection;
        public Database(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
        }
    }
}
