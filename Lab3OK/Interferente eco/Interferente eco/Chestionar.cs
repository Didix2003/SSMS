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
    public partial class Chestionar : Form
    {
        public Chestionar()
        {
            InitializeComponent();
        }
        string raspuns1="";
        string raspuns2="";
        string raspuns3="";
        string raspuns4="";
        string raspuns5="";
        string id = "1";

        private void Chestionar_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Eroare.con);
            con.Open();
            if(textBox1.Text=="")
            {
                SqlCommand cmd = new SqlCommand("select intrebare from intrebarii where id=1", con);
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox1.Text = rd.GetValue(0).ToString();

                }

            }
            else if(textBox2.Text=="")
            {
                SqlCommand ca = new SqlCommand("select intrebare from intrebarii where id=2", con);
                SqlDataReader ra;
                ra = ca.ExecuteReader();
                while (ra.Read())
                {
                    textBox2.Text = ra.GetValue(0).ToString();
                }

            }
            else if (textBox3.Text == "")
            {
                SqlCommand ca = new SqlCommand("select intrebare from intrebarii where id=3", con);
                SqlDataReader ra;
                ra = ca.ExecuteReader();
                while (ra.Read())
                {
                    textBox3.Text = ra.GetValue(0).ToString();
                }

            }
            else if (textBox4.Text == "")
            {
                SqlCommand ca = new SqlCommand("select intrebare from intrebarii where id=4", con);
                SqlDataReader ra;
                ra = ca.ExecuteReader();
                while (ra.Read())
                {
                    textBox4.Text = ra.GetValue(0).ToString();
                }

            }
            else if (textBox5.Text == "")
            {
                SqlCommand ca = new SqlCommand("select intrebare from intrebarii where id=5", con);
                SqlDataReader ra;
                ra = ca.ExecuteReader();
                while (ra.Read())
                {
                    textBox5.Text = ra.GetValue(0).ToString();
                }

            }
           //MessageBox.Show("Ti bugat");


        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Eroare.con);
            con.Open();
           
            if(checkBox1.Checked==true)
            {
                raspuns1 = "Da";

            }
            else if(checkBox2.Checked==true)
            {
                raspuns1 = "Am auzit intamplator";

            }
            else if(checkBox3.Checked==true)
            {
                raspuns1 = "Nu";

            }
            if (checkBox4.Checked == true)
            {
                raspuns2 = "Da";

            }
            else if (checkBox5.Checked == true)
            {
                raspuns2 = "Nu";

            }
            else if (checkBox6.Checked == true)
            {
                raspuns2 = "Nu stiu";

            }
            if (checkBox7.Checked == true)
            {
                raspuns3 = "Da";

            }
            else if (checkBox8.Checked == true)
            {
                raspuns3 = "Nu";

            }
            else if (checkBox9.Checked == true)
            {
                raspuns3 = "Nu stiu";

            }
            if (checkBox10.Checked == true)
            {
                raspuns4 = "Da";

            }
            else if (checkBox11.Checked == true)
            {
                raspuns4 = "Nu";

            }
            else if (checkBox12.Checked == true)
            {
                raspuns4 = "Nu stiu";

            }
            if (checkBox13.Checked == true)
            {
                raspuns5 = "Da";

            }
            else if (checkBox14.Checked == true)
            {
                raspuns5 = "Nu";

            }
            else if (checkBox15.Checked == true)
            {
                raspuns5 = "Nu stiu";

            }

            SqlCommand cmd = new SqlCommand("insert into Chestionar(r1,r2,r3,r4,r5) values (@r1,@r2,@r3,@r4,@r5)", con);
            cmd.Parameters.AddWithValue("@r1", raspuns1);
            cmd.Parameters.AddWithValue("@r2", raspuns2);
            cmd.Parameters.AddWithValue("@r3", raspuns3);
            cmd.Parameters.AddWithValue("@r4", raspuns4);
            cmd.Parameters.AddWithValue("@r5", raspuns5);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Salvat!");
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Petitie da = new Petitie();
            da.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
