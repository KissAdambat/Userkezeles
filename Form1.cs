using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User
{
    public partial class Form1 : Form
    {
        public static Connect conn = new Connect();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jelszo = (string)textBox3.Text;
            string veznev = (string)textbox.Text;
            MessageBox.Show("Nincs felhasználó");
            label4.Visible = true;
            label2.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textbox2.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;
            label1.Visible = false;
            label3.Visible = false;

        }
        
        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
