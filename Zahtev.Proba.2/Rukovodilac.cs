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
    public partial class Rukovodilac : Form
    {
        public Rukovodilac()
        {
            InitializeComponent();
        }





        //
        //Parametri potrebni za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
      


        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ,mPZOb;

        //
        //Klik na DIreqt logo vraća na main
        //
        private void picBoxDireqtLogo_Click(object sender, EventArgs e)
        {
            MainProgram mainForm = new MainProgram();
            mainForm.Show();
            Visible = false;
        }
        //
        //Funkcije za pomjeranje forme, treba spojiti sa panelom na vrhu svake forme (tamo gdje je x)
        //3 eventa MouseDown, MouseUp i MouseMove
        //
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
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

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //
        //X button
        //
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
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
        //Minimize button
        //
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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


        string em = "";
        string idbroj = "";
        string proid="";
        string izvor = "";

        string iduser = "";
        string jez = "";

        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Njem"))
            {
                lblBrZahtjevaOdobrenje.Text = "Antrag Nummer";
                button4.Text = "Antrag laden";
                btnOdobrenje.Text = "Genehmigung";
                btnZahtjeviNaCekanju.Text = "Anfragen werden gehalten";
                button6.Text = "Verantwortliche";


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
                mPZOb = "Antragsteller wurde informiert";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";


            }

            else if (Korisnik.Jezik.Equals("Bos"))
            {
                lblBrZahtjevaOdobrenje.Text = "Broj zahtjeva";
                button4.Text = "Učitvanje zahtjeva";
                btnOdobrenje.Text = "Odobrenje";
                btnZahtjeviNaCekanju.Text = "Zahtjevi na čekanju";
                button6.Text = "Odgovorne osobe";


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
                mPZOb = "Podnosilac zahtjeva je obavješten";
                   mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";




            }

        }
        

        private void Rukovodilac_Load(object sender, EventArgs e)
        {


            Rukovodilac frm1 = new Rukovodilac();
            frm1.Hide();
            //*frm3.Show();

            jez = Korisnik.Jezik;
            prjez();

            string username;

            username = Korisnik.korisnicko;

            string ime = "";
            string prezime = "";
            string odjel = "";
            string uloga = "";
            
            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [ime],[prezime],[odjel],[idbroj],[uloga],[idbroj] FROM Korisnici WHERE [username] = @usr ";

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
                odjel = (reader123["odjel"].ToString());
                iduser = (reader123["idbroj"].ToString());
                uloga = (reader123["uloga"].ToString());
                proid = (reader123["idbroj"].ToString());
            }

            else
            {
                reader123.Close();
                connection3.Close();
            }
            lblImePrezime.Text = ime + " " + prezime;
            lblOdjel.Text = odjel;


            if (uloga.Equals("Šef") || uloga.Equals("Direktor") || uloga.Equals("Admin"))
            {
                button6.Visible = true;
            }



        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        string prov = "";
        string odjel1 = "";
        string odjel2 = "";
        string odjel3 = "";
        string odjel4 = "";
        string odjel5 = "";

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
                textBox2.Text = "";
                return;
            }

            SqlConnection con = GetConnection();


            string ime = "";
            string datum = "";
            string ident = "";
            string odjel = "";
            string idbroj = "";

            string query3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj] FROM DiReqt WHERE [id] = @id ";



            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", textBox2.Text);

            SqlDataReader reader123 = command123.ExecuteReader();



            if (reader123.Read())
            {


                ime = (reader123["podnositelj"].ToString());
                datum = (reader123["datum"].ToString());
                ident = (reader123["id"].ToString());
                odjel = (reader123["odjel"].ToString());
                idbroj = (reader123["idbroj"].ToString());



                reader123.Close();
                con.Close();
            }

            else
            {
                reader123.Close();
                con.Close();
            }





            string q2 = "SELECT [idbroj] FROM Odjeli WHERE [odjel] = @id ";

            SqlCommand c2 = new SqlCommand(q2, con);
            con.Open();

            c2.Parameters.AddWithValue("@id", odjel);


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

          

            if (prov.Equals(proid))
            {

            }

            else
            {

                MessageBox.Show(mTNO);
                textBox2.Text = "";
                return;

            }


          
            string query5 = "SELECT [odjel1],[odjel2],[odjel3],[odjel4],[odjel5] FROM odobravanje WHERE [idbroj] = @id ";



            SqlCommand command5 = new SqlCommand(query5, con);
            con.Open();

            command5.Parameters.AddWithValue("@id", iduser);

            SqlDataReader reader5 = command5.ExecuteReader();

         
           // MessageBox.Show(iduser);
            if (reader5.Read())
            {



                odjel1 = (reader5["odjel1"].ToString());
                odjel2 = (reader5["odjel2"].ToString());
                odjel3 = (reader5["odjel3"].ToString());
                odjel4 = (reader5["odjel4"].ToString());
                odjel5 = (reader5["odjel5"].ToString());
                reader5.Close();
                con.Close();
            }

            else
            {
                reader5.Close();
                con.Close();
            }

          // MessageBox.Show(odjel1 + " " + odjel2);

            if ((odjel==odjel1) || (odjel==odjel2) || (odjel==odjel3) || (odjel == odjel4) || (odjel == odjel5))
            {




                PDF p = new PDF();
            p.id = textBox2.Text;

            string broj = textBox2.Text;




            bool result;
            result = PDFC.Create_PDF(broj);


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim()  + ".pdf";

                Korisnik.Pime = idbroj;
                Korisnik.Brz = textBox2.Text;

               
            


            axAcroPDF1.src = izvor;

            File.Delete(izvor);

            }

           else {

                MessageBox.Show(mNOo);
                return;
            }

            


           

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(mZBr);
                return;

            }
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                textBox2.Text = "";
                return;
            }

            SqlConnection con = GetConnection();

            SqlCommand podobri = new SqlCommand("Update [DiReqt] set [rukodo]=@st,[rukovodilac]=@rk where id=@konid", con);

            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


            podobri.Parameters.AddWithValue("@konid", textBox2.Text);


            string podobreno = "Odobreno";


            podobri.Parameters.AddWithValue("@st", podobreno);
            podobri.Parameters.AddWithValue("@rk", lblImePrezime.Text);

            con.Open();
            podobri.ExecuteNonQuery();

            PDF p = new PDF();
            p.id = textBox2.Text;



            string broj = textBox2.Text;




            bool result;
            result = PDFC.Create_PDF(broj);


            MessageBox.Show(mZO);





            //Mail
            try
            {


                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("From Address Ex direqt.nabavka@volkswagen-sa.ba" );
                MailMessage message = new MailMessage(from, to);
                message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                message.BodyEncoding = System.Text.Encoding.UTF8;




                message.Subject = "Odobren zahtjev: " + p.ime + " " + DateTime.Now.ToShortDateString() + " No. " + p.id;




                message.SubjectEncoding = System.Text.Encoding.UTF8;

                //
                //    MailAddress bcc = new MailAddress("direqt.nabavka@volkswagen-sa.ba");

                //  MailAddress bcc2 = new MailAddress("direqt.kontroling@volkswagen-sa.ba");
                // message.Bcc.Add(bcc);

                //   message.Bcc.Add(bcc2);


                System.Net.Mail.Attachment attachment;
                string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                if (!Directory.Exists(folderPath1))
                {
                    Directory.CreateDirectory(folderPath1);
                }
                // System.Net.Mail.Attachment attachment1;
                string folderPath41 = @"C:\Users\Public\Documents\ZZM\";

                if (!Directory.Exists(folderPath41))
                {
                    Directory.CreateDirectory(folderPath41);
                }
                attachment = new System.Net.Mail.Attachment(izvor);
                message.Attachments.Add(attachment);
                //  attachment1 = new System.Net.Mail.Attachment(folderPath1 + " " + this.textBox34.Text.Trim()+" " + DateTime.Now.ToShortDateString() + " No. " + textBox35.Text.Trim() + ".xls");
                // message.Attachments.Add(attachment1);


                client.Send(message);

                MessageBox.Show(mMail);
                foreach (System.Net.Mail.Attachment attachmentz in message.Attachments)

                {

                    attachment.Dispose();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }









        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(mZBr);
                return;

            }
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                textBox2.Text = "";
                return;
            }

            SqlConnection con = GetConnection();

            SqlCommand podobri = new SqlCommand("Update [DiReqt] set [rukodo]=@st,[rukovodilac]=@rk where id=@konid", con);

           


            podobri.Parameters.AddWithValue("@konid", textBox2.Text);


            string podobreno = "Odbijeno";


            podobri.Parameters.AddWithValue("@st", podobreno);
            podobri.Parameters.AddWithValue("@rk", lblImePrezime.Text);

            con.Open();
            podobri.ExecuteNonQuery();

           
            MessageBox.Show(mZahOdb);
            PDF p = new PDF();
            p.id = textBox2.Text;
            

            //bool result;

            idbroj = PDFC.GetValues(p.id);
          


            string query3 = "SELECT [email] FROM Korisnici WHERE [idbroj]=@ip ";
            SqlCommand odbij = new SqlCommand(query3,con);
            
            int a = Convert.ToInt32(idbroj);
            
            odbij.Parameters.AddWithValue("@ip", a);

            SqlDataReader reader123 = odbij.ExecuteReader();



            if (reader123.Read())
            {


                em = (reader123["email"].ToString());
               

            }

            else
            {
               
                reader123.Close();
                con.Close();
            }


            //Mail
            try
            {


                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("From Address Ex " + em);
                MailMessage message = new MailMessage(from, to);
                message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                message.BodyEncoding = System.Text.Encoding.UTF8;




                message.Subject = "Odbijen zahtjev: " + p.ime + " " + DateTime.Now.ToShortDateString() + " No. " + p.id;




                message.SubjectEncoding = System.Text.Encoding.UTF8;

                //
                //    MailAddress bcc = new MailAddress("direqt.nabavka@volkswagen-sa.ba");

                //  MailAddress bcc2 = new MailAddress("direqt.kontroling@volkswagen-sa.ba");
                // message.Bcc.Add(bcc);

                //   message.Bcc.Add(bcc2);


                //  System.Net.Mail.Attachment attachment;
                string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                if (!Directory.Exists(folderPath1))
                {
                    Directory.CreateDirectory(folderPath1);
                }
                // System.Net.Mail.Attachment attachment1;
                string folderPath41 = @"C:\Users\Public\Documents\ZZM\";

                if (!Directory.Exists(folderPath41))
                {
                    Directory.CreateDirectory(folderPath41);
                }


                client.Send(message);

                MessageBox.Show(mPZOb);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            

            if (lblOdjel.Text.Equals("ADMIN"))

            {
                AdminPR PR = new AdminPR();
                PR.Show();
            }

            else
            {
                PromjenaRukovodilaca PR = new PromjenaRukovodilaca();
                    PR.Show();
            }

        }

        private void LeftSidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(mZBr);
                return;

            }
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                textBox2.Text = "";
                return;
            }

            mail m = new mail();
            m.Show();
        }

        private void panelOdobrenjeRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = GetConnection();
            SqlCommand delete = new SqlCommand("Update DiReqt set  [rukovodilac]=@x,[rukodo]=@x" +
                
                  " where id=@lid", conn);
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            string query5 = "SELECT [odjel1],[odjel2],[odjel3],[odjel4],[odjel5] FROM odobravanje WHERE [idbroj] = @id ";



            SqlCommand command5 = new SqlCommand(query5, con);
            con.Open();

            command5.Parameters.AddWithValue("@id", iduser);

            SqlDataReader reader5 = command5.ExecuteReader();


            // MessageBox.Show(iduser);
            if (reader5.Read())
            {



                odjel1 = (reader5["odjel1"].ToString());
                odjel2 = (reader5["odjel2"].ToString());
                odjel3 = (reader5["odjel3"].ToString());
                odjel4 = (reader5["odjel4"].ToString());
                odjel5 = (reader5["odjel5"].ToString());
                reader5.Close();
                con.Close();
            }

            else
            {
                reader5.Close();
                con.Close();
            }



          



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
    "  ,[ident_sifra9] as 'Ident šifra 9',[naziv9] as 'Naziv materijala 9' ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'" +
    " ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11' from DiReqt where  ( [rukodo] is null or [rukodo]='') and (odjel=@od1 or odjel=@od2 or odjel=@od3 or odjel=@od4 or odjel=@od5) and ([nabavka] is null or [nabavka]='')", connectionN);


            adapters.SelectCommand.Parameters.AddWithValue("@od1", odjel1);
            adapters.SelectCommand.Parameters.AddWithValue("@od2", odjel2);
            adapters.SelectCommand.Parameters.AddWithValue("@od3", odjel3);
            adapters.SelectCommand.Parameters.AddWithValue("@od4", odjel4);
            adapters.SelectCommand.Parameters.AddWithValue("@od5", odjel5);

            adapters.Fill(dtN);
            dataGridView2.DataSource = dtN;









        }

        private void btnOdobrenje_Click_1(object sender, EventArgs e)
        {
            tbControl.SelectTab(0  );
        }

        private void panelOdobrenjeTop_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
