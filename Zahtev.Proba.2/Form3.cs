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
using System.Linq;
using System.ComponentModel;

namespace DiReqt
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
                 SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query2 = "select [username],[password] from Nabavka_korisnici where [username]=@usr and [password]=@pwd ";

                



                 SqlCommand command12 = new SqlCommand(query2, connection2);
                 connection2.Open();
                 command12.Parameters.AddWithValue("@usr", textBox1.Text);
                 command12.Parameters.AddWithValue("@pwd", textBox2.Text);

                 SqlDataReader reader12 = command12.ExecuteReader();





                 if (reader12.Read()==true)
                 {
                MessageBox.Show("Login uspješan!");

                Korisnik.korisnicko = textBox1.Text;
                this.Hide();
                Nabavka myForm = new Nabavka();
               // Form1 zatvori = new Form1();
                
                myForm.ShowDialog();
              //  zatvori.Hide();
                

               // this.Close();
               
                    }

                
                 
         
            else 
             {
                MessageBox.Show("Provjerite da li ste dobro unijeli korisničko ime ili lozinku!");
                reader12.Close();
                connection2.Close();
                //textBox1.Text = "";
                textBox2.Text = "";

            }
        }
        

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
              
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
