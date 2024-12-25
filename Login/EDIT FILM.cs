using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Login
{
    public partial class EDIT_FILM : Form
    {
        public EDIT_FILM(string title)
        {
            InitializeComponent();

        }

        private void EDIT_FILM_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxSpiderman_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PictureBox Clicked!"); // Untuk memastikan event ini dipanggil

            // Pastikan bahwa ini adalah form Menu yang memanggil
            Menu parentMenuForm = this.Owner as Menu; // Mendapatkan referensi form Menu (Owner)
            if (parentMenuForm != null)
            {
                // Kirim referensi form Menu ke konstruktor EDIT_FILM_1
                EDIT_FILM_1 editFilm1Form = new EDIT_FILM_1(parentMenuForm);
                editFilm1Form.Show();
                this.Hide(); // Sembunyikan form EDIT_FILM setelah membuka form baru
            }
        }

        private void pictureBoxGuardian_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PictureBox Clicked!"); // Untuk memastikan event ini dipanggil

            // Pastikan bahwa ini adalah form Menu yang memanggil
            Menu parentMenuForm = this.Owner as Menu; // Mendapatkan referensi form Menu (Owner)
            if (parentMenuForm != null)
            {
                // Kirim referensi form Menu ke konstruktor EDIT_FILM_1
                EDIT_FILM_2 editFilm2Form = new EDIT_FILM_2(parentMenuForm);
                editFilm2Form.Show();
                this.Hide(); // Sembunyikan form EDIT_FILM setelah membuka form baru
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxNorthman_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PictureBox Clicked!"); // Untuk memastikan event ini dipanggil

            // Pastikan bahwa ini adalah form Menu yang memanggil
            Menu parentMenuForm = this.Owner as Menu; // Mendapatkan referensi form Menu (Owner)
            if (parentMenuForm != null)
            {
                // Kirim referensi form Menu ke konstruktor EDIT_FILM_1
                EDIT_FILM_3 editFilm3Form = new EDIT_FILM_3(parentMenuForm);
                editFilm3Form.Show();
                this.Hide(); // Sembunyikan form EDIT_FILM setelah membuka form baru
            }
        }

        private void pictureBoxFowl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PictureBox Clicked!"); // Untuk memastikan event ini dipanggil

            // Pastikan bahwa ini adalah form Menu yang memanggil
            Menu parentMenuForm = this.Owner as Menu; // Mendapatkan referensi form Menu (Owner)
            if (parentMenuForm != null)
            {
                // Kirim referensi form Menu ke konstruktor EDIT_FILM_1
                EDIT_FILM4 editFilm4Form = new EDIT_FILM4(parentMenuForm);
                editFilm4Form.Show();
                this.Hide(); // Sembunyikan form EDIT_FILM setelah membuka form baru
            }
        }
    }
}
