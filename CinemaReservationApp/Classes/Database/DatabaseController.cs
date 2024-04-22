using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows.Input;
using SQLitePCL;
using static SQLite.TableMapping;

namespace CinemaReservationApp.Classes.Database
{
    internal class DatabaseController
    {
        private SQLiteAsyncConnection _connection;
        public DatabaseController(string path)
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

        public async Task<Dictionary<int, SeatModel>> GetSeatsAsync(int cinemaId)
        {
            var seatsList = await _connection.Table<SeatModel>()
                .Where(s => s.CinemaId == cinemaId)
                .ToListAsync();

            Dictionary<int, SeatModel> seatsDict = new Dictionary<int, SeatModel>();

            int counter = 0;
            foreach (var seat in seatsList)
            {
                seatsDict.Add(counter++, seat);

                counter += 1;
            }

            return seatsDict;
        }

        public async Task<List<MovieModel>> GetMoviesAsync(int cinemaId)
        {
            var movies = await _connection.Table<MovieModel>()
                .Where(m => m.CinemaId == cinemaId)
                .ToListAsync();

            foreach (var movie in movies)
            {
                movie.Cinema.Seats = await GetSeatsAsync(cinemaId);
            }

            return movies;
        }

        public async Task<List<CinemaModel>> GetCinemasAsync()
        {
            var cinemas = await _connection.Table<CinemaModel>().ToListAsync();

            foreach (var cinema in cinemas)
            {
                cinema.Seats = await GetSeatsAsync(cinema.Id);
                cinema.Movies = await GetMoviesAsync(cinema.Id);
            }

            return cinemas;
        }

        public async Task<int> GetCinemaIdByName(string cinemaName)
        {
            var cinema = await _connection.Table<CinemaModel>()
                .Where(s => s.Name == cinemaName).FirstAsync();

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

        public async Task<CinemaModel> GetCinemaById(int cinemaId)
        {

            var cinema = await _connection.Table<CinemaModel>()
                .Where(s => s.Id == cinemaId)
                .FirstOrDefaultAsync();

            return cinema;
        }

        public async Task<SeatModel> GetSeatById(int seatId)
        {
            var seat = await _connection.Table<SeatModel>()
                .Where(s => s.Id == seatId)
                .FirstOrDefaultAsync();

            return seat;
        }

        public async Task<SeatModel> GetSeatByPosition(int row, int column, int cinemaId)
        {
            var seat = await _connection.Table<SeatModel>()
                .Where(s => s.CinemaId == cinemaId)
                .Where(s => s.Column == column)
                .Where(s => s.Row == row)
                .FirstOrDefaultAsync();

            return seat;
        }


        public async Task<List<SeatModel>> GetSeatsByIds(List<int> seatsIds)
        {
            List<SeatModel> seats = new List<SeatModel>();
            foreach (var idSeat in seatsIds)
            {
                SeatModel seat = await _connection.Table<SeatModel>()
                    .Where(s => s.Id == idSeat)
                    .FirstOrDefaultAsync();
                seats.Add(seat);
            }

            return seats;
        }

        public async Task InsertReservation(string fullName, string email, int idSeat)
        {
            var existingReversation = await _connection.Table<ReservationModel>()
                .Where(s => s.FullName == fullName)
                .Where(s => s.Email == email)
                .Where(s => s.SeatId == idSeat)
                .FirstOrDefaultAsync();

            if (existingReversation != null)
            {
                return;
            }

            ReservationModel reservation = new ReservationModel() { FullName = fullName, Email = email, SeatId = idSeat };

            _connection.InsertAsync(reservation);
        }
    }
}
