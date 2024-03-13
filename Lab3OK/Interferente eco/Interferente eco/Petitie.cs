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
    public partial class Petitie : Form
    {
        SqlConnection con = new SqlConnection(Eroare.con);
        string email;
        private int imageNumber = 1;
        private string text;
        private int len=0;
        SqlDataAdapter da;
        DataTable dt;

        public Petitie()
        {
            InitializeComponent();
            
        }
      


        private void LoadNumberNext()
        {

            if (imageNumber == 10)
            {
                imageNumber = 1;
    
            }

            pictureBox1.ImageLocation = string.Format(@"imagini\{0}.jpg", imageNumber);
            imageNumber++;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Petitie_Load(object sender, EventArgs e)
        {

            text = label2.Text;
            label2.Text = " ";
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNumberNext();
            textBox1.Text = DateTime.Now.ToString("F");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chestionar ch = new Chestionar();
            ch.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
          //  LoadNumberNext();
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            LoadNumberNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            LoadNumberNext();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
      
            LoadNumberNext();
            

        }

     

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Galerie gr = new Galerie();
            gr.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(len<text.Length)
            {
                label2.Text = label2.Text+text.ElementAt(len);
                len++;
            
            }
            else
            {
                timer2.Stop();
            }
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Petitie2 du = new Petitie2();
            du.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
