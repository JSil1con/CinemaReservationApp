using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows.Input;

namespace CinemaReservationApp.Classes.Database
{
    internal class Database
    {
        private SQLiteAsyncConnection _connection;
        public Database(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
        }

        public async Task<bool> UpdateAsync<T>(T input)
        {
            var result = await _connection.UpdateAsync(input);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<SeatModel>> GetSeatsAsync(int cinemaId)
        {
            var seats = await _connection.Table<SeatModel>()
            .Where(s => s.CinemaId == cinemaId)
            .ToListAsync();

            return seats;
        }

        //public async Task<List<MovieModel>> GetMoviesAsync(int cinemaId)
        //{
        //    var movies = await _connection.Table<MovieModel>()
        //    .Where(m => m.CinemaId == cinemaId)
        //    .ToListAsync();

        //    foreach (var movie in movies)
        //    {
        //        movie.Cinema.Seats = await GetSeatsAsync(cinemaId);
        //    }

        //    return movies;
        //}

        public async Task<List<CinemaModel>> GetCinemasAsync()
        {
            var cinemas = await _connection.Table<CinemaModel>().ToListAsync();

            foreach (var cinema in cinemas)
            {
                cinema.Seats = await GetSeatsAsync(cinema.Id);
                //cinema.Movies = await GetMoviesAsync(cinema.Id);
            }

            return cinemas;
        }

        public async Task<int> GetCinemaIdByName(string cinemaName)
        {
            var cinema = await _connection.Table<CinemaModel>()
            .Where(s => s.Name == cinemaName).FirstOrDefaultAsync();

            return cinema.Id;
        }

        public async Task<List<MovieModel>> GetMoviesByCinemaName(string cinemaName)
        {
            int cinemaId = await GetCinemaIdByName(cinemaName);

            var cinema = await _connection.Table<MovieModel>()
            .Where(s => s.CinemaId == cinemaId)
            .ToListAsync();

            return cinema;
        }
    }
}
