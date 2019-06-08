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
    public partial class PromjenaSifre : Form
    {
        public PromjenaSifre()
        {
            InitializeComponent();
        }

        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;

        //varijable potrebne za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;

        //
        //X button
        //
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //
        // Pomoćna funkcija za brisanje placeholder-a
        //
        private void EraseTextOnEnter(TextBox txt, string str, Color color)
        {
            if (txt.Text == str)
            {
                txt.Text = "";
                txt.ForeColor = color;
                txt.PasswordChar = '*';
            }
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
        //Brisanje placeholdera za sva 3 textboxa
        //
        private void txtStaraSifra_Enter(object sender, EventArgs e)
        {
            EraseTextOnEnter(txtStaraSifra, "Stara šifra", Color.SteelBlue);
        }

        private void txtNovaSifra_Enter(object sender, EventArgs e)
        {
            EraseTextOnEnter(txtNovaSifra, "Nova šifra", Color.SteelBlue);
        }

        private void txtPotvrdaSifre_Enter(object sender, EventArgs e)
        {
            EraseTextOnEnter(txtPotvrdaSifre, "Ponovite novu šifru", Color.SteelBlue);
        }

        //
        //Upisivanje texta u placeholder za sva 3 textboxa
        //
        private void txtStaraSifra_Leave(object sender, EventArgs e)
        {
            PlaceholderOnLeave(txtStaraSifra, "Stara šifra", Color.SteelBlue);
        }

        private void txtNovaSifra_Leave(object sender, EventArgs e)
        {
            PlaceholderOnLeave(txtNovaSifra, "Nova šifra", Color.SteelBlue);
        }

        private void txtPotvrdaSifre_Leave(object sender, EventArgs e)
        {
            PlaceholderOnLeave(txtPotvrdaSifre, "Ponovite novu šifru", Color.SteelBlue);
        }

        //
        //Funkcije za pomjeranje forme, treba spojiti sa panelom na vrhu svake forme (tamo gdje je x)
        //3 eventa MouseDown, MouseUp i MouseMove
        //
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

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }


        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Bos"))
            {





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
               
                mUsPro = " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";















            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {

              






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
             
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }









        private void btnSpremi_Click(object sender, EventArgs e)
        {

            string username;

            username = Korisnik.korisnicko;

            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query2 = "select [username],[password] from Korisnici where [username]=@usr and [password]=@pwd  ";





            SqlCommand command12 = new SqlCommand(query2, connection2);
            connection2.Open();
            command12.Parameters.AddWithValue("@usr", username);
            command12.Parameters.AddWithValue("@pwd", txtStaraSifra.Text);
            
           SqlDataReader reader12 = command12.ExecuteReader();
           // MessageBox.Show(username);


            if (txtNovaSifra.Text == txtPotvrdaSifre.Text)
            {
                if (reader12.Read() == true)
                {

                    SqlConnection co2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string qu2 = "Update [Korisnici] set password=@uppw where [username]=@usr and [password]=@pwd ";



                    SqlCommand c1 = new SqlCommand(qu2, co2);
                    co2.Open();


                    c1.Parameters.AddWithValue("@usr", username);

                    c1.Parameters.AddWithValue("@pwd", txtStaraSifra.Text);

                    c1.Parameters.AddWithValue("@uppw", txtNovaSifra.Text);



                    c1.ExecuteNonQuery();

                    MessageBox.Show(mUsPro);

                    /*
                    txtPotvrdaSifre.Clear();
                    txtStaraSifra.Clear();
                    txtNovaSifra.Text = "";

                   
                    */
                    CloseButton.PerformClick();
                    co2.Close();

                }
            }
            
            else
            {

                string tekst = mSnJ;

                MessageBox.Show(tekst);
                txtPotvrdaSifre.Text = "";
                txtNovaSifra.Text = "";

            }


        }
        string jez;
        private void PromjenaSifre_Load(object sender, EventArgs e)
        {
            jez = Korisnik.Jezik;
            prjez();
        }
    }
}
