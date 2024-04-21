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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaReservationApp.Classes;
using CinemaReservationApp.Classes.Database;
using CinemaReservationApp.Classes.Database.Models;

namespace CinemaReservationApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cinema _cinema;
        private DatabaseController _database = new DatabaseController("database.db");
        public MainWindow(string selectedMovie, string selectedCinema)
        {
            InitializeComponent();

            ViewSeats(selectedMovie, selectedCinema);
        }

        private async void ViewSeats(string selectedMovie, string selectedCinema)
        {
            int cinemaId = await _database.GetCinemaIdByName(selectedCinema);

            CinemaModel cinemaModel = await _database.GetCinemaById(cinemaId);

            Cinema cinema = new Cinema(cinemaModel.Rows, cinemaModel.Columns, MainGrid, selectedCinema);
        }
    }
}
