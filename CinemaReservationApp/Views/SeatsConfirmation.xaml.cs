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
    /// Interakční logika pro SeatsConfirmation.xaml
    /// </summary>
    public partial class SeatsConfirmation : Window
    {
        private string _selectedOption;
        private DatabaseController _database = new DatabaseController("database.db");
        private List<int> _selectedSeatsIds = new List<int>();
        private List<SeatModel> _selectedSeats = new List<SeatModel>();
        public SeatsConfirmation(List<int> selectedSeats)
        {
            InitializeComponent();

            _selectedSeatsIds = selectedSeats;

            //Get selected seats
            GetSeats();
        }


        private void checkedRadioButton(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            _selectedOption = radioButton.Content.ToString();
        }

        private void buttonSeatConfirmation(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> selectOptions = new Dictionary<string, int>();

            //Every option
            selectOptions.Add("Free", 1);
            selectOptions.Add("Reservation", 2);
            selectOptions.Add("Sold", 3);
            selectOptions.Add("Unavailable", 4);

            //Selected option
            int selectedOption = selectOptions[_selectedOption];


            foreach (var seat in _selectedSeats)
            {
                // Update seat status
                seat.SeatStatusId = selectedOption;
                _database.UpdateAsync(seat);
            }

            if (selectedOption == 2)
            {
                // If reservation open reservation form
                ReservationForm reservationFormWindow = new ReservationForm(_selectedSeatsIds);
                reservationFormWindow.Show();
            }

            // Closet the window
            this.Close();
        }

        private async Task GetSeats()
        {
            _selectedSeats = await _database.GetSeatsByIds(_selectedSeatsIds);
        }
    }
}
