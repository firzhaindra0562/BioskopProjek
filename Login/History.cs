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
            if (!GlobalHistory.HistoryItems.Any(existingItem =>
                existingItem.Text == item.Text &&
                existingItem.SubItems[1].Text == item.SubItems[1].Text &&
                existingItem.SubItems[2].Text == item.SubItems[2].Text &&
                existingItem.SubItems[3].Text == item.SubItems[3].Text))
            {
                GlobalHistory.HistoryItems.Add(item);
                lvwHistory.Items.Add((ListViewItem)item.Clone());
                UpdateTotalPendapatan();
            }
        }

        private void History_Load(object sender, EventArgs e)
        {
            lvwHistory.Columns.Clear();
            lvwHistory.View = View.Details;
            lvwHistory.FullRowSelect = true;
            lvwHistory.GridLines = true;

            lvwHistory.Columns.Add("Movie Title", 300);
            lvwHistory.Columns.Add("Studio", 100);
            lvwHistory.Columns.Add("Show Time", 200);
            lvwHistory.Columns.Add("Date", 200);
            lvwHistory.Columns.Add("Seat Number", 200);
            lvwHistory.Columns.Add("Ticket Count", 200);
            lvwHistory.Columns.Add("Total Price", 300);

            lblTotal.Font = new Font("Times New Roman", 16, FontStyle.Bold);

            LoadHistory();
            UpdateTotalPendapatan();
        }

        private void LoadHistory()
        {
            lvwHistory.Items.Clear();
            foreach (var item in GlobalHistory.HistoryItems)
            {
                lvwHistory.Items.Add((ListViewItem)item.Clone());
            }
            UpdateTotalPendapatan();
        }

        private void btnHapusHistory_Click(object sender, EventArgs e)
        {
            if (lvwHistory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih item untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem selectedItem in lvwHistory.SelectedItems)
            {
                lvwHistory.Items.Remove(selectedItem);

                var itemToRemove = GlobalHistory.HistoryItems.FirstOrDefault(item =>
                    item.Text == selectedItem.Text &&
                    item.SubItems[3].Text == selectedItem.SubItems[3].Text &&
                    item.SubItems[4].Text == selectedItem.SubItems[4].Text);

                if (itemToRemove != null)
                {
                    GlobalHistory.HistoryItems.Remove(itemToRemove);
                }
            }

            MessageBox.Show("Item berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateTotalPendapatan();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            BOOKING menubooking = new BOOKING();
            menubooking.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtNama.Text.Trim();

            // Jika TextBox kosong, tampilkan semua data
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadHistory();
                return;
            }

            // Filter data berdasarkan keyword
            var filteredItems = GlobalHistory.HistoryItems
                .Where(item => item.SubItems.Cast<ListViewItem.ListViewSubItem>()
                                             .Any(subItem => subItem.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            // Bersihkan ListView sebelum menampilkan hasil pencarian
            lvwHistory.Items.Clear();

            // Tampilkan hasil pencarian
            foreach (var item in filteredItems)
            {
                lvwHistory.Items.Add((ListViewItem)item.Clone());
            }

            // Jika tidak ada hasil
            if (filteredItems.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTotalPendapatan()
        {
            decimal totalPendapatan = 0;

            foreach (ListViewItem item in lvwHistory.Items)
            {
                // Hilangkan "Rp" dan pemisah ribuan sebelum parsing
                string totalPriceText = item.SubItems[6].Text.Replace("Rp", "").Replace(".", "").Trim();

                if (decimal.TryParse(totalPriceText, out decimal totalPrice))
                {
                    totalPendapatan += totalPrice;
                }
            }

            lblTotal.Text = $"Total Pendapatan: Rp{totalPendapatan:N}"; // Format dengan pemisah ribuan
        }

    }
}
