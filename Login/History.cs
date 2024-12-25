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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();

        }
        public void AddItemToListView(ListViewItem item)
        {
            // Cek jika item sudah ada di GlobalHistory
            if (!GlobalHistory.HistoryItems.Any(existingItem =>
                existingItem.Text == item.Text &&
                existingItem.SubItems[1].Text == item.SubItems[1].Text &&
                existingItem.SubItems[2].Text == item.SubItems[2].Text &&
                existingItem.SubItems[3].Text == item.SubItems[3].Text))
            {
                GlobalHistory.HistoryItems.Add(item); // Tambahkan hanya jika belum ada
            }
        }
        private void History_Load(object sender, EventArgs e)
        {
          
                // Bersihkan kolom sebelumnya (jika ada)
                lvwHistory.Columns.Clear();

                // Tambahkan kolom ke ListView
                lvwHistory.Columns.Add("Movie Title", 300);    // Kolom untuk judul film
                lvwHistory.Columns.Add("Studio", 100);         // Kolom untuk studio
                lvwHistory.Columns.Add("Show Time", 200);      // Kolom untuk waktu tayang
                lvwHistory.Columns.Add("Date", 200);           // Kolom untuk tanggal
                lvwHistory.Columns.Add("Seat Number", 200);    // Kolom untuk nomor kursi
                lvwHistory.Columns.Add("Ticket Count", 200);   // Kolom untuk jumlah tiket
                lvwHistory.Columns.Add("Total Price", 300);    // Kolom untuk total harga

                // Atur mode tampilan ke Details agar kolom terlihat
                lvwHistory.View = View.Details;
                lvwHistory.FullRowSelect = true;  // Memungkinkan baris dipilih sepenuhnya
                lvwHistory.GridLines = true;      // Tambahkan garis antar baris untuk kejelasan

                // Muat data dari GlobalHistory ke ListView tanpa duplikasi
                lvwHistory.Items.Clear(); // Pastikan list kosong sebelum diisi ulang
                foreach (var item in GlobalHistory.HistoryItems)
                {
                    lvwHistory.Items.Add((ListViewItem)item.Clone());
                }
            }
            

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
