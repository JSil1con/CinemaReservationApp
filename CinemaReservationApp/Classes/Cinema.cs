﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaReservationApp.Classes
{
    internal class Cinema
    {
        public Dictionary<RowDefinition, List<ColumnDefinition>> Seats { get; } = new Dictionary<RowDefinition, List<ColumnDefinition>>();
        public int CountOfSeats;
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
            return button;
        }
    }
}
