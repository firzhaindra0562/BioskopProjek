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
    public partial class REGISTER : Form
    {
        public REGISTER()
        {
            InitializeComponent();
            textBox4.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text; // First Name
            string lastName = textBox2.Text;  // Last Name
            string username = textBox3.Text; // Username
            string password = textBox4.Text; // Password

            // Validasi input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password cannot be empty!", "Error");
                return;
            }

            // Periksa apakah username sudah terdaftar
            if (UserData.users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists!", "Error");
            }
            else
            {
                // Tambahkan pengguna ke dictionary UserData
                UserData.users.Add(username, password);
                UserData.SaveUserData(); // Simpan data pengguna

                MessageBox.Show("Registration successful!", "Success");
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide(); // Sembunyikan form Register
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Tampilkan atau sembunyikan password berdasarkan status checkbox
            if (checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0'; // Tampilkan teks password
            }
            else
            {
                textBox4.PasswordChar = '*'; // Sembunyikan password
            }
        }
    }
}
