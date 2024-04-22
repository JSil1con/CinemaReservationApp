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
            selectOptions.Add("Free", 1);
            selectOptions.Add("Reservation", 2);
            selectOptions.Add("Sold", 3);
            selectOptions.Add("Unavailable", 4);

            int selectedOption = selectOptions[_selectedOption];


            foreach (var seat in _selectedSeats)
            {
                seat.SeatStatusId = selectedOption;
                _database.UpdateAsync(seat);
            }

            this.Close();
        }

        private async Task GetSeats()
        {
            _selectedSeats = await _database.GetSeatsByIds(_selectedSeatsIds);
        }
    }
}
