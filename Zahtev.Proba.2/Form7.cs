using System;
using System.Data;
using System.Drawing.Printing;

using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text;
using System.Net.Mail;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Imaging;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DiReqt
{

    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query2 = "select [username],[password] from Kontroling_korisnici where [username]=@usr and [password]=@pwd and [uloga]!='Referent' ";





            SqlCommand command12 = new SqlCommand(query2, connection2);
            connection2.Open();
            command12.Parameters.AddWithValue("@usr", textBox1.Text);
            command12.Parameters.AddWithValue("@pwd", textBox2.Text);

            SqlDataReader reader12 = command12.ExecuteReader();





            if (reader12.Read() == true)
            {
                MessageBox.Show("Login uspješan!");

                Korisnik.korisnicko = textBox1.Text;
                this.Hide();
                PosebnoOdobrenje myForm = new PosebnoOdobrenje();
                // Form1 zatvori = new Form1();

                myForm.ShowDialog();
                //  zatvori.Hide();


                // this.Close();



            }


            else
            {
                MessageBox.Show("Check your username or your password!");
                reader12.Close();
                connection2.Close();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Would you like to change your password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button3.Visible = true;
                label3.Visible = true;
                textBox3.Visible = true;
                MessageBox.Show("Input your username, old password and your new password and click 'Update' button!");
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query2 = "select [username],[password] from Kontroling_korisnici where [username]=@usr and [password]=@pwd and [uloga]!='Referent' ";





            SqlCommand command12 = new SqlCommand(query2, connection2);
            connection2.Open();
            command12.Parameters.AddWithValue("@usr", textBox1.Text);
            command12.Parameters.AddWithValue("@pwd", textBox2.Text);

            SqlDataReader reader12 = command12.ExecuteReader();





            if (reader12.Read() == true)
            {

                SqlConnection co2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string qu2 = "Update [Kontroling_korisnici] set password=@uppw where [username]=@usr and [password]=@pwd ";


              
                SqlCommand c1 = new SqlCommand(qu2, co2);
                co2.Open();


                c1.Parameters.AddWithValue("@usr", textBox1.Text);
                c1.Parameters.AddWithValue("@pwd", textBox2.Text);

                c1.Parameters.AddWithValue("@uppw", textBox3.Text);

                

                    c1.ExecuteNonQuery();

                    MessageBox.Show("Password has been changed!");
                
                    co2.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox3.Visible = false;
                    label3.Visible = false;
                    button3.Visible = false;

    
                

            }
            
            
                else
                {
                    MessageBox.Show("Check your username or your  password! ");
                    reader12.Close();
                    connection2.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox3.Visible = false;
                    label3.Visible = false;
                    button3.Visible = false;
                    return;
                }

                    
            
              

           

        }
    }
}
