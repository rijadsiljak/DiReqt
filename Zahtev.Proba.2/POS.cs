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

namespace DiReqt
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }
        string username="";
        string idbroj = "";
        string uloga = "";
        string jez = "";
        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;

        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Bos"))
            {

                lblNaslov.Text = "Odgovorna osoba";


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
                mOdgOs = " Odgovorna osoba za odjel" + " je  ";
                mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";















            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {




                lblNaslov.Text = "Verantwortliche Person";



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
                mOdgOs = " Die Verantwortliche Person für die Abteilung" + " ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }




        private void POS_Load(object sender, EventArgs e)
        {
            username = Korisnik.korisnicko;

            jez = Korisnik.Jezik;
            prjez();

            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            string getid = "Select [idbroj] from Korisnici where username = @usr";

            SqlCommand cid = new SqlCommand(getid, connection2);
            connection2.Open();

            cid.Parameters.AddWithValue("@usr",username);
            SqlDataReader rid = cid.ExecuteReader();

            if (rid.Read())
            {
                idbroj = (rid["idbroj"].ToString());

            }

            rid.Close();
            connection2.Close();




            string getul = "Select [uloga] from posodo where [idbroj] = @usr";

            SqlCommand cul = new SqlCommand(getul, connection2);
            connection2.Open();

            cul.Parameters.AddWithValue("@usr", idbroj);
            SqlDataReader rul = cul.ExecuteReader();

            if (rul.Read())
            {
                uloga = (rul["uloga"].ToString());

            }

            rul.Close();
            connection2.Close();


            comboBox1.Items.Clear();
            string querymt="";
             querymt = "SELECT [ime] + ' ' + [prezime] as imeprezime  FROM posodo WHERE uloga=@ul ";

            if (uloga.Equals("ADMIN"))
            {
                 querymt = "SELECT [ime] + ' ' + [prezime] as imeprezime  FROM posodo   ";
            }


            SqlCommand sifre = new SqlCommand(querymt, connection2);
            connection2.Open();


            sifre.Parameters.AddWithValue("@ul", uloga);

            SqlDataReader mtsif = sifre.ExecuteReader();

            while (mtsif.Read())
            {
                comboBox1.Items.Add(mtsif[0]);

            }
        }
        string id1 = "";
        private void button1_Click(object sender, EventArgs e)
        {






            SqlConnection con = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

            string qid = "SELECT [idbroj] FROM posodo WHERE [ime] + ' ' + [prezime]=@lbl  ";


            SqlCommand ids = new SqlCommand(qid, con);
            con.Open();
            ids.Parameters.AddWithValue("@lbl", comboBox1.Text);

            SqlDataReader idz = ids.ExecuteReader();

            if (idz.Read())
            {

                id1 = (idz["idbroj"].ToString());

            }



            idz.Close();
            con.Close();

            string odjel = "";

            if (uloga.Equals("Kontroling"))
            { odjel = "OdKon"; }
            else if (uloga.Equals("Uprava"))
            {
                odjel = "OdDir";
            }
            

            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);

                podobri.Parameters.AddWithValue("@konid", odjel);

                podobri.Parameters.AddWithValue("@st", id1);

                con.Open();
                podobri.ExecuteNonQuery();

               

                MessageBox.Show(mOdgOs + comboBox1.Text  );


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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
