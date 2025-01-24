using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            string keznev = (string)textBox5.Text;
            conn.Connection.Open();

            string sql = "SELECT `FirstName`, `LastName`, `Password` FROM `data` WHERE 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            bool regisztralt = false;

            dr.Read();

            do
            {
                var felhasznalo = new
                {
                    VeznevAdatbazis = dr.GetString(0),
                    KeresztnevAdatbazis = dr.GetString(1),
                    JelszoAdatbazis = dr.GetString(2),
                };

                if (veznev == felhasznalo.VeznevAdatbazis && keznev == felhasznalo.KeresztnevAdatbazis && jelszo == felhasznalo.JelszoAdatbazis)
                {
                    regisztralt = true;
                }
               

            }
            while (dr.Read());

            if(regisztralt == true)
            {
                MessageBox.Show("Regisztrált tag");
            }
            else
            {
                
                    label4.Visible = true;
                    label2.Visible = true;
                    label5.Visible = true;
                    textBox1.Visible = true;
                    textbox2.Visible = true;
                    textBox4.Visible = true;
                    button2.Visible = true;
                    label1.Visible = false;
                    label3.Visible = false;
                    textBox3.Visible = false;
                    textbox.Visible = false;
                    button1.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    MessageBox.Show("Nincs felhasználó");
                
            }

            dr.Close();



            conn.Connection.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string vezeteknev = (string)textBox1.Text;
            string keresztnev = (string)textbox2.Text;
            string jelszo = (string)textBox4.Text;

            try
            {

                conn.Connection.Open();

                string sql = $"INSERT INTO `data`(`FirstName`, `LastName`, `Password`) VALUES ('{vezeteknev}','{keresztnev}','{jelszo}')";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
                cmd.ExecuteNonQuery();

                conn.Connection.Close();

                MessageBox.Show("Sikeres Regisztráció");
            }
            catch (Exception)
            {
                MessageBox.Show("Nem jó az adatbázis kapcsolódása");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Connection.Open();

            string sql = "SELECT `ID`, `FirstName`, `LastName`, `CreatedTime`, `UpdatedTime` FROM `data` WHERE 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            dr.Read();

            do
            {
                var felhasznalo = new
                {
                    IDAdatbazis = dr.GetInt32(0),
                    VezeteknevAdatbazis = dr.GetString(1),
                    KeresztnevAdatbazis = dr.GetString(2),
                    CreatedTimeAdatbazis = dr.GetMySqlDateTime(3),
                    UpdatedTimeAdatbazis = dr.GetMySqlDateTime(4),

                };

                listBox1.Items.Add(felhasznalo.IDAdatbazis + " , " + felhasznalo.VezeteknevAdatbazis+ " , " + felhasznalo.KeresztnevAdatbazis + " , " + felhasznalo.CreatedTimeAdatbazis + " , " + felhasznalo.UpdatedTimeAdatbazis);

            }
            while (dr.Read());


            dr.Close();
            conn.Connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sor = listBox1.SelectedItem.ToString();

                string[] felvag = sor.Split(',');

                string id = "";
                if (felvag.Length > 0)
                {
                    id = felvag[0].Trim();
                }
                conn.Connection.Open();

                string sql = $"DELETE FROM `data` WHERE `ID` = {id};";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
                cmd.ExecuteNonQuery();

                conn.Connection.Close();

                MessageBox.Show("Sikeres Törlés");
                listBox1.Items.Remove(sor);
            }
            catch (Exception)
            {

                MessageBox.Show("Hiba az ID ban");

            }
        }
    }
}
