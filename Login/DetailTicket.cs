using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class DetailTicket : Form
    {
        public DetailTicket()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            lblMovieTitle.Text = OrderData.MovieTitle ?? "N/A";
            lblStudio.Text = OrderData.Studio ?? "N/A";
            lblShowTime1.Text = OrderData.ShowTime ?? "N/A";
            lblDate.Text = OrderData.Date ?? "N/A";
            lblSeatNumber.Text = OrderData.SeatNumber ?? "N/A";
            lblPaymentMethod.Text = OrderData.PaymentMethod ?? "N/A";
            lblPrice.Text = OrderData.TotalPrice ?? "N/A";
            lblTicketCount.Text = $"{OrderData.TicketCount} Ticket(s)"; // Tampilkan jumlah tiket
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Gunakan konstruktor Menu dengan status admin
            Menu menu = new Menu(isAdmin: true); // Pastikan admin tetap diteruskan
            menu.Show();
            this.Hide();
        }

        private void lblTicket_Click(object sender, EventArgs e)
        {

        }
    }
}
