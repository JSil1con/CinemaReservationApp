﻿using System;
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
        public SeatsConfirmation()
        {
            InitializeComponent();
        }

        private void ConfirmButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ReservationRadioButton.IsChecked == true)
            {
                
            }
            else if (SellRadioButton.IsChecked == true)
            {

            }
            else if (UnavailableRadioButton.IsChecked == true)
            {

            }
        }
    }
}
