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
using System.Text;
using System.Threading.Tasks;



namespace DiReqt
{
    public partial class Kontroling : Form
    {
        public Kontroling()
        {
            InitializeComponent();
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        string job = "";

        string ime = "";
        string prezime = "";
        string odjel = "";
        string emkon = "";
        string emdir = "";
        string jez = "";
        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;




        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Bos"))
            {



                btnOdobrenjeZahtjeva.Text = "Odobrenje zahtjeva";
                btnPregledZahtjeva.Text = "Pregled zahtjeva";
                lblBrojZahtjevaUnosenjeCijene.Text = "Broj zahtjeva";
                checkBox1.Text = "Promjena količine";
                label5.Text = "Naziv materijala";
                label3.Text = "Količina";
                label4.Text = "Cijena";
                label2.Text = "Ukupna cijena";
                label1.Text = "Odobrena količina";
                button8.Text = "Završeni zahtjevi";
                button9.Text = "Nezavršeni zahtjevi";
                button5.Text = "Odobreno";
                button4.Text = "Neodobreno";






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
                //mOdgOs = " Odgovorna osoba za odjel " + comboBox1.Text + " je  ";
                mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";















            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {


                btnOdobrenjeZahtjeva.Text = "Genehmigung anfordern";
                btnPregledZahtjeva.Text = "Vorschau-Anfrage";
                lblBrojZahtjevaUnosenjeCijene.Text = "Antragsnummer";
                checkBox1.Text = "Mengenänderung";
                label5.Text = "Materialbeschreibung";
                label3.Text = "Menge";
                label4.Text = "Preis";
                label2.Text = "Konto";
                label1.Text = "Genehmigte menge";
                button8.Text = "Fertige Antragen";
                button9.Text = "Unvollendete Antragen";
                button5.Text = "Genehmigt";
                button4.Text = "Abgelehnt";




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
                //mOdgOs = " Die Verantwortliche Person für die Abteilung" + comboBox1.Text + " ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }


        private void Form4_Load(object sender, EventArgs e)
        {
            string username;
            jez = Korisnik.Jezik;
            prjez();

            username = Korisnik.korisnicko;

            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [ime],[prezime],[uloga],[odjel] FROM Korisnici WHERE [username] = @usr ";

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
                job = (reader123["uloga"].ToString());
                odjel = (reader123["odjel"].ToString());
            }

            else
            {
                reader123.Close();
                connection3.Close();
            }

            lblImePrezime.Text = ime + " " + prezime;
            lblOdjel.Text = odjel;







        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        //
        //Parametri potrebni za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;

        //
        //Klik na Direqt logo vraća na main
        //
       

        //
        //Minimize button
        //
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

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }










        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connectionN = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            DataTable dtN = new DataTable();

            SqlDataAdapter adapters = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[naziv_mt] as 'Naziv mjesta troška' " +
    "  ,[naziv_mt2] as 'Mjesto troška 2',[naziv_mt3] as 'Mjesto troška 3' ,[naziv_mt4] as 'Mjesto troška 4' ,[datum_nabavka] as 'Datum unošenja cijene',[datum_kontroling] as 'Datum odobrenja / odbijanja' ,[status] as 'Status'" +
    " ,[nabavka] as 'Referent nabavke',[kontroling] as 'Kontroling',[sklad] as 'Skladište',[napomena] as 'Napomena',[ident_sifra] as 'Ident šifra' ,[naziv] as 'Naziv materijala'  ,[jm] as 'Jedinica mjere' ,[kolicina] as 'Količina'" +
    "   ,[odobrena_kolicina] as 'Odobrena količina' ,[ukupna_cijena] 'Ukupna cijena' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'Ident šifra 2' ,[naziv2] as 'Naziv materijala 2' ,[jm2] as 'Jedinica mjere 2' ,[kolicina2] as 'Količina 2'" +
    "  ,[odobrena_kolicina2] as 'Odobrena količina 2' ,[ukupna_cijena2] 'Ukupna cijena 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'Ident šifra 3'  ,[naziv3] as 'Naziv materijala',[jm3] as 'Jedinica mjere 3'" +

    "  ,[kolicina3] as 'Količina 3' ,[odobrena_kolicina3] as 'Odobrena količina 3' ,[ukupna_cijena3] 'Ukupna cijena 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'Ident šifra 4' ,[naziv4] as 'Naziv materijala 4' ,[jm4] as 'Jedinica mjere 4' ,[kolicina4] as 'Količina 4'" +

// ",[kolicina3] as 'Količina'  ,[odobrena_kolicina3] as 'Odobrena količina' ,[ukupna_cijena3] as 'Ukupna cijena',[min3] as 'Min',[max3] as 'Max ,[stanje3] as 'Stanje',[ident_sifra4] as 'Ident šifra',[naziv4] as 'Naziv materijala',[jm4] as 'Jedinica mjere',[kolicina4] as 'Količina'"+
    " ,[odobrena_kolicina4] as 'Odobrena količina 4',[ukupna_cijena4] 'Ukupna cijena 4',[ident_sifra5] as 'Ident šifra 5'      ,[naziv5] as 'Naziv materijala 5'      ,[jm5] as 'Jedinica mjere 5'      ,[kolicina5] as 'Količina 5'      ,[odobrena_kolicina5] as 'Odobrena količina 5'      ,[ukupna_cijena5] 'Ukupna cijena 5'" +
    " ,[ident_sifra6] as 'Ident šifra 6' ,[naziv6] as 'Naziv materijala 6'      ,[jm6] as 'Jedinica mjere 6' ,[kolicina6] as 'Količina 6' ,[odobrena_kolicina6] as 'Odobrena količina 6'  ,[ukupna_cijena6] 'Ukupna cijena 6'      ,[ident_sifra7] as 'Ident šifra 7'      ,[naziv7] as 'Naziv materijala 7'      ,[jm7] as 'Jedinica mjere 7'" +
    " ,[kolicina7] as 'Količina 7'      ,[odobrena_kolicina7] as 'Odobrena količina 7' ,[ukupna_cijena7] 'Ukupna cijena 7'  ,[ident_sifra8] as 'Ident šifra 8'  ,[naziv8] as 'Naziv materijala'      ,[jm8] as 'Jedinica mjere 8'      ,[kolicina8] as 'Količina 8'      ,[odobrena_kolicina8] as 'Odobrena količina 8'      ,[ukupna_cijena8] as  'Ukupna cijena 8' " +
    "  ,[ident_sifra9] as 'Ident šifra 9'      ,[naziv9] as 'Naziv materijala 9'      ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'" +
    " ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11',[total] as 'Total' from DiReqt where status is NULL or status ='' ", connectionN);


            adapters.SelectCommand.Parameters.AddWithValue("@pid", lblImePrezime.Text);
            adapters.Fill(dtN);

            dataGridView2.DataSource = dtN;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                label1.Visible = true;
                textBox47.Visible = true;
                textBox48.Visible = true;
                textBox49.Visible = true;
                textBox50.Visible = true;
                textBox51.Visible = true;
                textBox52.Visible = true;
                textBox53.Visible = true;
                textBox54.Visible = true;
                textBox55.Visible = true;
                textBox56.Visible = true;
                textBox57.Visible = true;

                button7.Visible = true;
            }



            else
            {
                label1.Visible = false;
                textBox47.Visible = false;
                textBox48.Visible = false;
                textBox49.Visible = false;
                textBox50.Visible = false;
                textBox51.Visible = false;
                textBox52.Visible = false;
                textBox53.Visible = false;
                textBox54.Visible = false;
                textBox55.Visible = false;
                textBox56.Visible = false;
                textBox57.Visible = false;


            }
        }

        private void changeLabelText(string name, string text)
        {
            var label = Controls.Find(name, true).FirstOrDefault();
            label.Text = text;
        }





        private void button6_Click_1(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(textBox58.Text))
            {
                MessageBox.Show(mZBr);
                return;

            }

