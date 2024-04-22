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
        private Dictionary<int, SeatModel> _seats = new Dictionary<int, SeatModel>();
        private List<int> _selectedSeats = new List<int>();
        private Dictionary<int, Button> _buttons = new Dictionary<int, Button>();
        public int CountOfSeats { get; }
        private DatabaseController _database = new DatabaseController("database.db");
        private int _cinemaId;
        private string _cinemaName;
        private MainWindow _mainWindow;

        public Cinema(int rows, int columns, Grid grid, string cinemaName, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _cinemaName = cinemaName;

            // Get seats and cinema id
            Task.Run(async () =>
            {
                await InitializeAsync();
            });

            // Create row definitions
            for (int i = 0; i < rows; i++)
            {
                RowDefinition tempRow = new RowDefinition();
                grid.RowDefinitions.Add(tempRow);
            }

            // Create column definitions
            for (int i = 0; i < columns; i++)
            {
                ColumnDefinition tempColumn = new ColumnDefinition();
                grid.ColumnDefinitions.Add(tempColumn);
            }

            // Add confirm button
            grid.RowDefinitions.Add(new RowDefinition());
            Button confirmButton = new Button();
            confirmButton.Content = "Confirm";
            confirmButton.Click += ConfirmSeats;
            Grid.SetRow(confirmButton, rows);

            // Set column span
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

            Thread.Sleep(100);

            CountOfSeats = rows * columns;

            int counterId = 0;
            int counterDictionary = 0;

            for (int row = 1; row < rows + 1; row++)
            {
                // Row
                for (int column = 1; column < columns + 1; column++)
                {
                    // Column

                    //Create button
                    Button button = new Button();
                    button.Content = counterId + 1;

                    if (_seats[counterDictionary].SeatStatusId == 1)
                    {
                        // Free
                        button.Background = Brushes.Green;
                    }
                    else if (_seats[counterDictionary].SeatStatusId == 2)
                    {
                        // Reservation
                        button.Background = Brushes.Aqua;
                    }
                    else if (_seats[counterDictionary].SeatStatusId == 3 || _seats[counterDictionary].SeatStatusId == 4)
                    {
                        // Sold or Unavailable
                        button.Background = Brushes.Red;
                    }
                    button.Click += SeatClicked;
                    Grid.SetRow(button, row - 1);
                    Grid.SetColumn(button, column - 1);
                    _buttons.Add(counterDictionary, button);
                    grid.Children.Add(button);
                    counterId++;
                    counterDictionary += 2;
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
            SeatsConfirmation seatConfirmationWindow = new SeatsConfirmation(_selectedSeats);
            seatConfirmationWindow.Show();

            _mainWindow.Close();
        }

        private void SeatClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (e.Source as Button);
            int numberSeat = (Int32.Parse(clickedButton.Content.ToString()) - 1) * 2;

            int idSeat = _seats[numberSeat].Id;

            if (!_selectedSeats.Contains(idSeat))
            {
                //Selected
                _buttons[numberSeat].Background = Brushes.Blue;
                _selectedSeats.Add(idSeat);
            }
            else
            {
                //Not selected
                _buttons[numberSeat].Background = Brushes.Green;
                _selectedSeats.Remove(idSeat);
            }
        }
    }
}
