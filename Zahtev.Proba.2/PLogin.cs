using System;
using System.Data;
using System.Drawing.Printing;

using System.Windows.Forms;
//using iTextSharp.text.pdf;
//using iTextSharp.text.xml;
//using iTextSharp.text;
using System.Drawing;
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
    public partial class PLogin : Form
    {
        public PLogin()
        {
            InitializeComponent();
        }





        





        private void EraseTextOnEnter(TextBox txt, string str, Color color )
        {
            if (txt.Text == str)
            {
                txt.Text = "";
                txt.ForeColor = color;
            }
        }
        //
        //Brisanje Username placeholdera na enter
        //
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            EraseTextOnEnter(textBox1, "Username", Color.White);
        }
        // 
        // Brisanje Password placeholdera na enter
        //
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            EraseTextOnEnter(textBox2, "Password", Color.White);
            textBox2.PasswordChar = '*';
        }
        //
        // Pomoćna funkcija koja upisuje placeholder ukoliko je textbox prazan
        //
        private void PlaceholderOnLeave(TextBox txt, string str, Color color)
        {
            if (txt.Text == "")
            {
                txt.Text = str;
                txt.ForeColor = color;
                txt.PasswordChar = '\0';
            }
        }

        //
        // Upisuje Username u textbox ukoliko je textbox prazan
        //

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            PlaceholderOnLeave(textBox1, "Username", Color.WhiteSmoke);
        }

        //
        //Upisuje Password u textbox ukoliko je textbox prazan
        //

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            PlaceholderOnLeave(textBox2, "Password", Color.WhiteSmoke);
        }

        //
        // Close button
        //
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query2 = "select [username],[password] from Korisnici where [username]=@usr and [password]=@pwd ";





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
                MainProgram myForm = new MainProgram();
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

        private void PLogin_Load(object sender, EventArgs e)
        {
            button1.Select();
        }

       
    }
}
