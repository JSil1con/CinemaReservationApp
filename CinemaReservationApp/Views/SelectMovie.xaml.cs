using CinemaReservationApp.Classes.Database;
using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaReservationApp.Views
{
    /// <summary>
    /// Interakční logika pro SelectMovie.xaml
    /// </summary>
    public partial class SelectMovie : Window
    {
        private Database _database = new Database("database.db");
        public SelectMovie(string selectedCinema)
        {
            InitializeComponent();
            ViewMovies(selectedCinema);
        }

        private async void ViewMovies(string selectedCinema)
        {
            List<MovieModel> movies = await _database.GetMoviesByCinemaName(selectedCinema);

            foreach (MovieModel movie in movies)
            {
                MainListView.Items.Add(new ListViewItem { Name = movie.Name, Date = movie.Date });
            }
        }
    }

    public class ListViewItem
    {
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
