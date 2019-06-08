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

    public partial class PosebnoOdobrenje : Form
    {
        public PosebnoOdobrenje()
        {
            InitializeComponent();
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }


        string uloga = "";
        string idbroj = "";
        string odjel = "";
        string jez = "";
        string prov = "";
        string prov2 = "";
        string pu = "";
        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            SqlConnection conn = GetConnection();
            if (lblOdjel.Equals("Finansije i računovodstvo"))
            {
                sqlstring = fir;
            }
            else
            {
                sqlstring = "Update DiReqt set[dodobrenje] = @x,[pod] = @x" +

                  " where id=@lid";
            }


            SqlCommand delete = new SqlCommand(sqlstring, conn);
            delete.Parameters.AddWithValue("@lid", textBox2.Text);
            delete.Parameters.AddWithValue("@x", "");
            try
            {
                conn.Open();
                delete.ExecuteNonQuery();
                MessageBox.Show(mZOt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void panelZahtjeviNaCekanjuFill_Paint(object sender, PaintEventArgs e)
        {

        }

        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;




        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Bos"))
            {
                btnOdobrenje.Text = "Odobrenje";
                btnZahtjeviNaCekanju.Text = "Zahtjevi na čekanju";
                button5.Text = "Promjena odgovorne osobe";
                lblBrZahtjevaOdobrenje.Text = "Broj zahtjeva";


                                
                mMail = " Kopija zahtjeva je proslijeđena putem e-maila! ";
                mNPIS = " Polje 'Ident šifra' ne može biti prazno! ";
                mNPMT = " Mjesto troška ne može biti prazno! ";
                mNPKol = " Količina ne može biti prazna! ";
                mNPNM = " Naziv materijala ne može biti prazan! ";
                mNPTP = " Polje 'Tehnička priprema' ne može biti prazno! ";
                mZahSp = " Vaš zahtjev je spašen. Broj zahtjeva je : ";
                mZahPP = " Zahtjev je u fazi prikupljanja ponuda ";
                mZahK = " Zahtjev je u kontrolingu i čeka na odobrenje ! ";
                mZahOdo = " Zahtjev je odobren i u fazi je naručivanja! ";
                mZahOdb = " Zahtjev je odbijen! ";
                mNBr = " Niste upisali broj zahtjeva! ";
                mSID = " Možete upisati samo broj zahtjeva! ";
                mSPod = " Samo podnosilac zahtjeva može pregledati zahtjev! ";
                mZBr = " Unesite broj zahtjeva! ";
                mZS = " Ovaj zahtjev je već odobren/storniran. Kontakt osoba u slučaju potrebe otključavanja zahtjeva je: ";
                mZC = " Za ovaj zahtjev su već upisane cijene. Kontakt osoba u slučaju potrebe otključavanja zahtjeva je: ";
                mNoZah = " Zahtjev ne postoji! ";
                mNO = " Niste ovlašteni za modifikaciju ovog zahtjeva! ";
                mA = " Ažurirano ";
                mNA = " Ažuriranje nije uspjelo ";
                mZahSp = " Vaš zahtjev je spašen. Broj zahtjeva je : ";
                mTNO = " Trenutno niste ovlašteni za odobravanje zahtjeva! ";
                mNOo = " Niste ovlašteni za ovaj odjel! ";
                mZO = " Zahtjev je odobren! ";
                mCu = " Cijene su unešene u sistem! ";
                mCuTo = " Napomena! Cijene su već unešene za ovaj zahtjev! Total iznosi: ";
                mZNO = " Zahtjev nije dobio odobrenje ";
                mZav = " Zahtjev je završen. Status zahtjeva je: ";
                mZnU = " Zahtjev nije učitan! ";
                mCnU = " Cijena nije unešena! ";
                mZOt = " Zahtjev je otključan! ";
                mCNU = " Cijene nisu unešene za ovaj zahtjev! ";
                mOKnu = " Odobrena količina nije unešena! ";
                mZoZ = " Zahtjev je odbijen. Želite li ga stornirati? ";
                mZTOpm = " Zahtjev traži posebno odobrenje. Želite li poslati mail sa zahtjevom? ";
                mKZS = " Kopija zahtjeva je proslijeđena šefu putem e-maila! ";
                mKZSK = " Kopija zahtjeva je proslijeđena šefu kontrolinga ! ";
                mZTPOD = " Zahtjev traži posebno odobrenje od direktora. Želite li poslati mail sa zahtjevom? ";
                mKZPKD = " Kopija zahtjeva je proslijeđena šefu kontrolinga i direktoru putem e-maila! ";
                mKiCI = " Količina i cijene su izmjenjeni! ";
                mZSpa = " Zahtjev je spašen ";
                mOdo = " Odobreno! ";
                mOdb = " Odbijeno! ";
                mZPrint = " Zahtjev je na printanju! ";
                mPPMail = " Poruka proslijeđena putem e-maila! ";
             //   mOdgOs = " Odgovorna osoba za odjel " + comboBox1.Text + " je  ";
                mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";















            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {


                btnOdobrenje.Text = "Genehmigung";
                btnZahtjeviNaCekanju.Text = "Anfrage in der Warteschleife";
                button5.Text = "Verantwortlichen wechseln";
                lblBrZahtjevaOdobrenje.Text = "Antragsnummer";





                mMail = " Kopie des Antrags wurde per E-Mail weitergeleitet! ";
                mNPIS = " Das Feld „Ident-Kennnummer“ kann nicht leer sein! ";
                mNPMT = " Kostenstelle kann nicht leer sein! ";
                mNPKol = " Menge kann nicht leer sein! ";
                mNPNM = " Materialbezeichnung kann nicht leer sein! ";
                mNPTP = " Das Feld “Technische Vorbereitung” kann nicht leer sein! ";
                mZahSp = " Ihr Antrag wurde gespeichert. Nummer des Antrags ist: ";
                mZahPP = " Der Antrag ist in der Phase der Angebotssammlung ";
                mZahK = " Antrag ist im Controlling und wartet auf Genehmigung! ";
                mZahOdo = " Der Antrag wurde genehmigt und ist in der Bestellphase! ";
                mZahOdb = " Antrag wurde angelehnt! ";
                mNBr = " Sie haben die Antragsnummer nicht eingetragen! ";
                mSID = " Sie können nur die Antragsnummer eintragen!  ";
                mSPod = " Nur der Antragsteller kann den Antrag ansehen! ";
                mZBr = " Tragen Sie die Antragnummer ein! ";
                mZS = " Dieser Antrag wurde bereits genehmigt/storniert. Die Kontaktperson im Falle der Antragsentschlüsselung ist: ";
                mZC = " Zu diesem Antrag wurden bereits Preise eingetragen. Die Kontaktperson im Falle der Antragsentschlüsselung ist: ";
                mNoZah = " Den Antrag gibt es nicht! ";
                mNO = " Sie sind nicht berechtigt, diesen Antrag zu ändern! ";
                mA = " Aktualisiert ";
                mNA = " Aktualisierung gescheitert ";
                mahSp = " Ihr Antrag wurde gespeichert:  ";
                mTNO = " Derzeit sind Sie zur Genehmigung des Antrags nicht berechtigt! ";
                mNOo = " Sie sind für diese Abteilung nicht berechtigt! ";
                mZO = " Antrag wurde genehmigt! ";
                mCu = " Preise wurden ins System eingetragen! ";
                mCuTo = " Anmerkung! Preise sind für diesen Antrag schon eingetragen! Total beträgt: ";
                mZNO = " Antrag wurde nicht genehmigt ";
                mZav = "  Antrag ist abgeschlossen. Status des Antrags ist:  ";
                mZnU = " Antrag wurde nicht eingelesen! ";
                mCnU = " Preis wurde nicht eingetragen! ";
                mZOt = " Antrag ist entschlüsselt! ";
                mCNU = " Preise für diesen Antrag wurden nicht eingetragen! ";
                mOKnu = " Genehmigte Menge wurde nicht eingetragen! ";
                mZoZ = " Antrag wurde abgelehnt. Möchten Sie ihn stornieren? ";
                mZTOpm = " Antrag erfordert gesonderte Genehmigung. Möchten Sie die E-Mail mit dem Antrag versenden? ";
                mKZS = " Kopie des Antrags wurde an den Vorgesetzten weitergeleitet! ";
                mKZSK = " Eine Kopie des Antrages wurde dem Controllingleiter weitergeleitet! ";
                mZTPOD = " Antrag erfordert besondere Genehmigung des Geschäftsführers. Möchten Sie die E-Mail mit dem Antrag versenden? ";
                mKZPKD = " Eine Kopie des Antrags wurde an den Controllingleiter und den Geschäftsführer weitergeleitet! ";
                mKiCI = " Menge und Preise wurden geändert! ";
                mZSpa = " Antrag wurde gespeichert ";
                mOdo = " Genehmigt! ";
                mOdb = " Abgelehnt! ";
                mZPrint = " Antrag wird gedruckt! ";
                mPPMail = " Die Nachricht wurde per E-Mail weitergeleitet! ";
              //  mOdgOs = " Die Verantwortliche Person für die Abteilung" + comboBox1.Text + " ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }






        private void Form8_Load(object sender, EventArgs e)
        {
            PLogin frm1 = new PLogin();
            frm1.Hide();
            //*frm3.Show();
            string username;
            jez = Korisnik.Jezik;
            prjez();

            username = Korisnik.korisnicko;

            string ime = "";
            string prezime = "";
            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [ime],[prezime],[odjel],[uloga],[idbroj] FROM Korisnici WHERE [username] = @usr ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {

                ime = (reader123["ime"].ToString());
                prezime = (reader123["prezime"].ToString());
                uloga = (reader123["uloga"].ToString());
                odjel = (reader123["odjel"].ToString());
                idbroj = (reader123["idbroj"].ToString());

            }

            else
            {
                reader123.Close();
                connection3.Close();
            }


            if (uloga.Equals("Direktor")||uloga.Equals("ADMIN"))

            {
                button5.Visible = true;
            }


            if (uloga.Equals("Šef") && odjel.Equals("Finansije i računovodstvo"))

            {

                button5.Visible = true;
            }

            SqlConnection con = GetConnection();



            string kodo = "Select [uloga] from posodo where idbroj=@id";

            //  string dodo = "Select [idbroj] from Odjeli where odjel='OdDir'";

            SqlCommand c1 = new SqlCommand(kodo, con);
            con.Open();

            c1.Parameters.AddWithValue("@id", idbroj);

            SqlDataReader r1 = c1.ExecuteReader();



            if (r1.Read())
            {



                pu = (r1["uloga"].ToString());



                r1.Close();
                con.Close();
            }

            else
            {
                r1.Close();
                con.Close();
            }



            lblImePrezime.Text = ime + " " + prezime;
            lblOdjel.Text = odjel;
        }





        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //
        //Maximize button
        //
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                MaximizeButton.Image = global::DiReqt.Properties.Resources.Maximize_SteelBlue;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                MaximizeButton.Image = global::DiReqt.Properties.Resources.Restore_SteelBlue;
            }
        }

        //
        //X button
        //
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //
        //Klik na button Odobrenje otvara tab Odobrenje
        //
        private void btnOdobrenje_Click(object sender, EventArgs e)
        {
            tbControl.SelectTab(0);
        }

        //
        //Klik na button Zahtjevi na čekanju otvara tab Zahtjevi na čekanju
        //
        private void btnZahtjeviNaCekanju_Click(object sender, EventArgs e)
        {
            tbControl.SelectTab(1);
        }


        string fir = "Update DiReqt set  [podobrenje]=@x,[pok]=@ where id=@lid";
        string sqlstring="";

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(mNBr);
                return;

            }
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                return;
            }

            SqlConnection con = GetConnection();

            string izvor = "";
            string imep = "";
            string datum = "";
            string ident = "";
            string odjel = "";
            string idbroj2 = "";
            string query3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj] FROM DiReqt WHERE [id] = @id ";




            string query5 = "SELECT [idbroj] FROM Odjeli WHERE [odjel] ='OdKon' ";

            SqlCommand c2 = new SqlCommand(query5, con);
            con.Open();

          

            SqlDataReader r2 = c2.ExecuteReader();



            if (r2.Read())
            {
                
                prov = (r2["idbroj"].ToString());
               
                r2.Close();
                con.Close();
            }

            else
            {
                r2.Close();
                con.Close();
            }


            string query6 = "SELECT [idbroj] FROM Odjeli WHERE [odjel] ='OdDir' ";

            SqlCommand c3 = new SqlCommand(query6, con);
            con.Open();

      

            SqlDataReader r3 = c3.ExecuteReader();



            if (r3.Read())
            {

                prov2 = (r3["idbroj"].ToString());

                r3.Close();
                con.Close();
            }

            else
            {
                r3.Close();
                con.Close();
            }

            



            


            if (prov.Equals(idbroj) || idbroj.Equals(prov2))
            {

            }


            else
            {

                MessageBox.Show(mTNO);

                return; }
            







            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", textBox2.Text);

            SqlDataReader reader123 = command123.ExecuteReader();



            if (reader123.Read())
            {


                imep = (reader123["podnositelj"].ToString());
                datum = (reader123["datum"].ToString());
                ident = (reader123["id"].ToString());
                odjel = (reader123["odjel"].ToString());
                idbroj2 = (reader123["idbroj"].ToString());



                reader123.Close();
                con.Close();
            }

            else
            {
                reader123.Close();
                con.Close();
            }

            PDF p = new PDF();
            p.id = textBox2.Text;

            string broj = textBox2.Text;




            bool result;
            result = PDFC.Create_PDF(broj);


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + imep + " " + datum + " No. " + ident.Trim() + ".pdf";



            axAcroPDF1.src = izvor;

               


                File.Delete(izvor);
                

            



        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();



            if (prov.Equals(idbroj) || idbroj.Equals(prov2))
            {

            }


            else
            {

                MessageBox.Show(mTNO);

                return;
            }


            string kodo = "Select [uloga] from posodo where idbroj=@id";

          //  string dodo = "Select [idbroj] from Odjeli where odjel='OdDir'";

            SqlCommand c1 = new SqlCommand(kodo, con);
            con.Open();

            c1.Parameters.AddWithValue("@id", idbroj);

            SqlDataReader r1 = c1.ExecuteReader();



            if (r1.Read())
            {


               
                pu = (r1["uloga"].ToString());



                r1.Close();
                con.Close();
            }

            else
            {
                r1.Close();
                con.Close();
            }



            if (pu.Equals("Kontroling"))
            {
                string provjera = "";


            
                try
                {
                    SqlCommand podobri = new SqlCommand("Update [DiReqt] set [podobrenje]=@st,[pok]=@pok where id=@konid", con);

                    SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                    podobri.Parameters.AddWithValue("@konid", textBox2.Text);


                    string podobreno = "Odobreno";


                    podobri.Parameters.AddWithValue("@st", podobreno);
                    podobri.Parameters.AddWithValue("@pok", lblImePrezime.Text);

                    con.Open();
                    podobri.ExecuteNonQuery();


                    MessageBox.Show(mZO);







                    SqlConnection connect = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string que = "SELECT [tpod] FROM DiReqt WHERE id= @odid";

                    /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                     string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                     */


                    SqlCommand comman = new SqlCommand(que, connect);
                    connect.Open();
                    comman.Parameters.AddWithValue("@odid", textBox2.Text);

                    SqlDataReader re = comman.ExecuteReader();


                    if (re.Read())
                    {


                        provjera = (re["tpod"].ToString());



                    }

                    else
                    {
                        re.Close();
                        connect.Close();
                    }

                    string mes = "";
                    
                    if (provjera.Equals("Da"))
                    {

                        mes = " and needs your approval to be finalized!    ";
                    }

                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                    MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                    MailAddress to = new MailAddress("From Address Ex direqt.kontroling@volkswagen-sa.ba");

                  //  MailAddress to2 = new MailAddress("From Address Ex sascha.schreiner@volkswagen-sa.ba");
                    MailMessage message = new MailMessage(from, to);
                   // MailMessage messag = new MailMessage(from, to2);



                  //  messag.BodyEncoding = System.Text.Encoding.UTF8;
                   // messag.Subject = "Request " + " No. " + textBox2.Text.Trim();
                  //  messag.SubjectEncoding = System.Text.Encoding.UTF8;





                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Request " + " No. " + textBox2.Text.Trim();
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                  //  messag.Body= "Request " + " No. " + textBox2.Text.Trim() + " has been approved by " + lblImePrezime.Text.Trim() +" "+ DateTime.Now.ToShortDateString();
                    message.Body = "Request " + " No. " + textBox2.Text.Trim() + " has been approved by " + lblImePrezime.Text.Trim() + mes + DateTime.Now.ToShortDateString(); 
                  //  MailAddress bc2 = new MailAddress("rijad.siljak@volkswagen-sa.ba");
                    


                    if (provjera.Equals("Da"))
                    {
                        
                        mes = " and needs your approval to be finalized! ";
                       // client.Send(messag);
                        client.Send(message);
                    }
                    else
                    {
                       
                      //  client.Send(messag);
                    }

                        MessageBox.Show(mMail);
                   
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }




                finally
                {
                    con.Close();
                }





            }



            else if (pu.Equals("Uprava"))


            {

               
                try
                {
                    SqlCommand dodobri = new SqlCommand("Update [DiReqt] set [dodobrenje]=@st,[pod]=@pod where id=@konid", con);

                    SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                    dodobri.Parameters.AddWithValue("@konid", textBox2.Text);


                    string dodobreno = "Odobreno";

                    dodobri.Parameters.AddWithValue("@st", dodobreno);
                    dodobri.Parameters.AddWithValue("@pod", lblImePrezime.Text);

                    con.Open();
                    dodobri.ExecuteNonQuery();
                    

                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                    MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                    MailAddress to = new MailAddress("From Address Ex direqt.kontroling@volkswagen-sa.ba");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Zahtjev za materijalom, KONTROLING " + DateTime.Now.ToShortDateString();
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Zahtjev " + " No. " + textBox2.Text.Trim() + " je dobio odobrenje direktora !";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                    MailAddress bcc = new MailAddress("emina.imsirovic@volkswagen-sa.ba");
                  //  message.Bcc.Add(bcc);



                    client.Send(message);
                    MessageBox.Show(mOdo);

                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            
                finally
                {
                    con.Close();
                }

            }


            textBox2.Text="";
            axAcroPDF1.src= ("none");


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {



            if (prov.Equals(idbroj) || idbroj.Equals(prov2))
            {

            }


            else
            {

                MessageBox.Show(mTNO);

                return;
            }


            if (pu.Equals("Kontroling"))
            {
               

                SqlConnection con = GetConnection();
                try
                {
                    SqlCommand podobri = new SqlCommand("Update [DiReqt] set [podobrenje]=@st where id=@konid", con);
                    

                    

                    podobri.Parameters.AddWithValue("@konid", textBox2.Text);


                    string podobreno = "Odbijen";


                    podobri.Parameters.AddWithValue("@st", podobreno);


                    con.Open();
                    podobri.ExecuteNonQuery();
                    

                    

                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                    MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                    MailAddress to = new MailAddress("From Address Ex direqt.kontroling@volkswagen-sa.ba");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Zahtjev za materijalom, KONTROLING " + DateTime.Now.ToShortDateString();
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Request " + " No. " + textBox2.Text.Trim() + " has been declined by " + lblImePrezime.Text.Trim();
                    message.SubjectEncoding = System.Text.Encoding.UTF8;




                    client.Send(message);
                 


                    MessageBox.Show(mZahOdb);


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }




               

                
                finally
                {
                    con.Close();
                }


            }


            else if (pu.Equals("Uprava"))
            {


                SqlConnection con = GetConnection();
                try
                {
                    SqlCommand dodobri = new SqlCommand("Update [DiReqt] set [dodobrenje]=@st where id=@konid", con);

                    SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                    dodobri.Parameters.AddWithValue("@konid", textBox2.Text);


                    string dodobreno = "Odbijen";

                    dodobri.Parameters.AddWithValue("@st", dodobreno);

                    con.Open();
                    dodobri.ExecuteNonQuery();





                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                    MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                    MailAddress to = new MailAddress("From Address Ex direqt.kontroling@volkswagen-sa.ba");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Zahtjev za materijalom, KONTROLING " + DateTime.Now.ToShortDateString();
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Zahtjev " + " No. " + textBox2.Text.Trim() + " je storniran od strane direktora.";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;




                    client.Send(message);
                   



                    MessageBox.Show(mOdb);

                 

                }
                finally
                {
                    con.Close();
                }


            }



            textBox2.Text = "";
            axAcroPDF1.src = ("none");



        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (pu.Equals("Kontroling"))
            {

                SqlConnection connectionN = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

                DataTable dtN = new DataTable();

                SqlDataAdapter adapters = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[total] as 'Total',[valuta] as 'Valuta', [naziv_mt] as 'Naziv mjesta troška' " +
        "  ,[naziv_mt2] as 'Mjesto troška 2',[naziv_mt3] as 'Mjesto troška 3' ,[naziv_mt4] as 'Mjesto troška 4' ,[datum_nabavka] as 'Datum unošenja cijene',[datum_kontroling] as 'Datum odobrenja / odbijanja' ,[status] as 'Status'" +
        " ,[nabavka] as 'Referent nabavke',[kontroling] as 'Kontroling',[sklad] as 'Skladište',[napomena] as 'Napomena',[ident_sifra] as 'Ident šifra' ,[naziv] as 'Naziv materijala'  ,[jm] as 'Jedinica mjere' ,[kolicina] as 'Količina'" +
        "  ,[odobrena_kolicina] as 'Odobrena količina' ,[ukupna_cijena] 'Ukupna cijena' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'Ident šifra 2' ,[naziv2] as 'Naziv materijala 2' ,[jm2] as 'Jedinica mjere 2' ,[kolicina2] as 'Količina 2'" +
        "  ,[odobrena_kolicina2] as 'Odobrena količina 2' ,[ukupna_cijena2] 'Ukupna cijena 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'Ident šifra 3'  ,[naziv3] as 'Naziv materijala',[jm3] as 'Jedinica mjere 3'" +
        "  ,[kolicina3] as 'Količina 3' ,[odobrena_kolicina3] as 'Odobrena količina 3' ,[ukupna_cijena3] 'Ukupna cijena 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'Ident šifra 4' ,[naziv4] as 'Naziv materijala 4' ,[jm4] as 'Jedinica mjere 4' ,[kolicina4] as 'Količina 4'" +
        " ,[odobrena_kolicina4] as 'Odobrena količina 4',[ukupna_cijena4] 'Ukupna cijena 4',[ident_sifra5] as 'Ident šifra 5'      ,[naziv5] as 'Naziv materijala 5'      ,[jm5] as 'Jedinica mjere 5'      ,[kolicina5] as 'Količina 5'      ,[odobrena_kolicina5] as 'Odobrena količina 5'      ,[ukupna_cijena5] 'Ukupna cijena 5'" +
        " ,[ident_sifra6] as 'Ident šifra 6' ,[naziv6] as 'Naziv materijala 6'      ,[jm6] as 'Jedinica mjere 6' ,[kolicina6] as 'Količina 6' ,[odobrena_kolicina6] as 'Odobrena količina 6'  ,[ukupna_cijena6] 'Ukupna cijena 6'      ,[ident_sifra7] as 'Ident šifra 7'      ,[naziv7] as 'Naziv materijala 7'      ,[jm7] as 'Jedinica mjere 7'" +
        " ,[kolicina7] as 'Količina 7'      ,[odobrena_kolicina7] as 'Odobrena količina 7' ,[ukupna_cijena7] 'Ukupna cijena 7'  ,[ident_sifra8] as 'Ident šifra 8'  ,[naziv8] as 'Naziv materijala'      ,[jm8] as 'Jedinica mjere 8'      ,[kolicina8] as 'Količina 8'      ,[odobrena_kolicina8] as 'Odobrena količina 8'      ,[ukupna_cijena8] as  'Ukupna cijena 8' " +
        "  ,[ident_sifra9] as 'Ident šifra 9'      ,[naziv9] as 'Naziv materijala 9'      ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'" +
        " ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11' from DiReqt where [tpo]='Da' and [podobrenje] is null or [podobrenje]='' ", connectionN);

                adapters.Fill(dtN);
                dataGridView1.DataSource = dtN;


            }

            else if (pu.Equals("Uprava"))
                {

                SqlConnection connectionN = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

                DataTable dtN = new DataTable();

                SqlDataAdapter adapters = new SqlDataAdapter("Select [id] as 'Request ID',[podnositelj] as 'Name and surname',[datum] as 'Date', [naziv_mt] as 'Cost designation' " +
        "  ,[datum_nabavka] as 'Pricing date'" +
        " ,[nabavka] as 'Purchasing employee',[ident_sifra] as 'ID Number' , [total] as 'Total',[valuta] as 'Currency', [naziv] as 'Material name'  ,[jm] as 'Unit of measure' ,[kolicina] as 'Količina'" +
        "  ,[odobrena_kolicina] as 'Approved quantity' ,[ukupna_cijena] 'Total price' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'ID Number 2' ,[naziv2] as 'Material name 2' ,[jm2] as 'Unit of measure 2' ,[kolicina2] as 'Quantity 2'" +
        "  ,[odobrena_kolicina2] as 'Approved quantity 2' ,[ukupna_cijena2] 'Total price 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'ID Number 3'  ,[naziv3] as 'Material name',[jm3] as 'Unit of measure 3'" +
        "  ,[kolicina3] as 'Quantity 3' ,[odobrena_kolicina3] as 'Approved quantity 3' ,[ukupna_cijena3] 'Total price 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'ID Number 4' ,[naziv4] as 'Material name 4' ,[jm4] as 'Unit of measure 4' ,[kolicina4] as 'Quantity 4'" +
        " ,[odobrena_kolicina4] as 'Approved quantity 4',[ukupna_cijena4] 'Total price 4',[ident_sifra5] as 'ID Number 5'   ,[naziv5] as 'Material name 5'      ,[jm5] as 'Unit of measure 5'      ,[kolicina5] as 'Quantity 5'      ,[odobrena_kolicina5] as 'Approved quantity 5'      ,[ukupna_cijena5] 'Total price 5'" +
        " ,[ident_sifra6] as 'ID Number 6' ,[naziv6] as 'Material name 6'      ,[jm6] as 'Unit of measure 6' ,[kolicina6] as 'Quantity 6' ,[odobrena_kolicina6] as 'Approved quantity 6'  ,[ukupna_cijena6] 'Total price 6'      ,[ident_sifra7] as 'ID Number 7'      ,[naziv7] as 'Material name 7'      ,[jm7] as 'Unit of measure 7'" +
        " ,[kolicina7] as 'Quantity 7'      ,[odobrena_kolicina7] as 'Approved quantity 7' ,[ukupna_cijena7] 'Total price 7'  ,[ident_sifra8] as 'ID Number 8'  ,[naziv8] as 'Material name'      ,[jm8] as 'Unit of measure 8'      ,[kolicina8] as 'Quantity 8'      ,[odobrena_kolicina8] as 'Approved quantity 8'      ,[ukupna_cijena8] as  'Total price 8' " +
        "  ,[ident_sifra9] as 'ID Number 9'      ,[naziv9] as 'Material name 9'      ,[jm9] as 'Unit of measure 9' ,[kolicina9] as 'Quantity 9' ,[odobrena_kolicina9] as 'Approved quantity 9'      ,[ukupna_cijena9] 'Total price 9'      ,[ident_sifra10] as 'ID Number 10'      ,[naziv10] as 'Material name 10'      ,[jm10] as 'Unit of measure 10'" +
        " ,[kolicina10] as 'Quantity 10',[odobrena_kolicina10] as 'Approved quantity 10',[ukupna_cijena10] 'Total price 10',[ident_sifra11] as 'ID Number 11',[naziv11] as 'Material name 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Quantity 11'      ,[odobrena_kolicina11] as 'Approved quantity 11',[ukupna_cijena11] as 'Total price 11' from DiReqt where [tpod]='Da' and  ([dodobrenje]  is null or [dodobrenje]='')   ", connectionN);

                adapters.Fill(dtN);
                dataGridView1.DataSource = dtN;

            }


            }

        private void LeftSidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (lblOdjel.Text.Equals("ADMIN"))

            {
                AdminPOS PR = new AdminPOS();
                PR.Show();
            }

            else
            {
                POS PR = new POS();
                PR.Show();
            }
;
        }

        private void panelOdobrenjeTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelButtoni_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
 