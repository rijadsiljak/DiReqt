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


    public partial class Nabavka : Form
    {


        public Nabavka()
        {
            InitializeComponent();



            PDFC.BindGridDataSource(this.dataGridView1);
        }




        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;


        //
        //Parametri potrebni za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;

        //
        //Pomoćna funkcija za resize textboxa 
        //
        private void AutoSizeTextBox(TextBox txt)
        {
            //const int x_margin = 0;
          //  const int y_margin = 2;
           // Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
           // txt.ClientSize = new Size(size.Width + x_margin, size.Height + y_margin);
        }

        //
        //Funkcija potrebna za resize textboxa, event Load na formu
        //
        private void Nabavka_Load(object sender, EventArgs e)
        {
            
            
            
            
            
            
            //Register the TextChanged event handler.
            textBox1.TextChanged += txtNazivMaterijala1_TextChanged;
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.None;

            // Make the TextBox fit its initial text.
            AutoSizeTextBox(textBox1);
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
        //Funkcija za resize prvog textboxa ispod Naziv materijala 
        //
        private void txtNazivMaterijala1_TextChanged(object sender, EventArgs e)
        {
            AutoSizeTextBox(sender as TextBox);
        }

        //
        //Klik na button Unosenje cijene otvara tab Unosenje cijene
        //
        private void btnUnosenjeCijene_Click(object sender, EventArgs e)
        {
            tbControlNabavka.SelectTab(0);
        }

        //
        //Klik na button Zahtjev referenta otvara tab Zahtjevi referenta
        //
        private void btnZahtjeviReferenta_Click(object sender, EventArgs e)
        {
            tbControlNabavka.SelectTab(1);
        }

        //
        //Pomoćna funkcija za promjenu valute
        //
      
        //
        //Klik na radiobutton Bam mijenja Euro u KM
        //
       

        //
        //Klik na radiobutton Euro, mijenja KM u Euro
        //
       
        //
        //Klik na Direqt logo vraća na main
        //
        private void picBoxDireqtLogo_Click(object sender, EventArgs e)
        {
            MainProgram mainForm = new MainProgram();
            mainForm.Show();
            Visible = false;
            this.Close();
        }

        //
        //Klik na Save button otvara Messagebox i prikazuje Print button ukoliko je kliknuto DA
        //
     /*   private void btnSaveUnosenjeCijene_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = CustomMessageBox.Show("Da li želite sačuvati promjene?", "DA", "NE");
            if (dialogResult == DialogResult.Yes)
            {
                btnSaveUnosenjeCijene.Visible = false;
                btnEmailUnosenjeCijene.Visible = true;
            }
        }
        */
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
        public string UserName { get; set; }
        string jez = "";

        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Njem"))
            {
                lblBrojZahtjevaUnosenjeCijene.Text = "Antrag Nummer";
                button8.Text = "Preis Engabe";
                button9.Text = "Arbeiter Antrage";
                lblValuta.Text = "Währung";
                lblNapomena.Text = "Bemerkung";
                lblIdentSifra.Text = "Ident Nr";
                lblNazivMaterijala.Text = "Materialbeschreibung";
                lblKolicina.Text = "Menge";
                lblCijena.Text = "Preis";
                lblUkupnaCijena.Text = "Konto";
                lblTotal.Text = "TOTAL";


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
               // mOdgOs = " Die Verantwortliche Person für die Abteilung" + comboBox1.Text + " ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }

            else if (Korisnik.Jezik.Equals("Bos"))
            {
                lblBrojZahtjevaUnosenjeCijene.Text = "Broj zahtjeva";
                button8.Text = "Unošenje cijene";
                button9.Text = "Zahtjevi referenta";
                lblValuta.Text = "Valuta";
                lblNapomena.Text = "Napomena";
                lblIdentSifra.Text = "Ident šifra";
                lblNazivMaterijala.Text = "Naziv materijala";
                lblKolicina.Text = "Količina";
                lblCijena.Text = "Cijena";
                lblUkupnaCijena.Text = "Ukupna cijena";
                lblTotal.Text = "TOTAL";




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
               // mOdgOs = " Odgovorna osoba za odjel " + comboBox1.Text + " je  ";
                mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";


            }

        }




        private void Form2_Load(object sender, EventArgs e)
        {
            jez = Korisnik.Jezik;
            prjez();


            ZZM frm1 = new ZZM();
            frm1.Hide();
            //*frm3.Show();
            string username;
            


            username = Korisnik.korisnicko;

            string imet = "";
            string prezime = "";
            string odjelt = "";
            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [ime],[prezime],[odjel] FROM Korisnici WHERE [username] = @usr ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command123 = new SqlCommand(query3, connection3);
            connection3.Open();
            command123.Parameters.AddWithValue("@usr", username);

            SqlDataReader reader123 = command123.ExecuteReader();


            if (reader123.Read())
            {

                imet = (reader123["ime"].ToString());
                prezime = (reader123["prezime"].ToString());
                odjelt = (reader123["odjel"].ToString());
            }

            else
            {
                reader123.Close();
                connection3.Close();
            }
            lblImePrezime.Text = imet + " " + prezime;
            lblOdjel.Text = odjelt;

            if (lblOdjel.Text.Equals("ADMIN"))
            {
                button6.Visible = true;
                button3.Visible = false;
            }








        }






        // Waaaaaaaaaaaaaaaaaaaaaaaaaaaaagh

        private void changeLabelText(string name, string text)
        {
            var label = Controls.Find(name, true).FirstOrDefault();
            label.Text = text;
        }

        private void rBtnBam_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 23; i++)
            {
                changeLabelText("lblValutaC" + i, "KM");
            }
        }

        //
        //Klik na radiobutton Euro, mijenja KM u Euro
        //
        private void rBtnEuro_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 23; i++)
            {
                changeLabelText("lblValutaC" + i, "€");
            }
        }






        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connectionN = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            DataTable dtN = new DataTable();

            SqlDataAdapter adapters = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[naziv_mt] as 'Naziv mjesta troška' " +
"  ,[naziv_mt2] as 'Mjesto troška 2',[naziv_mt3] as 'Mjesto troška 3' ,[naziv_mt4] as 'Mjesto troška 4' ,[datum_nabavka] as 'Datum unošenja cijene',[datum_kontroling] as 'Datum odobrenja / odbijanja' ,[status] as 'Status'" +
" ,[nabavka] as 'Referent nabavke',[kontroling] as 'Kontroling',[sklad] as 'Skladište',[napomena] as 'Napomena',[ident_sifra] as 'Ident šifra' ,[naziv] as 'Naziv materijala'  ,[jm] as 'Jedinica mjere' ,[kolicina] as 'Količina'" +
"   ,[odobrena_kolicina] as 'Odobrena količina' ,[ukupna_cijena] 'Ukupna cijena' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'Ident šifra 2' ,[naziv2] as 'Naziv materijala 2' ,[jm2] as 'Jedinica mjere 2' ,[kolicina2] as 'Količina 2'" +
"  ,[odobrena_kolicina2] as 'Odobrena količina 2' ,[ukupna_cijena2] 'Ukupna cijena 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'Ident šifra 3'  ,[naziv3] as 'Naziv materijala',[jm3] as 'Jedinica mjere 3'" +

