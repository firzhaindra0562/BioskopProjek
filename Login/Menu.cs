using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Menu : Form
    {

       
        bool sidebarexpand;

        public Menu()
        {
            InitializeComponent();
        }
        private bool isAdmin; // Variabel untuk menyimpan status admin

        public Menu(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin; // Tetapkan status admin
        }

        // In EDIT_FILM.cs
        


        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    sidebarTimer.Stop();
                }
            }

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        

        private void Menu_Load(object sender, EventArgs e)
        {
            // Sembunyikan tombol jika bukan admin
            if (!isAdmin)
            {
                btnHistory.Visible = false; // Sembunyikan tombol History
                btnEditFilm.Visible = false; // Sembunyikan tombol Edit Film
            }
        }
        
        
        public void UpdateFilmInfo1(string judul, string durasi, string sutradara, string genre, Image gambar)
        {
            // Simpan data film ke properti
            lblJudul.Text = judul;
            lblDurasi.Text = durasi;
            lblSutradara.Text = sutradara;
            lblGenre.Text = genre;
            film1.Gambar = gambar;

            // Perbarui tampilan
            lblJudul.Text = judul;
            lblDurasi.Text = durasi;
            lblSutradara.Text = sutradara;
            lblGenre.Text = genre;
            pictureBoxSpiderman.Image = gambar;
            pictureBoxSpiderman.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void UpdateFilmInfo2(string judul, string durasi, string sutradara, string genre)
        {
            label9.Text = judul;
            label8.Text = durasi;
            label2.Text = sutradara;
            label3.Text = genre;
        }

        public void UpdateFilmInfo3(string judul, string durasi, string sutradara, string genre)
        {
            label5.Text = judul;
            label13.Text = durasi;
            label12.Text = sutradara;
            label4.Text = genre;
        }
        public void UpdateFilmInfo4(string judul, string durasi, string sutradara, string genre)
        {
            label7.Text = judul;
            label6.Text = durasi;
            label11.Text = sutradara;
            label10.Text = genre;
        }
        public void UpdateSpidermanPicture(Image newImage1)
        {
            pictureBoxSpiderman.Image = newImage1; // Memperbarui gambar Spiderman
            pictureBoxSpiderman.SizeMode = PictureBoxSizeMode.Zoom; // Pastikan gambar di-zoom
        }

        public void UpdateGuardianPicture(Image newImage2)
        {
            pictureBoxGuardian.Image = newImage2; // Memperbarui gambar Guardian
            pictureBoxGuardian.SizeMode = PictureBoxSizeMode.Zoom; // Pastikan gambar di-zoom
        }

        public void UpdateNorthmanPicture(Image newImage3)
        {
            pictureBoxNorthman.Image = newImage3; // Memperbarui gambar Guardian
            pictureBoxNorthman.SizeMode = PictureBoxSizeMode.Zoom; // Pastikan gambar di-zoom
        }
        public void UpdateArthemisPicture(Image newImage3)
        {
            pictureBoxFowl.Image = newImage3; // Memperbarui gambar Guardian
            pictureBoxFowl.SizeMode = PictureBoxSizeMode.Zoom; // Pastikan gambar di-zoom
        }
        private void pictureBoxSpiderman_Click(object sender, EventArgs e)
        {
            // Buka Form4 (Detail Film Spiderman)
            FILM1 detailSpiderman = new FILM1(film1);
            detailSpiderman.Show();
            this.Hide(); // Sembunyikan Form3
        }

        private void pictureBoxNorthman_Click(object sender, EventArgs e)
        {
            // Buka Form4 (Detail Film Spiderman)
            Form7 detailNorthman = new Form7();
            detailNorthman.Show();
            this.Hide(); // Sembunyikan Form3
        }

        private void pictureBoxGuardian_Click(object sender, EventArgs e)
        {
            // Buka Form4 (Detail Film Spiderman)
            Form5 detailGuardian = new Form5();
            detailGuardian.Show();
            this.Hide(); // Sembunyikan Form3
        }

        private void pictureBoxFowl_Click(object sender, EventArgs e)
        {
            Form6 detailAF = new Form6();
            detailAF.Show();
            this.Hide(); // 
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UserData.SaveUserData(); // Simpan data pengguna sebelum logout
            LoginBioskop.IsAdmin = false;
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void btnEditFilm_Click(object sender, EventArgs e)
        {
            // Membuka form EDIT_FILM dan menetapkan form Menu sebagai Owner
            EDIT_FILM editFilmForm = new EDIT_FILM("Judul Film"); // Gantilah "Judul Film" dengan data yang sesuai
            editFilmForm.Owner = this; // Menetapkan form Menu sebagai Owner
            editFilmForm.Show(); // Tampilkan form EDIT_FILM
        }
        public class FilmData
        {
            public string Judul { get; set; }
            public string Durasi { get; set; }
            public string Sutradara { get; set; }
            public string Genre { get; set; }
            public Image Gambar { get; set; }
        }

        // Tambahkan properti untuk setiap film
        private FilmData film1 = new FilmData();
        private FilmData film2 = new FilmData();
        private FilmData film3 = new FilmData();
        private FilmData film4 = new FilmData();

    }

}
