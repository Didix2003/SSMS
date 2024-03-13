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
using System.Device.Location;

namespace Interferente_eco
{

    
    public partial class Galerie : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader da;
        SqlParameter picture;
        public Galerie()
        {
            InitializeComponent();
          
        }
      
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void open()
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "C:/Picture/";
                f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(f.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    label1.Text = f.SafeFileName.ToString();
                }
            }
            catch { }
        }
        private void save()
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] a = ms.GetBuffer(); ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", a);
                cmd.CommandText = "insert into pictures (nume,picture) values ('" + label1.Text.ToString() + "', @picture)";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label1.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Salvat!");
            }
        }
        private void loaddata()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            cmd.CommandText = "select id,nume from pictures";
            con.Open();
            da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                while (da.Read())
                {
                    listBox1.Items.Add(da[0].ToString());
                    listBox2.Items.Add(da[1].ToString());

                }

            }
            da.Close();
            con.Close();

        }
        private void loadpicture()
        {
            con.Open();
            cmd.CommandText = "select picture from pictures where id='" + listBox1.Text.ToString() + "'";
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            SqlCommandBuilder cbd = new SqlCommandBuilder(dr);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            con.Close();
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = listBox2.Text.ToString();
            ms.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Galerie_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ecologie.mdf;Integrated Security=True;TrustServerCertificate=true;";
            cmd.Connection = con;
            label1.Text = "";
            picture = new SqlParameter("@picture", SqlDbType.Image);
            loaddata();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                loadpicture();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Petitie pt = new Petitie();
            pt.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
