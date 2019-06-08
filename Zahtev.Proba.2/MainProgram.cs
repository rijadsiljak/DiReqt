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
    public partial class MainProgram : Form
    {
        public MainProgram()
        {
            InitializeComponent();
        }




        //varijable potrebne za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        string jez = "Bos";
        string porModul = "";
        string porModulSef = "";

      




        //
        //Funkcije za pomjeranje forme, treba spojiti sa panelom na vrhu svake forme (tamo gdje je x)
        //3 eventa MouseDown, MouseUp i MouseMove
        //
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            SqlConnection con = GetConnection();

            string username;

            username = Korisnik.korisnicko;

            string ime = "";
            string prezime = "";
            string job = "";
            string odjel = "";
            string query3 = "SELECT [ime],[prezime],[uloga],[odjel] FROM Korisnici WHERE [username] = @usr ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {


                ime = (reader123["ime"].ToString());
                prezime = (reader123["prezime"].ToString());
                job = (reader123["uloga"].ToString());
                odjel = (reader123["odjel"].ToString());
            }

            else
            {
                reader123.Close();
                con.Close();
            }

            btnImePrezime.Text = ime + " " + prezime;
            lblOdjel.Text = odjel;

            Korisnik.Jezik = jez;

            if (Korisnik.Jezik.Equals("Bos"))
            {
                porModul = "Niste ovlašteni za ovaj modul!";
                porModulSef = "Trenutno niste ovlašteni za ovaj modul!";

            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {
                porModul = " Nein!!";
                porModulSef = "Nein sef!";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Korisnik.korisnicko = lblImePrezime.Text;
            //this.Hide();
            ZZM myForm = new ZZM();
            // Form1 zatvori = new Form1();

            myForm.ShowDialog();
            //  zatvori.Hide();


            MainProgram mp = new MainProgram();
            mp.Close();
        }

        private void prjez()
        {
            Korisnik.Jezik = jez;

            if (Korisnik.Jezik.Equals("Bos"))
            {
                porModul = "Niste ovlašteni za ovaj modul!";
                porModulSef = "Trenutno niste ovlašteni za ovaj modul!";

                button1.Text = "Zahtjev za materijalom";
                button5.Text = "Rukovodilac";
                button3.Text = "Nabavka";
                button2.Text = "Kontroling";
                button4.Text = "Posebno odobrenje";

            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {
                porModul = "Sie sind für diese Modul nicht berechtigt!";
                porModulSef = " Derzeit sind Sie zur diese Modul nicht berechtigt! ";

                button1.Text = "Antrag auf Materialbestellung";
                button5.Text = "Abteilungsleiter";
                button3.Text = "Beschaffung";
                button2.Text = "Controlling";
                button4.Text = "Sondergenehmigung";
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {


            string username;
            string odjel="";

            username=Korisnik.korisnicko;
           // MessageBox.Show(username);
            SqlConnection connab = GetConnection();
            string querynab = "SELECT [odjel] FROM Korisnici WHERE [username] = @usr ";

            SqlCommand command123 = new SqlCommand(querynab, connab);
            connab.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {



                odjel = (reader123["odjel"].ToString());
                
            }

            else
            {
                reader123.Close();
                connab.Close();
            }


          //  MessageBox.Show(odjel);

            if (odjel.Equals("Nabavka") || odjel.Equals("ADMIN"))
            {
                //Korisnik.korisnicko = username;
                //this.Hide();
                Nabavka myForm = new Nabavka();
                // Form1 zatvori = new Form1();

                myForm.ShowDialog();
                //  zatvori.Hide();


                // this.Close();
            }
            else
            {
                MessageBox.Show(porModul);
                return;
            }




    }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = "";
            string odjel = "";

            username = Korisnik.korisnicko;
            // MessageBox.Show(username);
            SqlConnection connab = GetConnection();
            string querynab = "SELECT [odjel] FROM Korisnici WHERE [username] = @usr ";

            SqlCommand command123 = new SqlCommand(querynab, connab);
            connab.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {



                odjel = (reader123["odjel"].ToString());

            }

            else
            {
                reader123.Close();
                connab.Close();
            }


            //  MessageBox.Show(odjel);

            if (odjel.Equals("Finansije i računovodstvo") || odjel.Equals("ADMIN"))
            {
                //Korisnik.korisnicko = username;
                //this.Hide();
                Kontroling myForm = new Kontroling();
                // Form1 zatvori = new Form1();

                myForm.ShowDialog();
                //  zatvori.Hide();


                // this.Close();
            }
            else
            {
                MessageBox.Show(porModul);
                return;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            string username = "";
            string job = "";

            username = Korisnik.korisnicko;
            // MessageBox.Show(username);
            SqlConnection connab = GetConnection();
            string querynab = "SELECT [uloga] FROM Korisnici WHERE [username] = @usr ";

            SqlCommand command123 = new SqlCommand(querynab, connab);
            connab.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {



                job = (reader123["uloga"].ToString());

            }

            else
            {
                reader123.Close();
                connab.Close();
            }


            //  MessageBox.Show(odjel);

            if (job.Equals("Šef") || job.Equals("Direktor") || job.Equals("ADMIN"))
            {
                //Korisnik.korisnicko = username;
                //this.Hide();
                PosebnoOdobrenje myForm = new PosebnoOdobrenje();
                // Form1 zatvori = new Form1();

                myForm.ShowDialog();
                //  zatvori.Hide();


                // this.Close();
            }
            else
            {
                MessageBox.Show(porModul);
                return;
            }




        }
        string idbroj="";
        private void LeftSidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string username = "";
            string job = "";

            username = Korisnik.korisnicko;
            // MessageBox.Show(username);
            SqlConnection connab = GetConnection();
            string querynab = "SELECT [uloga],[idbroj] FROM Korisnici WHERE [username] = @usr ";

            SqlCommand command123 = new SqlCommand(querynab, connab);
            connab.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {



                job = (reader123["uloga"].ToString());
                idbroj = (reader123["idbroj"].ToString());
                reader123.Close();
                connab.Close();
            }

            else
            {
                reader123.Close();
                connab.Close();
            }


            //  MessageBox.Show(odjel);

            if (job.Equals("Rukovodilac") ||job.Equals ("Šef") || job.Equals("Direktor") || job.Equals("ADMIN"))
            {


                string queryid = "SELECT 1 FROM Odjeli WHERE [idbroj] = @usr ";

                SqlCommand commandid = new SqlCommand(queryid, connab);
                connab.Open();
                commandid.Parameters.AddWithValue("@usr", idbroj);

                SqlDataReader readerid = commandid.ExecuteReader();


                if (readerid.Read())
                {

                //Korisnik.korisnicko = username;
                //this.Hide();
                Rukovodilac myForm = new Rukovodilac();
                // Form1 zatvori = new Form1();

                myForm.ShowDialog();
                //  zatvori.Hide();


                // this.Close();


                    
                }

                else
                {

                    if (job.Equals("Šef") || job.Equals("Direktor") || job.Equals("ADMIN"))

                    {
                        //Korisnik.korisnicko = username;
                        //this.Hide();
                        Rukovodilac myForm = new Rukovodilac();
                        // Form1 zatvori = new Form1();

                        myForm.ShowDialog();
                        //  zatvori.Hide();


                        // this.Close();

                    }

                    else

                    {

                         MessageBox.Show(porModulSef);
                         return;
                    }


                  
                }






            }
            else
            {
                MessageBox.Show(porModul);
                return;
            }

        }

        private void btnImePrezime_Click(object sender, EventArgs e)
        {
            PromjenaSifre promjenaSifre = new PromjenaSifre();
            promjenaSifre.Show();
        }








        private void fLayoutPanelButtoni_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
             jez = "Njem";
            Korisnik.Jezik = jez;

            prjez();
        }

        private void radioBtnBH_CheckedChanged(object sender, EventArgs e)
        {
             jez = "Bos";
            Korisnik.Jezik = jez;
            prjez();
        }
    }
}
