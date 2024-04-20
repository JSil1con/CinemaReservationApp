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
        public SeatsConfirmation()
        {
            InitializeComponent();
        }

        private void checkedRadioButton(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            _selectedOption = radioButton.Content.ToString();
        }

        private void buttonSeatConfirmation(object sender, RoutedEventArgs e)
        {

        }
    }
}
