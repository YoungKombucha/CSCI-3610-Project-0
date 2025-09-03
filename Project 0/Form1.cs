using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Project_0
{
    public partial class Form1 : Form
    {
        private int attempt = 0;
        private int maxAttempts = 3;
        private readonly string correctUsername = "demoUser";
        private readonly string storedPasswordHash = "abbcf5698b4df0d5e0a81f86e1ccb8a0b37e8c47d4d4812fdc044903ecaecf1e"; // SHA-256 hash for "SecretPassword#2025"
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = textBox1.Text;
            string enteredPassword = textBox2.Text;

            string enteredPasswordHash = GetSha256(enteredPassword);

            if (enteredUsername == correctUsername && enteredPasswordHash == storedPasswordHash)
            {
                MessageBox.Show("Login successful!");
                attempt = 0; // Reset attempt counter on successful login
            }
            else
            {
                attempt++;
                if (attempt >= maxAttempts)
                {
                    MessageBox.Show("Maximum login attempts exceeded. Application will close.");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Login failed. You have {maxAttempts - attempt} attempts left.");
                }
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
