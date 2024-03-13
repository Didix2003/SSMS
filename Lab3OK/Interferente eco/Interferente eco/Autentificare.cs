using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interferente_eco
{
    public partial class Autentificare : Form
    {
        public Autentificare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Eroare.con);
            try
            {
              
                
                    if (textBox5.Text != textBox4.Text) throw new Exception("Parolele nu corespund!");
                    else if (textBox5.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") throw new Exception("Compltetati toate campurile!");
                    else
                    {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into utilizatori2(nume,prenume,parola,email) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox4.Text+"','"+textBox3.Text+"')", con);
                       cmd.ExecuteNonQuery();
                       con.Close();
                        MessageBox.Show("Utilizator inregistrat!");
                        Hide();
                        Petitie pet = new Petitie();
                        pet.Show();
                        Close();

                    }
                

            }
            catch (Exception ee)
            {
                con.Close();
                Eroare.Mesaj(ee);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public static class Eroare
        {
            public static string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ecologie.mdf;Integrated Security=True";
            public static string nume_folder = Application.StartupPath + "\\Resurse\\";
            public static void Mesaj(Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            public static void Mesaj(object ee)
            {
                MessageBox.Show(ee.ToString(), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
