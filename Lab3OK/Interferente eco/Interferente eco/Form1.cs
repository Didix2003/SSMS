using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Interferente_eco
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(Eroare.con);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

       // string email;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label5.Text = email;
            try
            {
                con.Open();
                cmd =new SqlCommand ("truncate table utilizatori2",con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("truncate table intrebarii", con);
                cmd.ExecuteNonQuery();
                string[] utilizatori = File.ReadAllLines(Eroare.nume_folder + "utilizatori.txt");
                foreach(string user in utilizatori)
                {
                    string[] split = user.Split('*');
                    cmd = new SqlCommand("insert into utilizatori2(nume,prenume,parola,email) values(@nume,@prenume,@parola,@email)", con);
                    cmd.Parameters.AddWithValue("@nume", split[0]);
                    cmd.Parameters.AddWithValue("@prenume", split[1]);
                    cmd.Parameters.AddWithValue("@parola", split[2]);
                    cmd.Parameters.AddWithValue("@email", split[3]);
                    cmd.ExecuteNonQuery();
                }
                string[] intrebari = File.ReadAllLines(Eroare.nume_folder + "intrebarii.txt");
                foreach(string cioco in intrebari)
                {
                    string[] lata = cioco.Split(';');
                    cmd = new SqlCommand("insert into intrebarii(id,intrebare) values(@id,@intrebare)", con);
                    cmd.Parameters.AddWithValue("@id", lata[0]);
                    cmd.Parameters.AddWithValue("@intrebare", lata[1]);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ee)
            {
                Eroare.Mesaj(ee);
                con.Close();
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inregistrare cf= new Inregistrare();
            cf.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autentificare aut = new Autentificare();
            aut.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
