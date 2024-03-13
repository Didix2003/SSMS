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
using System.IO;

namespace Interferente_eco
{
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void Inregistrare_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Eroare.con);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from utilizatori2 where email = @email and parola = @pass", con);
                cmd.Parameters.AddWithValue("@email", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                int eut = (int)cmd.ExecuteScalar();
                if (eut == 0) throw new Exception("Eroare autentificare!");
                else
                {
                    con.Close();
                   // MessageBox.Show("Bine ati venit!");
                    Hide();
                    Petitie pet = new Petitie();
                    pet.Show();

                    Close();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                Eroare.Mesaj(ee);
            }
        }
             public static class Eroare
        {
            public static string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ecologie.mdf;Integrated Security=True;TrustServerCertificate=true;";
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

