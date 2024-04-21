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
    /// Interakční logika pro SelectCinema.xaml
    /// </summary>
    public partial class SelectCinema : Window
    {
        private Database _database = new Database("database.db");
        public SelectCinema()
        {
            InitializeComponent();

            ViewCinemasAsync();
        }

        private async void ViewCinemasAsync()
        {
            List<CinemaModel> cinemas = await _database.GetCinemasAsync();

            int row = 0;

            foreach (var cinema in cinemas)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition());
                Button cinemaButton = new Button();
                cinemaButton.Content = cinema.Name;
                cinemaButton.Click += buttonClicked;
                Grid.SetRow(cinemaButton, row);
                Grid.SetColumn(cinemaButton, 0);
                MainGrid.Children.Add(cinemaButton);
                row++;
            }
        }


        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (sender as Button);
            string choosedCinema = (string)clickedButton.Content;

            SelectMovie movieSelectWindow = new SelectMovie(choosedCinema);
            movieSelectWindow.Show();
        }
    }
}
