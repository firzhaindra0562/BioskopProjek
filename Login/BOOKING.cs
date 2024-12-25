using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class BOOKING : Form
    {
        // Dictionary untuk menyimpan pasangan film dan studio
        private Dictionary<string, string> movieStudioMapping = new Dictionary<string, string>
        {
            { "The Amazing : SPIDER-MAN", "STUDIO 1" },
            { "Artemis Fowl", "STUDIO 2" },
            { "Marvel Guardian of Galaxy", "STUDIO 3" },
            { "The Northman", "STUDIO 4" }
        };

        private int maxSelectableSeats = 0; // Variabel untuk menyimpan jumlah maksimum kursi yang bisa dipilih
        private List<Button> selectedSeats = new List<Button>(); // Daftar kursi yang telah dipilih

        public BOOKING()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Isi ComboBox dengan daftar film
            CmbMovieTitle.Items.AddRange(movieStudioMapping.Keys.ToArray());
            cmbShowTime.Items.AddRange(new string[] { "12:30 PM", "3:30 PM", "7:30 PM" });
            cmbTicket.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            // Loop semua kontrol di dalam form
            foreach (Control control in this.Controls)
            {
                // Cari tombol yang namanya dimulai dengan "button"
                if (control is Button && control.Name.StartsWith("button"))
                {
                    control.Click += new EventHandler(Seat_Click);
                    control.BackColor = Color.Gray; // Set warna default (belum dipilih)
                }
            }

            // Event handler untuk ComboBox MovieTitle
            CmbMovieTitle.SelectedIndexChanged += CmbMovieTitle_SelectedIndexChanged;

            // Event handler untuk ComboBox Ticket
            cmbTicket.SelectedIndexChanged += CmbTicket_SelectedIndexChanged;
        }

        private void CmbTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pastikan nilai tiket valid dan simpan ke maxSelectableSeats
            if (int.TryParse(cmbTicket.SelectedItem?.ToString(), out int ticketCount))
            {
                maxSelectableSeats = ticketCount;

                // Reset pilihan kursi jika jumlah kursi yang dipilih melebihi tiket
                while (selectedSeats.Count > maxSelectableSeats)
                {
                    Button seatToDeselect = selectedSeats.Last();
                    seatToDeselect.BackColor = Color.Gray;
                    selectedSeats.Remove(seatToDeselect);
                }

                UpdateSeatNumberTextBox();
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string seatNumber = clickedButton.Text; // Ambil teks tombol sebagai nomor kursi

                if (clickedButton.BackColor == Color.Green) // Jika kursi sudah dipilih
                {
                    clickedButton.BackColor = Color.Gray; // Reset warna ke default
                    selectedSeats.Remove(clickedButton); // Hapus dari daftar kursi yang dipilih
                }
                else
                {
                    if (selectedSeats.Count < maxSelectableSeats) // Periksa apakah masih bisa memilih kursi
                    {
                        clickedButton.BackColor = Color.Green; // Tandai kursi yang dipilih
                        selectedSeats.Add(clickedButton); // Tambahkan ke daftar kursi yang dipilih
                    }
                    else
                    {
                        MessageBox.Show($"You can only select up to {maxSelectableSeats} seat(s).", "Seat Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                UpdateSeatNumberTextBox();
            }
        }

        private void UpdateSeatNumberTextBox()
        {
            // Update TextBox dengan daftar kursi yang dipilih, dipisahkan dengan koma
            txtSeatNumber.Text = string.Join(", ", selectedSeats.Select(s => s.Text));
        }

        private void CmbMovieTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler jika film dipilih
            if (movieStudioMapping.TryGetValue(CmbMovieTitle.SelectedItem.ToString(), out string studio))
            {
                txtStudio.Text = studio;
            }
        }
        private int CalculateTicketPrice(DateTime selectedDate)
        {
            int weekdayPrice = 30000;
            int weekendPrice = 40000;

            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return weekendPrice;
            }
            else
            {
                return weekdayPrice;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (CmbMovieTitle.SelectedItem == null || string.IsNullOrEmpty(txtSeatNumber.Text) || cmbShowTime.SelectedItem == null || cmbTicket.SelectedItem == null)
            {
                MessageBox.Show("Please complete all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hitung harga tiket
            DateTime selectedDate = DatePicker.Value;
            int ticketPrice = CalculateTicketPrice(selectedDate);
            int ticketCount = int.Parse(cmbTicket.SelectedItem.ToString());
            int totalPrice = ticketPrice * ticketCount;

            // Simpan data ke OrderData (jika diperlukan)
            OrderData.MovieTitle = CmbMovieTitle.SelectedItem.ToString();
            OrderData.Studio = txtStudio.Text;
            OrderData.ShowTime = cmbShowTime.SelectedItem.ToString();
            OrderData.Date = selectedDate.ToString("dd/MM/yyyy");
            OrderData.SeatNumber = txtSeatNumber.Text;
            OrderData.PaymentMethod = "QRIS";
            OrderData.TicketCount = ticketCount;
            OrderData.TotalPrice = $"Rp {totalPrice:N0}";

            // Buat ListViewItem
            ListViewItem listItem = new ListViewItem(CmbMovieTitle.SelectedItem.ToString());
            listItem.SubItems.Add(txtStudio.Text);
            listItem.SubItems.Add(cmbShowTime.SelectedItem.ToString());
            listItem.SubItems.Add(selectedDate.ToString("dd/MM/yyyy"));
            listItem.SubItems.Add(txtSeatNumber.Text);
            listItem.SubItems.Add(ticketCount.ToString());
            listItem.SubItems.Add($"Rp {totalPrice:N0}");

            // Tambahkan data ke GlobalHistory melalui History form
            History historyForm = new History();
            historyForm.AddItemToListView(listItem);

            // Buka form DetailTicket atau History
            DetailTicket detailTicket = new DetailTicket();
            detailTicket.Show();
            this.Hide();

        }

        private void button75_Click(object sender, EventArgs e)
        {
            Menu form3 = new Menu();
            form3.Show();
            this.Hide(); // Tutup Fo
        }
    }
}
