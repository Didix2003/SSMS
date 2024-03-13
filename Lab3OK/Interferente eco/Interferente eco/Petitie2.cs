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
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Interferente_eco
{
    public partial class Petitie2 : Form
    {
        SqlConnection con = new SqlConnection(Eroare.con);
        string nume = "Anonim";
        string prenume = "Anonim";
        string tara = "Anonim";
        string oras = "Anonim";
        string email = "Anonim";
        public Petitie2()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Eroare.con);
            try
            {
                con.Open();
                if (checkBox2.Checked==true)
                {
                    SqlCommand cmd = new SqlCommand("insert into petitie (nume,prenume,tara,oras,email) values (@nume,@prenume,@tara,@oras,@email)", con);
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@prenume", prenume);
                    cmd.Parameters.AddWithValue("@tara",tara);
                    cmd.Parameters.AddWithValue("@oras", oras);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into petitie (nume,prenume,tara,oras,email) values (@nume,@prenume,@tara,@oras,@email)", con);
                    cmd.Parameters.AddWithValue("@nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@prenume", textBox2.Text);
                    cmd.Parameters.AddWithValue("@tara", comboBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@oras", textBox3.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    //  MessageBox.Show("Veti primi confirmare pe mail. Multumim");

                }



            }
            catch (Exception ee)
            {
                con.Close();
                Eroare.Mesaj(ee);
            }
            string to, from, pass, mail;
            to = (textBox4.Text).ToString();
            from = "csharp.ecologie2022@gmail.com";
            mail = "Multumim ca ati semnat petitia noastra!";
            pass = "csharp123";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "Multumim!";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Veti primi confirmare pe mail. Multumim", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void apasa()
        {
            button1.Enabled = checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Norvegia");
            comboBox1.Items.Add("Belgia");
            comboBox1.Items.Add("China");
            comboBox1.Items.Add("Grecia");
            comboBox1.Items.Add("Turcia");
            comboBox1.Items.Add("Serbia");
            comboBox1.Items.Add("Ungaria");
            comboBox1.Items.Add("Danemarca");
            comboBox1.Items.Add("Germania");
            comboBox1.Items.Add("Polonia");
            comboBox1.Items.Add("Rusia");
            comboBox1.Items.Add("Italia");
            comboBox1.Items.Add("Austria");
            comboBox1.Items.Add("Bulgaria");
            comboBox1.Items.Add("Cehia");
            comboBox1.Items.Add("Franta");
            comboBox1.Items.Add("Portugalia");
            comboBox1.Items.Add("Spania");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Petitie2_Load(object sender, EventArgs e)
        {
            apasa();
            gridview();
            
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            apasa();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
           





        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Petitie da = new Petitie();
            da.Show();
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Datele s-au exportat!", "Info!");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
        public void gridview()
        {
            con.Open();
            DataTable dte;
            SqlDataAdapter da;
            SqlCommand cma = new SqlCommand("select * from petitie ", con);
            dte = new DataTable();
            da = new SqlDataAdapter(cma);
            da.Fill(dte);
            BindingSource bd = new BindingSource();
            bd.DataSource = dte;
            dataGridView1.DataSource = bd;
            cma = new SqlCommand("select count(*) from petitie", con);
            Int32 count = (Int32)cma.ExecuteScalar();

            if (count > 0)
            {
                label6.Text = Convert.ToString(count.ToString());



            }
            else
            {

                label6.Text = "0";
            }


            con.Close();



        }


        private void button3_Click_2(object sender, EventArgs e)
        {
            gridview();
            dataGridView1.Update();
            dataGridView1.Refresh();

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
    }

