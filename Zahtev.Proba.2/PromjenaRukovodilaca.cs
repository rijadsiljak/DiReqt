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
    public partial class PromjenaRukovodilaca : Form
    {
        public PromjenaRukovodilaca()
        {
            InitializeComponent();
        }
        string username = "";
        string idbroj = "";
        string id1 = "";
        string id2 = "";
        string id3 = "";
        string id4 = "";
        string id5 = "";
        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ,mjeist;

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        string jez = "";


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
                mOdgOs = " Odgovorna osoba za odjel ";
                mjeist = " je ";
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
                mOdgOs = " Die Verantwortliche Person für die Abteilung";
                    mjeist=" ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }





        private void PromjenaRukovodilaca_Load(object sender, EventArgs e)
        {



            username = Korisnik.korisnicko;

            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");


            jez = Korisnik.Jezik;
            prjez();








            string query2 = "select [idbroj] from Korisnici where [username]=@usr ";




            SqlCommand command12 = new SqlCommand(query2, connection2);
            connection2.Open();
            command12.Parameters.AddWithValue("@usr", username);


            SqlDataReader reader12 = command12.ExecuteReader();


            if (reader12.Read())
            {



                idbroj = (reader12["idbroj"].ToString());
                connection2.Close();
            }

            else
            {
                connection2.Close();
                reader12.Close();
            }



            string query5 = "SELECT [odjel1],[odjel2],[odjel3],[odjel4],[odjel5] FROM odobravanje WHERE [idbroj] = @id ";



            SqlCommand command5 = new SqlCommand(query5, connection2);
            connection2.Open();

            command5.Parameters.AddWithValue("@id", idbroj);

            SqlDataReader reader5 = command5.ExecuteReader();

            string odjel1 = "";
            string odjel2 = "";
            string odjel3 = "";
            string odjel4 = "";
            string odjel5 = "";

            // MessageBox.Show(iduser);
            if (reader5.Read())
            {



                odjel1 = (reader5["odjel1"].ToString());
                odjel2 = (reader5["odjel2"].ToString());
                odjel3 = (reader5["odjel3"].ToString());
                odjel4 = (reader5["odjel4"].ToString());
                odjel5 = (reader5["odjel5"].ToString());
                reader5.Close();
                connection2.Close();
            }

            else
            {
                reader5.Close();
                connection2.Close();
            }




            label1.Text = odjel1;
            label2.Text = odjel2;
            label3.Text = odjel3;
            label4.Text = odjel4;
            label5.Text = odjel5;

            if (string.IsNullOrEmpty(label2.Text))
            {
                comboBox2.Visible = false;
                button2.Visible = false;
            }
            if (string.IsNullOrEmpty(label3.Text))
            {
                comboBox3.Visible = false;
                button3.Visible = false;
            }
            if (string.IsNullOrEmpty(label4.Text))
            {
                comboBox4.Visible = false;
                button4.Visible = false;

            }
            if (string.IsNullOrEmpty(label5.Text))
            {
                comboBox5.Visible = false;
                button5.Visible = false;
            }


            string querymt = "SELECT [ime] + ' ' + [prezime] as imeprezime  FROM odobravanje WHERE odjel1=@lbl or odjel2=@lbl or odjel3=@lbl or odjel4=@lbl or odjel5=@lbl ";




            SqlCommand sifre = new SqlCommand(querymt, connection2);
            connection2.Open();
            sifre.Parameters.AddWithValue("@lbl", label1.Text);

            SqlDataReader mtsif = sifre.ExecuteReader();

            while (mtsif.Read())
            {
                comboBox1.Items.Add(mtsif[0]);
                
            }



            mtsif.Close();
            connection2.Close();



            string querymt2 = "SELECT [ime] + ' ' + [prezime] as imeprezime FROM odobravanje WHERE odjel1=@lbl or odjel2=@lbl or odjel3=@lbl or odjel4=@lbl or odjel5=@lbl  ";




            SqlCommand sifre2 = new SqlCommand(querymt2, connection2);
            connection2.Open();
            sifre2.Parameters.AddWithValue("@lbl", label2.Text);

            SqlDataReader mtsif2 = sifre2.ExecuteReader();

            while (mtsif2.Read())
            {
                comboBox2.Items.Add(mtsif2[0]);
                
            }



            mtsif2.Close();
            connection2.Close();



            string querymt3 = "SELECT [ime] + ' ' + [prezime] as imeprezime,[idbroj]  FROM odobravanje WHERE odjel3=@lbl  ";




            SqlCommand sifre3 = new SqlCommand(querymt3, connection2);
            connection2.Open();
            sifre3.Parameters.AddWithValue("@lbl", label3.Text);

            SqlDataReader mtsif3 = sifre3.ExecuteReader();

            while (mtsif3.Read())
            {
                comboBox3.Items.Add(mtsif3[0]);
                id3 = (mtsif3["idbroj"].ToString());
            }



            mtsif3.Close();
            connection2.Close();


            string querymt4 = "SELECT [ime] + ' ' + [prezime] as imeprezime,[idbroj]  FROM odobravanje WHERE odjel4=@lbl  ";




            SqlCommand sifre4 = new SqlCommand(querymt4, connection2);
            connection2.Open();
            sifre4.Parameters.AddWithValue("@lbl", label4.Text);

            SqlDataReader mtsif4 = sifre4.ExecuteReader();

            while (mtsif4.Read())
            {
                comboBox4.Items.Add(mtsif4[0]);
                id4 = (mtsif4["idbroj"].ToString());
            }



            mtsif4.Close();
            connection2.Close();



            string querymt5 = "SELECT [ime] + ' ' + [prezime] as imeprezime,[idbroj]  FROM odobravanje WHERE odjel5=@lbl  ";




            SqlCommand sifre5 = new SqlCommand(querymt5, connection2);
            connection2.Open();
            sifre5.Parameters.AddWithValue("@lbl", label5.Text);

            SqlDataReader mtsif5 = sifre5.ExecuteReader();

            while (mtsif5.Read())
            {
                comboBox5.Items.Add(mtsif5[0]);
                id5 = (mtsif5["idbroj"].ToString());

            }



            mtsif5.Close();
            connection2.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            string qid = "SELECT [idbroj] FROM odobravanje WHERE [ime] + ' ' + [prezime]=@lbl  ";


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
         


            
            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);




                podobri.Parameters.AddWithValue("@konid", label1.Text);





                podobri.Parameters.AddWithValue("@st", id1);


                con.Open();
                podobri.ExecuteNonQuery();

                //mOdgOs
                MessageBox.Show(mOdgOs+ label1.Text + mjeist + comboBox1.Text);


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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            string qid = "SELECT [idbroj] FROM odobravanje WHERE [ime] + ' ' + [prezime]=@lbl  ";


            SqlCommand ids = new SqlCommand(qid, con);
            con.Open();
            ids.Parameters.AddWithValue("@lbl", comboBox2.Text);

            SqlDataReader idz = ids.ExecuteReader();

            if (idz.Read())
            {

                id2 = (idz["idbroj"].ToString());

            }



            idz.Close();
            con.Close();




            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);




                podobri.Parameters.AddWithValue("@konid", label2.Text);





                podobri.Parameters.AddWithValue("@st", id2);


                con.Open();
                podobri.ExecuteNonQuery();

                MessageBox.Show(mOdgOs + label2.Text + mjeist+ comboBox2.Text);


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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            string qid = "SELECT [idbroj] FROM odobravanje WHERE [ime] + ' ' + [prezime]=@lbl  ";


            SqlCommand ids = new SqlCommand(qid, con);
            con.Open();
            ids.Parameters.AddWithValue("@lbl", comboBox3.Text);

            SqlDataReader idz = ids.ExecuteReader();

            if (idz.Read())
            {

                id3 = (idz["idbroj"].ToString());

            }



            idz.Close();
            con.Close();




            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);




                podobri.Parameters.AddWithValue("@konid", label3.Text);





                podobri.Parameters.AddWithValue("@st", id3);


                con.Open();
                podobri.ExecuteNonQuery();
                MessageBox.Show(mOdgOs + label3.Text + mjeist + comboBox3.Text);


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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetConnection();

            string qid = "SELECT [idbroj] FROM odobravanje WHERE [ime] + ' ' + [prezime]=@lbl  ";


            SqlCommand ids = new SqlCommand(qid, con);
            con.Open();
            ids.Parameters.AddWithValue("@lbl", comboBox4.Text);

            SqlDataReader idz = ids.ExecuteReader();

            if (idz.Read())
            {

                id4 = (idz["idbroj"].ToString());

            }



            idz.Close();
            con.Close();




            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);




                podobri.Parameters.AddWithValue("@konid", label4.Text);





                podobri.Parameters.AddWithValue("@st", id4);


                con.Open();
                podobri.ExecuteNonQuery();
                MessageBox.Show(mOdgOs + label4.Text + mjeist + comboBox4.Text);


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

        private void button5_Click(object sender, EventArgs e)
        {




            SqlConnection con = GetConnection();

            string qid = "SELECT [idbroj] FROM odobravanje WHERE [ime] + ' ' + [prezime]=@lbl  ";


            SqlCommand ids = new SqlCommand(qid, con);
            con.Open();
            ids.Parameters.AddWithValue("@lbl", comboBox5.Text);

            SqlDataReader idz = ids.ExecuteReader();

            if (idz.Read())
            {

                id5 = (idz["idbroj"].ToString());

            }



            idz.Close();
            con.Close();




            try
            {
                SqlCommand podobri = new SqlCommand("Update [Odjeli] set [idbroj]=@st where odjel=@konid", con);




                podobri.Parameters.AddWithValue("@konid", label5.Text);





                podobri.Parameters.AddWithValue("@st", id5);


                con.Open();
                podobri.ExecuteNonQuery();
                MessageBox.Show(mOdgOs + label5.Text + mjeist + comboBox5.Text);


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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}