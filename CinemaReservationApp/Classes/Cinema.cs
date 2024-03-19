using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaReservationApp.Classes
{
    internal class Cinema
    {
        private Dictionary<int, Seat> _seats = new Dictionary<int, Seat>();
        private List<int> _selectedSeats = new List<int>();
        public int CountOfSeats { get; }
        public Cinema(int rows, int columns, Grid grid)
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition tempRow = new RowDefinition();
                grid.RowDefinitions.Add(tempRow);
            }

            for (int i = 0; i < columns; i++)
            {
                ColumnDefinition tempColumn = new ColumnDefinition();
                grid.ColumnDefinitions.Add(tempColumn);
            }

            CountOfSeats = rows * columns;

            int seatCounter = 1;

            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    _seats.Add(seatCounter, new Seat());
                    Button tempButton = CreateSeat(seatCounter);
                    Grid.SetRow(tempButton, j);
                    Grid.SetColumn(tempButton, k);
                    grid.Children.Add(tempButton);
                    seatCounter++;
                }
            }

        }

        private Button CreateSeat(int id)
        {
            Button button = new Button();
            button.Content = id;
            button.Background = Brushes.Red;
            button.Click += SeatClicked;
            return button;
        }

        private void SeatClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (e.Source as Button);
            int idSeat = Int32.Parse(clickedButton.Content.ToString());
            if (!_selectedSeats.Contains(idSeat))
            {
                clickedButton.Background = Brushes.LightGreen;
                _selectedSeats.Add(idSeat);
            }
            else
            {
                clickedButton.Background = Brushes.Red;
                _selectedSeats.Remove(idSeat);
            }
        }
    }
}