            int parsedValue;
            if (!int.TryParse(textBox58.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                return;
            }



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";

            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";
            textBox50.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            textBox54.Text = "";
            textBox55.Text = "";
            textBox56.Text = "";
            textBox57.Text = "";











            SqlConnection con = GetConnection();



            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [valuta],[total],[dodobrenje],[podobrenje] FROM DiReqt WHERE [id] = @ident ";


            string val = "";
            double tot = 0;
            string totalz = "";
            string po = "";
            string dio = "";

            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@ident", textBox58.Text);



            try
            {

                SqlDataReader reader123 = command123.ExecuteReader();

                try
                {
                    if (reader123.Read())
                    {


                        val = (reader123["valuta"].ToString());
                        totalz = (reader123["total"].ToString());
                        po = (reader123["podobrenje"].ToString());
                        dio = (reader123["dodobrenje"].ToString());

                    }

                    else
                    {
                        reader123.Close();
                        connection3.Close();
                        return;
                    }
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }



            string username;

            username = Korisnik.korisnicko;
            string job = "";
            SqlConnection conn = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string que = "SELECT [ime],[prezime],[uloga] FROM Kontroling_korisnici WHERE [username] = @usr ";





            SqlCommand com = new SqlCommand(que, conn);
            conn.Open();
            com.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader = com.ExecuteReader();


            if (reader.Read())
            {



                job = (reader["uloga"].ToString());

            }

            else
            {
                reader.Close();
                conn.Close();
                return;
            }

            /*  if (job.Equals("Referent") == false)
              {
                  label9.Visible = false;
                  button4.Visible = false;
                  button5.Visible = false;
              }
              else
              {
                  button5.Visible = true;
                  button4.Visible = true;
                  label9.Visible = true;
              }

              */

            try
            {
                tot = double.Parse(totalz);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(mCNU);
                return;
            }








            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3]" +
                                                     ",[sklad],[napomena],[valuta],[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11]" +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11]" +
                                                     ",[total],[ukupna_cijena],[ukupna_cijena2],[ukupna_cijena3],[ukupna_cijena4],[ukupna_cijena5],[ukupna_cijena6],[ukupna_cijena7],[ukupna_cijena8],[ukupna_cijena9],[ukupna_cijena10],[ukupna_cijena11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]," +
                                                     "[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8]" +
                                                     ",[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11] FROM DiReqt WHERE id = @kid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@kid", textBox58.Text);

            SqlDataReader reader1 = command1.ExecuteReader();

            string cijka = "";
            string cijka2 = "";
            string cijka3 = "";
            string cijka4 = "";
            string cijka5 = "";
            string cijka6 = "";
            string cijka7 = "";
            string cijka8 = "";
            string cijka9 = "";
            string cijka10 = "";

            string cijka11 = "";




            if (reader1.Read())
            {

                this.textBox1.Text = (reader1["naziv"].ToString());
                this.textBox2.Text = (reader1["naziv2"].ToString());
                this.textBox3.Text = (reader1["naziv3"].ToString());
                this.textBox4.Text = (reader1["naziv4"].ToString());
                this.textBox5.Text = (reader1["naziv5"].ToString());
                this.textBox6.Text = (reader1["naziv6"].ToString());
                this.textBox7.Text = (reader1["naziv7"].ToString());
                this.textBox8.Text = (reader1["naziv8"].ToString());
                this.textBox9.Text = (reader1["naziv9"].ToString());
                this.textBox10.Text = (reader1["naziv10"].ToString());
                this.textBox11.Text = (reader1["naziv11"].ToString());


                this.textBox23.Text = (reader1["kolicina"].ToString());
                this.textBox24.Text = (reader1["kolicina2"].ToString());
                this.textBox25.Text = (reader1["kolicina3"].ToString());
                this.textBox26.Text = (reader1["kolicina4"].ToString());
                this.textBox27.Text = (reader1["kolicina5"].ToString());
                this.textBox28.Text = (reader1["kolicina6"].ToString());
                this.textBox29.Text = (reader1["kolicina7"].ToString());
                this.textBox30.Text = (reader1["kolicina8"].ToString());
                this.textBox31.Text = (reader1["kolicina9"].ToString());
                this.textBox32.Text = (reader1["kolicina10"].ToString());
                this.textBox33.Text = (reader1["kolicina11"].ToString());

                this.textBox47.Text = (reader1["odobrena_kolicina"].ToString());


                if (string.IsNullOrEmpty(textBox47.Text))
                { }
                else
                {
                    checkBox1.Checked = true;
                }
                this.textBox48.Text = (reader1["odobrena_kolicina2"].ToString());
                this.textBox49.Text = (reader1["odobrena_kolicina3"].ToString());
                this.textBox50.Text = (reader1["odobrena_kolicina4"].ToString());
                this.textBox51.Text = (reader1["odobrena_kolicina5"].ToString());
                this.textBox52.Text = (reader1["odobrena_kolicina6"].ToString());
                this.textBox53.Text = (reader1["odobrena_kolicina7"].ToString());
                this.textBox54.Text = (reader1["odobrena_kolicina8"].ToString());
                this.textBox55.Text = (reader1["odobrena_kolicina9"].ToString());
                this.textBox56.Text = (reader1["odobrena_kolicina10"].ToString());
                this.textBox57.Text = (reader1["odobrena_kolicina11"].ToString());
                if (val == "KM")

                {
                    cijka = (reader1["cijena"].ToString());
                    if (cijka.Equals("0") == true)
                    {
                        cijka = "";
                    }
                    cijka2 = (reader1["cijena2"].ToString());
                    if (cijka2.Equals("0") == true)
                    {
                        cijka2 = "";
                    }
                    cijka3 = (reader1["cijena3"].ToString());
                    if (cijka3.Equals("0") == true)
                    {
                        cijka3 = "";
                    }
                    cijka4 = (reader1["cijena4"].ToString());
                    if (cijka4.Equals("0") == true)
                    {
                        cijka4 = "";
                    }
                    cijka5 = (reader1["cijena5"].ToString());
                    if (cijka5.Equals("0") == true)
                    {
                        cijka5 = "";
                    }
                    cijka6 = (reader1["cijena6"].ToString());
                    if (cijka6.Equals("0") == true)
                    {
                        cijka6 = "";
                    }
                    cijka7 = (reader1["cijena7"].ToString());
                    if (cijka7.Equals("0") == true)
                    {
                        cijka7 = "";
                    }
                    cijka8 = (reader1["cijena8"].ToString());
                    if (cijka8.Equals("0") == true)
                    {
                        cijka8 = "";
                    }
                    cijka9 = (reader1["cijena9"].ToString());
                    if (cijka9.Equals("0") == true)
                    {
                        cijka9 = "";
                    }
                    cijka10 = (reader1["cijena10"].ToString());
                    if (cijka10.Equals("0") == true)
                    {
                        cijka10 = "";
                    }
                    cijka11 = (reader1["cijena11"].ToString());
                    if (cijka11.Equals("0") == true)
                    {
                        cijka11 = "";
                    }

                    // ci = double.Parse(reader1["cijena"].ToString());
                    /*   ci2 = double.Parse(reader1["cijena2"].ToString());
                       ci3 = double.Parse(reader1["cijena3"].ToString());
                       ci4 = double.Parse(reader1["cijena4"].ToString());
                       ci5 = double.Parse(reader1["cijena5"].ToString());
                       ci6 = double.Parse(reader1["cijena6"].ToString());
                       ci7 = double.Parse(reader1["cijena7"].ToString());
                       ci8 = double.Parse(reader1["cijena8"].ToString());
                       ci9 = double.Parse(reader1["cijena9"].ToString());
                       ci10 = double.Parse(reader1["cijena10"].ToString());
                       ci11 = double.Parse(reader1["cijena11"].ToString());*/

                }


                if (val == "EUR")

                {

                    cijka = (reader1["cijena_eur"].ToString());
                    cijka2 = (reader1["cijena_eur2"].ToString());
                    cijka3 = (reader1["cijena_eur3"].ToString());
                    cijka4 = (reader1["cijena_eur4"].ToString());
                    cijka5 = (reader1["cijena_eur5"].ToString());
                    cijka6 = (reader1["cijena_eur6"].ToString());
                    cijka7 = (reader1["cijena_eur7"].ToString());
                    cijka8 = (reader1["cijena_eur8"].ToString());
                    cijka9 = (reader1["cijena_eur9"].ToString());

                    cijka10 = (reader1["cijena_eur10"].ToString());
                    cijka11 = (reader1["cijena_eur11"].ToString());

                    //ci = double.Parse(reader1["cijena_eur"].ToString());
                    /* ci2 = double.Parse(reader1["cijena_eur2"].ToString());
                     ci3 = double.Parse(reader1["cijena_eur3"].ToString());
                     ci4 = double.Parse(reader1["cijena_eur4"].ToString());
                     ci5 = double.Parse(reader1["cijena_eur5"].ToString());
                     ci6 = double.Parse(reader1["cijena_eur6"].ToString());
                     ci7 = double.Parse(reader1["cijena_eur7"].ToString());
                     ci8 = double.Parse(reader1["cijena_eur8"].ToString());
                     ci9 = double.Parse(reader1["cijena_eur9"].ToString());
                     ci10 = double.Parse(reader1["cijena_eur10"].ToString());
                     ci11 = double.Parse(reader1["cijena_eur11"].ToString());*/
                }

                /*  this.textBox22.Text = Convert.ToString(ci);
                */
                this.textBox22.Text = cijka;
                this.textBox21.Text = cijka2;
                this.textBox20.Text = cijka3;
                this.textBox19.Text = cijka4;
                this.textBox18.Text = cijka5;
                this.textBox17.Text = cijka6;
                this.textBox16.Text = cijka7;
                this.textBox15.Text = cijka8;
                this.textBox14.Text = cijka9;
                this.textBox13.Text = cijka10;
                this.textBox12.Text = cijka11;




                this.textBox44.Text = (reader1["ukupna_cijena"].ToString());
                this.textBox43.Text = (reader1["ukupna_cijena2"].ToString());
                this.textBox42.Text = (reader1["ukupna_cijena3"].ToString());
                this.textBox41.Text = (reader1["ukupna_cijena4"].ToString());
                this.textBox40.Text = (reader1["ukupna_cijena5"].ToString());
                this.textBox39.Text = (reader1["ukupna_cijena6"].ToString());
                this.textBox38.Text = (reader1["ukupna_cijena7"].ToString());
                this.textBox37.Text = (reader1["ukupna_cijena8"].ToString());
                this.textBox36.Text = (reader1["ukupna_cijena9"].ToString());
                this.textBox35.Text = (reader1["ukupna_cijena10"].ToString());
                this.textBox34.Text = (reader1["ukupna_cijena11"].ToString());



                string ident_sifra = (reader1["ident_sifra"].ToString());
                string ident_sifra2 = (reader1["ident_sifra2"].ToString());
                string ident_sifra3 = (reader1["ident_sifra3"].ToString());
                string ident_sifra4 = (reader1["ident_sifra4"].ToString());
                string ident_sifra5 = (reader1["ident_sifra5"].ToString());
                string ident_sifra6 = (reader1["ident_sifra6"].ToString());
                string ident_sifra7 = (reader1["ident_sifra7"].ToString());
                string ident_sifra8 = (reader1["ident_sifra8"].ToString());
                string ident_sifra9 = (reader1["ident_sifra9"].ToString());
                string ident_sifra10 = (reader1["ident_sifra10"].ToString());
                string ident_sifra11 = (reader1["ident_sifra11"].ToString());

                string valuta = (reader1["valuta"].ToString());
                string bam = "KM";



                


                if (valuta == bam)
                {

                    for (int i = 1; i <= 23; i++)
                    {
                        changeLabelText("lblValutaC" + i, "KM");
                    }

                }
                else if (valuta == "EUR")
                {

                    for (int i = 1; i <= 23; i++)
                    {
                        changeLabelText("lblValutaC" + i, "€");
                    }
                }

            }

            else
            {
                reader1.Close();
                return;

            }


            // label9.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            button7.Visible = true;

        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();
            try
            {

                SqlCommand odobri = new SqlCommand("Update [DiReqt] set [status]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                odobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string odobreno = "Odobreno";

                odobri.Parameters.AddWithValue("@st", odobreno);


                con.Open();
                odobri.ExecuteNonQuery();
                MessageBox.Show(mZO);

                button4.Visible = false;
                button5.Visible = false;

                button1.Visible = true;

            }
            finally
            {
                con.Close();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();
            try
            {

                SqlCommand odobri = new SqlCommand("Update [DiReqt] set [status]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                odobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string odbijeno = "Odbijeno";

                odobri.Parameters.AddWithValue("@st", odbijeno);


                con.Open();
                odobri.ExecuteNonQuery();
                MessageBox.Show(mZNO);

                button4.Visible = false;
                button5.Visible = false;

                button1.Visible = true;

            }
            finally
            {
                con.Close();
            }

        }

        private void button7_Click_1(object sender, EventArgs e)
        {






            if (checkBox1.Checked == true)
            {

                if (string.IsNullOrEmpty(textBox47.Text))
                {
                    MessageBox.Show(mOKnu);
                    return;
                }
            }







            double uci = 0;
            double uci1 = 0;
            double uci2 = 0;
            double uci3 = 0;
            double uci4 = 0;

            double uci5 = 0;
            double uci6 = 0;
            double uci7 = 0;
            double uci8 = 0;
            double uci9 = 0;
            double uci10 = 0;
            double total = 0.0;

            /////////




            ////////////////
            if (checkBox1.Checked == true)
            {




                if (string.IsNullOrEmpty(textBox1.Text))
                {
                }
                else
                {
                    double cci = Convert.ToDouble(textBox22.Text);

                    int ckoli = Convert.ToInt32(textBox47.Text);

                    uci = cci * ckoli;

                    textBox44.Text = uci.ToString();
                }

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                }
                else
                {
                    double cci1 = Convert.ToDouble(textBox21.Text);
                    int ckoli1 = Convert.ToInt32(textBox48.Text);
                    uci1 = cci1 * ckoli1;
                    textBox43.Text = uci1.ToString();
                }

                if (string.IsNullOrEmpty(textBox3.Text))
                {
                }
                else
                {
                    double cci2 = Convert.ToDouble(textBox20.Text);
                    int ckoli2 = Convert.ToInt32(textBox49.Text);
                    uci2 = cci2 * ckoli2;
                    textBox42.Text = uci2.ToString();
                }

                if (string.IsNullOrEmpty(textBox4.Text))
                {
                }
                else
                {
                    double cci3 = Convert.ToDouble(textBox19.Text);
                    int ckoli3 = Convert.ToInt32(textBox50.Text);
                    uci3 = cci3 * ckoli3;
                    textBox41.Text = uci3.ToString();
                }


                if (string.IsNullOrEmpty(textBox5.Text))
                {
                }
                else
                {
                    double cci4 = Convert.ToDouble(textBox18.Text);
                    int ckoli4 = Convert.ToInt32(textBox51.Text);
                    uci4 = cci4 * ckoli4;
                    textBox40.Text = uci4.ToString();
                }

                if (string.IsNullOrEmpty(textBox6.Text))
                {
                }
                else
                {
                    double cci5 = Convert.ToDouble(textBox17.Text);
                    int ckoli5 = Convert.ToInt32(textBox52.Text);
                    uci5 = cci5 * ckoli5;
                    textBox39.Text = uci5.ToString();
                }

                if (string.IsNullOrEmpty(textBox7.Text))
                {
                }
                else
                {
                    double cci6 = Convert.ToDouble(textBox16.Text);
                    int ckoli6 = Convert.ToInt32(textBox53.Text);
                    uci6 = cci6 * ckoli6;
                    textBox38.Text = uci6.ToString();
                }
                if (string.IsNullOrEmpty(textBox8.Text))
                {
                }
                else
                {
                    double cci7 = Convert.ToDouble(textBox15.Text);
                    int ckoli7 = Convert.ToInt32(textBox54.Text);
                    uci7 = cci7 * ckoli7;
                    textBox37.Text = uci7.ToString();
                }

                if (string.IsNullOrEmpty(textBox9.Text))
                {
                }
                else
                {
                    double cci8 = Convert.ToDouble(textBox14.Text);
                    int ckoli8 = Convert.ToInt32(textBox55.Text);
                    uci8 = cci8 * ckoli8;
                    textBox36.Text = uci8.ToString();
                }
                if (string.IsNullOrEmpty(textBox10.Text))
                {
                }
                else
                {
                    double cci9 = Convert.ToDouble(textBox13.Text);
                    int ckoli9 = Convert.ToInt32(textBox56.Text);
                    uci9 = cci9 * ckoli9;
                    textBox35.Text = uci9.ToString();
                }
                if (string.IsNullOrEmpty(textBox11.Text))
                {
                }
                else
                {
                    double cci10 = Convert.ToDouble(textBox12.Text);
                    int ckoli10 = Convert.ToInt32(textBox57.Text);
                    uci10 = cci10 * ckoli10;
                    textBox34.Text = uci10.ToString();
                }






                total = uci + uci1 + uci2 + uci3 + uci4 + uci5 + uci6 + uci7 + uci8 + uci9 + uci10;
            }



            else
            {

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                }
                else
                {
                    double cci = Convert.ToDouble(textBox22.Text);

                    int ckoli = Convert.ToInt32(textBox23.Text);

                    uci = cci * ckoli;

                    textBox44.Text = uci.ToString();
                }




                if (string.IsNullOrEmpty(textBox2.Text))
                {
                }
                else
                {
                    double cci1 = Convert.ToDouble(textBox21.Text);
                    int ckoli1 = Convert.ToInt32(textBox24.Text);
                    uci1 = cci1 * ckoli1;
                    textBox43.Text = uci1.ToString();
                }

                if (string.IsNullOrEmpty(textBox3.Text))
                {
                }
                else
                {
                    double cci2 = Convert.ToDouble(textBox20.Text);
                    int ckoli2 = Convert.ToInt32(textBox25.Text);
                    uci2 = cci2 * ckoli2;
                    textBox42.Text = uci2.ToString();
                }

                if (string.IsNullOrEmpty(textBox4.Text))
                {
                }
                else
                {
                    double cci3 = Convert.ToDouble(textBox19.Text);
                    int ckoli3 = Convert.ToInt32(textBox26.Text);
                    uci3 = cci3 * ckoli3;
                    textBox41.Text = uci3.ToString();
                }


                if (string.IsNullOrEmpty(textBox5.Text))
                {
                }
                else
                {
                    double cci4 = Convert.ToDouble(textBox18.Text);
                    int ckoli4 = Convert.ToInt32(textBox27.Text);
                    uci4 = cci4 * ckoli4;
                    textBox40.Text = uci4.ToString();
                }

                if (string.IsNullOrEmpty(textBox6.Text))
                {
                }
                else
                {
                    double cci5 = Convert.ToDouble(textBox17.Text);
                    int ckoli5 = Convert.ToInt32(textBox28.Text);
                    uci5 = cci5 * ckoli5;
                    textBox39.Text = uci5.ToString();
                }

                if (string.IsNullOrEmpty(textBox7.Text))
                {
                }
                else
                {
                    double cci6 = Convert.ToDouble(textBox16.Text);
                    int ckoli6 = Convert.ToInt32(textBox29.Text);
                    uci6 = cci6 * ckoli6;
                    textBox38.Text = uci6.ToString();
                }
                if (string.IsNullOrEmpty(textBox8.Text))
                {
                }
                else
                {
                    double cci7 = Convert.ToDouble(textBox15.Text);
                    int ckoli7 = Convert.ToInt32(textBox30.Text);
                    uci7 = cci7 * ckoli7;
                    textBox37.Text = uci7.ToString();
                }

                if (string.IsNullOrEmpty(textBox9.Text))
                {
                }
                else
                {
                    double cci8 = Convert.ToDouble(textBox14.Text);
                    int ckoli8 = Convert.ToInt32(textBox31.Text);
                    uci8 = cci8 * ckoli8;
                    textBox36.Text = uci8.ToString();
                }
                if (string.IsNullOrEmpty(textBox10.Text))
                {
                }
                else
                {
                    double cci9 = Convert.ToDouble(textBox13.Text);
                    int ckoli9 = Convert.ToInt32(textBox32.Text);
                    uci9 = cci9 * ckoli9;
                    textBox35.Text = uci9.ToString();
                }
                if (string.IsNullOrEmpty(textBox11.Text))
                {
                }
                else
                {
                    double cci10 = Convert.ToDouble(textBox12.Text);
                    int ckoli10 = Convert.ToInt32(textBox33.Text);
                    uci10 = cci10 * ckoli10;
                    textBox34.Text = uci10.ToString();
                }






                total = uci + uci1 + uci2 + uci3 + uci4 + uci5 + uci6 + uci7 + uci8 + uci9 + uci10;




            }


            textBox46.Text = total.ToString();




            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [valuta],[total],[dodobrenje],[podobrenje] FROM DiReqt WHERE [id] = @ident ";


            string val = "";
            double tot = 0;
            tot = total;


            string po = "";
            string dio = "";

            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@ident", textBox58.Text);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {


                val = (reader123["valuta"].ToString());

                po = (reader123["podobrenje"].ToString());
                dio = (reader123["dodobrenje"].ToString());

            }

            else
            {
                reader123.Close();
                connection3.Close();
                return;
            }



            string n = "";
            string n2 = "";
            string n3 = "";
            string n4 = "";
            string n5 = "";
            string n6 = "";
            string n7 = "";
            string n8 = "";
            string n9 = "";
            string n10 = "";
            string n11 = "";

            string k = "";
            string k2 = "";
            string k3 = "";
            string k4 = "";
            string k5 = "";
            string k6 = "";
            string k7 = "";
            string k8 = "";
            string k9 = "";
            string k10 = "";
            string k11 = "";

            string ci = "";
            string ci2 = "";
            string ci3 = "";
            string ci4 = "";
            string ci5 = "";
            string ci6 = "";
            string ci7 = "";
            string ci8 = "";
            string ci9 = "";
            string ci10 = "";
            string ci11 = "";

            string tuci = "";
            string tuci2 = "";
            string tuci3 = "";
            string tuci4 = "";
            string tuci5 = "";
            string tuci6 = "";
            string tuci7 = "";
            string tuci8 = "";
            string tuci9 = "";
            string tuci10 = "";
            string tuci11 = "";




            string jm = "";
            string jm2 = "";
            string jm3 = "";
            string jm4 = "";
            string jm5 = "";
            string jm6 = "";
            string jm7 = "";
            string jm8 = "";
            string jm9 = "";
            string jm10 = "";
            string jm11 = "";
            string mt = "";
            string mt2 = "";
            string mt3 = "";
            string mt4 = "";
            string st = "";
            string st2 = "";
            string st3 = "";
            string st4 = "";
            string ime = "";
            string datum = "";
            string stoks = "";
            string vrsta = "";
            string min = "";
            string min2 = "";
            string min3 = "";
            string max = "";
            string max2 = "";
            string max3 = "";
            string stanje = "";
            string stanje2 = "";
            string stanje3 = "";
            string sklad = "";
            string napo = "";
            string napnab = "";
            string ids = " ";
            string ids2 = " ";
            string ids3 = " ";
            string ids4 = " ";
            string ids5 = " ";
            string ids6 = " ";
            string ids7 = " ";
            string ids8 = " ";
            string ids9 = " ";
            string ids10 = " ";
            string ids11 = " ";
            string datumnab = "";
            string vt = "";
            string status = "";
            string ok = "";
            string ok2 = "";
            string ok3 = "";
            string ok4 = "";
            string ok5 = "";
            string ok6 = "";
            string ok7 = "";
            string ok8 = "";
            string ok9 = "";
            string ok10 = "";
            string ok11 = "";
            string cij = "";
            string cij2 = "";
            string cij3 = "";
            string cij4 = "";
            string cij5 = "";
            string cij6 = "";
            string cij7 = "";
            string cij8 = "";
            string cij9 = "";
            string cij10 = "";
            string cij11 = "";

            string cijeuro = "";
            string cijeuro2 = "";
            string cijeuro3 = "";
            string cijeuro4 = "";
            string cijeuro5 = "";
            string cijeuro6 = "";
            string cijeuro7 = "";
            string cijeuro8 = "";
            string cijeuro9 = "";
            string cijeuro10 = "";
            string cijeuro11 = "";
            string odjel = "";
            string nam = "";

            double ckm = 0;
            double ckm2 = 0;
            double ckm3 = 0;
            double ckm4 = 0;
            double ckm5 = 0;
            double ckm6 = 0;
            double ckm7 = 0;
            double ckm8 = 0;
            double ckm9 = 0;
            double ckm10 = 0;
            double ckm11 = 0;


            double uc = 0;
            double uc2 = 0;
            double uc3 = 0;
            double uc4 = 0;
            double uc5 = 0;
            double uc6 = 0;
            double uc7 = 0;
            double uc8 = 0;
            double uc9 = 0;
            double uc10 = 0;
            double uc11 = 0;

            int koc = 0;
            int koc2 = 0;
            int koc3 = 0;
            int koc4 = 0;
            int koc5 = 0;
            int koc6 = 0;
            int koc7 = 0;
            int koc8 = 0;
            int koc9 = 0;
            int koc10 = 0;
            int koc11 = 0;
            string datkon = "";
            string kod = "";
            string dod = "";


            SqlConnection conz = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string qy = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status],[nabavka]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[datum_kontroling],[podobrenje],[dodobrenje],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel],[total] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand c1 = new SqlCommand(qy, conz);
            conz.Open();
            c1.Parameters.AddWithValue("@zid", textBox58.Text);

            SqlDataReader r1 = c1.ExecuteReader();


            if (r1.Read())
            {
                n = (r1["naziv"].ToString());
                n2 = (r1["naziv2"].ToString());
                n3 = (r1["naziv3"].ToString());
                n4 = (r1["naziv4"].ToString());
                n5 = (r1["naziv5"].ToString());
                n6 = (r1["naziv6"].ToString());
                n7 = (r1["naziv7"].ToString());
                n8 = (r1["naziv8"].ToString());
                n9 = (r1["naziv9"].ToString());
                n10 = (r1["naziv10"].ToString());
                n11 = (r1["naziv11"].ToString());

                k = (r1["kolicina"].ToString());
                k2 = (r1["kolicina2"].ToString());
                k3 = (r1["kolicina3"].ToString());
                k4 = (r1["kolicina4"].ToString());
                k5 = (r1["kolicina5"].ToString());
                k6 = (r1["kolicina6"].ToString());
                k7 = (r1["kolicina7"].ToString());
                k8 = (r1["kolicina8"].ToString());
                k9 = (r1["kolicina9"].ToString());
                k10 = (r1["kolicina10"].ToString());
                k11 = (r1["kolicina11"].ToString());


                ids = (r1["ident_sifra"].ToString());
                ids2 = (r1["ident_sifra2"].ToString());
                ids3 = (r1["ident_sifra3"].ToString());
                ids4 = (r1["ident_sifra4"].ToString());
                ids5 = (r1["ident_sifra5"].ToString());
                ids6 = (r1["ident_sifra6"].ToString());
                ids7 = (r1["ident_sifra7"].ToString());
                ids8 = (r1["ident_sifra8"].ToString());
                ids9 = (r1["ident_sifra9"].ToString());
                ids10 = (r1["ident_sifra10"].ToString());
                ids11 = (r1["ident_sifra11"].ToString());

                jm = (r1["jm"].ToString());
                jm2 = (r1["jm2"].ToString());
                jm3 = (r1["jm3"].ToString());
                jm4 = (r1["jm4"].ToString());
                jm5 = (r1["jm5"].ToString());
                jm6 = (r1["jm6"].ToString());
                jm7 = (r1["jm7"].ToString());
                jm8 = (r1["jm8"].ToString());
                jm9 = (r1["jm9"].ToString());
                jm10 = (r1["jm10"].ToString());
                jm11 = (r1["jm11"].ToString());
                mt = (r1["naziv_mt"].ToString());
                mt2 = (r1["naziv_mt2"].ToString());
                mt3 = (r1["naziv_mt3"].ToString());
                mt4 = (r1["naziv_mt4"].ToString());
                st = (r1["sifra_mt"].ToString());
                st2 = (r1["sifra_mt2"].ToString());
                st3 = (r1["sifra_mt3"].ToString());
                st4 = (r1["sifra_mt4"].ToString());
                ime = (r1["podnositelj"].ToString());
                datum = (r1["datum"].ToString());
                datumnab = (r1["datum_nabavka"].ToString());
                stoks = (r1["stok"].ToString());
                vrsta = (r1["vrsta"].ToString());
                min = (r1["min"].ToString());
                min2 = (r1["min2"].ToString());
                min3 = (r1["min3"].ToString());
                max = (r1["max"].ToString());
                max2 = (r1["max2"].ToString());
                max3 = (r1["max3"].ToString());
                stanje = (r1["stanje"].ToString());
                stanje2 = (r1["stanje2"].ToString());
                stanje3 = (r1["stanje3"].ToString());
                sklad = (r1["sklad"].ToString());
                napo = (r1["napomena"].ToString());
                napnab = (r1["napnab"].ToString());
                nam = (r1["nabavka"].ToString());
                vt = (r1["valuta"].ToString());
                status = (r1["status"].ToString());


                if (checkBox1.Checked == false)

                {
                    ok = textBox23.Text;
                    ok2 = textBox24.Text;
                    ok3 = textBox25.Text;
                    ok4 = textBox26.Text;
                    ok5 = textBox27.Text;
                    ok6 = textBox28.Text;
                    ok7 = textBox29.Text;
                    ok8 = textBox30.Text;
                    ok9 = textBox31.Text;
                    ok10 = textBox32.Text;
                    ok11 = textBox33.Text;

                    /*
                    ok = (r1["odobrena_kolicina"].ToString());
                    ok2 = (r1["odobrena_kolicina2"].ToString());
                    ok3 = (r1["odobrena_kolicina3"].ToString());
                    ok4 = (r1["odobrena_kolicina4"].ToString());
                    ok5 = (r1["odobrena_kolicina5"].ToString());
                    ok6 = (r1["odobrena_kolicina6"].ToString());
                    ok7 = (r1["odobrena_kolicina7"].ToString());
                    ok8 = (r1["odobrena_kolicina8"].ToString());
                    ok9 = (r1["odobrena_kolicina9"].ToString());
                    ok10 = (r1["odobrena_kolicina10"].ToString());
                    ok11 = (r1["odobrena_kolicina11"].ToString());*/
                }
                else
                {
                    ok = textBox47.Text;
                    ok2 = textBox48.Text;
                    ok3 = textBox49.Text;
                    ok4 = textBox50.Text;
                    ok5 = textBox51.Text;
                    ok6 = textBox52.Text;
                    ok7 = textBox53.Text;
                    ok8 = textBox54.Text;
                    ok9 = textBox55.Text;
                    ok10 = textBox56.Text;
                    ok11 = textBox57.Text;


                    /*
                    ok = (r1["odobrena_kolicina"].ToString());
                    ok2 = (r1["odobrena_kolicina2"].ToString());
                    ok3 = (r1["odobrena_kolicina3"].ToString());
                    ok4 = (r1["odobrena_kolicina4"].ToString());
                    ok5 = (r1["odobrena_kolicina5"].ToString());
                    ok6 = (r1["odobrena_kolicina6"].ToString());
                    ok7 = (r1["odobrena_kolicina7"].ToString());
                    ok8 = (r1["odobrena_kolicina8"].ToString());
                    ok9 = (r1["odobrena_kolicina9"].ToString());
                    ok10 = (r1["odobrena_kolicina10"].ToString());
                    ok11 = (r1["odobrena_kolicina11"].ToString());*/
                }

                datkon = (r1["datum_kontroling"].ToString());
                kod = (r1["podobrenje"].ToString());
                dod = (r1["dodobrenje"].ToString());
                cij = (r1["cijena"].ToString());
                cij2 = (r1["cijena2"].ToString());
                cij3 = (r1["cijena3"].ToString());
                cij4 = (r1["cijena4"].ToString());
                cij5 = (r1["cijena5"].ToString());
                cij6 = (r1["cijena6"].ToString());
                cij7 = (r1["cijena7"].ToString());
                cij8 = (r1["cijena8"].ToString());
                cij9 = (r1["cijena9"].ToString());
                cij10 = (r1["cijena10"].ToString());
                cij11 = (r1["cijena11"].ToString());
                nam = (r1["nabavka"].ToString());
                cijeuro = (r1["cijena_eur"].ToString());
                cijeuro2 = (r1["cijena_eur2"].ToString());
                cijeuro3 = (r1["cijena_eur3"].ToString());
                cijeuro4 = (r1["cijena_eur4"].ToString());
                cijeuro5 = (r1["cijena_eur5"].ToString());
                cijeuro6 = (r1["cijena_eur6"].ToString());
                cijeuro7 = (r1["cijena_eur7"].ToString());
                cijeuro8 = (r1["cijena_eur8"].ToString());
                cijeuro9 = (r1["cijena_eur9"].ToString());
                cijeuro10 = (r1["cijena_eur10"].ToString());
                cijeuro11 = (r1["cijena_eur11"].ToString());
                odjel = (r1["odjel"].ToString());


                //toti = (r1["total"].ToString());


            }

            else
            {
                r1.Close();
            }

            conz.Close();




            string ini = "";

            SqlConnection cot = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string quey = "SELECT [inicijali] FROM Nabavka_korisnici WHERE [ime i prezime] = @usr ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand coma = new SqlCommand(quey, cot);
            cot.Open();
            coma.Parameters.AddWithValue("@usr", nam);

            SqlDataReader rex = coma.ExecuteReader();


            if (rex.Read())
            {


                ini = (rex["inicijali"].ToString());



            }

            else
            {
                rex.Close();
                cot.Close();
            }








            if (vt.Equals("KM") == true)
            {
                ci = cij;

                ci2 = cij2;
                ci3 = cij3;
                ci4 = cij4;
                ci5 = cij5;
                ci6 = cij6;
                ci7 = cij7;
                ci8 = cij8;
                ci9 = cij9;
                ci10 = cij10;
                ci11 = cij11;



                if (string.IsNullOrEmpty(status))

                {


                    if (string.IsNullOrEmpty(ci))
                    {

                    }
                    else
                    {
                        ckm = double.Parse(ci);
                        koc = Int32.Parse(k);
                        uc = ckm * koc;
                        tuci = Convert.ToString(uc);
                    }

                    if (string.IsNullOrEmpty(ci2))
                    {
                    }
                    else
                    {
                        ckm2 = double.Parse(cij2);
                        koc2 = Int32.Parse(k2);
                        uc2 = ckm2 * koc2;
                        tuci2 = Convert.ToString(uc2);

                    }
                    if (string.IsNullOrEmpty(ci3))
                    {
                    }
                    else
                    {
                        ckm3 = double.Parse(cij3);
                        koc3 = Int32.Parse(k3);
                        uc3 = ckm3 * koc3;
                        tuci3 = Convert.ToString(uc3);
                    }
                    if (string.IsNullOrEmpty(ci4))
                    {
                    }
                    else
                    {


                        ckm4 = double.Parse(cij4);
                        koc4 = Int32.Parse(k4);
                        uc4 = ckm4 * koc4;
                        tuci4 = Convert.ToString(uc4);
                    }
                    if (string.IsNullOrEmpty(ci5))
                    {
                    }
                    else
                    {
                        ckm5 = double.Parse(cij5);
                        koc5 = Int32.Parse(k5);
                        uc5 = ckm5 * koc5;
                        tuci5 = Convert.ToString(uc5);
                    }
                    if (string.IsNullOrEmpty(ci6))
                    {
                    }
                    else
                    {
                        ckm6 = double.Parse(cij6);
                        koc6 = Int32.Parse(k6);
                        uc6 = ckm6 * koc6;
                        tuci6 = Convert.ToString(uc6);

                    }
                    if (string.IsNullOrEmpty(ci7))
                    {
                    }
                    else
                    {
                        ckm7 = double.Parse(cij7);
                        koc7 = Int32.Parse(k7);
                        uc7 = ckm7 * koc7;
                        tuci7 = Convert.ToString(uc7);


                    }
                    if (string.IsNullOrEmpty(ci8))
                    {
                    }
                    else
                    {
                        ckm8 = double.Parse(cij8);
                        koc8 = Int32.Parse(k8);
                        uc8 = ckm8 * koc8;
                        tuci8 = Convert.ToString(uc8);

                    }
                    if (string.IsNullOrEmpty(ci9))
                    {
                    }
                    else
                    {
                        ckm9 = double.Parse(cij9);
                        koc9 = Int32.Parse(k9);
                        uc9 = ckm9 * koc9;
                        tuci9 = Convert.ToString(uc9);
                    }
                    if (string.IsNullOrEmpty(ci10))
                    {
                    }
                    else
                    {
                        ckm10 = double.Parse(cij10);
                        koc10 = Int32.Parse(k10);

                        uc10 = ckm10 * koc10;

                        tuci10 = Convert.ToString(uc10);
                    }
                    if (string.IsNullOrEmpty(ci11))
                    {
                    }
                    else
                    {
                        ckm11 = double.Parse(cij11);
                        koc11 = Int32.Parse(k11);
                        uc11 = ckm11 * koc11;
                        tuci11 = Convert.ToString(uc11);
                    }





                }

                else
                {

                    if (string.IsNullOrEmpty(ci))
                    {

                    }
                    else
                    {
                        ckm = double.Parse(ci);
                        koc = Int32.Parse(ok);
                        uc = ckm * koc;
                        tuci = Convert.ToString(uc);
                    }

                    if (string.IsNullOrEmpty(ci2))
                    {
                    }
                    else
                    {
                        ckm2 = double.Parse(cij2);
                        koc2 = Int32.Parse(ok2);
                        uc2 = ckm2 * koc2;
                        tuci2 = Convert.ToString(uc2);

                    }
                    if (string.IsNullOrEmpty(ci3))
                    {
                    }
                    else
                    {
                        ckm3 = double.Parse(cij3);
                        koc3 = Int32.Parse(ok3);
                        uc3 = ckm3 * koc3;
                        tuci3 = Convert.ToString(uc3);
                    }
                    if (string.IsNullOrEmpty(ci4))
                    {
                    }
                    else
                    {


                        ckm4 = double.Parse(cij4);
                        koc4 = Int32.Parse(ok4);
                        uc4 = ckm4 * koc4;
                        tuci4 = Convert.ToString(uc4);
                    }
                    if (string.IsNullOrEmpty(ci5))
                    {
                    }
                    else
                    {
                        ckm5 = double.Parse(cij5);
                        koc5 = Int32.Parse(ok5);
                        uc5 = ckm5 * koc5;
                        tuci5 = Convert.ToString(uc5);
                    }
                    if (string.IsNullOrEmpty(ci6))
                    {
                    }
                    else
                    {
                        ckm6 = double.Parse(cij6);
                        koc6 = Int32.Parse(ok6);
                        uc6 = ckm6 * koc6;
                        tuci6 = Convert.ToString(uc6);

                    }
                    if (string.IsNullOrEmpty(ci7))
                    {
                    }
                    else
                    {
                        ckm7 = double.Parse(cij7);
                        koc7 = Int32.Parse(ok7);
                        uc7 = ckm7 * koc7;
                        tuci7 = Convert.ToString(uc7);


                    }
                    if (string.IsNullOrEmpty(ci8))
                    {
                    }
                    else
                    {
                        ckm8 = double.Parse(cij8);
                        koc8 = Int32.Parse(ok8);
                        uc8 = ckm8 * koc8;
                        tuci8 = Convert.ToString(uc8);

                    }
                    if (string.IsNullOrEmpty(ci9))
                    {
                    }
                    else
                    {
                        ckm9 = double.Parse(cij9);
                        koc9 = Int32.Parse(ok9);
                        uc9 = ckm9 * koc9;
                        tuci9 = Convert.ToString(uc9);
                    }
                    if (string.IsNullOrEmpty(ci10))
                    {
                    }
                    else
                    {
                        ckm10 = double.Parse(cij10);
                        koc10 = Int32.Parse(ok10);

                        uc10 = ckm10 * koc10;

                        tuci10 = Convert.ToString(uc10);
                    }
                    if (string.IsNullOrEmpty(ci11))
                    {
                    }
                    else
                    {
                        ckm11 = double.Parse(cij11);
                        koc11 = Int32.Parse(ok11);
                        uc11 = ckm11 * koc11;
                        tuci11 = Convert.ToString(uc11);
                    }




                }









            }

            else if (vt.Equals("EUR") == true)
            {
                ci = cijeuro;
                ci2 = cijeuro2;
                ci3 = cijeuro3;
                ci4 = cijeuro4;
                ci5 = cijeuro5;
                ci6 = cijeuro6;
                ci7 = cijeuro7;
                ci8 = cijeuro8;
                ci9 = cijeuro9;
                ci10 = cijeuro10;
                ci11 = cijeuro11;


                if (string.IsNullOrEmpty(status))

                {


                    if (string.IsNullOrEmpty(ci))
                    {

                    }
                    else
                    {
                        ckm = double.Parse(ci);
                        koc = Int32.Parse(k);
                        uc = ckm * koc;
                        tuci = Convert.ToString(uc);
                    }

                    if (string.IsNullOrEmpty(ci2))
                    {
                    }
                    else
                    {
                        ckm2 = double.Parse(cij2);
                        koc2 = Int32.Parse(k2);
                        uc2 = ckm2 * koc2;
                        tuci2 = Convert.ToString(uc2);

                    }
                    if (string.IsNullOrEmpty(ci3))
                    {
                    }
                    else
                    {
                        ckm3 = double.Parse(cij3);
                        koc3 = Int32.Parse(k3);
                        uc3 = ckm3 * koc3;
                        tuci3 = Convert.ToString(uc3);
                    }
                    if (string.IsNullOrEmpty(ci4))
                    {
                    }
                    else
                    {


                        ckm4 = double.Parse(cij4);
                        koc4 = Int32.Parse(k4);
                        uc4 = ckm4 * koc4;
                        tuci4 = Convert.ToString(uc4);
                    }
                    if (string.IsNullOrEmpty(ci5))
                    {
                    }
                    else
                    {
                        ckm5 = double.Parse(cij5);
                        koc5 = Int32.Parse(k5);
                        uc5 = ckm5 * koc5;
                        tuci5 = Convert.ToString(uc5);
                    }
                    if (string.IsNullOrEmpty(ci6))
                    {
                    }
                    else
                    {
                        ckm6 = double.Parse(cij6);
                        koc6 = Int32.Parse(k6);
                        uc6 = ckm6 * koc6;
                        tuci6 = Convert.ToString(uc6);

                    }
                    if (string.IsNullOrEmpty(ci7))
                    {
                    }
                    else
                    {
                        ckm7 = double.Parse(cij7);
                        koc7 = Int32.Parse(k7);
                        uc7 = ckm7 * koc7;
                        tuci7 = Convert.ToString(uc7);


                    }
                    if (string.IsNullOrEmpty(ci8))
                    {
                    }
                    else
                    {
                        ckm8 = double.Parse(cij8);
                        koc8 = Int32.Parse(k8);
                        uc8 = ckm8 * koc8;
                        tuci8 = Convert.ToString(uc8);

                    }
                    if (string.IsNullOrEmpty(ci9))
                    {
                    }
                    else
                    {
                        ckm9 = double.Parse(cij9);
                        koc9 = Int32.Parse(k9);
                        uc9 = ckm9 * koc9;
                        tuci9 = Convert.ToString(uc9);
                    }
                    if (string.IsNullOrEmpty(ci10))
                    {
                    }
                    else
                    {
                        ckm10 = double.Parse(cij10);
                        koc10 = Int32.Parse(k10);

                        uc10 = ckm10 * koc10;

                        tuci10 = Convert.ToString(uc10);
                    }
                    if (string.IsNullOrEmpty(ci11))
                    {
                    }
                    else
                    {
                        ckm11 = double.Parse(cij11);
                        koc11 = Int32.Parse(k11);
                        uc11 = ckm11 * koc11;
                        tuci11 = Convert.ToString(uc11);
                    }





                }

                else
                {

                    if (string.IsNullOrEmpty(ci))
                    {

                    }
                    else
                    {
                        ckm = double.Parse(ci);
                        koc = Int32.Parse(ok);
                        uc = ckm * koc;
                        tuci = Convert.ToString(uc);
                    }

                    if (string.IsNullOrEmpty(ci2))
                    {
                    }
                    else
                    {
                        ckm2 = double.Parse(cij2);
                        koc2 = Int32.Parse(ok2);
                        uc2 = ckm2 * koc2;
                        tuci2 = Convert.ToString(uc2);

                    }
                    if (string.IsNullOrEmpty(ci3))
                    {
                    }
                    else
                    {
                        ckm3 = double.Parse(cij3);
                        koc3 = Int32.Parse(ok3);
                        uc3 = ckm3 * koc3;
                        tuci3 = Convert.ToString(uc3);
                    }
                    if (string.IsNullOrEmpty(ci4))
                    {
                    }
                    else
                    {


                        ckm4 = double.Parse(cij4);
                        koc4 = Int32.Parse(ok4);
                        uc4 = ckm4 * koc4;
                        tuci4 = Convert.ToString(uc4);
                    }
                    if (string.IsNullOrEmpty(ci5))
                    {
                    }
                    else
                    {
                        ckm5 = double.Parse(cij5);
                        koc5 = Int32.Parse(ok5);
                        uc5 = ckm5 * koc5;
                        tuci5 = Convert.ToString(uc5);
                    }
                    if (string.IsNullOrEmpty(ci6))
                    {
                    }
                    else
                    {
                        ckm6 = double.Parse(cij6);
                        koc6 = Int32.Parse(ok6);
                        uc6 = ckm6 * koc6;
                        tuci6 = Convert.ToString(uc6);

                    }
                    if (string.IsNullOrEmpty(ci7))
                    {
                    }
                    else
                    {
                        ckm7 = double.Parse(cij7);
                        koc7 = Int32.Parse(ok7);
                        uc7 = ckm7 * koc7;
                        tuci7 = Convert.ToString(uc7);


                    }
                    if (string.IsNullOrEmpty(ci8))
                    {
                    }
                    else
                    {
                        ckm8 = double.Parse(cij8);
                        koc8 = Int32.Parse(ok8);
                        uc8 = ckm8 * koc8;
                        tuci8 = Convert.ToString(uc8);

                    }
                    if (string.IsNullOrEmpty(ci9))
                    {
                    }
                    else
                    {
                        ckm9 = double.Parse(cij9);
                        koc9 = Int32.Parse(ok9);
                        uc9 = ckm9 * koc9;
                        tuci9 = Convert.ToString(uc9);
                    }
                    if (string.IsNullOrEmpty(ci10))
                    {
                    }
                    else
                    {
                        ckm10 = double.Parse(cij10);
                        koc10 = Int32.Parse(ok10);

                        uc10 = ckm10 * koc10;

                        tuci10 = Convert.ToString(uc10);
                    }
                    if (string.IsNullOrEmpty(ci11))
                    {
                    }
                    else
                    {
                        ckm11 = double.Parse(cij11);
                        koc11 = Int32.Parse(ok11);
                        uc11 = ckm11 * koc11;
                        tuci11 = Convert.ToString(uc11);
                    }




                }







            }












            SqlConnection con = GetConnection();

            SqlCommand upkolicine = new SqlCommand("Update [DiReqt] set [ukupna_cijena]=@uci,[ukupna_cijena2]=@uci2,[ukupna_cijena3]=@uci3,[ukupna_cijena4]=@uci4,[ukupna_cijena5]=@uci5,[ukupna_cijena6]=@uci6" +
                   ",[ukupna_cijena7]=@uci7,[ukupna_cijena8]=@uci8,[ukupna_cijena9]=@uci9,[ukupna_cijena10]=@uci10,[ukupna_cijena11]=@uci11,[total]=@tot,[odobrena_kolicina]=@ok" +
                    ",[odobrena_kolicina2]=@ok2,[odobrena_kolicina3]=@ok3,[odobrena_kolicina4]=@ok4,[odobrena_kolicina5]=@ok5,[odobrena_kolicina6]=@ok6,[odobrena_kolicina7]=@ok7,[odobrena_kolicina8]=@ok8,[odobrena_kolicina9]=@ok9,[odobrena_kolicina10]=@ok10,[odobrena_kolicina11]=@ok11 where id=@zaid", con);

            upkolicine.Parameters.AddWithValue("@zaid", textBox58.Text);


            if (checkBox1.Checked == true)
            {



                upkolicine.Parameters.AddWithValue("@ok", textBox47.Text);

                upkolicine.Parameters.AddWithValue("@uci", textBox44.Text);

                upkolicine.Parameters.AddWithValue("@ok2", textBox48.Text);

                upkolicine.Parameters.AddWithValue("@uci2", textBox43.Text);

                upkolicine.Parameters.AddWithValue("@ok3", textBox49.Text);

                upkolicine.Parameters.AddWithValue("@uci3", textBox42.Text);

                upkolicine.Parameters.AddWithValue("@ok4", textBox50.Text);

                upkolicine.Parameters.AddWithValue("@uci4", textBox41.Text);

                upkolicine.Parameters.AddWithValue("@ok5", textBox51.Text);

                upkolicine.Parameters.AddWithValue("@uci5", textBox40.Text);

                upkolicine.Parameters.AddWithValue("@ok6", textBox52.Text);

                upkolicine.Parameters.AddWithValue("@uci6", textBox39.Text);

                upkolicine.Parameters.AddWithValue("@ok7", textBox53.Text);

                upkolicine.Parameters.AddWithValue("@uci7", textBox38.Text);

                upkolicine.Parameters.AddWithValue("@ok8 ", textBox54.Text);

                upkolicine.Parameters.AddWithValue("@uci8", textBox37.Text);

                upkolicine.Parameters.AddWithValue("@ok9", textBox55.Text);

                upkolicine.Parameters.AddWithValue("@uci9", textBox36.Text);

                upkolicine.Parameters.AddWithValue("@ok10", textBox56.Text);

                upkolicine.Parameters.AddWithValue("@uci10", textBox35.Text);

                upkolicine.Parameters.AddWithValue("@ok11", textBox57.Text);

                upkolicine.Parameters.AddWithValue("@uci11", textBox34.Text);

                upkolicine.Parameters.AddWithValue("@tot", textBox46.Text);
            }
            else
            {
                upkolicine.Parameters.AddWithValue("@ok", textBox23.Text);

                upkolicine.Parameters.AddWithValue("@uci", textBox44.Text);

                upkolicine.Parameters.AddWithValue("@ok2", textBox24.Text);

                upkolicine.Parameters.AddWithValue("@uci2", textBox43.Text);

                upkolicine.Parameters.AddWithValue("@ok3", textBox25.Text);

                upkolicine.Parameters.AddWithValue("@uci3", textBox42.Text);

                upkolicine.Parameters.AddWithValue("@ok4", textBox26.Text);

                upkolicine.Parameters.AddWithValue("@uci4", textBox41.Text);

                upkolicine.Parameters.AddWithValue("@ok5", textBox27.Text);

                upkolicine.Parameters.AddWithValue("@uci5", textBox40.Text);

                upkolicine.Parameters.AddWithValue("@ok6", textBox28.Text);

                upkolicine.Parameters.AddWithValue("@uci6", textBox39.Text);

                upkolicine.Parameters.AddWithValue("@ok7", textBox29.Text);

                upkolicine.Parameters.AddWithValue("@uci7", textBox38.Text);

                upkolicine.Parameters.AddWithValue("@ok8 ", textBox30.Text);

                upkolicine.Parameters.AddWithValue("@uci8", textBox37.Text);

                upkolicine.Parameters.AddWithValue("@ok9", textBox31.Text);

                upkolicine.Parameters.AddWithValue("@uci9", textBox36.Text);

                upkolicine.Parameters.AddWithValue("@ok10", textBox32.Text);

                upkolicine.Parameters.AddWithValue("@uci10", textBox35.Text);

                upkolicine.Parameters.AddWithValue("@ok11", textBox33.Text);

                upkolicine.Parameters.AddWithValue("@uci11", textBox34.Text);

                upkolicine.Parameters.AddWithValue("@tot", textBox46.Text);
            }

            con.Open();
            upkolicine.ExecuteNonQuery();

            //  MessageBox.Show("Količine su izmijenjene!");
            con.Close();





         
       
            string ident = "";
       
            string idbroj = "";
            string izvor = "";
            string q3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj] FROM DiReqt WHERE [id] = @id ";



            SqlCommand c12 = new SqlCommand(q3, con);
            con.Open();

            c12.Parameters.AddWithValue("@id", textBox58.Text);

            SqlDataReader r12 = c12.ExecuteReader();



            if (r12.Read())
            {


               
                ident = (r12["id"].ToString());
             
                idbroj = (r12["idbroj"].ToString());



                r12.Close();
                con.Close();
            }

            else
            {
                r12.Close();
                con.Close();
            }



            PDF p = new PDF();
            p.id = textBox58.Text;

            string broj = textBox58.Text;




            bool result;
            result = PDFC.Create_PDF(broj);


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";

            string prov = "";
            string prov2 = "";



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

            int b = Convert.ToInt32(prov2);
       

            string query8 = "SELECT [email] FROM Korisnici WHERE [idbroj] =@id2 ";

            SqlCommand c5 = new SqlCommand(query8, con);
            con.Open();


            c5.Parameters.AddWithValue("@id2", b);
            SqlDataReader r5 = c5.ExecuteReader();



            if (r5.Read())
            {

                emdir = (r5["email"].ToString());

                r5.Close();
                con.Close();

            }

            else
            {
                r5.Close();
                con.Close();
            }
            int a = Convert.ToInt32(prov);
          

            string query7= "SELECT [email] FROM Korisnici WHERE [idbroj] =@id ";

            SqlCommand c4 = new SqlCommand(query7, con);
            con.Open();

            c4.Parameters.AddWithValue("@id", a);

            SqlDataReader r4 = c4.ExecuteReader();



            if (r4.Read())
            {

                emkon = (r4["email"].ToString());

                r4.Close();
                con.Close();
            }

            else
            {
                r4.Close();
                con.Close();
            }

           



            if (total >= 1000 && total < 10000 && val.Equals("KM") == true)
            {

                try
                {


                    if (po.Equals("Odbijen"))


                    {
                        if (MessageBox.Show(mZoZ, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            try
                            {



                                button4.Visible = true;
                                button5.Visible = false;



                            }
                            finally
                            {
                                con.Close();

                            }

                        }
                        else
                        {
                            return;
                        }


                    }


                    else if (!po.Equals("Odobreno"))
                    {


                        if (MessageBox.Show(mZTOpm, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {


                            try
                            {

                                SqlCommand update = new SqlCommand("Update [DiReqt] set [tpo]='Da' where id=@zaid", con);


                                update.Parameters.AddWithValue("@zaid", textBox58.Text);

                                con.Open();
                                update.ExecuteNonQuery();




                                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                                client.EnableSsl = true;
                                client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                                MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                                MailAddress to = new MailAddress("From Address Ex " + emkon);
                                MailMessage message = new MailMessage(from, to);
                                message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                                message.BodyEncoding = System.Text.Encoding.UTF8;
                                message.Subject = "Posebno odobrenje";
                                message.SubjectEncoding = System.Text.Encoding.UTF8;


                                System.Net.Mail.Attachment attachmentz;
                                string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                                if (!Directory.Exists(folderPath1))
                                {
                                    Directory.CreateDirectory(folderPath1);
                                }

                                attachmentz = new System.Net.Mail.Attachment(izvor);
                                message.Attachments.Add(attachmentz);

                                client.Send(message);
                                MessageBox.Show(mKZS);


                                foreach (System.Net.Mail.Attachment attachment in message.Attachments)

                                {

                                    attachment.Dispose();

                                }

                                brisanje();



                                File.Delete(izvor);





                                // 

                                button5.Visible = false;
                                button4.Visible = false;


                                //  textBox58.Text = "";


                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }

                            con.Close();
                            return;

                        }


                        else
                        {

                            button4.Visible = true;
                            return;
                        }
                    }

                    else if (po.Equals("Odobreno"))
                    {

                        button4.Visible = true;
                        button5.Visible = true;
                        return;

                    }


                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }

            }





            else if (total >= 511.29 && total < 5112.92 && val.Equals("EUR") == true)
            {

                if ((po.Equals("Odbijen") || dio.Equals("Odbijen")) && job.Equals("Referent") == true)


                {
                    if (MessageBox.Show(mZoZ, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {



                            button4.Visible = true;
                            button5.Visible = false;



                        }
                        finally
                        {
                            con.Close();
                        }

                    }



                    else
                    {
                        button4.Visible = false;
                        button5.Visible = false;

                        return;
                    }


                }


                else if (!po.Equals("Odobreno"))
                {
                    if (MessageBox.Show(mZTOpm, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        try
                        {
                            SqlCommand update = new SqlCommand("Update [DiReqt] set [tpo]='Da' where id=@zaid", con);


                            update.Parameters.AddWithValue("@zaid", textBox58.Text);
                            con.Open();
                            update.ExecuteNonQuery();

                            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                            client.EnableSsl = true;
                            client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                            MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                            MailAddress to = new MailAddress("From Address Ex "+ emkon);
                            MailMessage message = new MailMessage(from, to);
                            message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.Subject = "Posebno odobrenje";
                            message.SubjectEncoding = System.Text.Encoding.UTF8;


                            System.Net.Mail.Attachment attachmentz;
                            string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                            if (!Directory.Exists(folderPath1))
                            {
                                Directory.CreateDirectory(folderPath1);
                            }

                            attachmentz = new System.Net.Mail.Attachment(izvor);
                            message.Attachments.Add(attachmentz);

                           client.Send(message);
                            MessageBox.Show(mKZSK);



                            foreach (System.Net.Mail.Attachment attachment in message.Attachments)

                            {

                                attachment.Dispose();

                            }


                            File.Delete(izvor);
                            brisanje();
                            // textBox58.Text = "";

                            button4.Visible = false;
                            button5.Visible = false;

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.ToString());

                        }
                        con.Close();

                        return;

                    }




                    else
                    {


                        button4.Visible = true;
                        return;
                    }
                }

                else if (po.Equals("Odobreno"))
                {

                    button4.Visible = true;
                    button5.Visible = true;

                }

            }






            else if (total >= 10000 && val.Equals("KM") == true)
            {


                if ((po.Equals("Odbijen") || dio.Equals("Odbijen")) && job.Equals("Referent") == true)


                {
                    if (MessageBox.Show(mZoZ, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {


                            button4.Visible = true;
                            button5.Visible = false;



                        }
                        finally
                        {
                            con.Close();
                        }

                    }
                    else
                    {
                        button4.Visible = false;
                        button5.Visible = false;

                        return;
                    }


                }




                else if (!dio.Equals("Odobreno") == true && job.Equals("Referent") == true)

                {
                    if (MessageBox.Show(mZTPOD, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {


                            SqlCommand update = new SqlCommand("Update [DiReqt] set [tpo]='Da', [tpod]='Da' where id=@zaid", con);



                            update.Parameters.AddWithValue("@zaid", textBox58.Text);

                            con.Open();
                            update.ExecuteNonQuery();




                            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                            client.EnableSsl = true;
                            client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                            MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                            MailAddress to = new MailAddress("From Address Ex " + emkon);
                            MailMessage message = new MailMessage(from, to);
                            message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.Subject = "Posebno odobrenje / Special approval";
                            message.SubjectEncoding = System.Text.Encoding.UTF8;



                            MailAddress bcc2 = new MailAddress(emdir);
                            message.Bcc.Add(bcc2);

                            /*OpenFileDialog fol = new OpenFileDialog();
                            fol.ShowDialog();*/
                            System.Net.Mail.Attachment attachmentz;
                            string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                            if (!Directory.Exists(folderPath1))
                            {
                                Directory.CreateDirectory(folderPath1);
                            }

                            attachmentz = new System.Net.Mail.Attachment(izvor);
                            message.Attachments.Add(attachmentz);

                           client.Send(message);
                            MessageBox.Show(mKZPKD);

                            foreach (System.Net.Mail.Attachment attachment in message.Attachments)

                            {

                                attachment.Dispose();

                            }

                            brisanje();

                            File.Delete(izvor);
                            // textBox58.Text = "";

                            button4.Visible = false;
                            button5.Visible = false;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            con.Close();
                        }
                        return;
                    }



                    else
                    {
                        button4.Visible = false;
                        button5.Visible = false;

                        return;
                    }

                }

                else
                {
                    button4.Visible = true;
                    button5.Visible = true;


                }

            }



            else if (total >= 5112.92 && val.Equals("EUR") == true)
            {
                if ((po.Equals("Odbijen") || dio.Equals("Odbijen")) && job.Equals("Referent") == true)


                {
                    if (MessageBox.Show(mZoZ, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {

                            button4.Visible = true;
                            button5.Visible = false;



                        }
                        finally
                        {
                            con.Close();

                        }

                    }
                    else
                    {
                        return;
                    }


                }


                else if ((!dio.Equals("Odobreno") == true || !po.Equals("Odobreno") == true) && job.Equals("Referent") == true)
                {
                    if (MessageBox.Show(mZTOpm, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {


                            SqlCommand update = new SqlCommand("Update [DiReqt] set [tpo]='Da', [tpod]='Da' where id=@zaid", con);



                            update.Parameters.AddWithValue("@zaid", textBox58.Text);

                            con.Open();
                            update.ExecuteNonQuery();




                            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                            client.EnableSsl = true;
                            client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                            MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                            MailAddress to = new MailAddress("From Address Ex "+ emkon);
                            MailMessage message = new MailMessage(from, to);
                            message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.Subject = "Posebno odobrenje / Special approval";
                            message.SubjectEncoding = System.Text.Encoding.UTF8;



                            MailAddress bcc2 = new MailAddress(emdir);
                            message.Bcc.Add(bcc2);

                            /*OpenFileDialog fol = new OpenFileDialog();
                            fol.ShowDialog();*/
                            System.Net.Mail.Attachment attachmentz;
                            string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                            if (!Directory.Exists(folderPath1))
                            {
                                Directory.CreateDirectory(folderPath1);
                            }

                            attachmentz = new System.Net.Mail.Attachment(izvor);
                            message.Attachments.Add(attachmentz);

                            client.Send(message);
                            MessageBox.Show(mKZPKD);

                            foreach (System.Net.Mail.Attachment attachment in message.Attachments)

                            {

                                attachment.Dispose();

                            }

                            brisanje();
                            File.Delete(izvor);
                            // textBox58.Text = "";

                            button4.Visible = false;
                            button5.Visible = false;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            con.Close();
                        }
                        return;
                    }
                    else
                    {
                        button4.Visible = true;
                        button5.Visible = false;

                        return;
                    }

                }
            }


            else
            {
                button4.Visible = true;
                button5.Visible = true;



            }





        



        textBox46.Text = total.ToString();
        }


    

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = GetConnection();



            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [valuta] FROM DiReqt WHERE [id] = @ident ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */
            string val = "";
            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@ident", textBox58.Text);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {


                val = (reader123["valuta"].ToString());


            }

            else
            {
                reader123.Close();
                connection3.Close();
            }

            if (checkBox1.Checked)
            {

                try
                {

                    SqlCommand update = new SqlCommand("Update [DiReqt] set [cijena_eur]=@cie,[ukupna_cijena]=@uci,[ukupna_cijena2]=@uci2,[ukupna_cijena3]=@uci3,[ukupna_cijena4]=@uci4,[ukupna_cijena5]=@uci5,[ukupna_cijena6]=@uci6" +
                        ",[cijena_eur2]=@cie2,[cijena_eur3]=@cie3,[cijena_eur4]=@cie4,[cijena_eur5]=@cie5,[cijena_eur6]=@cie6,[cijena_eur7]=@cie7,[cijena_eur8]=@cie8,[cijena_eur9]=@cie9,[cijena_eur10]=@cie10,[cijena_eur11]=@cie11" +
                        ",[cijena]=@ci,[cijena2]=@ci2,[cijena3]=@ci3,[cijena4]=@ci4,[cijena5]=@ci5,[cijena6]=@ci6,[cijena7]=@ci7,[cijena8]=@ci8,[cijena9]=@ci9,[cijena10]=@ci10,[cijena11]=@ci11" +
                        ",[ukupna_cijena7]=@uci7,[ukupna_cijena8]=@uci8,[ukupna_cijena9]=@uci9,[ukupna_cijena10]=@uci10,[ukupna_cijena11]=@uci11,[total]=@tot,[datum_kontroling]=@dat_kon,[kontroling]=@kon,[odobrena_kolicina]=@ok" +
                        ",[odobrena_kolicina2]=@ok2,[odobrena_kolicina3]=@ok3,[odobrena_kolicina4]=@ok4,[odobrena_kolicina5]=@ok5,[odobrena_kolicina6]=@ok6,[odobrena_kolicina7]=@ok7,[odobrena_kolicina8]=@ok8,[odobrena_kolicina9]=@ok9,[odobrena_kolicina10]=@ok10,[odobrena_kolicina11]=@ok11 where id=@konid", con);

                    SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                    update.Parameters.AddWithValue("@konid", textBox58.Text);


                    double cibam = 0;
                    double cibam2 = 0;
                    double cibam3 = 0;
                    double cibam4 = 0;
                    double cibam5 = 0;
                    double cibam6 = 0;
                    double cibam7 = 0;
                    double cibam8 = 0;
                    double cibam9 = 0;
                    double cibam10 = 0;
                    double cibam11 = 0;

                    double cieu = 0;
                    double cieu2 = 0;
                    double cieu3 = 0;
                    double cieu4 = 0;
                    double cieu5 = 0;
                    double cieu6 = 0;
                    double cieu7 = 0;
                    double cieu8 = 0;
                    double cieu9 = 0;
                    double cieu10 = 0;
                    double cieu11 = 0;

                    double euro = 1.95583;


                    double cipot;
                    double cipot2;
                    double cipot3;
                    double cipot4;
                    double cipot5;
                    double cipot6;
                    double cipot7;
                    double cipot8;
                    double cipot9;
                    double cipot10;
                    double cipot11;

                    string valuta = val;






                    if (string.IsNullOrEmpty(textBox22.Text))
                    { cipot = 0; }
                    else
                    { cipot = double.Parse(textBox22.Text); }

                    if (string.IsNullOrEmpty(textBox21.Text))
                    { cipot2 = 0; }
                    else
                    { cipot2 = double.Parse(textBox21.Text); }


                    if (string.IsNullOrEmpty(textBox20.Text))
                    { cipot3 = 0; }
                    else
                    { cipot3 = double.Parse(textBox20.Text); }

                    if (string.IsNullOrEmpty(textBox19.Text))
                    { cipot4 = 0; }
                    else
                    { cipot4 = double.Parse(textBox19.Text); }

                    if (string.IsNullOrEmpty(textBox18.Text))
                    { cipot5 = 0; }
                    else
                    { cipot5 = double.Parse(textBox18.Text); }

                    if (string.IsNullOrEmpty(textBox17.Text))
                    { cipot6 = 0; }
                    else
                    { cipot6 = double.Parse(textBox17.Text); }

                    if (string.IsNullOrEmpty(textBox16.Text))
                    { cipot7 = 0; }
                    else
                    { cipot7 = double.Parse(textBox16.Text); }

                    if (string.IsNullOrEmpty(textBox15.Text))
                    { cipot8 = 0; }
                    else
                    { cipot8 = double.Parse(textBox15.Text); }

                    if (string.IsNullOrEmpty(textBox14.Text))
                    { cipot9 = 0; }
                    else
                    { cipot9 = double.Parse(textBox14.Text); }

                    if (string.IsNullOrEmpty(textBox13.Text))
                    { cipot10 = 0; }
                    else
                    { cipot10 = double.Parse(textBox13.Text); }

                    if (string.IsNullOrEmpty(textBox12.Text))
                    { cipot11 = 0; }
                    else
                    { cipot11 = double.Parse(textBox12.Text); }




                    if (valuta == "KM")
                    {
                        cibam = cipot;
                        cibam2 = cipot2;
                        cibam3 = cipot3;
                        cibam4 = cipot4;
                        cibam5 = cipot5;
                        cibam6 = cipot6;
                        cibam7 = cipot7;
                        cibam8 = cipot8;
                        cibam9 = cipot9;
                        cibam10 = cipot10;
                        cibam11 = cipot11;



                        cieu = cipot / euro;
                        cieu2 = cipot2 / euro;
                        cieu3 = cipot3 / euro;
                        cieu4 = cipot4 / euro;
                        cieu5 = cipot5 / euro;
                        cieu6 = cipot6 / euro;
                        cieu7 = cipot7 / euro;
                        cieu8 = cipot8 / euro;
                        cieu9 = cipot9 / euro;
                        cieu10 = cipot10 / euro;
                        cieu11 = cipot11 / euro;


                    }
                    else if (valuta == "EUR")
                    {
                        cibam = cipot * euro;
                        cibam2 = cipot2 * euro;
                        cibam3 = cipot3 * euro;

                        cibam4 = cipot4 * euro;

                        cibam5 = cipot5 * euro;
                        cibam6 = cipot6 * euro;
                        cibam7 = cipot7 * euro;
                        cibam8 = cipot8 * euro;
                        cibam9 = cipot9 * euro;
                        cibam10 = cipot10 * euro;
                        cibam11 = cipot11 * euro;

                        cieu = cipot;
                        cieu2 = cipot2;
                        cieu3 = cipot3;

                        cieu4 = cipot4;

                        cieu5 = cipot5;
                        cieu6 = cipot6;
                        cieu7 = cipot7;
                        cieu8 = cipot8;
                        cieu9 = cipot9;
                        cieu10 = cipot10;
                        cieu11 = cipot11;
                    }

                    cibam = Math.Round(cibam, 2);
                    cibam2 = Math.Round(cibam2, 2);
                    cibam3 = Math.Round(cibam3, 2);
                    cibam4 = Math.Round(cibam4, 2);
                    cibam5 = Math.Round(cibam5, 2);
                    cibam6 = Math.Round(cibam6, 2);
                    cibam7 = Math.Round(cibam7, 2);
                    cibam8 = Math.Round(cibam8, 2);

                    cibam9 = Math.Round(cibam9, 2);
                    cibam10 = Math.Round(cibam10, 2);
                    cibam11 = Math.Round(cibam11, 2);


                    cieu = Math.Round(cieu, 2);
                    cieu2 = Math.Round(cieu2, 2);
                    cieu3 = Math.Round(cieu3, 2);
                    cieu4 = Math.Round(cieu4, 2);
                    cieu5 = Math.Round(cieu5, 2);
                    cieu6 = Math.Round(cieu6, 2);
                    cieu7 = Math.Round(cieu7, 2);
                    cieu8 = Math.Round(cieu8, 2);
                    cieu9 = Math.Round(cieu9, 2);
                    cieu10 = Math.Round(cieu10, 2);
                    cieu11 = Math.Round(cieu11, 2);




                    string ciupbam = Convert.ToString(cibam);
                    string ciupbam2 = Convert.ToString(cibam2);
                    string ciupbam3 = Convert.ToString(cibam3);
                    string ciupbam4 = Convert.ToString(cibam4);
                    string ciupbam5 = Convert.ToString(cibam5);
                    string ciupbam6 = Convert.ToString(cibam6);
                    string ciupbam7 = Convert.ToString(cibam7);
                    string ciupbam8 = Convert.ToString(cibam8);
                    string ciupbam9 = Convert.ToString(cibam9);
                    string ciupbam10 = Convert.ToString(cibam10);
                    string ciupbam11 = Convert.ToString(cibam11);

                    string ciupeur = Convert.ToString(cieu);
                    string ciupeur2 = Convert.ToString(cieu2);
                    string ciupeur3 = Convert.ToString(cieu3);
                    string ciupeur4 = Convert.ToString(cieu4);
                    string ciupeur5 = Convert.ToString(cieu5);
                    string ciupeur6 = Convert.ToString(cieu6);
                    string ciupeur7 = Convert.ToString(cieu7);
                    string ciupeur8 = Convert.ToString(cieu8);
                    string ciupeur9 = Convert.ToString(cieu9);
                    string ciupeur10 = Convert.ToString(cieu10);
                    string ciupeur11 = Convert.ToString(cieu11);

                    if (ciupbam.Equals("0") == true)
                    { ciupbam = ""; }

                    if (ciupbam2.Equals("0") == true)
                    { ciupbam2 = ""; }

                    if (ciupbam3.Equals("0") == true)
                    { ciupbam3 = ""; }

                    if (ciupbam4.Equals("0") == true)
                    { ciupbam4 = ""; }

                    if (ciupbam5.Equals("0") == true)
                    { ciupbam5 = ""; }

                    if (ciupbam6.Equals("0") == true)
                    { ciupbam6 = ""; }

                    if (ciupbam7.Equals("0") == true)
                    { ciupbam7 = ""; }

                    if (ciupbam8.Equals("0") == true)
                    { ciupbam8 = ""; }

                    if (ciupbam9.Equals("0") == true)
                    { ciupbam9 = ""; }

                    if (ciupbam10.Equals("0") == true)
                    { ciupbam10 = ""; }

                    if (ciupbam11.Equals("0") == true)
                    { ciupbam11 = ""; }


                    if (ciupeur.Equals("0") == true)
                    { ciupeur = ""; }


                    if (ciupeur2.Equals("0") == true)
                    { ciupeur2 = ""; }


                    if (ciupeur3.Equals("0") == true)
                    { ciupeur3 = ""; }


                    if (ciupeur4.Equals("0") == true)
                    { ciupeur4 = ""; }


                    if (ciupeur5.Equals("0") == true)
                    { ciupeur5 = ""; }


                    if (ciupeur6.Equals("0") == true)
                    { ciupeur6 = ""; }


                    if (ciupeur7.Equals("0") == true)
                    { ciupeur7 = ""; }


                    if (ciupeur8.Equals("0") == true)
                    { ciupeur8 = ""; }


                    if (ciupeur9.Equals("0") == true)
                    { ciupeur9 = ""; }


                    if (ciupeur10.Equals("0") == true)
                    { ciupeur10 = ""; }

                    if (ciupeur11.Equals("0") == true)
                    { ciupeur11 = ""; }



                    update.Parameters.AddWithValue("@ci", ciupbam);

                    update.Parameters.AddWithValue("@ok", textBox47.Text);
                    update.Parameters.AddWithValue("@uci", textBox44.Text);
                    update.Parameters.AddWithValue("@cie", ciupeur);


                    update.Parameters.AddWithValue("@ci2", ciupbam2);
                    update.Parameters.AddWithValue("@ok2", textBox48.Text);
                    update.Parameters.AddWithValue("@uci2", textBox43.Text);
                    update.Parameters.AddWithValue("@cie2", ciupeur2);

                    update.Parameters.AddWithValue("@ci3", ciupbam3);
                    update.Parameters.AddWithValue("@ok3", textBox49.Text);
                    update.Parameters.AddWithValue("@uci3", textBox42.Text);
                    update.Parameters.AddWithValue("@cie3", ciupeur3);

                    update.Parameters.AddWithValue("@ci4", ciupbam4);
                    update.Parameters.AddWithValue("@ok4", textBox50.Text);
                    update.Parameters.AddWithValue("@uci4", textBox41.Text);
                    update.Parameters.AddWithValue("@cie4", ciupeur4);

                    update.Parameters.AddWithValue("@ci5", ciupbam5);
                    update.Parameters.AddWithValue("@ok5", textBox51.Text);
                    update.Parameters.AddWithValue("@uci5", textBox40.Text);
                    update.Parameters.AddWithValue("@cie5", ciupeur5);

                    update.Parameters.AddWithValue("@ci6", ciupbam6);
                    update.Parameters.AddWithValue("@ok6", textBox52.Text);
                    update.Parameters.AddWithValue("@uci6", textBox39.Text);
                    update.Parameters.AddWithValue("@cie6", ciupeur6);

                    update.Parameters.AddWithValue("@ci7", ciupbam7);
                    update.Parameters.AddWithValue("@ok7", textBox53.Text);
                    update.Parameters.AddWithValue("@uci7", textBox38.Text);
                    update.Parameters.AddWithValue("@cie7", ciupeur7);

                    update.Parameters.AddWithValue("@ci8", ciupbam8);
                    update.Parameters.AddWithValue("@ok8", textBox54.Text);
                    update.Parameters.AddWithValue("@uci8", textBox37.Text);
                    update.Parameters.AddWithValue("@cie8", ciupeur8);

                    update.Parameters.AddWithValue("@ci9", ciupbam9);
                    update.Parameters.AddWithValue("@ok9", textBox55.Text);
                    update.Parameters.AddWithValue("@uci9", textBox36.Text);
                    update.Parameters.AddWithValue("@cie9", ciupeur9);

                    update.Parameters.AddWithValue("@ci10", ciupbam10);
                    update.Parameters.AddWithValue("@ok10", textBox56.Text);
                    update.Parameters.AddWithValue("@uci10", textBox35.Text);
                    update.Parameters.AddWithValue("@cie10", ciupeur10);

                    update.Parameters.AddWithValue("@ci11", ciupbam11);
                    update.Parameters.AddWithValue("@ok11", textBox57.Text);
                    update.Parameters.AddWithValue("@uci11", textBox34.Text);
                    update.Parameters.AddWithValue("@cie11", ciupeur11);

                    update.Parameters.AddWithValue("@tot", textBox46.Text);

                    update.Parameters.AddWithValue("@kon", lblImePrezime.Text);

                    update.Parameters.AddWithValue("@dat_kon", DateTime.Now.ToShortDateString());

                    con.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show(mKiCI);





                }
                finally
                {
                    con.Close();
                }

            }

            else
            {




                try
                {

                    SqlCommand update = new SqlCommand("Update [DiReqt] set " +
                 "[odobrena_kolicina]=@ok,[odobrena_kolicina2]=@ok2,[odobrena_kolicina3]=@ok3,[odobrena_kolicina4]=@ok4,[odobrena_kolicina5]=@ok5,[odobrena_kolicina6]=@ok6,[odobrena_kolicina7]=@ok7,[odobrena_kolicina8]=@ok8" +
                  ",[odobrena_kolicina9]=@ok9,[odobrena_kolicina10]=@ok10,[odobrena_kolicina11]=@ok11,[datum_kontroling]=@dat_kon,[kontroling]=@kon where id=@konid", con);
                    update.Parameters.AddWithValue("@konid", textBox58.Text);


                    update.Parameters.AddWithValue("@ok", textBox23.Text);
                    update.Parameters.AddWithValue("@ok2", textBox24.Text);
                    update.Parameters.AddWithValue("@ok3", textBox25.Text);
                    update.Parameters.AddWithValue("@ok4", textBox26.Text);
                    update.Parameters.AddWithValue("@ok5", textBox27.Text);
                    update.Parameters.AddWithValue("@ok6", textBox28.Text);
                    update.Parameters.AddWithValue("@ok7", textBox29.Text);
                    update.Parameters.AddWithValue("@ok8", textBox30.Text);
                    update.Parameters.AddWithValue("@ok9", textBox31.Text);
                    update.Parameters.AddWithValue("@ok10", textBox32.Text);
                    update.Parameters.AddWithValue("@ok11", textBox33.Text);
                    update.Parameters.AddWithValue("@kon", lblImePrezime.Text);

                    update.Parameters.AddWithValue("@dat_kon", DateTime.Now.ToShortDateString());

                    con.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show(mZSpa);
                }
                finally
                {
                    con.Close();
                }



            }


            button1.Visible = false;
            button2.Visible = true;

        }

    


        private void button9_Click(object sender, EventArgs e)
        {

            SqlConnection connectionNK = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            DataTable dtK = new DataTable();

            SqlDataAdapter adaptersk = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[naziv_mt] as 'Naziv mjesta troška' " +
"  ,[naziv_mt2] as 'Mjesto troška 2',[naziv_mt3] as 'Mjesto troška 3' ,[naziv_mt4] as 'Mjesto troška 4' ,[datum_nabavka] as 'Datum unošenja cijene',[datum_kontroling] as 'Datum odobrenja / odbijanja' ,[status] as 'Status'" +
" ,[nabavka] as 'Referent nabavke',[kontroling] as 'Kontroling',[sklad] as 'Skladište',[napomena] as 'Napomena',[ident_sifra] as 'Ident šifra' ,[naziv] as 'Naziv materijala'  ,[jm] as 'Jedinica mjere' ,[kolicina] as 'Količina'" +
"   ,[odobrena_kolicina] as 'Odobrena količina' ,[ukupna_cijena] 'Ukupna cijena' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'Ident šifra 2' ,[naziv2] as 'Naziv materijala 2' ,[jm2] as 'Jedinica mjere 2' ,[kolicina2] as 'Količina 2'" +
"  ,[odobrena_kolicina2] as 'Odobrena količina 2' ,[ukupna_cijena2] 'Ukupna cijena 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'Ident šifra 3'  ,[naziv3] as 'Naziv materijala',[jm3] as 'Jedinica mjere 3'" +

"  ,[kolicina3] as 'Količina 3' ,[odobrena_kolicina3] as 'Odobrena količina 3' ,[ukupna_cijena3] 'Ukupna cijena 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'Ident šifra 4' ,[naziv4] as 'Naziv materijala 4' ,[jm4] as 'Jedinica mjere 4' ,[kolicina4] as 'Količina 4'" +

// ",[kolicina3] as 'Količina'  ,[odobrena_kolicina3] as 'Odobrena količina' ,[ukupna_cijena3] as 'Ukupna cijena',[min3] as 'Min',[max3] as 'Max ,[stanje3] as 'Stanje',[ident_sifra4] as 'Ident šifra',[naziv4] as 'Naziv materijala',[jm4] as 'Jedinica mjere',[kolicina4] as 'Količina'"+
" ,[odobrena_kolicina4] as 'Odobrena količina 4',[ukupna_cijena4] 'Ukupna cijena 4',[ident_sifra5] as 'Ident šifra 5'      ,[naziv5] as 'Naziv materijala 5'      ,[jm5] as 'Jedinica mjere 5'      ,[kolicina5] as 'Količina 5'      ,[odobrena_kolicina5] as 'Odobrena količina 5'      ,[ukupna_cijena5] 'Ukupna cijena 5'" +
" ,[ident_sifra6] as 'Ident šifra 6' ,[naziv6] as 'Naziv materijala 6'      ,[jm6] as 'Jedinica mjere 6' ,[kolicina6] as 'Količina 6' ,[odobrena_kolicina6] as 'Odobrena količina 6'  ,[ukupna_cijena6] 'Ukupna cijena 6'      ,[ident_sifra7] as 'Ident šifra 7'      ,[naziv7] as 'Naziv materijala 7'      ,[jm7] as 'Jedinica mjere 7'" +
" ,[kolicina7] as 'Količina 7'      ,[odobrena_kolicina7] as 'Odobrena količina 7' ,[ukupna_cijena7] 'Ukupna cijena 7'  ,[ident_sifra8] as 'Ident šifra 8'  ,[naziv8] as 'Naziv materijala'      ,[jm8] as 'Jedinica mjere 8'      ,[kolicina8] as 'Količina 8'      ,[odobrena_kolicina8] as 'Odobrena količina 8'      ,[ukupna_cijena8] as  'Ukupna cijena 8' " +
"  ,[ident_sifra9] as 'Ident šifra 9'      ,[naziv9] as 'Naziv materijala 9'      ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'" +
" ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11',[total] as 'Total' from DiReqt where status='Odobreno' or status='Odbijeno' ", connectionNK);

            adaptersk.SelectCommand.Parameters.AddWithValue("@pid", lblImePrezime.Text);

            adaptersk.Fill(dtK);

            dataGridView2.DataSource = dtK;

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {

        }

       /* private void button10_Click(object sender, EventArgs e)
        {

            SqlConnection con = GetConnection();
            try
            {
                SqlCommand podobri = new SqlCommand("Update [DiReqt] set [podobrenje]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                podobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string podobreno = "Odobreno";






                podobri.Parameters.AddWithValue("@st", podobreno);


                con.Open();
                podobri.ExecuteNonQuery();
                MessageBox.Show("Zahtjev je odobren!");

                button4.Visible = false;
                button5.Visible = false;

                label9.Visible = false;





            }
            finally
            {
                con.Close();
            }

        }*/

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand dodobri = new SqlCommand("Update [DiReqt] set [dodobrenje]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                dodobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string dodobreno = "Odobreno";

                dodobri.Parameters.AddWithValue("@st", dodobreno);

                con.Open();
                dodobri.ExecuteNonQuery();
                MessageBox.Show(mOdo);

                button4.Visible = false;
                button5.Visible = false;

            


            }
            finally
            {
                con.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand podobri = new SqlCommand("Update [DiReqt] set [podobrenje]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                podobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string podobreno = "Odbijen";






                podobri.Parameters.AddWithValue("@st", podobreno);


                con.Open();
                podobri.ExecuteNonQuery();
                MessageBox.Show(mZahOdb);

                button4.Visible = false;
                button5.Visible = false;

                


            }
            finally
            {
                con.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand dodobri = new SqlCommand("Update [DiReqt] set [dodobrenje]=@st where id=@konid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                dodobri.Parameters.AddWithValue("@konid", textBox58.Text);


                string dodobreno = "Odbijen";

                dodobri.Parameters.AddWithValue("@st", dodobreno);

                con.Open();
                dodobri.ExecuteNonQuery();
                MessageBox.Show(mOdb);

                button4.Visible = false;
                button5.Visible = false;

               


            }
            finally
            {
                con.Close();
            }
        }

        private void tabPage1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {


            string jm = "";
            string jm2 = "";
            string jm3 = "";
            string jm4 = "";
            string jm5 = "";
            string jm6 = "";
            string jm7 = "";
            string jm8 = "";
            string jm9 = "";
            string jm10 = "";
            string jm11 = "";
            string mt = "";
            string mt2 = "";
            string mt3 = "";
            string mt4 = "";
            string st = "";
            string st2 = "";
            string st3 = "";
            string st4 = "";
            string datum = "";
            string stoks = "";
            string vrsta = "";
            string min = "";
            string min2 = "";
            string min3 = "";
            string max = "";
            string max2 = "";
            string max3 = "";
            string stanje = "";
            string stanje2 = "";
            string stanje3 = "";
            string sklad = "";
            string napo = "";
            string napnab = "";
            string ident_sifra = " ";
            string ident_sifra2 = " ";
            string ident_sifra3 = " ";
            string ident_sifra4 = " ";
            string ident_sifra5 = " ";
            string ident_sifra6 = " ";
            string ident_sifra7 = " ";
            string ident_sifra8 = " ";
            string ident_sifra9 = " ";
            string ident_sifra10 = " ";
            string ident_sifra11 = " ";
            string datumnab = "";
            string valuta = "";
            string status = "";
            string ok = "";
            string ok2 = "";
            string ok3 = "";
            string ok4 = "";
            string ok5 = "";
            string ok6 = "";
            string ok7 = "";
            string ok8 = "";
            string ok9 = "";
            string ok10 = "";
            string ok11 = "";
            string cij = "";
            string cij2 = "";
            string cij3 = "";
            string cij4 = "";
            string cij5 = "";
            string cij6 = "";
            string cij7 = "";
            string cij8 = "";
            string cij9 = "";
            string cij10 = "";
            string cij11 = "";

            string cijeuro = "";
            string cijeuro2 = "";
            string cijeuro3 = "";
            string cijeuro4 = "";
            string cijeuro5 = "";
            string cijeuro6 = "";
            string cijeuro7 = "";
            string cijeuro8 = "";
            string cijeuro9 = "";
            string cijeuro10 = "";
            string cijeuro11 = "";
            string odjel = "";
            string email = "";
            string nabref = "";
            string dod = "";
            string kod = "";
           
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka],[nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel] " +
                                                     ",[podobrenje],[dodobrenje],[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */
            SqlConnection con = GetConnection();

            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@zid", textBox58.Text);

            SqlDataReader reader1 = command1.ExecuteReader();


            if (reader1.Read())
            {

                ident_sifra = (reader1["ident_sifra"].ToString());
                ident_sifra2 = (reader1["ident_sifra2"].ToString());
                ident_sifra3 = (reader1["ident_sifra3"].ToString());
                ident_sifra4 = (reader1["ident_sifra4"].ToString());
                ident_sifra5 = (reader1["ident_sifra5"].ToString());
                ident_sifra6 = (reader1["ident_sifra6"].ToString());
                ident_sifra7 = (reader1["ident_sifra7"].ToString());
                ident_sifra8 = (reader1["ident_sifra8"].ToString());
                ident_sifra9 = (reader1["ident_sifra9"].ToString());
                ident_sifra10 = (reader1["ident_sifra10"].ToString());
                ident_sifra11 = (reader1["ident_sifra11"].ToString());

                jm = (reader1["jm"].ToString());
                jm2 = (reader1["jm2"].ToString());
                jm3 = (reader1["jm3"].ToString());
                jm4 = (reader1["jm4"].ToString());
                jm5 = (reader1["jm5"].ToString());
                jm6 = (reader1["jm6"].ToString());
                jm7 = (reader1["jm7"].ToString());
                jm8 = (reader1["jm8"].ToString());
                jm9 = (reader1["jm9"].ToString());
                jm10 = (reader1["jm10"].ToString());
                jm11 = (reader1["jm11"].ToString());
                mt = (reader1["naziv_mt"].ToString());
                mt2 = (reader1["naziv_mt2"].ToString());
                mt3 = (reader1["naziv_mt3"].ToString());
                mt4 = (reader1["naziv_mt4"].ToString());
                st = (reader1["sifra_mt"].ToString());
                st2 = (reader1["sifra_mt2"].ToString());
                st3 = (reader1["sifra_mt3"].ToString());
                st4 = (reader1["sifra_mt4"].ToString());
                ime = (reader1["podnositelj"].ToString());
                datum = (reader1["datum"].ToString());
                datumnab = (reader1["datum_nabavka"].ToString());
                stoks = (reader1["stok"].ToString());
                vrsta = (reader1["vrsta"].ToString());
                min = (reader1["min"].ToString());
                min2 = (reader1["min2"].ToString());
                min3 = (reader1["min3"].ToString());
                max = (reader1["max"].ToString());
                max2 = (reader1["max2"].ToString());
                max3 = (reader1["max3"].ToString());
                stanje = (reader1["stanje"].ToString());
                stanje2 = (reader1["stanje2"].ToString());
                stanje3 = (reader1["stanje3"].ToString());
                sklad = (reader1["sklad"].ToString());
                napo = (reader1["napomena"].ToString());
                napnab = (reader1["napnab"].ToString());
                nabref = (reader1["nabavka"].ToString());


                valuta = (reader1["valuta"].ToString());
                status = (reader1["status"].ToString());
                ok = (reader1["odobrena_kolicina"].ToString());
                ok2 = (reader1["odobrena_kolicina2"].ToString());
                ok3 = (reader1["odobrena_kolicina3"].ToString());
                ok4 = (reader1["odobrena_kolicina4"].ToString());
                ok5 = (reader1["odobrena_kolicina5"].ToString());
                ok6 = (reader1["odobrena_kolicina6"].ToString());
                ok7 = (reader1["odobrena_kolicina7"].ToString());
                ok8 = (reader1["odobrena_kolicina8"].ToString());
                ok9 = (reader1["odobrena_kolicina9"].ToString());
                ok10 = (reader1["odobrena_kolicina10"].ToString());
                ok11 = (reader1["odobrena_kolicina11"].ToString());


                cij = (reader1["cijena"].ToString());
                cij2 = (reader1["cijena2"].ToString());
                cij3 = (reader1["cijena3"].ToString());
                cij4 = (reader1["cijena4"].ToString());
                cij5 = (reader1["cijena5"].ToString());
                cij6 = (reader1["cijena6"].ToString());
                cij7 = (reader1["cijena7"].ToString());
                cij8 = (reader1["cijena8"].ToString());
                cij9 = (reader1["cijena9"].ToString());
                cij10 = (reader1["cijena10"].ToString());
                cij11 = (reader1["cijena11"].ToString());

                cijeuro = (reader1["cijena_eur"].ToString());
                cijeuro2 = (reader1["cijena_eur2"].ToString());
                cijeuro3 = (reader1["cijena_eur3"].ToString());
                cijeuro4 = (reader1["cijena_eur4"].ToString());
                cijeuro5 = (reader1["cijena_eur5"].ToString());
                cijeuro6 = (reader1["cijena_eur6"].ToString());
                cijeuro7 = (reader1["cijena_eur7"].ToString());
                cijeuro8 = (reader1["cijena_eur8"].ToString());
                cijeuro9 = (reader1["cijena_eur9"].ToString());
                cijeuro10 = (reader1["cijena_eur10"].ToString());
                cijeuro11 = (reader1["cijena_eur11"].ToString());
                odjel = (reader1["odjel"].ToString());
                kod = (reader1["podobrenje"].ToString());
                dod = (reader1["dodobrenje"].ToString());


            }

            else
            {
                reader1.Close();
            }

            connection.Close();



            string ini = "";

            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [inicijali] FROM Nabavka_korisnici WHERE [ime i prezime] = @usr ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@usr", nabref);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {


                ini = (reader123["inicijali"].ToString());



            }

            else
            {
                reader123.Close();
                connection3.Close();
            }



            button2.Visible = false;
            button1.Visible = false;



            string ident = "";

            string idbroj = "";
            string izvor = "";
            string q3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj] FROM DiReqt WHERE [id] = @id ";



            SqlCommand c12 = new SqlCommand(q3, con);
            con.Open();

            c12.Parameters.AddWithValue("@id", textBox58.Text);

            SqlDataReader r12 = c12.ExecuteReader();



            if (r12.Read())
            {



                ident = (r12["id"].ToString());

                idbroj = (r12["idbroj"].ToString());



                r12.Close();
                con.Close();
            }

            else
            {
                r12.Close();
                con.Close();
            }



            PDF p = new PDF();
            p.id = textBox58.Text;

            string broj = textBox58.Text;




            bool result;
            result = PDFC.Create_PDF(broj);


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";











            // Excel
            Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                /*this.dataGridView1.Columns[5].ValueType = typeof(Double);
                this.dataGridView1.Columns[6].ValueType = typeof(Double);
                this.dataGridView1.Columns[4].ValueType = typeof(Double);*/




                string t1 = "Ident Šifra";
                string t2 = "Naziv ";
                string t3 = "JM";
                string t4 = "Količina";
                string t4o = "Odobrena količina";
                string tcikm = "Cijena KM";
                string tcieuro = "Cijena EUR";
                string t5 = "Broj zahtjeva: " + textBox58.Text;
                string t6 = datum;


                string tb1 = "'" + ident_sifra;
                string tb2 = textBox1.Text;
                string tb3 = jm;
                string tb4 = textBox23.Text;
                string tb3o = ok;

                /* if (cij.Equals("0") == true)
                 { cikm = ""; }
                //*/// string cieuro = cijeuro;
                    /* if (cijeuro.Equals("0") == true)
                     { cieuro = ""; }*/

                string tb5 = "'" + ident_sifra2;
                string tb6 = textBox2.Text;
                string tb7 = jm2;
                string tb8 = textBox23.Text;
                string tb8o = ok2;
                string cikm2 = cij2;

                /* if (cij2.Equals("0") == true)
                 { cikm2 = ""; }*/
                string cieuro2 = cijeuro2;
                /* if (cijeuro2.Equals("0") == true)
                 { cieuro2 = ""; }
                 */
                string tb9 = "'" + ident_sifra3;
                string tb10 = textBox3.Text;
                string tb11 = jm3;
                string tb12 = textBox25.Text;
                string tb12o = ok3;
                string cikm3 = cij3;
                string cieuro3 = cijeuro3;
                /*
                if (cij3.Equals("0") == true)
                { cikm3 = ""; }
                if (cijeuro3.Equals("0") == true)
                { cieuro3 = ""; }*/
                string tb13 = "'" + ident_sifra4;
                string tb14 = textBox4.Text;
                string tb15 = jm4;
                string tb16 = textBox26.Text;
                string tb16o = ok4;
                string cikm4 = cij4;
                string cieuro4 = cijeuro4;
                /*  if (cij4.Equals("0") == true)
                  { cikm4= ""; }
                  if (cijeuro4.Equals("0") == true)
                  { cieuro4 = ""; }*/

                string tb17 = "'" + ident_sifra5;
                string tb18 = textBox5.Text;
                string tb19 = jm5;
                string tb20 = textBox27.Text;
                string tb20o = ok5;
                string cikm5 = cij5;
                string cieuro5 = cijeuro5;
                /*  if (cij5.Equals("0") == true)
                  { cikm5 = ""; }
                  if (cijeuro5.Equals("0") == true)
                  { cieuro5 = ""; }
                  */
                string tb21 = "'" + ident_sifra6;
                string tb22 = textBox6.Text;
                string tb23 = jm6;
                string tb24 = textBox28.Text;
                string tb24o = ok6;
                string cikm6 = cij6;
                string cieuro6 = cijeuro6;
                /*   if (cij6.Equals("0") == true)
                   { cikm6 = ""; }
                   if (cijeuro6.Equals("0") == true)
                   { cieuro6 = ""; }*/

                string tb25 = "'" + ident_sifra7;
                string tb26 = textBox7.Text;
                string tb27 = jm7;
                string tb28 = textBox29.Text;
                string tb28o = ok7;
                string cikm7 = cij7;
                string cieuro7 = cijeuro7;
                /*  if (cij7.Equals("0") == true)
                  { cikm7 = ""; }
                  if (cijeuro7.Equals("0") == true)
                  { cieuro7 = ""; }*/

                string tb29 = "'" + ident_sifra8;
                string tb30 = textBox8.Text;
                string tb31 = jm8;
                string tb32 = textBox30.Text;
                string tb32o = ok8;
                string cikm8 = cij8;
                string cieuro8 = cijeuro8;
                /*  if (cij8.Equals("0") == true)
                  { cikm8 = ""; }
                  if (cijeuro8.Equals("0") == true)
                  { cieuro8 = ""; }*/

                string tb33 = "'" + ident_sifra9;
                string tb34 = textBox9.Text;
                string tb35 = jm9;
                string tb36 = textBox31.Text;
                string tb36o = ok9;
                string cikm9 = cij9;
                string cieuro9 = cijeuro9;
                /* if (cij9.Equals("0") == true)
                 { cikm9 = ""; }
                 if (cijeuro9.Equals("0") == true)
                 { cieuro9 = ""; }
                 */
                string tb37 = "'" + ident_sifra10;
                string tb38 = textBox10.Text;
                string tb39 = jm10;
                string tb40 = textBox32.Text;
                string tb40o = ok10;
                string cikm10 = cij10;
                string cieuro10 = cijeuro10;
                /*   if (cij10.Equals("0") == true)
                   { cikm10 = ""; }
                   if (cijeuro10.Equals("0") == true)
                   { cieuro10 = ""; }
                   */
                string tb41 = "'" + ident_sifra11;
                string tb42 = textBox11.Text;
                string tb43 = jm11;
                string tb44 = textBox33.Text;
                string tb44o = ok11;
                string cikm11 = cij11;
                string cieuro11 = cijeuro11;
                /* if (cij11.Equals("0") == true)
                 { cikm11 = ""; }
                 if (cijeuro11.Equals("0") == true)
                 { cieuro11 = ""; }
                 */



                string[] row0 = { t1, t2, t3, t4, t4o, tcikm, tcieuro, t5, t6 };


                //  MessageBox.Show(cijeuro2, " //" + cieuro2);



                string[] row = { tb1, tb2, tb3, tb4, ok, cij, cijeuro };
                string[] row1 = { tb5, tb6, tb7, tb8, ok2, cij2, cijeuro2 };
                string[] row2 = { tb9, tb10, tb11, tb12, ok3, cij3, cijeuro3 };
                string[] row3 = { tb13, tb14, tb15, tb16, ok4, cij4, cijeuro4 };
                string[] row4 = { tb17, tb18, tb19, tb20, ok5, cij5, cieuro5 };
                string[] row5 = { tb21, tb22, tb23, tb24, ok6, cij6, cieuro6 };
                string[] row6 = { tb25, tb26, tb27, tb28, ok7, cij7, cieuro7 };
                string[] row7 = { tb29, tb30, tb31, tb32, ok8, cij8, cieuro8 };
                string[] row8 = { tb33, tb34, tb35, tb36, ok9, cij9, cieuro9 };
                string[] row9 = { tb37, tb38, tb39, tb40, ok10, cij10, cieuro10 };
                string[] row10 = { tb41, tb42, tb43, tb44, ok11, cij11, cieuro11 };



                dataGridView1.Rows.Add(row0);
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows.Add(row1);
                dataGridView1.Rows.Add(row2);
                dataGridView1.Rows.Add(row3);
                dataGridView1.Rows.Add(row4);
                dataGridView1.Rows.Add(row5);
                dataGridView1.Rows.Add(row6);
                dataGridView1.Rows.Add(row7);
                dataGridView1.Rows.Add(row8);
                dataGridView1.Rows.Add(row9);
                dataGridView1.Rows.Add(row10);


                int i = 0;
                int j = 0;

                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs(@"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + textBox58.Text.Trim() + " " + "K" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();



                SqlConnection connection34 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string query34 = "SELECT [email] FROM DiReqt_Korisnici WHERE [ime] = @usr ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */

                SqlCommand command1234 = new SqlCommand(query34, connection34);
                connection34.Open();
                command1234.Parameters.AddWithValue("@usr", ime);

                SqlDataReader reader1234 = command1234.ExecuteReader();


                if (reader1234.Read())
                {


                    email = (reader1234["email"].ToString());


                }

                else
                {
                    reader1234.Close();
                    connection34.Close();
                }



                try
                {
                    /* MailMessage mail = new MailMessage();
                     SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                     mail.From = new MailAddress("zzm@volkswagen-sa@.ba");
                     mail.To.Add("rijad.siljak@volkswagen-sa.ba");
                     mail.Subject = "Zahtjev za materijalom";
                     mail.Body = "Zahtjev za materijalom";
                     */
                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                    MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                    MailAddress to = new MailAddress("From Address Ex direqt.nabavka@volkswagen-sa.ba");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Zahtjev za materijalom, KONTROLING " + DateTime.Now.ToShortDateString();
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = ime + " " + datum + " No. " + textBox58.Text.Trim() + " " + status;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;


                    MailAddress bcc = new MailAddress(email);

                    MailAddress bcc2 = new MailAddress("direqt.cskl@volkswagen-sa.ba");
                    message.Bcc.Add(bcc2);

                    message.Bcc.Add(bcc);


                    System.Net.Mail.Attachment attachment;
                    string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                    if (!Directory.Exists(folderPath1))
                    {
                        Directory.CreateDirectory(folderPath1);
                    }
                    //  System.Net.Mail.Attachment attachment1;
                    // string folderPath41 = @"C:\Users\Public\Documents\ZZM\";

                    /* if (!Directory.Exists(folderPath41))
                     {
                         Directory.CreateDirectory(folderPath41);
                     }*/
                    attachment = new System.Net.Mail.Attachment(izvor);
                    message.Attachments.Add(attachment);
                    //     attachment1 = new System.Net.Mail.Attachment(folderPath1 + " " + ime + " " +datum + " No. " + textBox45.Text.Trim() + ".xls");
                    //   message.Attachments.Add(attachment1);

                    /*  SmtpServer.Port = 587;
                      SmtpServer.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18 ");
                      SmtpServer.EnableSsl = true;
                      */
                    // SmtpServer.Send(mail);


                    client.Send(message);
                    MessageBox.Show(mMail);

                    foreach (System.Net.Mail.Attachment attachmentx in message.Attachments)

                    {

                        attachmentx.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }




                /*
                                Excel.Application xlApp;
                                Excel.Workbook xlWorkBook;
                                Excel.Worksheet xlWorkSheet;
                                object misValue = System.Reflection.Missing.Value;

                                xlApp = new Excel.Application();
                                xlWorkBook = xlApp.Workbooks.Add(misValue);
                                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                                DataTable dt = new DataTable();

                                connection.Open();
                                try
                                { 
                                SqlDataAdapter adapt = new SqlDataAdapter("Select  [cijena] as 'Cijena (BAM)',[cijena_eur] as 'Cijena (EUR)'  from DiReqt where id=@prof ", connection);
                                adapt.SelectCommand.Parameters.AddWithValue("@prof", textBox58.Text);
                                adapt.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }

                                finally
                                {
                                    connection.Close();
                                }

                                int i = 0;
                            int j = 0;

                            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                                {
                                    DataGridViewCell cell = dataGridView1[j, i];
                                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                                }
                            }

                                xlWorkBook.SaveAs(@"C:\Users\Public\Documents\ZZM\" +  "PLS " + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();



                    */
                // System.Diagnostics.Process.Start(folderPath + this.comboBox12.Text.Trim() + " " + this.textBox34.Text.Trim() + DateTime.Now.ToShortDateString() + ".pdf");
                // this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                string folderPath2 = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + textBox58.Text.Trim() + " " + "K" + ".pdf";
                using (PrintDialog Dialog = new PrintDialog())
                {
                    // Dialog.ShowDialog();

                    ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                    {
                        Verb = "print",
                        CreateNoWindow = true,
                        FileName = izvor,
                        WindowStyle = ProcessWindowStyle.Normal
                    };
                    //Proces printanja


                    Process printProcess = new Process();
                    printProcess.StartInfo = printProcessInfo;


                    printProcess.Start();
                    printProcess.Start();
                    //  printProcess.Start();
                    // printProcess.Start();


                    //   printProcess.WaitForInputIdle(); 



                    MessageBox.Show(mZPrint);



                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";

                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";
                    textBox24.Text = "";
                    textBox25.Text = "";
                    textBox26.Text = "";
                    textBox27.Text = "";
                    textBox28.Text = "";
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox31.Text = "";
                    textBox32.Text = "";
                    textBox33.Text = "";
                    textBox34.Text = "";
                    textBox35.Text = "";
                    textBox36.Text = "";
                    textBox37.Text = "";
                    textBox38.Text = "";
                    textBox39.Text = "";
                    textBox40.Text = "";
                    textBox41.Text = "";
                    textBox42.Text = "";
                    textBox43.Text = "";
                    textBox44.Text = "";
                    textBox45.Text = "";
                    textBox46.Text = "";
                    textBox47.Text = "";
                    textBox48.Text = "";
                    textBox49.Text = "";
                    textBox50.Text = "";
                    textBox51.Text = "";
                    textBox52.Text = "";
                    textBox53.Text = "";
                    textBox54.Text = "";
                    textBox55.Text = "";
                    textBox56.Text = "";
                    textBox57.Text = "";
                    textBox58.Text = "";
                    // button1.Visible = true;
                    button2.Visible = false;



                }

            }

        

        private void textBox44_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        void brisanje ()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";

            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";
            textBox50.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            textBox54.Text = "";
            textBox55.Text = "";
            textBox56.Text = "";
            textBox57.Text = "";
            textBox58.Text = "";
            // button1.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
           
            button2.Visible = false;
            button1.Visible = false;
            checkBox1.Checked = false;
            button2.Visible = false;
        }

        private void obrisi_Click(object sender, EventArgs e)
        {
            brisanje();
        }

        private void tabPage1_Click_3(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox58_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

            SqlConnection conn = GetConnection();
            SqlCommand delete = new SqlCommand("Update DiReqt set  [odobrena_kolicina]=@x,[odobrena_kolicina2]=@x," +
                "[odobrena_kolicina3]=@x,[odobrena_kolicina4]=@x,[odobrena_kolicina5]=@x,[odobrena_kolicina6]=@x,[odobrena_kolicina7]=@x," +
                "[odobrena_kolicina8]=@x,[odobrena_kolicina9]=@x,[odobrena_kolicina10]=@x,[odobrena_kolicina11]=@x," +
                "[datum_kontroling]=@x,[status]=@x,[kontroling]=@x,[podobrenje]=@x,[dodobrenje]=@x,[tpo]=@x,[tpod]=@x" +

                  " where id=@lid", conn);
            delete.Parameters.AddWithValue("@lid", textBox58.Text);
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

        private void LeftSidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPregledZahtjeva_Click(object sender, EventArgs e)
        {
                tbControl.SelectTab(1);
        }

        private void btnOdobrenjeZahtjeva_Click(object sender, EventArgs e)
        {
            tbControl.SelectTab(0);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelUnosenjeCijene_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}