using CinemaReservationApp.Classes.Database;
using CinemaReservationApp.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interakční logika pro ReservationForm.xaml
    /// </summary>
    public partial class ReservationForm : Window
    {
        private DatabaseController _database = new DatabaseController("database.db");
        private List<int> _idsSeats = new List<int>();
        public ReservationForm(List<int> idsSeats)
        {
            InitializeComponent();

            _idsSeats = idsSeats;
        }

        private void SubmitButtonClicked(object sender, RoutedEventArgs e)
        {
            string fullName = fullNameTextBox.Text;
            string email = emailTextBox.Text;

            //Fullname validation
            if (fullName == "")
            {
                return;
            }

            //Mail validation
            try
            {
                MailAddress mailAdress = new MailAddress(email);
            }
            catch
            {
                return;
            }

            //Save each seat status
            foreach (var idSeat in _idsSeats)
            {
                _database.InsertReservation(fullName, email, idSeat);
            }

            //Close the window
            this.Close();
        }
    }
}