"  ,[kolicina3] as 'Količina 3' ,[odobrena_kolicina3] as 'Odobrena količina 3' ,[ukupna_cijena3] 'Ukupna cijena 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'Ident šifra 4' ,[naziv4] as 'Naziv materijala 4' ,[jm4] as 'Jedinica mjere 4' ,[kolicina4] as 'Količina 4'" +
" ,[odobrena_kolicina4] as 'Odobrena količina 4',[ukupna_cijena4] 'Ukupna cijena 4',[ident_sifra5] as 'Ident šifra 5'      ,[naziv5] as 'Naziv materijala 5'      ,[jm5] as 'Jedinica mjere 5'      ,[kolicina5] as 'Količina 5'      ,[odobrena_kolicina5] as 'Odobrena količina 5'      ,[ukupna_cijena5] 'Ukupna cijena 5'" +
" ,[ident_sifra6] as 'Ident šifra 6' ,[naziv6] as 'Naziv materijala 6'      ,[jm6] as 'Jedinica mjere 6' ,[kolicina6] as 'Količina 6' ,[odobrena_kolicina6] as 'Odobrena količina 6'  ,[ukupna_cijena6] 'Ukupna cijena 6'      ,[ident_sifra7] as 'Ident šifra 7'      ,[naziv7] as 'Naziv materijala 7'      ,[jm7] as 'Jedinica mjere 7'" +
" ,[kolicina7] as 'Količina 7'      ,[odobrena_kolicina7] as 'Odobrena količina 7' ,[ukupna_cijena7] 'Ukupna cijena 7'  ,[ident_sifra8] as 'Ident šifra 8'  ,[naziv8] as 'Naziv materijala'      ,[jm8] as 'Jedinica mjere 8'      ,[kolicina8] as 'Količina 8'      ,[odobrena_kolicina8] as 'Odobrena količina 8'      ,[ukupna_cijena8] as  'Ukupna cijena 8' " +
"  ,[ident_sifra9] as 'Ident šifra 9'      ,[naziv9] as 'Naziv materijala 9'      ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'" +
" ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11',[total] as 'Total' from DiReqt where nabavka=@pid ", connectionN);


            adapters.SelectCommand.Parameters.AddWithValue("@pid", lblImePrezime.Text);
            adapters.Fill(dtN);

            dataGridView2.DataSource = dtN;
        }
       

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            SqlDataAdapter adapters = new SqlDataAdapter("Select [inicijali] from Korisnici where [ime]+[prezime]=@ip",con);

            adapters.SelectCommand.Parameters.AddWithValue("@ip", lblImePrezime.Text);




            try
            {

                SqlCommand update = new SqlCommand("Update [DiReqt] set [cijena]=@ci,[cijena_eur]=@cie,[ukupna_cijena]=@uci,[cijena2]=@ci2,[ukupna_cijena2]=@uci2,[cijena3]=@ci3,[ukupna_cijena3]=@uci3,[cijena4]=@ci4,[ukupna_cijena4]=@uci4,[cijena5]=@ci5,[ukupna_cijena5]=@uci5,[cijena6]=@ci6,[ukupna_cijena6]=@uci6" +
                    ",[cijena_eur2]=@cie2,[cijena_eur3]=@cie3,[cijena_eur4]=@cie4,[cijena_eur5]=@cie5,[cijena_eur6]=@cie6,[cijena_eur7]=@cie7,[cijena_eur8]=@cie8,[cijena_eur9]=@cie9,[cijena_eur10]=@cie10,[cijena_eur11]=@cie11" +
                    ",[cijena7]=@ci7,[ukupna_cijena7]=@uci7,[cijena8]=@ci8,[ukupna_cijena8]=@uci8,[cijena9]=@ci9,[ukupna_cijena9]=@uci9,[cijena10]=@ci10,[ukupna_cijena10]=@uci10,[cijena11]=@ci11,[ukupna_cijena11]=@uci11,[total]=@tot,[datum_nabavka]=@dat_na,[nabavka]=@nab,[valuta]=@val,[napnab]=@nana where id=@zaid", con);

                SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


                update.Parameters.AddWithValue("@zaid", textBox45.Text);


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

                string valuta = "";


                if (radioButton1.Checked)
                {
                    valuta = "KM";
                }
                else if (radioButton2.Checked)
                {
                    valuta = "EUR";
                }






                if (string.IsNullOrEmpty(textBox22.Text))
                { cipot = 0;
                }
                else
                { cipot = double.Parse(textBox22.Text);
                }

                if (string.IsNullOrEmpty(textBox21.Text))
                { cipot2 = 0;
                }
                else
                { cipot2 = double.Parse(textBox21.Text);
                }


                if (string.IsNullOrEmpty(textBox20.Text))
                { cipot3 = 0;
                }
                else
                { cipot3 = double.Parse(textBox20.Text);
                }

                if (string.IsNullOrEmpty(textBox19.Text))
                { cipot4 = 0;
                }
                else
                { cipot4 = double.Parse(textBox19.Text);
                }

                if (string.IsNullOrEmpty(textBox18.Text))
                { cipot5 = 0;
                }
                else
                { cipot5 = double.Parse(textBox18.Text);
                }

                if (string.IsNullOrEmpty(textBox17.Text))
                { cipot6 = 0;
                }
                else
                { cipot6 = double.Parse(textBox17.Text);
                }

                if (string.IsNullOrEmpty(textBox16.Text))
                { cipot7 = 0;
                }
                else
                { cipot7 = double.Parse(textBox16.Text);
                }

                if (string.IsNullOrEmpty(textBox15.Text))
                { cipot8 = 0;
                }
                else
                { cipot8 = double.Parse(textBox15.Text);
                }

                if (string.IsNullOrEmpty(textBox14.Text))
                { cipot9 = 0;
                }
                else
                { cipot9 = double.Parse(textBox14.Text);
                }

                if (string.IsNullOrEmpty(textBox13.Text))
                { cipot10 = 0;
                }
                else
                { cipot10 = double.Parse(textBox13.Text);
                }

                if (string.IsNullOrEmpty(textBox12.Text))
                { cipot11 = 0;
                }
                else
                { cipot11 = double.Parse(textBox12.Text);
                }




                if (radioButton1.Checked)
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
                else if (radioButton2.Checked)
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

                string cijenaKM = Convert.ToString(cibam);
                if (cijenaKM.Equals("0") == true)
                { cijenaKM = "";
                }



                string cijenaKM2 = Convert.ToString(cibam2);
                if (cijenaKM2.Equals("0") == true)
                { cijenaKM2 = "";
                }

                string cijenaKM3 = Convert.ToString(cibam3);
                if (cijenaKM3.Equals("0") == true)
                { cijenaKM3 = "";
                }

                string cijenaKM4 = Convert.ToString(cibam4);
                if (cijenaKM4.Equals("0") == true)
                { cijenaKM4 = "";
                }

                string cijenaKM5 = Convert.ToString(cibam5);
                if (cijenaKM5.Equals("0") == true)
                { cijenaKM5 = "";
                }

                string cijenaKM6 = Convert.ToString(cibam6);
                if (cijenaKM6.Equals("0") == true)
                { cijenaKM6 = "";
                }

                string cijenaKM7 = Convert.ToString(cibam7);
                if (cijenaKM7.Equals("0") == true)
                { cijenaKM7 = "";
                }

                string cijenaKM8 = Convert.ToString(cibam8);
                if (cijenaKM8.Equals("0") == true)
                { cijenaKM8 = "";
                }

                string cijenaKM9 = Convert.ToString(cibam9);
                if (cijenaKM9.Equals("0") == true)
                { cijenaKM9 = "";
                }

                string cijenaKM10 = Convert.ToString(cibam10);
                if (cijenaKM10.Equals("0") == true)
                { cijenaKM10 = "";
                }

                string cijenaKM11 = Convert.ToString(cibam11);
                if (cijenaKM11.Equals("0") == true)
                { cijenaKM11 = "";
                }

                string cijenaEUR = Convert.ToString(cieu);
                if (cijenaEUR.Equals("0") == true)
                { cijenaEUR = "";
                }


                string cijenaEUR2 = Convert.ToString(cieu2);
                if (cijenaEUR2.Equals("0") == true)
                { cijenaEUR2 = "";
                }


                string cijenaEUR3 = Convert.ToString(cieu3);
                if (cijenaEUR3.Equals("0") == true)
                { cijenaEUR3 = "";
                }


                string cijenaEUR4 = Convert.ToString(cieu4);
                if (cijenaEUR4.Equals("0") == true)
                { cijenaEUR4 = "";
                }


                string cijenaEUR5 = Convert.ToString(cieu5);
                if (cijenaEUR5.Equals("0") == true)
                { cijenaEUR5 = "";
                }


                string cijenaEUR6 = Convert.ToString(cieu6);
                if (cijenaEUR6.Equals("0") == true)
                { cijenaEUR6 = "";
                }


                string cijenaEUR7 = Convert.ToString(cieu7);
                if (cijenaEUR7.Equals("0") == true)
                { cijenaEUR7 = "";
                }


                string cijenaEUR8 = Convert.ToString(cieu8);
                if (cijenaEUR8.Equals("0") == true)
                { cijenaEUR8 = "";
                }


                string cijenaEUR9 = Convert.ToString(cieu9);
                if (cijenaEUR9.Equals("0") == true)
                { cijenaEUR9 = "";
                }


                string cijenaEUR10 = Convert.ToString(cieu10);
                if (cijenaEUR10.Equals("0") == true)
                { cijenaEUR10 = "";
                }


                string cijenaEUR11 = Convert.ToString(cieu11);
                if (cijenaEUR11.Equals("0") == true)
                { cijenaEUR11 = "";
                }








                update.Parameters.AddWithValue("@ci", cijenaKM);
                update.Parameters.AddWithValue("@uci", textBox44.Text);
                update.Parameters.AddWithValue("@cie", cijenaEUR);

                update.Parameters.AddWithValue("@ci2", cijenaKM2);
                update.Parameters.AddWithValue("@uci2", textBox43.Text);
                update.Parameters.AddWithValue("@cie2", cijenaEUR2);
                update.Parameters.AddWithValue("@ci3", cijenaKM3);
                update.Parameters.AddWithValue("@uci3", textBox42.Text);
                update.Parameters.AddWithValue("@cie3", cijenaEUR3);
                update.Parameters.AddWithValue("@ci4", cijenaKM4);
                update.Parameters.AddWithValue("@uci4", textBox41.Text);
                update.Parameters.AddWithValue("@cie4", cijenaEUR4);
                update.Parameters.AddWithValue("@ci5", cijenaKM5);
                update.Parameters.AddWithValue("@uci5", textBox40.Text);
                update.Parameters.AddWithValue("@cie5", cijenaEUR5);
                update.Parameters.AddWithValue("@ci6", cijenaKM6);
                update.Parameters.AddWithValue("@uci6", textBox39.Text);
                update.Parameters.AddWithValue("@cie6", cijenaEUR6);
                update.Parameters.AddWithValue("@ci7", cijenaKM7);
                update.Parameters.AddWithValue("@uci7", textBox38.Text);
                update.Parameters.AddWithValue("@cie7", cijenaEUR7);
                update.Parameters.AddWithValue("@ci8", cijenaKM8);
                update.Parameters.AddWithValue("@uci8", textBox37.Text);
                update.Parameters.AddWithValue("@cie8", cijenaEUR8);
                update.Parameters.AddWithValue("@ci9", cijenaKM9);
                update.Parameters.AddWithValue("@uci9", textBox36.Text);
                update.Parameters.AddWithValue("@cie9", cijenaEUR9);
                update.Parameters.AddWithValue("@ci10", cijenaKM10);
                update.Parameters.AddWithValue("@uci10", textBox35.Text);
                update.Parameters.AddWithValue("@cie10", cijenaEUR10);
                update.Parameters.AddWithValue("@ci11", cijenaKM11);
                update.Parameters.AddWithValue("@uci11", textBox34.Text);
                update.Parameters.AddWithValue("@cie11", cijenaEUR11);
                update.Parameters.AddWithValue("@val", valuta);
                update.Parameters.AddWithValue("@tot", textBox46.Text);
                update.Parameters.AddWithValue("@nab", lblImePrezime.Text);
                update.Parameters.AddWithValue("@nana", textBox59.Text);
                update.Parameters.AddWithValue("@dat_na", DateTime.Now.ToShortDateString());

                con.Open();
                update.ExecuteNonQuery();
                MessageBox.Show(mCu);

                button4.Visible = false;
                button2.Visible = true;


            }
            finally
            {
                con.Close();
            }

        }












        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

            
            }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
           
              
            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox45.Text))
            {
                MessageBox.Show(mZBr);
                return;

            }

            int parsedValue;
            if (!int.TryParse(textBox45.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                return;
            }




            button1.Visible = true;
            button2.Visible = false;
            button4.Visible = false;
            




                string status = "";
            string totaltest = "";
            string ruodo = "";

                SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string query2 = "SELECT [status],[total],[rukodo] FROM DiReqt WHERE id = @staid ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */

                SqlCommand command12 = new SqlCommand(query2, connection2);
                connection2.Open();
                command12.Parameters.AddWithValue("@staid", textBox45.Text);

                SqlDataReader reader12 = command12.ExecuteReader();


                if (reader12.Read())
                {


                    status = (reader12["status"].ToString());
                totaltest = (reader12["total"].ToString());
                ruodo = (reader12["rukodo"].ToString());
                }

                else
                {
                    reader12.Close();
                    connection2.Close();
                return;
                }
            if (string.IsNullOrEmpty(totaltest))
            { }
            else
            {
                MessageBox.Show(mCuTo + totaltest);
            }

                if (string.IsNullOrEmpty(status))
                {

                }
                else
                {

                    MessageBox.Show(mZav + status);
                    return;
                }

            if (string.IsNullOrEmpty(ruodo))
            {
                MessageBox.Show(mZNO) ;
                return;
            }
            else if (ruodo.Equals("Odbijeno"))
            {
                MessageBox.Show(mZNO);
                return;

            }
            else

            { }
            ///////////////////////////////////////


            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string query = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2]" +
                                                         ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                         ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                         ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4]" +
                                                         ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3]" +
                                                         ",[sklad],[napomena]" +
                                                         ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11] FROM DiReqt WHERE id = @zid ";
            

                SqlCommand command1 = new SqlCommand(query, connection);
                connection.Open();
                command1.Parameters.AddWithValue("@zid", textBox45.Text);

                SqlDataReader reader1 = command1.ExecuteReader();


                ; if (reader1.Read())
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


                textBox58.Text = ident_sifra;
                textBox57.Text = ident_sifra2;
                textBox56.Text = ident_sifra3;
                textBox55.Text = ident_sifra4;
                textBox54.Text = ident_sifra5;
                textBox53.Text = ident_sifra6;
                textBox52.Text = ident_sifra7;
                textBox51.Text = ident_sifra8;
                textBox50.Text = ident_sifra9;
                textBox49.Text = ident_sifra10;
                textBox48.Text = ident_sifra11;

                /*  string jm = (reader1["jm"].ToString());
                  string jm2 = (reader1["jm2"].ToString());
                  string jm3 = (reader1["jm3"].ToString());
                  string jm4 = (reader1["jm4"].ToString());
                  string jm5 = (reader1["jm5"].ToString());
                  string jm6 = (reader1["jm6"].ToString());
                  string jm7 = (reader1["jm7"].ToString());
                  string jm8 = (reader1["jm8"].ToString());
                  string jm9 = (reader1["jm9"].ToString());
                  string jm10 = (reader1["jm10"].ToString());
                  string jm11 = (reader1["jm11"].ToString());
                   string mt = (reader1["naziv_mt"].ToString());
                  string mt2 = (reader1["naziv_mt2"].ToString());
                  string mt3 = (reader1["naziv_mt3"].ToString());
                  string mt4 = (reader1["naziv_mt4"].ToString());
                   string st = (reader1["sifra_mt"].ToString());
                  string st2 = (reader1["sifra_mt2"].ToString());
                  string st3 = (reader1["sifra_mt3"].ToString());
                  string st4 = (reader1["sifra_mt4"].ToString());
                  string ime = (reader1["podnositelj"].ToString());
                  string datum = (reader1["datum"].ToString());

                  string min = (reader1["min"].ToString());
                  string min2 = (reader1["min2"].ToString());
                  string min3 = (reader1["min3"].ToString());
                  string max = (reader1["max"].ToString());
                  string max2 = (reader1["max2"].ToString());
                  string max3 = (reader1["max3"].ToString());
                  string stanje = (reader1["stanje"].ToString());
                  string stanje2 = (reader1["stanje2"].ToString());
                  string stanje3 = (reader1["stanje3"].ToString());
                  string sklad = (reader1["sklad"].ToString());
                  string napo = (reader1["napomena"].ToString());*/
            }

                else
                {
                    reader1.Close();
                }





            }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(mZnU);
                return;
            }


            if (string.IsNullOrEmpty(textBox22.Text))
                {
                    MessageBox.Show(mCnU);
                    return;
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


                /////////




                ////////////////


                if (string.IsNullOrEmpty(textBox1.Text))
                {
                }
                else
                {
                    double ci = Convert.ToDouble(textBox22.Text);

                    int koli = Convert.ToInt32(textBox23.Text);
                    uci = ci * koli;

                    textBox44.Text = uci.ToString();
                }




                if (string.IsNullOrEmpty(textBox2.Text))
                {
                }
                else
                {
                    double ci1 = Convert.ToDouble(textBox21.Text);
                    int koli1 = Convert.ToInt32(textBox24.Text);
                    uci1 = ci1 * koli1;
                    textBox43.Text = uci1.ToString();
                }

                if (string.IsNullOrEmpty(textBox3.Text))
                {
                }
                else
                {
                    double ci2 = Convert.ToDouble(textBox20.Text);
                    int koli2 = Convert.ToInt32(textBox25.Text);
                    uci2 = ci2 * koli2;
                    textBox42.Text = uci2.ToString();
                }

                if (string.IsNullOrEmpty(textBox4.Text))
                {
                }
                else
                {
                    double ci3 = Convert.ToDouble(textBox19.Text);
                    int koli3 = Convert.ToInt32(textBox26.Text);
                    uci3 = ci3 * koli3;
                    textBox41.Text = uci3.ToString();
                }


                if (string.IsNullOrEmpty(textBox5.Text))
                {
                }
                else
                {
                    double ci4 = Convert.ToDouble(textBox18.Text);
                    int koli4 = Convert.ToInt32(textBox27.Text);
                    uci4 = ci4 * koli4;
                    textBox40.Text = uci4.ToString();
                }

                if (string.IsNullOrEmpty(textBox6.Text))
                {
                }
                else
                {
                    double ci5 = Convert.ToDouble(textBox17.Text);
                    int koli5 = Convert.ToInt32(textBox28.Text);
                    uci5 = ci5 * koli5;
                    textBox39.Text = uci5.ToString();
                }

                if (string.IsNullOrEmpty(textBox7.Text))
                {
                }
                else
                {
                    double ci6 = Convert.ToDouble(textBox16.Text);
                    int koli6 = Convert.ToInt32(textBox29.Text);
                    uci6 = ci6 * koli6;
                    textBox38.Text = uci6.ToString();
                }
                if (string.IsNullOrEmpty(textBox8.Text))
                {
                }
                else
                {
                    double ci7 = Convert.ToDouble(textBox15.Text);
                    int koli7 = Convert.ToInt32(textBox30.Text);
                    uci7 = ci7 * koli7;
                    textBox37.Text = uci7.ToString();
                }
                if (string.IsNullOrEmpty(textBox9.Text))
                {
                }
                else
                {
                    double ci8 = Convert.ToDouble(textBox14.Text);
                    int koli8 = Convert.ToInt32(textBox31.Text);
                    uci8 = ci8 * koli8;
                    textBox36.Text = uci8.ToString();
                }
                if (string.IsNullOrEmpty(textBox10.Text))
                {
                }
                else
                {
                    double ci9 = Convert.ToDouble(textBox13.Text);
                    int koli9 = Convert.ToInt32(textBox32.Text);
                    uci9 = ci9 * koli9;
                    textBox35.Text = uci9.ToString();
                }
                if (string.IsNullOrEmpty(textBox11.Text))
                {
                }
                else
                {
                    double ci10 = Convert.ToDouble(textBox12.Text);
                    int koli10 = Convert.ToInt32(textBox33.Text);
                    uci10 = ci10 * koli10;
                    textBox34.Text = uci10.ToString();
                }



                double total = uci + uci1 + uci2 + uci3 + uci4 + uci5 + uci6 + uci7 + uci8 + uci9 + uci10;

            
            





                textBox46.Text = total.ToString();


                button1.Visible = false;
                button4.Visible = true;
            }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connectiondel = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            try
            {
                
                string querydel = "DELETE FROM DiReqt WHERE id = @zid ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */

                SqlCommand command1d = new SqlCommand(querydel, connectiondel);
                connectiondel.Open();
                command1d.Parameters.AddWithValue("@zid", textBox45.Text);
                command1d.ExecuteNonQuery();
                MessageBox.Show("Zahtjev broj: " + textBox45.Text + " je izbrisan!");
                textBox45.Text = "";
            }
            finally
            { connectiondel.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
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
            textBox59.Text = "";
            button4.Visible = false;
            button2.Visible = false;
        }

        private void rBtnBam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            tbControlNabavka.SelectTab(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbControlNabavka.SelectTab(0);
        }

        

        private void picBoxOdjel_Click(object sender, EventArgs e)
        {

        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }


     
        string izvor = "";
        string ime = "";
        string datum = "";
        string ident = "";
        string idbroj = "";
        string odjel = "";

        
        

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = GetConnection();

            string query3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj] FROM DiReqt WHERE [id] = @id ";



            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", textBox45.Text);

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


            PDF p = new PDF();
            p.id = textBox45.Text;

            string broj = textBox45.Text;


         

            bool result;
            result = PDFC.Create_PDF(broj);


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";




            string datumnab = "";
            string ko = "";
            string ko2 = "";
            string ko3 = "";
            string ko4 = "";
            string ko5 = "";
            string ko6 = "";
            string ko7 = "";
            string ko8 = "";
            string ko9 = "";
            string ko10 = "";
            string ko11 = "";
            string nz = "";

            string nz2 = "";
            string nz3 = "";
            string nz4 = "";
            string nz5 = "";
            string nz6 = "";
            string nz7 = "";
            string nz8 = "";
            string nz9 = "";
            string nz10 = "";
            string nz11 = "";





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







            if (string.IsNullOrEmpty(textBox22.Text))
            {
                cipot = 0;
            }
            else
            {
                cipot = double.Parse(textBox22.Text);
            }

            if (string.IsNullOrEmpty(textBox21.Text))
            {
                cipot2 = 0;
            }
            else
            {
                cipot2 = double.Parse(textBox21.Text);
            }


            if (string.IsNullOrEmpty(textBox20.Text))
            {
                cipot3 = 0;
            }
            else
            {
                cipot3 = double.Parse(textBox20.Text);
            }

            if (string.IsNullOrEmpty(textBox19.Text))
            {
                cipot4 = 0;
            }
            else
            {
                cipot4 = double.Parse(textBox19.Text);
            }

            if (string.IsNullOrEmpty(textBox18.Text))
            {
                cipot5 = 0;
            }
            else
            {
                cipot5 = double.Parse(textBox18.Text);
            }

            if (string.IsNullOrEmpty(textBox17.Text))
            {
                cipot6 = 0;
            }
            else
            {
                cipot6 = double.Parse(textBox17.Text);
            }

            if (string.IsNullOrEmpty(textBox16.Text))
            {
                cipot7 = 0;
            }
            else
            {
                cipot7 = double.Parse(textBox16.Text);
            }

            if (string.IsNullOrEmpty(textBox15.Text))
            {
                cipot8 = 0;
            }
            else
            {
                cipot8 = double.Parse(textBox15.Text);
            }

            if (string.IsNullOrEmpty(textBox14.Text))
            {
                cipot9 = 0;
            }
            else
            {
                cipot9 = double.Parse(textBox14.Text);
            }

            if (string.IsNullOrEmpty(textBox13.Text))
            {
                cipot10 = 0;
            }
            else
            {
                cipot10 = double.Parse(textBox13.Text);
            }

            if (string.IsNullOrEmpty(textBox12.Text))
            {
                cipot11 = 0;
            }
            else
            {
                cipot11 = double.Parse(textBox12.Text);
            }




            if (radioButton1.Checked)
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
            else if (radioButton2.Checked)
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

            string cijenaKM = Convert.ToString(cibam);
            if (cijenaKM.Equals("0") == true)
            {
                cijenaKM = "";
            }



            string cijenaKM2 = Convert.ToString(cibam2);
            if (cijenaKM2.Equals("0") == true)
            {
                cijenaKM2 = "";
            }

            string cijenaKM3 = Convert.ToString(cibam3);
            if (cijenaKM3.Equals("0") == true)
            {
                cijenaKM3 = "";
            }

            string cijenaKM4 = Convert.ToString(cibam4);
            if (cijenaKM4.Equals("0") == true)
            {
                cijenaKM4 = "";
            }

            string cijenaKM5 = Convert.ToString(cibam5);
            if (cijenaKM5.Equals("0") == true)
            {
                cijenaKM5 = "";
            }

            string cijenaKM6 = Convert.ToString(cibam6);
            if (cijenaKM6.Equals("0") == true)
            {
                cijenaKM6 = "";
            }

            string cijenaKM7 = Convert.ToString(cibam7);
            if (cijenaKM7.Equals("0") == true)
            {
                cijenaKM7 = "";
            }

            string cijenaKM8 = Convert.ToString(cibam8);
            if (cijenaKM8.Equals("0") == true)
            {
                cijenaKM8 = "";
            }

            string cijenaKM9 = Convert.ToString(cibam9);
            if (cijenaKM9.Equals("0") == true)
            {
                cijenaKM9 = "";
            }

            string cijenaKM10 = Convert.ToString(cibam10);
            if (cijenaKM10.Equals("0") == true)
            {
                cijenaKM10 = "";
            }

            string cijenaKM11 = Convert.ToString(cibam11);
            if (cijenaKM11.Equals("0") == true)
            {
                cijenaKM11 = "";
            }

            string cijenaEUR = Convert.ToString(cieu);
            if (cijenaEUR.Equals("0") == true)
            {
                cijenaEUR = "";
            }


            string cijenaEUR2 = Convert.ToString(cieu2);
            if (cijenaEUR2.Equals("0") == true)
            {
                cijenaEUR2 = "";
            }


            string cijenaEUR3 = Convert.ToString(cieu3);
            if (cijenaEUR3.Equals("0") == true)
            {
                cijenaEUR3 = "";
            }


            string cijenaEUR4 = Convert.ToString(cieu4);
            if (cijenaEUR4.Equals("0") == true)
            {
                cijenaEUR4 = "";
            }


            string cijenaEUR5 = Convert.ToString(cieu5);
            if (cijenaEUR5.Equals("0") == true)
            {
                cijenaEUR5 = "";
            }


            string cijenaEUR6 = Convert.ToString(cieu6);
            if (cijenaEUR6.Equals("0") == true)
            {
                cijenaEUR6 = "";
            }


            string cijenaEUR7 = Convert.ToString(cieu7);
            if (cijenaEUR7.Equals("0") == true)
            {
                cijenaEUR7 = "";
            }


            string cijenaEUR8 = Convert.ToString(cieu8);
            if (cijenaEUR8.Equals("0") == true)
            {
                cijenaEUR8 = "";
            }


            string cijenaEUR9 = Convert.ToString(cieu9);
            if (cijenaEUR9.Equals("0") == true)
            {
                cijenaEUR9 = "";
            }


            string cijenaEUR10 = Convert.ToString(cieu10);
            if (cijenaEUR10.Equals("0") == true)
            {
                cijenaEUR10 = "";
            }


            string cijenaEUR11 = Convert.ToString(cieu11);
            if (cijenaEUR11.Equals("0") == true)
            {
                cijenaEUR11 = "";
            }


            double totalz = cieu + cieu2 + cieu3 + cieu4 + cieu5 + cieu6 + cieu7 + cieu8 + cieu9 + cieu10 + cieu11;




            string val = "";
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
          


            SqlConnection connections = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            string querys = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3]" +
                                                     ",[sklad],[napomena],[stok],[vrsta],[valuta]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11]" +
                                                     "FROM DiReqt WHERE id = @zidi ";


            SqlCommand commands = new SqlCommand(querys, connections);
            connections.Open();
            commands.Parameters.AddWithValue("@zidi", textBox45.Text);

            SqlDataReader readers = commands.ExecuteReader();


            if (readers.Read())
            {
                nz = (readers["naziv"].ToString());
                nz2 = (readers["naziv2"].ToString());
                nz3 = (readers["naziv3"].ToString());
                nz4 = (readers["naziv4"].ToString());
                nz5 = (readers["naziv5"].ToString());
                nz6 = (readers["naziv6"].ToString());
                nz7 = (readers["naziv7"].ToString());
                nz8 = (readers["naziv8"].ToString());
                nz9 = (readers["naziv9"].ToString());
                nz10 = (readers["naziv10"].ToString());
                nz11 = (readers["naziv11"].ToString());

                ko = (readers["kolicina"].ToString());
                ko2 = (readers["kolicina2"].ToString());
                ko3 = (readers["kolicina3"].ToString());
                ko4 = (readers["kolicina4"].ToString());
                ko5 = (readers["kolicina5"].ToString());
                ko6 = (readers["kolicina6"].ToString());
                ko7 = (readers["kolicina7"].ToString());
                ko8 = (readers["kolicina8"].ToString());
                ko9 = (readers["kolicina9"].ToString());
                ko10 = (readers["kolicina10"].ToString());
                ko11 = (readers["kolicina11"].ToString());

                ident_sifra = (readers["ident_sifra"].ToString());
                ident_sifra2 = (readers["ident_sifra2"].ToString());
                ident_sifra3 = (readers["ident_sifra3"].ToString());
                ident_sifra4 = (readers["ident_sifra4"].ToString());
                ident_sifra5 = (readers["ident_sifra5"].ToString());
                ident_sifra6 = (readers["ident_sifra6"].ToString());
                ident_sifra7 = (readers["ident_sifra7"].ToString());
                ident_sifra8 = (readers["ident_sifra8"].ToString());
                ident_sifra9 = (readers["ident_sifra9"].ToString());
                ident_sifra10 = (readers["ident_sifra10"].ToString());
                ident_sifra11 = (readers["ident_sifra11"].ToString());

                jm = (readers["jm"].ToString());
                jm2 = (readers["jm2"].ToString());
                jm3 = (readers["jm3"].ToString());
                jm4 = (readers["jm4"].ToString());
                jm5 = (readers["jm5"].ToString());
                jm6 = (readers["jm6"].ToString());
                jm7 = (readers["jm7"].ToString());
                jm8 = (readers["jm8"].ToString());
                jm9 = (readers["jm9"].ToString());
                jm10 = (readers["jm10"].ToString());
                jm11 = (readers["jm11"].ToString());
                mt = (readers["naziv_mt"].ToString());
                mt2 = (readers["naziv_mt2"].ToString());
                mt3 = (readers["naziv_mt3"].ToString());
                mt4 = (readers["naziv_mt4"].ToString());
                st = (readers["sifra_mt"].ToString());
                st2 = (readers["sifra_mt2"].ToString());
                st3 = (readers["sifra_mt3"].ToString());
                st4 = (readers["sifra_mt4"].ToString());
            
           
                datumnab = (readers["datum_nabavka"].ToString());
                val = (readers["valuta"].ToString());



                /*
                                cijeuro = (readers["cijena_eur"].ToString());
                                cijeuro2 = (readers["cijena_eur2"].ToString());
                                cijeuro3 = (readers["cijena_eur3"].ToString());
                                cijeuro4 = (readers["cijena_eur4"].ToString());
                                cijeuro5 = (readers["cijena_eur5"].ToString());
                                cijeuro6 = (readers["cijena_eur6"].ToString());
                                cijeuro7 = (readers["cijena_eur7"].ToString());
                                cijeuro8 = (readers["cijena_eur8"].ToString());
                                cijeuro9 = (readers["cijena_eur9"].ToString());
                                cijeuro10 = (readers["cijena_eur10"].ToString());
                                cijeuro11 = (readers["cijena_eur11"].ToString());
                                */


            }

            else
            {
                readers.Close();
            }


            string mjesto_troska = mt + "  " + mt2 + "  " + mt3 + "  " + mt4;
            string sifra_troska = st + "  " + st2 + "  " + st3 + "  " + st4;







            double koc = 0;
            double koc2 = 0;
            double koc3 = 0;
            double koc4 = 0;
            double koc5 = 0;
            double koc6 = 0;
            double koc7 = 0;
            double koc8 = 0;
            double koc9 = 0;
            double koc10 = 0;
            double koc11 = 0;



            if (string.IsNullOrEmpty(textBox23.Text))
            {
                koc = 0;
            }
            else
            {
                koc = double.Parse(textBox23.Text);
            }


            if (string.IsNullOrEmpty(textBox24.Text))
            {
                koc2 = 0;
            }
            else
            {
                koc2 = double.Parse(textBox24.Text);
            }
            if (string.IsNullOrEmpty(textBox25.Text))
            {
                koc3 = 0;
            }
            else
            {
                koc3 = double.Parse(textBox25.Text);
            }
            if (string.IsNullOrEmpty(textBox26.Text))
            {
                koc4 = 0;
            }
            else
            {
                koc4 = double.Parse(textBox26.Text);
            }
            if (string.IsNullOrEmpty(textBox27.Text))
            {
                koc5 = 0;
            }
            else
            {
                koc5 = double.Parse(textBox27.Text);
            }
            if (string.IsNullOrEmpty(textBox28.Text))
            {
                koc6 = 0;
            }
            else
            {
                koc6 = double.Parse(textBox28.Text);
            }
            if (string.IsNullOrEmpty(textBox29.Text))
            {
                koc7 = 0;
            }
            else
            {
                koc7 = double.Parse(textBox29.Text);
            }
            if (string.IsNullOrEmpty(textBox30.Text))
            {
                koc8 = 0;
            }
            else
            {
                koc8 = double.Parse(textBox30.Text);
            }
            if (string.IsNullOrEmpty(textBox31.Text))
            {
                koc9 = 0;
            }
            else
            {
                koc9 = double.Parse(textBox31.Text);
            }
            if (string.IsNullOrEmpty(textBox32.Text))
            {
                koc10 = 0;
            }
            else
            {
                koc10 = double.Parse(textBox32.Text);
            }
            if (string.IsNullOrEmpty(textBox33.Text))
            {
                koc11 = 0;
            }
            else
            {
                koc11 = double.Parse(textBox33.Text);
            }

            double cikm = 0;
            double cikm2 = 0;
            double cikm3 = 0;
            double cikm4 = 0;
            double cikm5 = 0;
            double cikm6 = 0;
            double cikm7 = 0;
            double cikm8 = 0;
            double cikm9 = 0;
            double cikm10 = 0;
            double cikm11 = 0;



            cieu = cieu * koc;
            cieu2 = cieu2 * koc2;
            cieu3 = cieu3 * koc3;
            cieu4 = cieu4 * koc4;
            cieu5 = cieu5 * koc5;
            cieu6 = cieu6 * koc6;
            cieu7 = cieu7 * koc7;
            cieu8 = cieu8 * koc8;
            cieu9 = cieu9 * koc9;
            cieu10 = cieu10 * koc10;
            cieu11 = cieu11 * koc11;


            cikm = cibam * koc;
            cikm2 = cibam2 * koc2;
            cikm3 = cibam3 * koc3;
            cikm4 = cibam4 * koc4;
            cikm5 = cibam5 * koc5;
            cikm6 = cibam6 * koc6;
            cikm7 = cibam7 * koc7;
            cikm8 = cibam8 * koc8;
            cikm9 = cibam9 * koc9;
            cikm10 = cibam10 * koc10;
            cikm11 = cibam11 * koc11;

            double toteu = cieu + cieu2 + cieu3 + cieu4 + cieu5 + cieu6 + cieu7 + cieu8 + cieu9 + cieu10 + cieu11;



            string c = "";
            string c2 = "";
            string c3 = "";
            string c4 = "";
            string c5 = "";
            string c6 = "";
            string c7 = "";
            string c8 = "";
            string c9 = "";
            string c10 = "";
            string c11 = "";
            string toteustring;
            if (cieu != 0)
            { c = Convert.ToString(cieu); }
            if (cieu2 != 0)
            { c2 = Convert.ToString(cieu2); }
            if (cieu3 != 0)
            {
                c3 = Convert.ToString(cieu3);
            }
            if (cieu4 != 0)
            { c4 = Convert.ToString(cieu4); }

            if (cieu5 != 0)

            { c5 = Convert.ToString(cieu5); }
            if (cieu6 != 0)
            {
                c6 = Convert.ToString(cieu6);
            }
            if (cieu7 != 0)
            {
                c7 = Convert.ToString(cieu7);
            }
            if (cieu8 != 0)
            {
                c8 = Convert.ToString(cieu8);
            }
            if (cieu9 != 0)
            {
                c9 = Convert.ToString(cieu9);
            }
            if (cieu10 != 0)
            {
                c10 = Convert.ToString(cieu10);
            }
            if (cieu11 != 0)
            {
                c11 = Convert.ToString(cieu11);
            }
            toteustring = Convert.ToString(toteu);




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
            string pp = "";

            string broj_zah = textBox45.Text;


            string t1 = "Datum zaprimanja u kontroling";
            string t2 = "Datum ";
            string t3 = "Šifra zahtjeva";
            string t31 = "MT-ŠIFRA";
            string t4 = "Ident šifra";
            string t4o = "Naziv mjesta troška";
            string tcikm = "Naziv materijala";
            string tcieuro = "JM";
            string t5 = "Količina";
            string t51 = "Odobrena količina";
            string t61 = "Cijena (KM)";
            string t6 = "Cijena (€)";
            string t7 = "Total (€)";
            string t8 = "Ukupni total (€)";





            string[] row0 = { t1, t2, t3, t31, t4, t4o, tcikm, tcieuro, t5, t51, t61, t6, t7, t8 };

            string[] row = { datumnab, datum, broj_zah, sifra_troska, ident_sifra, mjesto_troska, nz, jm, ko, pp, cijenaKM, cijenaEUR, c, toteustring };

            string[] row1 = { pp, pp, pp, pp, ident_sifra2, pp, nz2, jm2, ko2, pp, cijenaKM2, cijenaEUR2, c2, pp };

            string[] row2 = { pp, pp, pp, pp, ident_sifra3, pp, nz3, jm3, ko3, pp, cijenaKM3, cijenaEUR3, c3, pp };

            string[] row3 = { pp, pp, pp, pp, ident_sifra4, pp, nz4, jm4, ko4, pp, cijenaKM4, cijenaEUR4, c4, pp };

            string[] row4 = { pp, pp, pp, pp, ident_sifra5, pp, nz5, jm5, ko5, pp, cijenaKM5, cijenaEUR5, c5, pp };

            string[] row5 = { pp, pp, pp, pp, ident_sifra6, pp, nz6, jm6, ko6, pp, cijenaKM6, cijenaEUR6, c6, pp };

            string[] row6 = { pp, pp, pp, pp, ident_sifra7, pp, nz7, jm7, ko7, pp, cijenaKM7, cijenaEUR7, c7, pp };

            string[] row7 = { pp, pp, pp, pp, ident_sifra8, pp, nz8, jm8, ko8, pp, cijenaKM8, cijenaEUR8, c8, pp };

            string[] row8 = { pp, pp, pp, pp, ident_sifra9, pp, nz9, jm9, ko9, pp, cijenaKM9, cijenaEUR9, c9, pp };

            string[] row9 = { pp, pp, pp, pp, ident_sifra10, pp, nz10, jm10, ko10, pp, cijenaKM10, cijenaEUR10, c10, pp };

            string[] row10 = { pp, pp, pp, pp, ident_sifra11, pp, nz11, jm11, ko11, pp, cijenaKM11, cijenaEUR11, c11, pp };

            //string[] row11 = { pp, pp, pp, pp,pp, pp, pp, pp, pp, pp, pp, pp,  };





            dataGridView1.Rows.Add(row0);
            if (cieu != 0)
            {
                dataGridView1.Rows.Add(row);
            }
            if (cieu2 != 0)

            { dataGridView1.Rows.Add(row1); }
            if (cieu3 != 0)
            { dataGridView1.Rows.Add(row2); }
            if (cieu4 != 0)
            { dataGridView1.Rows.Add(row3); }
            if (cieu5 != 0)
            { dataGridView1.Rows.Add(row4); }
            if (cieu6 != 0)
            { dataGridView1.Rows.Add(row5); }
            if (cieu7 != 0)
            { dataGridView1.Rows.Add(row6); }
            if (cieu8 != 0)
            { dataGridView1.Rows.Add(row7); }
            if (cieu9 != 0)
            { dataGridView1.Rows.Add(row8); }
            if (cieu10 != 0)
            { dataGridView1.Rows.Add(row9); }
            if (cieu11 != 0)
            { dataGridView1.Rows.Add(row10); }
            ;


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

            xlWorkBook.SaveAs(@"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + textBox45.Text.Trim() + " " + "NC" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            /*releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);*/




            //Mail
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
                MailAddress to = new MailAddress("From Address Ex direqt.kontroling@volkswagen-sa.ba");
                MailMessage message = new MailMessage(from, to);
                message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = ime + " " + datum + " No. " + textBox45.Text.Trim();
                message.SubjectEncoding = System.Text.Encoding.UTF8;





                //  MailAddress bcc = new MailAddress("emina.imsirovic@volkswagen-sa.ba");
                //  MailAddress bcc = new MailAddress("rijad.siljak@volkswagen-sa.ba");

                //   MailAddress bcc2 = new MailAddress("sascha.schreiner@volkswagen-sa.ba");
                //     MailAddress bcc2 = new MailAddress("rijadsiljak@gmail.com");



                System.Net.Mail.Attachment attachment;
                string folderPath1 = @"C:\Users\Public\Documents\ZZM\";

                if (!Directory.Exists(folderPath1))
                {
                    Directory.CreateDirectory(folderPath1);
                }
                System.Net.Mail.Attachment attachment1;
                // string folderPath41 = @"C:\Users\Public\Documents\ZZM\";

                /* if (!Directory.Exists(folderPath41))
                 {
                     Directory.CreateDirectory(folderPath41);
                 }*/
                attachment = new System.Net.Mail.Attachment(izvor);
                message.Attachments.Add(attachment);
                attachment1 = new System.Net.Mail.Attachment(folderPath1 + " " + ime + " " + datum + " No. " + textBox45.Text.Trim() + " " + "NC" + ".xls");
                message.Attachments.Add(attachment1);

                /*  SmtpServer.Port = 587;
                  SmtpServer.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18 ");
                  SmtpServer.EnableSsl = true;
                  */
                // SmtpServer.Send(mail);


                client.Send(message);
                MessageBox.Show(mMail);

                foreach (System.Net.Mail.Attachment attachmentz in message.Attachments)

                {

                    attachmentz.Dispose();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




            // System.Diagnostics.Process.Start(folderPath + this.comboBox12.Text.Trim() + " " + this.textBox34.Text.Trim() + DateTime.Now.ToShortDateString() + ".pdf");
            // this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            string folderPath2 = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + textBox45.Text.Trim() + " " + "NC" + ".pdf";
            using (PrintDialog Dialog = new PrintDialog())
            {
                // Dialog.ShowDialog();

                ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                {
                    Verb = "print",
                    CreateNoWindow = true,
                    FileName = folderPath2,
                    WindowStyle = ProcessWindowStyle.Normal
                };
                //Proces printanja


                Process printProcess = new Process();
                printProcess.StartInfo = printProcessInfo;


                // printProcess.Start(); 
                // printProcess.Start();
                //  printProcess.Start();
                // printProcess.Start();


                //   printProcess.WaitForInputIdle(); 



                // MessageBox.Show("Zahtjev je na printanju!");



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
                textBox59.Text = "";



                button1.Visible = true;
                button2.Visible = false;











            }

            }

        private void button10_Click(object sender, EventArgs e)
        {

            SqlConnection conn = GetConnection();
            SqlCommand delete = new SqlCommand("Update DiReqt set  [cijena]=@x,[cijena_eur]=@x,[ukupna_cijena]=@x," +
                "[cijena2]=@x,[cijena_eur2]=@x,[ukupna_cijena2]=@x,[cijena3]=@x,[cijena_eur3]=@x,[ukupna_cijena3]=@x,[cijena4]=@x,[cijena_eur4]=@x,[ukupna_cijena4]=@x,[cijena5]=@x,[cijena_eur5]=@x,[ukupna_cijena5]=@x," +
                "[cijena6]=@x,[cijena_eur6]=@x,[ukupna_cijena6]=@x,[cijena7]=@x,[cijena_eur7]=@x,[ukupna_cijena7]=@x,[cijena8]=@x,[cijena_eur8]=@x,[ukupna_cijena8]=@x,[cijena9]=@x,[cijena_eur9]=@x," +
                "[ukupna_cijena9]=@x,[cijena10]=@x,[cijena_eur10]=@x,[ukupna_cijena10]=@x," +
                "[cijena11]=@x,[cijena_eur11]=@x,[ukupna_cijena11]=@x," +
                "[total]=@x,[valuta]=@x,[datum_nabavka]=@x,[napnab]=@x,[nabavka]=@x" +
                  " where id=@lid", conn);
            delete.Parameters.AddWithValue("@lid", textBox45.Text);
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

        private void panelUnosenjeCijene_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
