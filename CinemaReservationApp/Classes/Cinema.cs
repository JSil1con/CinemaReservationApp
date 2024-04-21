using CinemaReservationApp.Classes.Database;
using CinemaReservationApp.Classes.Database.Models;
using CinemaReservationApp.Views;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static SQLite.TableMapping;

namespace CinemaReservationApp.Classes
{
    internal class Cinema
    {
        private List<SeatModel> _seats = new List<SeatModel>();
        private List<int> _selectedSeats = new List<int>();
        public int CountOfSeats { get; }
        private DatabaseController _database = new DatabaseController("database.db");
        private int _cinemaId;
        private string _cinemaName;
        private TaskCompletionSource<Button> _buttonCompletionSource = new TaskCompletionSource<Button>();

        public Cinema(int rows, int columns, Grid grid, string cinemaName)
        {
            _cinemaName = cinemaName;

            Task.Run(async () =>
            {
                await InitializeAsync();
            });

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

            int counter = 0;

            Thread.Sleep(500);

            for (int row = 1; row < rows + 1; row++)
            {
                for (int column = 1; column < columns + 1; column++)
                {
                    Button button = new Button();
                    button.Content = counter + 1;
                    if (_seats[counter].SeatStatusId == 1)
                    {
                        // Free
                        button.Background = Brushes.Green;
                    }
                    else if (_seats[counter].SeatStatusId == 2)
                    {
                        // Reservation
                        button.Background = Brushes.Blue;
                    }
                    else if (_seats[counter].SeatStatusId == 3 || _seats[counter].SeatStatusId == 4)
                    {
                        // Sold or Unavailable
                        button.Background = Brushes.Red;
                    }
                    button.Click += SeatClicked;
                    Grid.SetRow(button, row - 1);
                    Grid.SetColumn(button, column - 1);
                    grid.Children.Add(button);
                    counter++;
                }
            }

        }

        private async Task InitializeAsync()
        {
            _cinemaId = await _database.GetCinemaIdByName(_cinemaName);
            _seats = await _database.GetSeatsAsync(_cinemaId);
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

        private async void GetSeats()
        {
            _seats = await _database.GetSeatsAsync(_cinemaId);
        }
    }
}
