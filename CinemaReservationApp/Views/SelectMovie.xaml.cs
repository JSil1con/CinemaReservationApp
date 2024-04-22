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
        private DatabaseController _database = new DatabaseController("database.db");
        private string _cinemaName;
        public SelectMovie(string selectedCinema)
        {
            InitializeComponent();
            ViewMovies(selectedCinema);

            _cinemaName = selectedCinema;
        }

        private async void ViewMovies(string selectedCinema)
        {
            List<MovieModel> movies = await _database.GetMoviesByCinemaName(selectedCinema);

            MainListView.ItemsSource = movies;

            MainListView.MouseDoubleClick += SelectedMovieClicked;
        }

        private void SelectedMovieClicked(object sender, RoutedEventArgs e)
        {
            MovieModel selectedMovie = (sender as ListView).SelectedItem as MovieModel;

            // Ověření, zda byl vybrán film
            if (selectedMovie != null)
            {
                MainWindow mainwindow = new MainWindow(selectedMovie.Name, _cinemaName);
                mainwindow.Show();
            }
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
