using CinemaReservationApp.Views;
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

            grid.RowDefinitions.Add(new RowDefinition());
            Button confirmButton = new Button();
            confirmButton.Content = "Confirm selection";
            confirmButton.Click += ConfirmSeats;
            Grid.SetRow(confirmButton, rows);

            if (columns % 2 == 0)
            {
                Grid.SetColumn(confirmButton, columns / 2 - 1);
                Grid.SetColumnSpan(confirmButton, 2);
            }
            else
            {
                Grid.SetColumn(confirmButton, columns / 2);
            }

            grid.Children.Add(confirmButton);


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

        private void ConfirmSeats(object sender, RoutedEventArgs e)
        {
            SeatsConfirmation seatConfirmationWindow = new SeatsConfirmation();
            seatConfirmationWindow.Show();
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
