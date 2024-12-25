using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Login : Form
    {
        // Dictionary untuk menyimpan user yang telah terdaftar
        public static Dictionary<string, string> users = new Dictionary<string, string>();

        // Tambahkan admin sebagai default user
        private const string adminUsername = "admin";
        private const string adminPassword = "admin123";


        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pastikan password disembunyikan saat form dimuat
            textBox2.PasswordChar = '*';

            // Tambahkan admin ke dictionary user jika belum ada
            if (!users.ContainsKey(adminUsername))
            {
                users.Add(adminUsername, adminPassword);
            }
            UserData.LoadUserData(); // Muat data pengguna saat aplikasi dimulai
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Username yang dimasukkan
            string password = textBox2.Text; // Password yang dimasukkan

            // Periksa jika admin
            if (username == LoginBioskop.AdminUsername && password == LoginBioskop.AdminPassword)
            {
                MessageBox.Show("Login as Admin successful!", "Success");

                // Buka form Menu untuk admin dan sembunyikan form login
                Menu menuForm = new Menu(true); // Mengirim status admin sebagai true
                menuForm.Show();
                this.Hide(); // Sembunyikan form login
            }
            // Jika bukan admin, periksa daftar pengguna biasa
            else if (UserData.users.ContainsKey(username) && UserData.users[username] == password)
            {
                MessageBox.Show("Login successful!", "Success");

                // Buka form Menu untuk pengguna biasa
                Menu menuForm = new Menu(false); // Mengirim status admin sebagai false
                menuForm.Show();
                this.Hide(); // Sembunyikan form login
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Tampilkan atau sembunyikan password berdasarkan status checkbox
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0'; // Tampilkan teks password
            }
            else
            {
                textBox2.PasswordChar = '*'; // Sembunyikan password
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            REGISTER registerForm = new REGISTER();
            registerForm.Show();
            this.Hide(); // Sembunyikan form Login
        }
    }
}
