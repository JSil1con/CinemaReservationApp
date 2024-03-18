using System;
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
        }

        private Button CreateSeat()
        {
            Button button = new Button();
            button.Background = Brushes.Red;
            return button;
        }
    }
}
