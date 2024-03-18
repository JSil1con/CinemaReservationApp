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
        public Cinema(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition tempRow = new RowDefinition();
                List<ColumnDefinition> tempList = new List<ColumnDefinition>();
                for (int j = 0; j < columns; j++)
                {
                    ColumnDefinition tempColumnDefinition = new ColumnDefinition();
                    tempList.Add(tempColumnDefinition);
                }
                Seats.Add(tempRow, tempList);
            }
        }
    }
}
