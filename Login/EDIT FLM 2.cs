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
    public partial class EDIT_FILM_2 : Form
    {
        private Menu edit2; // Menyimpan referensi form Menu

        public EDIT_FILM_2(Menu edit2)
        {
            InitializeComponent();
            this.edit2 = edit2; // Menyimpan referensi form Menu
        }
        private void EDIT_FLM_2_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ambil data dari form EDIT_FILM_1
            string judul = txtJudul.Text;
            string genre = txtGenre.Text;
            string durasi = txtDurasi.Text;
            string sutradara = txtSutradara.Text;
            Image gambar = pictureBox1.Image;

            // Kirim data ke form Menu untuk diupdate
            edit2.UpdateFilmInfo2(judul, durasi, sutradara, genre);
            edit2.UpdateGuardianPicture(gambar);

            // Tampilkan pesan sukses
            MessageBox.Show("Data film berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tutup form EDIT_FILM_1 setelah update
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Membuat objek OpenFileDialog untuk memilih gambar
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Filter untuk gambar
            openFileDialog.Title = "Pilih Gambar"; // Judul dialog file

            // Menampilkan dialog dan memeriksa apakah pengguna memilih file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mengambil path file yang dipilih
                string filePath = openFileDialog.FileName;

                try
                {
                    // Mengatur gambar ke PictureBox dan menggunakan StretchImage agar gambar di-stretch
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Setel ukuran gambar agar stretch
                }
                catch
                {
                    // Menangani kemungkinan error jika file tidak valid atau tidak dapat dibuka
                    MessageBox.Show("Gambar tidak valid. Pastikan file gambar dapat dibuka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
