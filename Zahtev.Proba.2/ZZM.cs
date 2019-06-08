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


    public partial class ZZM : Form
    {

        
        public ZZM()
        {
            InitializeComponent();
          // button1.Visible = false;
        }

        PDF pdf;
        string sif1 = "";
        string sif2 = "";
        string sif3 = "";
        string sif4 = "";
        string insertID = "";





        string mMail, mNPIS, mNPMT, mNPKol, mNPNM, mNPTP, mZahSp, mZahPP, mZahK, mZahOdo, mZahOdb, mNBr, mSID, mSPod, mZBr, mZS, mZC, mNoZah, mNO, mA, mNA, mahSp, mTNO, mNOo, mZO, mCu, mCuTo, mZNO, mZav;
        string mZnU, mCnU, mZOt, mCNU, mOKnu, mZoZ, mZTOpm, mKZS, mKZSK, mZTPOD, mKZPKD, mKiCI, mZSpa, mOdo, mOdb, mZPrint, mPPMail, mOdgOs, mUsPro, mSnJ;













        


        //
        //Parametri potrebni za pomjeranje forme
        //
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;



        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        //
        //Pomoćna funkcija za postavljanje Dodatnih polja ispod prvog reda 
        private void PlaceCorrectly(TableLayoutPanel tblP, TableLayoutPanel panel)
        {
            panel.Location = new System.Drawing.Point(tblP.Location.X, tblP.Location.Y + tblP.Size.Height);
        }
        //
        //Klik na button Zahtjev za materijalom otvara tab Zahtjev za materijalom
        //
        private void btnZahtjevMaterijal_Click(object sender, EventArgs e)
        {
            tbControlZahtjevZaMaterijalom.SelectTab(0);
        }

        //
        //Klik na button Modifikacija zahtjeva otvara tab Modifikacija zahtjeva
        //
        private void btnModifikacijaZahtjeva_Click(object sender, EventArgs e)
        {
            tbControlZahtjevZaMaterijalom.SelectTab(1);
        }

        //
        //Klik na button Pregled zahtjeva otvara tab Pregled zahtjeva
        //
        private void btnPregledZahtjeva_Click(object sender, EventArgs e)
        {
            tbControlZahtjevZaMaterijalom.SelectTab(2);
        }

        //
        //Klik na button Pretraga zahtjeva otvara tab Pretraga zahtjeva
        //
        private void btnPretragaZahtjeva_Click(object sender, EventArgs e)
        {
            tbControlZahtjevZaMaterijalom.SelectTab(3);
        }

        //
        //Funkcija za resize prvog textboxa Naziva materijala na Modifikaciji
        //
        private void txtNazivMaterijalaEdit1_TextChanged(object sender, EventArgs e)
        {
            AutoSizeTextBox(sender as TextBox);
        }

        //
        //Klik na Direqt logo vraća na main
        //
        private void DireqtLogoZahtjevZaMaterijalom_Click(object sender, EventArgs e)
        {
            MainProgram mainForm = new MainProgram();
            mainForm.Show();
            Visible = false;
        }

        private void txtTehnickaPriprema_TextChanged(object sender, EventArgs e)
        {

        }


        //
        //Minimize button
        //
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Pomoćna funkcija za resize textboxa
        //
        private void AutoSizeTextBox(TextBox txt)
        {
         /*   const int x_margin = 0;
            const int y_margin = 2;
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.ClientSize = new Size(size.Width + x_margin, size.Height + y_margin);*/
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

        private void txtNazivMaterijala1_TextChanged(object sender, EventArgs e)
        {
            AutoSizeTextBox(sender as TextBox);
            PlaceCorrectly(tblPanelPocetniNovi, tblPanelDodatnaPolja);
            tblPanelMinMaxDrugi.Location = new System.Drawing.Point(tblPanelDodatnaPolja.Location.X + tblPanelDodatnaPolja.Size.Width, tblPanelDodatnaPolja.Location.Y);
        }

        string jez = "";

    



        private void button1_Click(object sender, EventArgs e)
        {



            button2.Visible = true;






            PDF p = new PDF();
            p.id = insertID;

            string broj = insertID;




            bool result;
            result = PDFC.Create_PDF(broj);


            string izvor = "";


            string ime = "";
            string datum = "";
            string ident = "";


            string query3 = "SELECT [podnositelj],[datum],[id] FROM DiReqt WHERE [id] = @id ";

            SqlConnection con = GetConnection();

            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", insertID);

            SqlDataReader reader123 = command123.ExecuteReader();



            if (reader123.Read())
            {


                ime = (reader123["podnositelj"].ToString());
                datum = (reader123["datum"].ToString());
                ident = (reader123["id"].ToString());

                reader123.Close();
                con.Close();

            }

            else
            {
                reader123.Close();
                con.Close();
            }



            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";









            // button1.Visible = false;
            /*
            
            PdfPTable infotable = new PdfPTable(6);
            infotable.TotalWidth = 700f;
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 14, 0, Color.BLACK);
            PdfPCell ppolje = new PdfPCell(new Phrase(" ", new Font(fntColumnHeader)));
            ppolje.HorizontalAlignment = 1;
            ppolje.VerticalAlignment = Element.ALIGN_MIDDLE;
            ppolje.Border = 0;
            Font fnt1ColumnHeader = new Font(btnColumnHeader, 16, 1, Color.BLACK);
            Font fnt2ColumnHeader = new Font(btnColumnHeader, 10, 0, Color.BLACK);
            Font fnt4ColumnHeader = new Font(btnColumnHeader, 15, 0, Color.BLACK);
            Font fnt3ColumnHeader = new Font(btnColumnHeader, 24, 0, Color.RED);
            float[] columnWidths = new float[] { 15f, 10f, 15f, 10f, 50f, 12f };
            infotable.HorizontalAlignment = 1;
            infotable.SetWidths(columnWidths);



            infotable.AddCell(ppolje);
            infotable.AddCell(ppolje);
            infotable.AddCell(ppolje);
            infotable.AddCell(ppolje);
            infotable.AddCell(ppolje);
            infotable.AddCell(ppolje);
           


            PdfPCell bwa = new PdfPCell(new Phrase("BWA", new Font(fnt2ColumnHeader)));
            bwa.HorizontalAlignment = 0;
            bwa.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(bwa);

            PdfPCell dtm = new PdfPCell(new Phrase("Datum", new Font(fnt2ColumnHeader)));
            dtm.HorizontalAlignment = 1;
            dtm.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dtm);

            PdfPCell tep = new PdfPCell(new Phrase("Teh. priprema \nTech. Vorbereitung", new Font(fnt2ColumnHeader)));
            tep.HorizontalAlignment = 1;
            tep.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(tep);

            PdfPCell sifra = new PdfPCell(new Phrase("Šifra \nMT/Kst", new Font(fnt2ColumnHeader)));
            sifra.HorizontalAlignment = 1;
            sifra.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(sifra);

            PdfPCell nmj = new PdfPCell(new Phrase("Naziv mj. troška" + "\n Kostenstellenbezeichung", new Font(fnt2ColumnHeader)));
            nmj.HorizontalAlignment = 1;
            nmj.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(nmj);

            PdfPCell dtm2 = new PdfPCell(new Phrase("Datum", new Font(fnt2ColumnHeader)));
            dtm2.HorizontalAlignment = 1;
            dtm2.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dtm2);

            
            //
            //infotable.AddCell(DateTime.Now.ToShortDateString());
            PdfPCell poz = new PdfPCell(new Phrase("Poz.", new Font(fnt2ColumnHeader)));

            poz.HorizontalAlignment = 0;
            poz.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(poz);
            PdfPCell dat = new PdfPCell(new Phrase(/*DateTime.Now.ToShortDateString()/" ", new Font(fnt2ColumnHeader )));

            dat.HorizontalAlignment = 1;
            dat.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dat);
            infotable.AddCell(" ");







            ////////////////////////////////////////////////////////////////////////////////////
            ///
/*
            if (comboBox16.Text == "Uprava")
            {

                textBox44.Text = " 10 ";

            }
            else if (comboBox16.Text == "Rukovodilac finansija")

            {
                textBox44.Text = " 100 ";
            }
            else if (comboBox16.Text == "Finansije i računovodstvo")

            {
                textBox44.Text = " 110 ";
            }
            else if (comboBox16.Text == "Kontroling")

            {
                textBox44.Text = " 120 ";

            }
            else if (comboBox16.Text == "Personalno i pravno")

            {
                textBox44.Text = " 130 ";

            }
            else if (comboBox16.Text == "IT sistemi")

            {
                textBox44.Text = " 150 ";
            }
            else if (comboBox16.Text == "Nabavka")

            {
                textBox44.Text = " 180 ";
            }
            else if (comboBox16.Text == "Prodaja")

            {
                textBox44.Text = " 190 ";
            }
            else if (comboBox16.Text == "Vođa proizvodnje")

            {
                textBox44.Text = " 200 ";
            }
            else if (comboBox16.Text == "Proizvodnja režija - Paleta")

            {
                textBox44.Text = " 205 ";
            }
            else if (comboBox16.Text == "Proizvodnja režija - Komponente")

            {
                textBox44.Text = " 210 ";
            }
            else if (comboBox16.Text == "PQ 24")

            {
                textBox44.Text = " 222 ";
            }
            else if (comboBox16.Text == "PQ 34")

            {
                textBox44.Text = " 224 ";
            }
            else if (comboBox16.Text == "MQB")

            {
                textBox44.Text = " 225 ";
            }
            else if (comboBox16.Text == "MQB A0")

            {
                textBox44.Text = " 247 ";
            }
            else if (comboBox16.Text == "Ozubljeni vijenac 055")

            {
                textBox44.Text = " 231 ";
            }
            else if (comboBox16.Text == "Ozubljeni vijenac 03CA")

            {
                textBox44.Text = " 233 ";
            }
            else if (comboBox16.Text == "Ozubljeni vijenac 037A")

            {
                textBox44.Text = " 234 ";
            }
            else if (comboBox16.Text == "Glavčina točka 1S0")

            {
                textBox44.Text = " 242 ";
            }
            else if (comboBox16.Text == "Prirubnica točka")

            {
                textBox44.Text = " 245 "; ;
            }
            else if (comboBox16.Text == "Prirubnica točka 7P0 7L0")

            {
                textBox44.Text = " 246 ";
            }
            else if (comboBox16.Text == "Usisna grana")

            {
                textBox44.Text = " 252 ";


            }
            else if (comboBox16.Text == "Lakirnica")

            {
                textBox44.Text = " 265 ";
            }
            else if (comboBox16.Text == "Paleta")

            {
                textBox44.Text = " 268 ";
            }
            else if (comboBox16.Text == "Održavanje - centralno")

            {
                textBox44.Text = " 270 ";

            }
            else if (comboBox16.Text == "Održavanje")

            {
                textBox44.Text = " 271 ";
            }
            else if (comboBox16.Text == "KVP tim")

            {
                textBox44.Text = " 273 ";
            }
            else if (comboBox16.Text == "Logistika - centralna")

            {
                textBox44.Text = " 300 "; ;
            }
            else if (comboBox16.Text == "Špedicija")

            {
                textBox44.Text = " 310 ";
            }
            else if (comboBox16.Text == "Reklamacije")

            {
                textBox44.Text = " 320 ";
            }
            else if (comboBox16.Text == "Operativna logistika")

            {
                textBox44.Text = " 350 ";
            }
            else if (comboBox16.Text == "Osiguranje kvaliteta - centralno")

            {
                textBox44.Text = " 400 ";
            }
            else if (comboBox16.Text == "Operativno osiguranje kvaliteta")

            {
                textBox44.Text = " 450 ";
            }
            else if (comboBox16.Text == "Planiranje - centralno")

            {
                textBox44.Text = " 500 ";
            }
            else if (comboBox16.Text == "Zaštita okoliša i zaštita na radu")

            {
                textBox44.Text = " 520 ";
            }
            else if (comboBox16.Text == "Operativno planiranje")

            {
                textBox44.Text = " 550 ";
            }
            else if (comboBox16.Text == "Svi programi")
            {
                textBox44.Text = " ";

            }
            else
            {
                textBox44.Text = " ";

            }

            ///////////////////////////////////////////////////////////////////////


            if (comboBox17.Text == "Uprava")
            {

                textBox45.Text = " 10 ";

            }
            else if (comboBox17.Text == "Rukovodilac finansija")

            {
                textBox45.Text = " 100 ";
            }
            else if (comboBox17.Text == "Finansije i računovodstvo")

            {
                textBox45.Text = " 110 ";
            }
            else if (comboBox17.Text == "Kontroling")

            {
                textBox45.Text = " 120 ";

            }
            else if (comboBox17.Text == "Personalno i pravno")

            {
                textBox45.Text = " 130 ";

            }
            else if (comboBox17.Text == "IT sistemi")

            {
                textBox45.Text = " 150 ";
            }
            else if (comboBox17.Text == "Nabavka")

            {
                textBox45.Text = " 180 ";
            }
            else if (comboBox17.Text == "Prodaja")

            {
                textBox45.Text = " 190 ";
            }
            else if (comboBox17.Text == "Vođa proizvodnje")

            {
                textBox45.Text = " 200 ";
            }
            else if (comboBox17.Text == "Proizvodnja režija - Paleta")

            {
                textBox45.Text = " 205 ";
            }
            else if (comboBox17.Text == "Proizvodnja režija - Komponente")

            {
                textBox45.Text = " 210 ";
            }
            else if (comboBox17.Text == "PQ 24")

            {
                textBox45.Text = " 222 ";
            }
            else if (comboBox17.Text == "PQ 34")

            {
                textBox45.Text = " 224 ";
            }
            else if (comboBox17.Text == "MQB")

            {
                textBox45.Text = " 225 ";
            }
            else if (comboBox17.Text == "MQB A0")

            {
                textBox45.Text = " 247 ";
            }
            else if (comboBox17.Text == "Ozubljeni vijenac 055")

            {
                textBox45.Text = " 231 ";
            }
            else if (comboBox17.Text == "Ozubljeni vijenac 03CA")

            {
                textBox45.Text = " 233 ";
            }
            else if (comboBox17.Text == "Ozubljeni vijenac 037A")

            {
                textBox45.Text = " 234 ";
            }
            else if (comboBox17.Text == "Glavčina točka 1S0")

            {
                textBox45.Text = " 242 ";
            }
            else if (comboBox17.Text == "Prirubnica točka")

            {
                textBox45.Text = " 245 "; ;
            }
            else if (comboBox17.Text == "Prirubnica točka 7P0 7L0")

            {
                textBox45.Text = " 246 ";
            }
            else if (comboBox17.Text == "Usisna grana")

            {
                textBox45.Text = " 252 ";


            }
            else if (comboBox17.Text == "Lakirnica")

            {
                textBox45.Text = " 265 ";
            }
            else if (comboBox17.Text == "Paleta")

            {
                textBox45.Text = " 268 ";
            }
            else if (comboBox17.Text == "Održavanje - centralno")

            {
                textBox45.Text = " 270 ";

            }
            else if (comboBox17.Text == "Održavanje")

            {
                textBox45.Text = " 271 ";
            }
            else if (comboBox17.Text == "KVP tim")

            {
                textBox45.Text = " 273 ";
            }
            else if (comboBox17.Text == "Logistika - centralna")

            {
                textBox45.Text = " 300 "; ;
            }
            else if (comboBox17.Text == "Špedicija")

            {
                textBox45.Text = " 310 ";
            }
            else if (comboBox17.Text == "Reklamacije")

            {
                textBox45.Text = " 320 ";
            }
            else if (comboBox17.Text == "Operativna logistika")

            {
                textBox45.Text = " 350 ";
            }
            else if (comboBox17.Text == "Osiguranje kvaliteta - centralno")

            {
                textBox45.Text = " 400 ";
            }
            else if (comboBox17.Text == "Operativno osiguranje kvaliteta")

            {
                textBox45.Text = " 450 ";
            }
            else if (comboBox17.Text == "Planiranje - centralno")

            {
                textBox45.Text = " 500 ";
            }
            else if (comboBox17.Text == "Zaštita okoliša i zaštita na radu")

            {
                textBox45.Text = " 520 ";
            }
            else if (comboBox17.Text == "Operativno planiranje")

            {
                textBox45.Text = " 550 ";
            }

            ///
            else if (comboBox17.Text=="Svi programi")
            {
                textBox45.Text = " ";

            }
            ///
            else
            {
                textBox45.Text = " ";

            }
            

            ///
           
            


            if (comboBox12.Text != "")
            {
                SqlConnection connectionsif1 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string querysif = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 

                SqlCommand csif = new SqlCommand(querysif, connectionsif1);
                connectionsif1.Open();
                csif.Parameters.AddWithValue("@nmt", comboBox12.Text);

                SqlDataReader readersif1 = csif.ExecuteReader();


                if (readersif1.Read())
                {


                    sif1 = (readersif1["sifra_mt"].ToString());
                    readersif1.Close();
                    connectionsif1.Close();
                   
                  
                }

                else
                {
                    readersif1.Close();
                    connectionsif1.Close();
                    return;
                }

            }




            if (comboBox13.Text != "")
            {
                SqlConnection connectionsif2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string querysif2 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";
               
                 
                
                SqlCommand csif2 = new SqlCommand(querysif2, connectionsif2);
                connectionsif2.Open();
                csif2.Parameters.AddWithValue("@nmt", comboBox13.Text);

                SqlDataReader readersif2 = csif2.ExecuteReader();


                if (readersif2.Read())
                {


                    sif2 = (readersif2["sifra_mt"].ToString());
                    readersif2.Close();
                    connectionsif2.Close();


                }

                else
                {
                    readersif2.Close();
                    connectionsif2.Close();
                    return;
                }

            }



            if (comboBox14.Text != "")
            {
                SqlConnection connectionsif3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string querysif3 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 

                SqlCommand csif3 = new SqlCommand(querysif3, connectionsif3);
                connectionsif3.Open();
                csif3.Parameters.AddWithValue("@nmt", comboBox14.Text);

                SqlDataReader readersif3 = csif3.ExecuteReader();


                if (readersif3.Read())
                {


                    sif3 = (readersif3["sifra_mt"].ToString());
                    readersif3.Close();
                    connectionsif3.Close();


                }

                else
                {

                    return;
                  
                  
                }

            }



            if (comboBox15.Text != "")
            {
                SqlConnection connectionsif4 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                string querysif4 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 

                SqlCommand csif4 = new SqlCommand(querysif4, connectionsif4);
                connectionsif4.Open();
                csif4.Parameters.AddWithValue("@nmt", comboBox15.Text);

                SqlDataReader readersif4 = csif4.ExecuteReader();


                if (readersif4.Read())
                {


                    sif4 = (readersif4["sifra_mt"].ToString());
                    readersif4.Close();
                    connectionsif4.Close();


                }

                else
                {

                    return;
                   
                    
                }

            }


            string zz = "";
            string zz2 = "";
            string zz3 = "";


            if (comboBox13.Text != "")
            { zz= ", "; }
            else { }
            if (comboBox14.Text != "")
            {zz2 = ", "; }
            if (comboBox15.Text != "")
            { zz3 = ", "; }

            PdfPCell msif = new PdfPCell(new Phrase(sif1 +zz+ sif2 +zz2 + sif3 +zz3 + sif4  , new Font(fnt2ColumnHeader)));

            msif.HorizontalAlignment = 1;
            msif.VerticalAlignment = Element.ALIGN_MIDDLE;



      


        


            infotable.AddCell(msif);

            PdfPCell mjesto = new PdfPCell(new Phrase(comboBox12.Text +zz + comboBox13.Text + zz2+ comboBox14.Text + zz3 + comboBox15.Text  , new Font(fnt2ColumnHeader)));
            mjesto.HorizontalAlignment = 1;
            mjesto.VerticalAlignment = Element.ALIGN_MIDDLE;


            infotable.AddCell(mjesto);





            //infotable.AddCell(" ");
           // infotable.AddCell(" ");

            PdfPCell dat2 = new PdfPCell(new Phrase(DateTime.Now.ToShortDateString(), new Font(fnt2ColumnHeader)));
            dat2.HorizontalAlignment = 1;
            infotable.AddCell(dat2);

            infotable.LockedWidth = true;


            PdfPTable table = new PdfPTable(6);
            table.TotalWidth = 700f;

            float[] columnWidthts = new float[] { 10f, 30f, 5f, 10f, 10f, 10f };
            table.SetWidths(columnWidthts);
            table.LockedWidth = true;

            table.AddCell(ppolje);
            table.AddCell(ppolje);
            table.AddCell(ppolje);
            table.AddCell(ppolje);
            table.AddCell(ppolje);
            table.AddCell(ppolje);



            PdfPCell sifra1 = new PdfPCell(new Phrase("Ident šifra \nIdent Nr", new Font(fnt2ColumnHeader)));
            sifra1.HorizontalAlignment = 1;
            sifra1.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(sifra1);

            // table.AddCell("Naziv materijala");
            PdfPCell nmat = new PdfPCell(new Phrase("Naziv materijala" + "\nMaterialbeschreibung", new Font(fnt2ColumnHeader)));
            nmat.HorizontalAlignment = 1;
            nmat.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell npon = new PdfPCell(new Phrase("Naziv ponude" + "\n", new Font(fnt2ColumnHeader)));
            npon.HorizontalAlignment = 1;
            npon.VerticalAlignment = Element.ALIGN_MIDDLE;

          


            //table.AddCell("JM");
            PdfPCell jm = new PdfPCell(new Phrase("JM\nML", new Font(fnt2ColumnHeader)));
            jm.HorizontalAlignment = 1;
            jm.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(jm);

            //table.AddCell("Količina");
           PdfPCell koli = new PdfPCell(new Phrase("Količina \nMenge", new Font(fnt2ColumnHeader)));
            koli.HorizontalAlignment = 1;
            koli.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(koli);

            //table.AddCell("Cijena");
            PdfPCell cijena = new PdfPCell(new Phrase("Cijena/JM" + "\nPreis/ML", new Font(fnt2ColumnHeader)));
            cijena.HorizontalAlignment = 1;
            cijena.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cijena);

            //table.AddCell("Konto");

            PdfPCell konto = new PdfPCell(new Phrase("Ukupna cijena"+"\nSumme", new Font(fnt2ColumnHeader)));
            konto.HorizontalAlignment = 1;
            konto.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(konto);

           
            

            //table.AddCell(this.textBox22.Text.Trim());

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Naziv materijala ne može biti prazan!");
                return;
            }
            else
            {
                PdfPCell is1 = new PdfPCell(new Phrase(this.textBox22.Text.Trim(), new Font(fnt4ColumnHeader)));
                is1.HorizontalAlignment = 1;
                is1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is1);
                PdfPCell nm1 = new PdfPCell(new Phrase(this.textBox1.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm1.HorizontalAlignment = 0;
                nm1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm1);

                PdfPCell jm1 = new PdfPCell(new Phrase(this.textBox33.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm1.HorizontalAlignment = 1;
                jm1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm1);

                PdfPCell kol1 = new PdfPCell(new Phrase(this.comboBox1.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol1.HorizontalAlignment = 1;
                kol1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol1);
                table.AddCell(" ");
                table.AddCell(" ");
            }
           

            if (string.IsNullOrEmpty(textBox2.Text))
            { }
            else
            {
                PdfPCell is2 = new PdfPCell(new Phrase(this.textBox21.Text.Trim(), new Font(fnt4ColumnHeader)));
                is2.HorizontalAlignment = 1;
                is2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is2);
                PdfPCell nm2 = new PdfPCell(new Phrase(this.textBox2.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm2.HorizontalAlignment = 0;
                nm2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm2);

                PdfPCell jm2 = new PdfPCell(new Phrase(this.textBox32.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm2.HorizontalAlignment = 1;
                jm2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm2);

                PdfPCell kol2 = new PdfPCell(new Phrase(this.comboBox2.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol2.HorizontalAlignment = 1;
                kol2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol2);

                table.AddCell(" ");
                table.AddCell(" ");
            }

          
            if (string.IsNullOrEmpty(textBox3.Text))
            { }

            else
            {
                PdfPCell is3 = new PdfPCell(new Phrase(this.textBox20.Text.Trim(), new Font(fnt4ColumnHeader)));
                is3.HorizontalAlignment = 1;
                is3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is3);
                PdfPCell nm3 = new PdfPCell(new Phrase(this.textBox3.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm3.HorizontalAlignment = 0;
                nm3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm3);

                PdfPCell jm3 = new PdfPCell(new Phrase(this.textBox31.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm3.HorizontalAlignment = 1;
                jm3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm3);

                PdfPCell kol3 = new PdfPCell(new Phrase(this.comboBox3.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol3.HorizontalAlignment = 1;
                kol3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol3);

                table.AddCell(" ");
                table.AddCell(" ");
            }

          
            if (string.IsNullOrEmpty(textBox4.Text))
            { }
            else
            {
                PdfPCell is4 = new PdfPCell(new Phrase(this.textBox19.Text.Trim(), new Font(fnt4ColumnHeader)));
                is4.HorizontalAlignment = 1;
                is4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is4);

                PdfPCell nm4 = new PdfPCell(new Phrase(this.textBox4.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm4.HorizontalAlignment = 0;
                nm4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm4);

                PdfPCell jm4 = new PdfPCell(new Phrase(this.textBox30.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm4.HorizontalAlignment = 1;
                jm4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm4);

                PdfPCell kol4 = new PdfPCell(new Phrase(this.comboBox4.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol4.HorizontalAlignment = 1;
                kol4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol4);

                table.AddCell(" ");
                table.AddCell(" ");
            }


           
            if (string.IsNullOrEmpty(textBox5.Text))
            { }
            else
            {
                PdfPCell is5 = new PdfPCell(new Phrase(this.textBox18.Text.Trim(), new Font(fnt4ColumnHeader)));
                is5.HorizontalAlignment = 1;
                is5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is5);

                PdfPCell nm5 = new PdfPCell(new Phrase(this.textBox5.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm5.HorizontalAlignment = 0;
                nm5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm5);

                PdfPCell jm5 = new PdfPCell(new Phrase(this.textBox29.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm5.HorizontalAlignment = 1;
                jm5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm5);

                PdfPCell kol5 = new PdfPCell(new Phrase(this.comboBox5.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol5.HorizontalAlignment = 1;
                kol5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol5);

                table.AddCell(" ");
                table.AddCell(" ");
            }
           

            if (string.IsNullOrEmpty(textBox6.Text))
            { }
            else
            {
                PdfPCell is6 = new PdfPCell(new Phrase(this.textBox17.Text.Trim(), new Font(fnt4ColumnHeader)));
                is6.HorizontalAlignment = 1;
                is6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is6);

                PdfPCell nm6 = new PdfPCell(new Phrase(this.textBox6.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm6.HorizontalAlignment = 0;
                nm6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm6);

                PdfPCell jm6 = new PdfPCell(new Phrase(this.textBox28.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm6.HorizontalAlignment = 1;
                jm.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm6);

                PdfPCell kol6 = new PdfPCell(new Phrase(this.comboBox6.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol6.HorizontalAlignment = 1;
                kol6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol6);

                table.AddCell(" ");
                table.AddCell(" ");
            }

          
            if (string.IsNullOrEmpty(textBox7.Text))
            { }
            else
            {

                PdfPCell is7 = new PdfPCell(new Phrase(this.textBox16.Text.Trim(), new Font(fnt4ColumnHeader)));
                is7.HorizontalAlignment = 1;
                is7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is7);

                PdfPCell nm7 = new PdfPCell(new Phrase(this.textBox7.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm7.HorizontalAlignment = 0;
                nm7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm7);

                PdfPCell jm7 = new PdfPCell(new Phrase(this.textBox27.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm7.HorizontalAlignment = 1;
                jm7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm7);

                PdfPCell kol7 = new PdfPCell(new Phrase(this.comboBox7.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol7.HorizontalAlignment = 1;
                kol7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol7);

                table.AddCell(" ");
                table.AddCell(" ");
            }


            if (string.IsNullOrEmpty(textBox8.Text))
            { }
            else
            {
                PdfPCell is8 = new PdfPCell(new Phrase(this.textBox15.Text.Trim(), new Font(fnt4ColumnHeader)));
                is8.HorizontalAlignment = 1;
                is8.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(is8);

                PdfPCell nm8 = new PdfPCell(new Phrase(this.textBox8.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm8.HorizontalAlignment = 0;
                nm8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm8);

                PdfPCell jm8 = new PdfPCell(new Phrase(this.textBox26.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm8.HorizontalAlignment = 1;
                jm8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm8);

                PdfPCell kol8 = new PdfPCell(new Phrase(this.comboBox8.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol8.HorizontalAlignment = 1;
                kol8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol8);

                table.AddCell(" ");
                table.AddCell(" ");
            }
                       

            if (string.IsNullOrEmpty(textBox9.Text))
            { }
            else
            {
                PdfPCell is9 = new PdfPCell(new Phrase(this.textBox14.Text.Trim(), new Font(fnt4ColumnHeader)));
                is9.HorizontalAlignment = 1;
                is9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is9);

                PdfPCell nm9 = new PdfPCell(new Phrase(this.textBox9.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm9.HorizontalAlignment = 0;
                nm9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm9);

                PdfPCell jm9 = new PdfPCell(new Phrase(this.textBox25.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm9.HorizontalAlignment = 1;
                jm9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm9);

                PdfPCell kol9 = new PdfPCell(new Phrase(this.comboBox9.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol9.HorizontalAlignment = 1;
                kol9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol9);

                table.AddCell(" ");
                table.AddCell(" ");
            }

         
            if (string.IsNullOrEmpty(textBox10.Text))
            { }

            else
            {
                PdfPCell is10 = new PdfPCell(new Phrase(this.textBox13.Text.Trim(), new Font(fnt4ColumnHeader)));
                is10.HorizontalAlignment = 1;
                is10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is10);

                PdfPCell nm10 = new PdfPCell(new Phrase(this.textBox10.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm10.HorizontalAlignment = 0;
                nm10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm10);

                PdfPCell jm10 = new PdfPCell(new Phrase(this.textBox24.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm10.HorizontalAlignment = 1;
                jm10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm10);

                PdfPCell kol10 = new PdfPCell(new Phrase(this.comboBox10.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol10.HorizontalAlignment = 1;
                kol10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol10);

                table.AddCell(" ");
                table.AddCell(" "); }

           
            if (string.IsNullOrEmpty(textBox11.Text))
            { }
            else
            {
                PdfPCell is11 = new PdfPCell(new Phrase(this.textBox12.Text.Trim(), new Font(fnt4ColumnHeader)));
                is11.HorizontalAlignment = 1;
                is11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is11);

                PdfPCell nm11 = new PdfPCell(new Phrase(this.textBox11.Text.Trim(), new Font(fnt4ColumnHeader)));
                nm11.HorizontalAlignment = 0;
                nm11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm11);

                PdfPCell jm11 = new PdfPCell(new Phrase(this.textBox23.Text.Trim(), new Font(fnt4ColumnHeader)));
                jm11.HorizontalAlignment = 1;
                jm11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm11);

                PdfPCell kol11 = new PdfPCell(new Phrase(this.comboBox11.Text.Trim(), new Font(fnt4ColumnHeader)));
                kol11.HorizontalAlignment = 1;
                kol11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol11);

                table.AddCell(" ");
                table.AddCell(" ");
            }
            PdfPCell kcij = new PdfPCell(new Phrase(" "));

            kcij.Colspan = 4;
            table.AddCell(kcij);


            PdfPCell kona = new PdfPCell(new Phrase("TOTAL: ", fnt4ColumnHeader));
            kona.HorizontalAlignment = 0;
            kona.VerticalAlignment = Element.ALIGN_MIDDLE;
            kona.Colspan = 2;
            table.AddCell(kona);
          //  table.AddCell(" ");

            PdfPTable dtable = new PdfPTable(8);
            dtable.TotalWidth = 700f;
            //table.DefaultCell.Phrase = new Phrase(font = Arial);  

            float[] dcolumnWidth = new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f };
            dtable.SetWidths(dcolumnWidth);
            dtable.HorizontalAlignment = 1;
            dtable.LockedWidth = true;


            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            dtable.AddCell(ppolje);
            PdfPCell izd = new PdfPCell(new Phrase("Izdao \nErsteller ", fnt2ColumnHeader));
            izd.HorizontalAlignment = 1;
            izd.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(izd);
            PdfPCell odb = new PdfPCell(new Phrase("Odobrio \nBefürwortet ", fnt2ColumnHeader));
            odb.HorizontalAlignment = 1;
            odb.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(odb);
            PdfPCell einkauf = new PdfPCell(new Phrase("Nabavka \nEinkauf ", fnt2ColumnHeader));
            einkauf.HorizontalAlignment = 1;
            einkauf.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(einkauf);
            PdfPCell date = new PdfPCell(new Phrase("Datum ", fnt2ColumnHeader));
            date.HorizontalAlignment = 1;
            date.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(date);
            PdfPCell cntrl = new PdfPCell(new Phrase("Controlling", fnt2ColumnHeader));
            cntrl.HorizontalAlignment = 1;
            cntrl.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(cntrl);
            PdfPCell datum = new PdfPCell(new Phrase("Datum ", fnt2ColumnHeader));
            datum.HorizontalAlignment = 1;
            datum.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(date);
            PdfPCell ovjerio = new PdfPCell(new Phrase("Ovjerio \nGenehmigt", fnt2ColumnHeader));
            ovjerio.Colspan = 2;
            ovjerio.HorizontalAlignment = 1;
            ovjerio.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(ovjerio);

            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");
            dtable.AddCell(" \n ");

            // dtable.AddCell("Sklad");
            PdfPCell sklad = new PdfPCell(new Phrase("Sklad-Lager\n", fnt2ColumnHeader));
            sklad.HorizontalAlignment = 0;
            sklad.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(sklad);

            PdfPCell sklad1 = new PdfPCell(new Phrase(textBox57.Text, fnt4ColumnHeader));
            sklad1.HorizontalAlignment = 1;
            sklad1.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(sklad1);
           
            PdfPCell prazno = new PdfPCell(new Phrase("  "));
            prazno.Colspan = 6;
            dtable.AddCell(prazno);

            PdfPCell napomena = new PdfPCell(new Phrase("Napomena-Bemerkung :\n ", fnt2ColumnHeader));

            napomena.HorizontalAlignment = 0;
            napomena.VerticalAlignment = Element.ALIGN_MIDDLE;

            dtable.AddCell(napomena);

            PdfPCell napomena1 = new PdfPCell(new Phrase(textBox58.Text, fnt4ColumnHeader));

            napomena1.Colspan = 7;
            napomena1.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(napomena1);

        
            PdfPTable idtable = new PdfPTable(6);
            idtable.TotalWidth = 700f;
            idtable.HorizontalAlignment = Element.ALIGN_CENTER;
            
            float[] idcolumnWidthts = new float[] { 20f,20f,20f,20f,20f,20f };
            idtable.SetWidths(idcolumnWidthts);
            idtable.LockedWidth = true;

            PdfPCell zahpo = new PdfPCell(new Phrase("Zahtjev podnosi: ", new Font(fntColumnHeader)));
            zahpo.HorizontalAlignment = 2;
            zahpo.Border = 0;
            idtable.AddCell(zahpo);
            PdfPCell zahpo2 = new PdfPCell(new Phrase(this.lblIme.Text.Trim(),new Font (fntColumnHeader)));
            zahpo2.HorizontalAlignment = 1;
            idtable.AddCell(zahpo2);
            
                PdfPCell zahm = new PdfPCell(new Phrase("Zahtjev za materijalom", new Font(fnt1ColumnHeader)));
                zahm.HorizontalAlignment = 1;
                zahm.Border = 0;
                zahm.Colspan = 2;
                idtable.AddCell(zahm);
            
           /* else if (radioButton2.Checked == true)
            {
                PdfPCell zahp = new PdfPCell(new Phrase("Zahtjev za ponudom", new Font(fnt1ColumnHeader)));
                zahp.HorizontalAlignment = 1;
                zahp.Border = 0;
                zahp.Colspan = 2;
                idtable.AddCell(zahp);
            }
            

            PdfPCell idbroj = new PdfPCell(new Phrase("No: ", new Font(fnt4ColumnHeader)));
            idbroj.HorizontalAlignment = 2;
            idbroj.Border = 0;
            idtable.AddCell(idbroj);


            PdfPCell idbroj2 = new PdfPCell(new Phrase(insertID, new Font(fnt4ColumnHeader)));
            idbroj2.HorizontalAlignment = 1;
            idtable.AddCell(idbroj2);
            PdfPCell blank = new PdfPCell(new Phrase(" ", new Font(fnt1ColumnHeader)));
            blank.HorizontalAlignment = 1;
            blank.Border = 0;
            blank.Colspan = 6;
            idtable.AddCell(blank);



            PdfPTable mimax = new PdfPTable(3);
            mimax.TotalWidth = 700f;
            PdfPCell misif = new PdfPCell(new Phrase(this.textBox22.Text, new Font(fntColumnHeader)));
            misif.HorizontalAlignment = 1;
            misif.VerticalAlignment = Element.ALIGN_MIDDLE;
            // mimax.AddCell(misif);
            PdfPCell misif1 = new PdfPCell(new Phrase(this.textBox21.Text, new Font(fntColumnHeader)));
            misif1.HorizontalAlignment = 1;
            misif1.VerticalAlignment = Element.ALIGN_MIDDLE;
            //   mimax.AddCell(misif1);
            PdfPCell misif2 = new PdfPCell(new Phrase(this.textBox20.Text, new Font(fntColumnHeader)));
            misif2.HorizontalAlignment = 1;
            misif2.VerticalAlignment = Element.ALIGN_MIDDLE;
            //  mimax.AddCell(misif2);


            //  mimax.AddCell(misif2);
            mimax.AddCell(ppolje);
            mimax.AddCell(ppolje);
            mimax.AddCell(ppolje);

            PdfPCell mimax1 = new PdfPCell(new Phrase("MIN: "+this.textBox37.Text+" "+this.textBox33.Text+"\nMAX: "+this.textBox38.Text+" "+this.textBox33.Text+"\nSTANJE: "+this.textBox39.Text+" "+this.textBox33.Text  , new Font(fntColumnHeader)));
            mimax1.HorizontalAlignment = 1;
            mimax1.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (this.textBox37.Text != "" && this.textBox51.Text == "" && this.textBox54.Text=="")
            {
                //mimax1.Border = 0;
                //  mimax1.Colspan = 3;
                //  mimax1.HorizontalAlignment = 0;
                mimax.AddCell(ppolje);
                mimax.AddCell(misif);
                mimax.AddCell(ppolje);
                mimax.AddCell(ppolje);
                mimax.AddCell(mimax1);
                
                mimax.AddCell(ppolje);

            }
            PdfPCell mimax2 = new PdfPCell(new Phrase("MIN: " + this.textBox51.Text + " " + this.textBox32.Text + "\nMAX: " + this.textBox52.Text + " " +this.textBox32.Text+ "\nSTANJE: " + this.textBox53.Text + " " + this.textBox32.Text, new Font(fntColumnHeader)));
            mimax2.HorizontalAlignment = 1;
            mimax2.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (this.textBox37.Text!="" && this.textBox54.Text == "" && this.textBox51.Text!="")
            {
                mimax.AddCell(misif);
                mimax.AddCell(misif1);
                mimax.AddCell(ppolje);
                mimax.AddCell(mimax1);
                mimax.AddCell(mimax2);
                mimax.AddCell(ppolje);
            }

            // mimax.AddCell(mimax2);
            // mimax.AddCell(mimax3);

            if (this.textBox37.Text != "" && this.textBox54.Text != "" && this.textBox51.Text != "")
            {
                PdfPCell mimax3 = new PdfPCell(new Phrase("MIN: " + this.textBox54.Text + " " + this.textBox31.Text + "\nMAX: " + this.textBox55.Text + " " + this.textBox31.Text + "\nSTANJE: " + this.textBox56.Text + " " + this.textBox31.Text, new Font(fntColumnHeader)));
                mimax3.HorizontalAlignment = 1;
                mimax3.VerticalAlignment = Element.ALIGN_MIDDLE;
                mimax.AddCell(misif);
                mimax.AddCell(misif1);
                mimax.AddCell(misif2);
                mimax.AddCell(mimax1);
                mimax.AddCell(mimax2);
                mimax.AddCell(mimax3);
            }




            PdfPTable stokhitno = new PdfPTable(6);
            stokhitno.TotalWidth = 700f;
            stokhitno.HorizontalAlignment = Element.ALIGN_CENTER;
           

            float[] shWidthts = new float[] { 20f, 20f, 20f, 20f, 20f, 20f };
            stokhitno.SetWidths(shWidthts);
            stokhitno.LockedWidth = true;
            PdfPCell stok = new PdfPCell(new Phrase(" ŠTOK ", new Font(fnt3ColumnHeader)));
            stok.HorizontalAlignment = 1;
            stok.VerticalAlignment = Element.ALIGN_MIDDLE;
            stok.Border = 0;
            stok.Colspan = 2;

            PdfPCell hitno = new PdfPCell(new Phrase(" HITNO! ", new Font(fnt3ColumnHeader)));
            hitno.HorizontalAlignment = 2;
            hitno.VerticalAlignment = Element.ALIGN_MIDDLE;
            hitno.Border = 0;
            hitno.Colspan = 2;
            PdfPCell ppolje1 = new PdfPCell(new Phrase(" ", new Font(fnt3ColumnHeader)));
            ppolje1.HorizontalAlignment = 1;
            ppolje.VerticalAlignment = Element.ALIGN_MIDDLE;
            ppolje1.Border = 0;
            ppolje1.Colspan = 2;

           
             if (checkBox2.Checked)
            {
                stokhitno.AddCell(ppolje1);
                stokhitno.AddCell(stok);
                stokhitno.AddCell(ppolje1);
            }
              
            
            else
            {

            }
            
     

            string folderPath = @"C:\Users\Public\Documents\ZZM\";
            
             if (!Directory.Exists(folderPath))
             {
                 Directory.CreateDirectory(folderPath);
             }

            Paragraph razmak = new Paragraph();
            razmak.Alignment = Element.ALIGN_CENTER;

                 


            
            razmak.Add(new Chunk("\n "));


            using (FileStream stream = new FileStream(folderPath + " " + this.lblIme.Text.Trim()+" " + DateTime.Now.ToShortDateString() + " No. " + insertID + ".pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4.Rotate());
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

               // pdfDoc.Add(prgAuthor);

                pdfDoc.Add(idtable);


                /*
                                if (checkBox2.Checked)
                                {
                                    pdfDoc.Add(stok);
                                }
                               if(checkBox5.Checked)
                                {
                                    pdfDoc.Add(hitno);
                                }
                pdfDoc.Add(stokhitno);
                pdfDoc.Add(infotable);
                //pdfDoc.Add(razmak);
                pdfDoc.Add(table);
               // pdfDoc.Add(razmak);
                pdfDoc.Add(dtable);

                if (checkBox2.Checked==true)
                {
                    pdfDoc.Add(mimax);
                }
                
            
                pdfDoc.Close();
                stream.Close();

            }

// Excel
/*
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

           
            string t1 = "Ident Šifra";
            
             string t2 = "Naziv "; 
           
           
           
           
            string t3 = "JM";
            string t4 = "Količina";
            string t5 = "Broj zahtjeva: "+ textBox35.Text;
            string t6 =  DateTime.Now.ToShortDateString();

            string tb1 = "'"+textBox22.Text.Trim();
            string tb2 = textBox1.Text;
            string tb3 = textBox33.Text;
            string tb4 = comboBox1.Text;

            string tb5 = "'" + textBox21.Text;
            string tb6 = textBox2.Text;
            string tb7 = textBox32.Text;
            string tb8 = comboBox2.Text;

            string tb9 = "'" + textBox20.Text;
            string tb10 = textBox3.Text;
            string tb11 = textBox31.Text;
            string tb12 = comboBox3.Text;

            string tb13 = "'" + textBox19.Text;
            string tb14 = textBox4.Text;
            string tb15 = textBox30.Text;
            string tb16 = comboBox4.Text;

            string tb17 = "'" + textBox18.Text;
            string tb18 = textBox5.Text;
            string tb19 = textBox29.Text;
            string tb20 = comboBox5.Text;

            string tb21 = "'" + textBox17.Text;
            string tb22 = textBox6.Text;
            string tb23 = textBox28.Text;
            string tb24 = comboBox6.Text;

            string tb25 = "'" + textBox16.Text;
            string tb26 = textBox7.Text;
            string tb27 = textBox27.Text;
            string tb28 = comboBox7.Text;

            string tb29 = "'" + textBox15.Text;
            string tb30 = textBox8.Text;
            string tb31 = textBox26.Text;
            string tb32 = comboBox8.Text;

            string tb33 = "'" + textBox14.Text;
            string tb34 = textBox9.Text;
            string tb35 = textBox25.Text;
            string tb36 = comboBox9.Text;

            string tb37 = "'" + textBox13.Text;
            string tb38 = textBox10.Text;
            string tb39 = textBox24.Text;
            string tb40 = comboBox10.Text;

            string tb41 = "'" + textBox12.Text;
            string tb42 = textBox11.Text;
            string tb43 = textBox23.Text;
            string tb44 = comboBox11.Text;

           
             string[] row0 = { t1, t2, t3, t4, t5, t6 };
            
            
             
            


            string[] row = { tb1, tb2, tb3, tb4 };
            string[] row1 = { tb5, tb6, tb7, tb8 };
            string[] row2 = { tb9, tb10, tb11, tb12 };
            string[] row3 = { tb13, tb14, tb15, tb16 };
            string[] row4 = { tb17, tb18, tb19, tb20 };
            string[] row5 = { tb21, tb22, tb23, tb24 };
            string[] row6 = { tb25, tb26, tb27, tb28 };
            string[] row7 = { tb29, tb30, tb31, tb32 };
            string[] row8  = { tb33, tb34, tb35, tb36 };
            string[] row9 = { tb37, tb38, tb39, tb40 };
            string[] row10 = { tb41, tb42, tb43, tb44 };
           
                       

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

            xlWorkBook.SaveAs(@"C:\Users\Public\Documents\ZZM\" +  " " + this.textBox34.Text.Trim()+" " + DateTime.Now.ToShortDateString() + " No. " + textBox35.Text.Trim()+ ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            /*releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);*/

            string q = "SELECT [idbroj] FROM Odjeli WHERE [odjel] = @idbr ";
            string idruk="";


            SqlCommand comn = new SqlCommand(q, con);
            con.Open();

            comn.Parameters.AddWithValue("@idbr", lblOdjel.Text);

            SqlDataReader re = comn.ExecuteReader();



            if (re.Read())
            {


                idruk = (re["idbroj"].ToString());


                re.Close();
                con.Close();

            }

            else
            {
                re.Close();
                con.Close();
            }


            string q2 = "SELECT [email] FROM Korisnici WHERE [idbroj] = @idr ";



            SqlCommand comn2 = new SqlCommand(q2, con);
            con.Open();

            comn2.Parameters.AddWithValue("@idr", idruk);

            SqlDataReader red = comn2.ExecuteReader();


            string em = "";

            if (red.Read())
            {


                em = (red["email"].ToString());


                red.Close();
                con.Close();

            }

            else
            {
                red.Close();
                con.Close();
            }





            //Mail
            try
            {
             

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("zzm@volkswagen-sa.ba", "20Zahmatvw18");
                MailAddress from = new MailAddress("From Address zzm@volkswagen-sa.ba", String.Empty, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("From Address Ex "+ em);
                MailMessage message = new MailMessage(from, to);
                message.Body = "Zahtjev za materijalom " + DateTime.Now.ToShortDateString();
                message.BodyEncoding = System.Text.Encoding.UTF8;


             

                message.Subject ="Potrebno odobrenje za zahtjev : " + this.lblIme.Text.Trim() + " " + DateTime.Now.ToShortDateString() + " No. " + insertID;




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



        
/*
            // System.Diagnostics.Process.Start(folderPath + this.comboBox12.Text.Trim() + " " + this.textBox34.Text.Trim() + DateTime.Now.ToShortDateString() + ".pdf");
            // this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            string folderPath2 = @"C:\Users\Public\Documents\ZZM\" +  " " + this.lblIme.Text.Trim() +" "+ DateTime.Now.ToShortDateString() +" No. "+ insertID + ".pdf";
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




              // printProcess.Start(); 


                               
             //   printProcess.WaitForInputIdle(); 
                


              //  MessageBox.Show("Zahtjev je na printanju!");
                  //  Thread.Sleep(3000);

                  /*  if (false == printProcess.CloseMainWindow())
                    {
                        printProcess.Kill();
                    }
                }
                */


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





                textBox37.Text = "";
                textBox38.Text = "";
                textBox39.Text = "";







                textBox51.Text = "";
                textBox52.Text = "";
                textBox53.Text = "";
                textBox54.Text = "";
                textBox55.Text = "";
                textBox56.Text = "";
                textBox57.Text = "";
                textBox58.Text = "";

                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";

                comboBox9.Text = "";
                comboBox10.Text = "";
                comboBox11.Text = "";
                comboBox12.Text = "";

                comboBox13.Text = "";
                comboBox14.Text = "";
                comboBox15.Text = "";



                sif1 = "";
                sif2 = "";
                sif3 = "";
                sif4 = "";
            button1.Visible = false;
            button2.Visible = true;

            }
            
            

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (string.IsNullOrEmpty(textBox22.Text))
                {
                    MessageBox.Show(mNPIS);
                    return;
                }

            }            
            if (string.IsNullOrEmpty(comboBox12.Text))
            {
                MessageBox.Show(mNPMT);
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show(mNPKol);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(mNPNM);
                return;
            }
            if (string.IsNullOrEmpty(txtTehnickaPriprema.Text))
            {
                MessageBox.Show(mNPTP);
                return;
            }



            else
            {
                

                button2.Visible = false;
            button1.Visible = true;
            string connetionString = null;
            string sql = null;
                string stok="";
                string vrsta = "";
                if (checkBox2.Checked)
                                    {
                  
                        stok = "DA";
                }
                else
                { stok = "NE"; }
             
                vrsta = "MATERIJAL";



                if (comboBox12.Text != "")
                {
                    SqlConnection connectionsif1 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string querysif = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                   
                  



                    SqlCommand csif = new SqlCommand(querysif, connectionsif1);
                    connectionsif1.Open();
                    csif.Parameters.AddWithValue("@nmt", comboBox12.Text);

                    SqlDataReader readersif1 = csif.ExecuteReader();


                    if (readersif1.Read())
                    {


                        sif1 = (readersif1["sifra_mt"].ToString());
                        readersif1.Close();
                        connectionsif1.Close();


                    }

                    else
                    {
                        readersif1.Close();
                        connectionsif1.Close();
                        return;
                    }

                }




                if (comboBox13.Text != "")
                {
                    SqlConnection connectionsif2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string querysif2 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                  


                    SqlCommand csif2 = new SqlCommand(querysif2, connectionsif2);
                    connectionsif2.Open();
                    csif2.Parameters.AddWithValue("@nmt", comboBox13.Text);

                    SqlDataReader readersif2 = csif2.ExecuteReader();


                    if (readersif2.Read())
                    {


                        sif2 = (readersif2["sifra_mt"].ToString());
                        readersif2.Close();
                        connectionsif2.Close();


                    }

                    else
                    {
                        readersif2.Close();
                        connectionsif2.Close();
                        return;
                    }

                }



                if (comboBox14.Text != "")
                {
                    SqlConnection connectionsif3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string querysif3 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                    


                    SqlCommand csif3 = new SqlCommand(querysif3, connectionsif3);
                    connectionsif3.Open();
                    csif3.Parameters.AddWithValue("@nmt", comboBox14.Text);

                    SqlDataReader readersif3 = csif3.ExecuteReader();


                    if (readersif3.Read())
                    {


                        sif3 = (readersif3["sifra_mt"].ToString());
                        readersif3.Close();
                        connectionsif3.Close();


                    }

                    else
                    {

                        return;


                    }

                }



                if (comboBox15.Text != "")
                {
                    SqlConnection connectionsif4 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                    string querysif4 = "SELECT [sifra_mt] FROM Mjesto_troska WHERE  Naziv_mt= @nmt ";

                    

                    SqlCommand csif4 = new SqlCommand(querysif4, connectionsif4);
                    connectionsif4.Open();
                    csif4.Parameters.AddWithValue("@nmt", comboBox15.Text);

                    SqlDataReader readersif4 = csif4.ExecuteReader();


                    if (readersif4.Read())
                    {


                        sif4 = (readersif4["sifra_mt"].ToString());
                        readersif4.Close();
                        connectionsif4.Close();


                    }

                    else
                    {

                        return;


                    }

                }



                    /*

                                    if (comboBox12.Text == "Uprava")
                                    {

                                        textBox40.Text = " 10 ";

                                    }
                                    else if (comboBox12.Text == "Rukovodilac finansija")

                                    {
                                        textBox40.Text = " 100 ";
                                    }
                                    else if (comboBox12.Text == "Finansije i računovodstvo")

                                    {
                                        textBox40.Text = " 110 ";
                                    }
                                    else if (comboBox12.Text == "Kontroling")

                                    {
                                        textBox40.Text = " 120 ";

                                    }
                                    else if (comboBox12.Text == "Personalno i pravno")

                                    {
                                        textBox40.Text = " 130 ";

                                    }
                                    else if (comboBox12.Text == "IT sistemi")

                                    {
                                        textBox40.Text = " 150 ";
                                    }
                                    else if (comboBox12.Text == "Nabavka")

                                    {
                                        textBox40.Text = " 180 ";
                                    }
                                    else if (comboBox12.Text == "Prodaja")

                                    {
                                        textBox40.Text = " 190 ";
                                    }
                                    else if (comboBox12.Text == "Vođa proizvodnje")

                                    {
                                        textBox40.Text = " 200 ";
                                    }
                                    else if (comboBox12.Text == "Proizvodnja režija - Paleta")

                                    {
                                        textBox40.Text = " 205 ";
                                    }
                                    else if (comboBox12.Text == "Proizvodnja režija - Komponente")

                                    {
                                        textBox40.Text = " 210 ";
                                    }
                                    else if (comboBox12.Text == "PQ 24")

                                    {
                                        textBox40.Text = " 222 ";
                                    }
                                    else if (comboBox12.Text == "PQ 34")

                                    {
                                        textBox40.Text = " 224 ";
                                    }
                                    else if (comboBox12.Text == "MQB")

                                    {
                                        textBox40.Text = " 225 ";
                                    }
                                    else if (comboBox12.Text == "MQB A0")

                                    {
                                        textBox40.Text = " 247 ";
                                    }
                                    else if (comboBox12.Text == "Ozubljeni vijenac 055")

                                    {
                                        textBox40.Text = " 231 ";
                                    }
                                    else if (comboBox12.Text == "Ozubljeni vijenac 03CA")

                                    {
                                        textBox40.Text = " 233 ";
                                    }
                                    else if (comboBox12.Text == "Ozubljeni vijenac 037A")

                                    {
                                        textBox40.Text = " 234 ";
                                    }
                                    else if (comboBox12.Text == "Glavčina točka 1S0")

                                    {
                                        textBox40.Text = " 242 ";
                                    }
                                    else if (comboBox12.Text == "Prirubnica točka")

                                    {
                                        textBox40.Text = " 245 "; ;
                                    }
                                    else if (comboBox12.Text == "Prirubnica točka 7P0 7L0")

                                    {
                                        textBox40.Text = " 246 ";
                                    }
                                    else if (comboBox12.Text == "Usisna grana")

                                    {
                                        textBox40.Text = " 252 ";


                                    }
                                    else if (comboBox12.Text == "Lakirnica")

                                    {
                                        textBox40.Text = " 265 ";
                                    }
                                    else if (comboBox12.Text == "Paleta")

                                    {
                                        textBox40.Text = " 268 ";
                                    }
                                    else if (comboBox12.Text == "Održavanje - centralno")

                                    {
                                        textBox40.Text = " 270 ";

                                    }
                                    else if (comboBox12.Text == "Održavanje")

                                    {
                                        textBox40.Text = " 271 ";
                                    }
                                    else if (comboBox12.Text == "KVP tim")

                                    {
                                        textBox40.Text = " 273 ";
                                    }
                                    else if (comboBox12.Text == "Logistika - centralna")

                                    {
                                        textBox40.Text = " 300 "; ;
                                    }
                                    else if (comboBox12.Text == "Špedicija")

                                    {
                                        textBox40.Text = " 310 ";
                                    }
                                    else if (comboBox12.Text == "Reklamacije")

                                    {
                                        textBox40.Text = " 320 ";
                                    }
                                    else if (comboBox12.Text == "Operativna logistika")

                                    {
                                        textBox40.Text = " 350 ";
                                    }
                                    else if (comboBox12.Text == "Osiguranje kvaliteta - centralno")

                                    {
                                        textBox40.Text = " 400 ";
                                    }
                                    else if (comboBox12.Text == "Operativno osiguranje kvaliteta")

                                    {
                                        textBox40.Text = " 450 ";
                                    }
                                    else if (comboBox12.Text == "Planiranje - centralno")

                                    {
                                        textBox40.Text = " 500 ";
                                    }
                                    else if (comboBox12.Text == "Zaštita okoliša i zaštita na radu")

                                    {
                                        textBox40.Text = " 520 ";
                                    }
                                    else if (comboBox12.Text == "Operativno planiranje")

                                    {
                                        textBox40.Text = " 550 ";
                                    }
                                    else if (comboBox12.Text == "Svi programi")
                                    {
                                        textBox40.Text = " ";

                                    }
                                    else
                                    {
                                        textBox40.Text = " ";

                                    }

                                    ////////////////////////////////////////////////////////////////////////////////////////////////////

                                    if (comboBox13.Text == "Uprava")
                                    {

                                        textBox41.Text = " 10 ";

                                    }
                                    else if (comboBox13.Text == "Rukovodilac finansija")

                                    {
                                        textBox41.Text = " 100 ";
                                    }
                                    else if (comboBox13.Text == "Finansije i računovodstvo")

                                    {
                                        textBox41.Text = " 110 ";
                                    }
                                    else if (comboBox13.Text == "Kontroling")

                                    {
                                        textBox41.Text = " 120 ";

                                    }
                                    else if (comboBox13.Text == "Personalno i pravno")

                                    {
                                        textBox41.Text = " 130 ";

                                    }
                                    else if (comboBox13.Text == "IT sistemi")

                                    {
                                        textBox41.Text = " 150 ";
                                    }
                                    else if (comboBox13.Text == "Nabavka")

                                    {
                                        textBox41.Text = " 180 ";
                                    }
                                    else if (comboBox13.Text == "Prodaja")

                                    {
                                        textBox41.Text = " 190 ";
                                    }
                                    else if (comboBox13.Text == "Vođa proizvodnje")

                                    {
                                        textBox41.Text = " 200 ";
                                    }
                                    else if (comboBox13.Text == "Proizvodnja režija - Paleta")

                                    {
                                        textBox41.Text = " 205 ";
                                    }
                                    else if (comboBox13.Text == "Proizvodnja režija - Komponente")

                                    {
                                        textBox41.Text = " 210 ";
                                    }
                                    else if (comboBox13.Text == "PQ 24")

                                    {
                                        textBox41.Text = " 222 ";
                                    }
                                    else if (comboBox13.Text == "PQ 34")

                                    {
                                        textBox41.Text = " 224 ";
                                    }
                                    else if (comboBox13.Text == "MQB")

                                    {
                                        textBox41.Text = " 225 ";
                                    }
                                    else if (comboBox13.Text == "MQB A0")

                                    {
                                        textBox41.Text = " 247 ";
                                    }
                                    else if (comboBox13.Text == "Ozubljeni vijenac 055")

                                    {
                                        textBox41.Text = " 231 ";
                                    }
                                    else if (comboBox13.Text == "Ozubljeni vijenac 03CA")

                                    {
                                        textBox41.Text = " 233 ";
                                    }
                                    else if (comboBox13.Text == "Ozubljeni vijenac 037A")

                                    {
                                        textBox41.Text = " 234 ";
                                    }
                                    else if (comboBox13.Text == "Glavčina točka 1S0")

                                    {
                                        textBox41.Text = " 242 ";
                                    }
                                    else if (comboBox13.Text == "Prirubnica točka")

                                    {
                                        textBox41.Text = " 245 "; ;
                                    }
                                    else if (comboBox13.Text == "Prirubnica točka 7P0 7L0")

                                    {
                                        textBox41.Text = " 246 ";
                                    }
                                    else if (comboBox13.Text == "Usisna grana")

                                    {
                                        textBox41.Text = " 252 ";


                                    }
                                    else if (comboBox13.Text == "Lakirnica")

                                    {
                                        textBox41.Text = " 265 ";
                                    }
                                    else if (comboBox13.Text == "Paleta")

                                    {
                                        textBox41.Text = " 268 ";
                                    }
                                    else if (comboBox13.Text == "Održavanje - centralno")

                                    {
                                        textBox41.Text = " 270 ";

                                    }
                                    else if (comboBox13.Text == "Održavanje")

                                    {
                                        textBox41.Text = " 271 ";
                                    }
                                    else if (comboBox13.Text == "KVP tim")

                                    {
                                        textBox41.Text = " 273 ";
                                    }
                                    else if (comboBox13.Text == "Logistika - centralna")

                                    {
                                        textBox41.Text = " 300 "; ;
                                    }
                                    else if (comboBox13.Text == "Špedicija")

                                    {
                                        textBox41.Text = " 310 ";
                                    }
                                    else if (comboBox13.Text == "Reklamacije")

                                    {
                                        textBox41.Text = " 320 ";
                                    }
                                    else if (comboBox13.Text == "Operativna logistika")

                                    {
                                        textBox41.Text = " 350 ";
                                    }
                                    else if (comboBox13.Text == "Osiguranje kvaliteta - centralno")

                                    {
                                        textBox41.Text = " 400 ";
                                    }
                                    else if (comboBox13.Text == "Operativno osiguranje kvaliteta")

                                    {
                                        textBox41.Text = " 450 ";
                                    }
                                    else if (comboBox13.Text == "Planiranje - centralno")

                                    {
                                        textBox41.Text = " 500 ";
                                    }
                                    else if (comboBox13.Text == "Zaštita okoliša i zaštita na radu")

                                    {
                                        textBox41.Text = " 520 ";
                                    }
                                    else if (comboBox13.Text == "Operativno planiranje")

                                    {
                                        textBox41.Text = " 550 ";
                                    }
                                    else if (comboBox13.Text == "Svi programi")
                                    {
                                        textBox41.Text = " ";

                                    }
                                    else
                                    {
                                        textBox41.Text = " ";

                                    }

                                    //////////////////////////////////////////////////////////////////////////////////////////////////
                                    ///

                                    if (comboBox14.Text == "Uprava")
                                    {

                                        textBox42.Text = " 10 ";

                                    }
                                    else if (comboBox14.Text == "Rukovodilac finansija")

                                    {
                                        textBox42.Text = " 100 ";
                                    }
                                    else if (comboBox14.Text == "Finansije i računovodstvo")

                                    {
                                        textBox42.Text = " 110 ";
                                    }
                                    else if (comboBox14.Text == "Kontroling")

                                    {
                                        textBox42.Text = " 120 ";

                                    }
                                    else if (comboBox14.Text == "Personalno i pravno")

                                    {
                                        textBox42.Text = " 130 ";

                                    }
                                    else if (comboBox14.Text == "IT sistemi")

                                    {
                                        textBox42.Text = " 150 ";
                                    }
                                    else if (comboBox14.Text == "Nabavka")

                                    {
                                        textBox42.Text = " 180 ";
                                    }
                                    else if (comboBox14.Text == "Prodaja")

                                    {
                                        textBox42.Text = " 190 ";
                                    }
                                    else if (comboBox14.Text == "Vođa proizvodnje")

                                    {
                                        textBox42.Text = " 200 ";
                                    }
                                    else if (comboBox14.Text == "Proizvodnja režija - Paleta")

                                    {
                                        textBox42.Text = " 205 ";
                                    }
                                    else if (comboBox14.Text == "Proizvodnja režija - Komponente")

                                    {
                                        textBox42.Text = " 210 ";
                                    }
                                    else if (comboBox14.Text == "PQ 24")

                                    {
                                        textBox42.Text = " 222 ";
                                    }
                                    else if (comboBox14.Text == "PQ 34")

                                    {
                                        textBox42.Text = " 224 ";
                                    }
                                    else if (comboBox14.Text == "MQB")

                                    {
                                        textBox42.Text = " 225 ";
                                    }
                                    else if (comboBox14.Text == "MQB A0")

                                    {
                                        textBox42.Text = " 247 ";
                                    }
                                    else if (comboBox14.Text == "Ozubljeni vijenac 055")

                                    {
                                        textBox42.Text = " 231 ";
                                    }
                                    else if (comboBox14.Text == "Ozubljeni vijenac 03CA")

                                    {
                                        textBox42.Text = " 233 ";
                                    }
                                    else if (comboBox14.Text == "Ozubljeni vijenac 037A")

                                    {
                                        textBox42.Text = " 234 ";
                                    }
                                    else if (comboBox14.Text == "Glavčina točka 1S0")

                                    {
                                        textBox42.Text = " 242 ";
                                    }
                                    else if (comboBox14.Text == "Prirubnica točka")

                                    {
                                        textBox42.Text = " 245 "; ;
                                    }
                                    else if (comboBox14.Text == "Prirubnica točka 7P0 7L0")

                                    {
                                        textBox42.Text = " 246 ";
                                    }
                                    else if (comboBox14.Text == "Usisna grana")

                                    {
                                        textBox42.Text = " 252 ";


                                    }
                                    else if (comboBox14.Text == "Lakirnica")

                                    {
                                        textBox42.Text = " 265 ";
                                    }
                                    else if (comboBox14.Text == "Paleta")

                                    {
                                        textBox42.Text = " 268 ";
                                    }
                                    else if (comboBox14.Text == "Održavanje - centralno")

                                    {
                                        textBox42.Text = " 270 ";

                                    }
                                    else if (comboBox14.Text == "Održavanje")

                                    {
                                        textBox41.Text = " 271 ";
                                    }
                                    else if (comboBox14.Text == "KVP tim")

                                    {
                                        textBox42.Text = " 273 ";
                                    }
                                    else if (comboBox14.Text == "Logistika - centralna")

                                    {
                                        textBox42.Text = " 300 "; ;
                                    }
                                    else if (comboBox14.Text == "Špedicija")

                                    {
                                        textBox42.Text = " 310 ";
                                    }
                                    else if (comboBox14.Text == "Reklamacije")

                                    {
                                        textBox42.Text = " 320 ";
                                    }
                                    else if (comboBox14.Text == "Operativna logistika")

                                    {
                                        textBox42.Text = " 350 ";
                                    }
                                    else if (comboBox14.Text == "Osiguranje kvaliteta - centralno")

                                    {
                                        textBox42.Text = " 400 ";
                                    }
                                    else if (comboBox14.Text == "Operativno osiguranje kvaliteta")

                                    {
                                        textBox42.Text = " 450 ";
                                    }
                                    else if (comboBox14.Text == "Planiranje - centralno")

                                    {
                                        textBox42.Text = " 500 ";
                                    }
                                    else if (comboBox14.Text == "Zaštita okoliša i zaštita na radu")

                                    {
                                        textBox42.Text = " 520 ";
                                    }
                                    else if (comboBox14.Text == "Operativno planiranje")

                                    {
                                        textBox42.Text = " 550 ";
                                    }
                                    else if (comboBox14.Text == "Svi programi")
                                    {
                                        textBox42.Text = " ";

                                    }
                                    else
                                    {
                                        textBox42.Text = " ";

                                    }


                                    //////////////////////////////////////////////////////////////////////////////////////
                                    ///


                                    if (comboBox15.Text == "Uprava")
                                    {

                                        textBox43.Text = " 10 ";

                                    }
                                    else if (comboBox15.Text == "Rukovodilac finansija")

                                    {
                                        textBox43.Text = " 100 ";
                                    }
                                    else if (comboBox15.Text == "Finansije i računovodstvo")

                                    {
                                        textBox43.Text = " 110 ";
                                    }
                                    else if (comboBox15.Text == "Kontroling")

                                    {
                                        textBox43.Text = " 120 ";

                                    }
                                    else if (comboBox15.Text == "Personalno i pravno")

                                    {
                                        textBox43.Text = " 130 ";

                                    }
                                    else if (comboBox15.Text == "IT sistemi")

                                    {
                                        textBox43.Text = " 150 ";
                                    }
                                    else if (comboBox15.Text == "Nabavka")

                                    {
                                        textBox43.Text = " 180 ";
                                    }
                                    else if (comboBox15.Text == "Prodaja")

                                    {
                                        textBox43.Text = " 190 ";
                                    }
                                    else if (comboBox15.Text == "Vođa proizvodnje")

                                    {
                                        textBox43.Text = " 200 ";
                                    }
                                    else if (comboBox15.Text == "Proizvodnja režija - Paleta")

                                    {
                                        textBox43.Text = " 205 ";
                                    }
                                    else if (comboBox15.Text == "Proizvodnja režija - Komponente")

                                    {
                                        textBox43.Text = " 210 ";
                                    }
                                    else if (comboBox15.Text == "PQ 24")

                                    {
                                        textBox43.Text = " 222 ";
                                    }
                                    else if (comboBox15.Text == "PQ 34")

                                    {
                                        textBox43.Text = " 224 ";
                                    }
                                    else if (comboBox15.Text == "MQB")

                                    {
                                        textBox43.Text = " 225 ";
                                    }
                                    else if (comboBox15.Text == "MQB A0")

                                    {
                                        textBox43.Text = " 247 ";
                                    }
                                    else if (comboBox15.Text == "Ozubljeni vijenac 055")

                                    {
                                        textBox43.Text = " 231 ";
                                    }
                                    else if (comboBox15.Text == "Ozubljeni vijenac 03CA")

                                    {
                                        textBox43.Text = " 233 ";
                                    }
                                    else if (comboBox15.Text == "Ozubljeni vijenac 037A")

                                    {OzzS
                                        textBox43.Text = " 234 ";
                                    }
                                    else if (comboBox15.Text == "Glavčina točka 1S0")

                                    {
                                        textBox43.Text = " 242 ";
                                    }
                                    else if (comboBox15.Text == "Prirubnica točka")

                                    {
                                        textBox43.Text = " 245 "; ;
                                    }
                                    else if (comboBox15.Text == "Prirubnica točka 7P0 7L0")

                                    {
                                        textBox43.Text = " 246 ";
                                    }
                                    else if (comboBox15.Text == "Usisna grana")

                                    {
                                        textBox43.Text = " 252 ";


                                    }
                                    else if (comboBox15.Text == "Lakirnica")

                                    {
                                        textBox43.Text = " 265 ";
                                    }
                                    else if (comboBox15.Text == "Paleta")

                                    {
                                        textBox43.Text = " 268 ";
                                    }
                                    else if (comboBox15.Text == "Održavanje - centralno")

                                    {
                                        textBox43.Text = " 270 ";

                                    }
                                    else if (comboBox15.Text == "Održavanje")

                                    {
                                        textBox43.Text = " 271 ";
                                    }
                                    else if (comboBox15.Text == "KVP tim")

                                    {
                                        textBox43.Text = " 273 ";
                                    }
                                    else if (comboBox15.Text == "Logistika - centralna")

                                    {
                                        textBox43.Text = " 300 "; ;
                                    }
                                    else if (comboBox15.Text == "Špedicija")

                                    {
                                        textBox43.Text = " 310 ";
                                    }
                                    else if (comboBox15.Text == "Reklamacije")

                                    {
                                        textBox43.Text = " 320 ";
                                    }
                                    else if (comboBox15.Text == "Operativna logistika")

                                    {
                                        textBox43.Text = " 350 ";
                                    }
                                    else if (comboBox15.Text == "Osiguranje kvaliteta - centralno")

                                    {
                                        textBox43.Text = " 400 ";
                                    }
                                    else if (comboBox15.Text == "Operativno osiguranje kvaliteta")

                                    {
                                        textBox43.Text = " 450 ";
                                    }
                                    else if (comboBox15.Text == "Planiranje - centralno")

                                    {
                                        textBox43.Text = " 500 ";
                                    }
                                    else if (comboBox15.Text == "Zaštita okoliša i zaštita na radu")

                                    {
                                        textBox43.Text = " 520 ";
                                    }
                                    else if (comboBox15.Text == "Operativno planiranje")

                                    {
                                        textBox43.Text = " 550 ";
                                    }
                                    else if (comboBox15.Text == "Svi programi")
                                    {
                                        textBox43.Text = " ";

                                    }
                                    else
                                    {
                                        textBox43.Text = " ";

                                    }
                                    */




                    connetionString = "Data Source=SERVER2008\\SAFEQ4SQL;Initial Catalog=Zahtjev_za_materijalom;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "insert into DiReqt ([podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2]" +
                    ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5],[tehp]" +
                    ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                    ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11],[stok],[napomena],[sklad],[vrsta],[min],[max],[stanje],[min2],[max2],[stanje2],[min3],[max3],[stanje3]" +
                    ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[odjel],[idbroj]" +
                    ") values(@pod,@dat,@is,@naz,@jm,@kol,@is2,@naz2,@jm2,@kol2,@is3,@naz3,@jm3,@kol3,@is4,@naz4,@jm4,@kol4,@is5,@naz5,@jm5,@kol5,@tp,@is6,@naz6,@jm6,@kol6" +
                    ",@is7,@naz7,@jm7,@kol7,@is8,@naz8,@jm8,@kol8,@is9,@naz9,@jm9,@kol9,@is10,@naz10,@jm10,@kol10,@is11,@naz11,@jm11,@kol11,@stk,@napo,@sklad,@vrsta,@min,@max,@stanje,@min2,@max2,@stanje2,@min3,@max3,@stanje3,@mjesto,@mjesto2,@mjesto3,@mjesto4"+
                   ",@smjesto,@smjesto2,@smjesto3,@smjesto4,@odjel,@idb)" ;
                cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@odj", lblOdjel.Text);
                        cmd.Parameters.AddWithValue("@idb", idbroj);
                        cmd.Parameters.AddWithValue("@pod", lblIme.Text);
                        cmd.Parameters.AddWithValue("@dat", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@is", textBox22.Text);
                        cmd.Parameters.AddWithValue("@naz", textBox1.Text);
                        cmd.Parameters.AddWithValue("@jm", textBox33.Text);
                        cmd.Parameters.AddWithValue("@kol", comboBox1.Text);

                        cmd.Parameters.AddWithValue("@is2", textBox21.Text);
                        cmd.Parameters.AddWithValue("@naz2", textBox2.Text);
                        cmd.Parameters.AddWithValue("@jm2", textBox32.Text);
                        cmd.Parameters.AddWithValue("@kol2", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@tp", txtTehnickaPriprema.Text);
                        cmd.Parameters.AddWithValue("@is3", textBox20.Text);
                        cmd.Parameters.AddWithValue("@naz3", textBox3.Text);
                        cmd.Parameters.AddWithValue("@jm3", textBox31.Text);
                        cmd.Parameters.AddWithValue("@kol3", comboBox3.Text);

                        cmd.Parameters.AddWithValue("@is4", textBox19.Text);
                        cmd.Parameters.AddWithValue("@naz4", textBox4.Text);
                        cmd.Parameters.AddWithValue("@jm4", textBox30.Text);
                        cmd.Parameters.AddWithValue("@kol4", comboBox4.Text);

                        cmd.Parameters.AddWithValue("@is5", textBox18.Text);
                        cmd.Parameters.AddWithValue("@naz5", textBox5.Text);
                        cmd.Parameters.AddWithValue("@jm5", textBox29.Text);
                        cmd.Parameters.AddWithValue("@kol5", comboBox5.Text);

                        cmd.Parameters.AddWithValue("@is6", textBox17.Text);
                        cmd.Parameters.AddWithValue("@naz6", textBox6.Text);
                        cmd.Parameters.AddWithValue("@jm6", textBox28.Text);
                        cmd.Parameters.AddWithValue("@kol6", comboBox6.Text);

                        cmd.Parameters.AddWithValue("@is7", textBox16.Text);
                        cmd.Parameters.AddWithValue("@naz7", textBox7.Text);
                        cmd.Parameters.AddWithValue("@jm7", textBox27.Text);
                        cmd.Parameters.AddWithValue("@kol7", comboBox7.Text);

                        cmd.Parameters.AddWithValue("@is8", textBox15.Text);
                        cmd.Parameters.AddWithValue("@naz8", textBox8.Text);
                        cmd.Parameters.AddWithValue("@jm8", textBox26.Text);
                        cmd.Parameters.AddWithValue("@kol8", comboBox8.Text);

                        cmd.Parameters.AddWithValue("@is9", textBox14.Text);
                        cmd.Parameters.AddWithValue("@naz9", textBox9.Text);
                        cmd.Parameters.AddWithValue("@jm9", textBox25.Text);
                        cmd.Parameters.AddWithValue("@kol9", comboBox9.Text);

                        cmd.Parameters.AddWithValue("@is10", textBox13.Text);
                        cmd.Parameters.AddWithValue("@naz10", textBox10.Text);
                        cmd.Parameters.AddWithValue("@jm10", textBox24.Text);
                        cmd.Parameters.AddWithValue("@kol10", comboBox10.Text);

                        cmd.Parameters.AddWithValue("@is11", textBox12.Text);
                        cmd.Parameters.AddWithValue("@naz11", textBox11.Text);
                        cmd.Parameters.AddWithValue("@jm11", textBox23.Text);
                        cmd.Parameters.AddWithValue("@kol11", comboBox11.Text);

                        cmd.Parameters.AddWithValue("@stk", stok);
                        cmd.Parameters.AddWithValue("@napo", textBox58.Text);
                        cmd.Parameters.AddWithValue("@sklad", textBox57.Text);
                        cmd.Parameters.AddWithValue("@vrsta", vrsta);

                        cmd.Parameters.AddWithValue("@min", textBox37.Text);
                        cmd.Parameters.AddWithValue("@max", textBox38.Text);
                        cmd.Parameters.AddWithValue("@stanje", textBox39.Text);

                        cmd.Parameters.AddWithValue("@min2", textBox51.Text);
                        cmd.Parameters.AddWithValue("@max2", textBox52.Text);
                        cmd.Parameters.AddWithValue("@stanje2", textBox53.Text);

                        cmd.Parameters.AddWithValue("@min3", textBox54.Text);
                        cmd.Parameters.AddWithValue("@max3", textBox55.Text);
                        cmd.Parameters.AddWithValue("@stanje3", textBox56.Text);

                        cmd.Parameters.AddWithValue("@mjesto", comboBox12.Text);
                        cmd.Parameters.AddWithValue("@mjesto2", comboBox13.Text);
                        cmd.Parameters.AddWithValue("@mjesto3", comboBox14.Text);
                        cmd.Parameters.AddWithValue("@mjesto4", comboBox15.Text);
                     
                        cmd.Parameters.AddWithValue("@smjesto", sif1);
                        cmd.Parameters.AddWithValue("@smjesto2", sif2);
                        cmd.Parameters.AddWithValue("@smjesto3", sif3);
                        cmd.Parameters.AddWithValue("@smjesto4", sif4);
                        cmd.Parameters.AddWithValue("@odjel", lblOdjel.Text);


                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT @@IDENTITY";
                        
                        // Get the last inserted id.
                      insertID = Convert.ToString(cmd.ExecuteScalar());
                        //textBox35.Text = insertID;
                        MessageBox.Show(mZahSp + insertID);

                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            
                try
                {
                
                    SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");

                    DataTable dt = new DataTable();


              //  if (radioButton3.Checked)
              //  {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[naziv_mt] as 'Naziv mjesta troška' "+
    "  ,[naziv_mt2] as 'Mjesto troška 2',[naziv_mt3] as 'Mjesto troška 3' ,[naziv_mt4] as 'Mjesto troška 4' ,[datum_nabavka] as 'Datum unošenja cijene',[datum_kontroling] as 'Datum odobrenja / odbijanja' ,[status] as 'Status'"+
    " ,[nabavka] as 'Referent nabavke',[kontroling] as 'Kontroling',[sklad] as 'Skladište',[napomena] as 'Napomena',[ident_sifra] as 'Ident šifra' ,[naziv] as 'Naziv materijala'  ,[jm] as 'Jedinica mjere' ,[kolicina] as 'Količina'"+
 "   ,[odobrena_kolicina] as 'Odobrena količina' ,[ukupna_cijena] 'Ukupna cijena' ,[min] as 'Min'  ,[max] as 'Max' ,[stanje] as 'Stanje',[ident_sifra2] as 'Ident šifra 2' ,[naziv2] as 'Naziv materijala 2' ,[jm2] as 'Jedinica mjere 2' ,[kolicina2] as 'Količina 2'"+
   "  ,[odobrena_kolicina2] as 'Odobrena količina 2' ,[ukupna_cijena2] 'Ukupna cijena 2' ,[min2] as 'Min 2',[max2] as 'Max 2'  ,[stanje2] as 'Stanje 2' ,[ident_sifra3] as 'Ident šifra 3'  ,[naziv3] as 'Naziv materijala',[jm3] as 'Jedinica mjere 3'"+
   "  ,[kolicina3] as 'Količina 3' ,[odobrena_kolicina3] as 'Odobrena količina 3' ,[ukupna_cijena3] 'Ukupna cijena 3' ,[min3] as 'Min 3'  ,[max3] as 'Max 3' ,[stanje3] as 'Stanje 3',[ident_sifra4] as 'Ident šifra 4' ,[naziv4] as 'Naziv materijala 4' ,[jm4] as 'Jedinica mjere 4' ,[kolicina4] as 'Količina 4'" +
    " ,[odobrena_kolicina4] as 'Odobrena količina 4',[ukupna_cijena4] 'Ukupna cijena 4',[ident_sifra5] as 'Ident šifra 5'      ,[naziv5] as 'Naziv materijala 5'      ,[jm5] as 'Jedinica mjere 5'      ,[kolicina5] as 'Količina 5'      ,[odobrena_kolicina5] as 'Odobrena količina 5'      ,[ukupna_cijena5] 'Ukupna cijena 5'" +
     " ,[ident_sifra6] as 'Ident šifra 6' ,[naziv6] as 'Naziv materijala 6'      ,[jm6] as 'Jedinica mjere 6' ,[kolicina6] as 'Količina 6' ,[odobrena_kolicina6] as 'Odobrena količina 6'  ,[ukupna_cijena6] 'Ukupna cijena 6'      ,[ident_sifra7] as 'Ident šifra 7'      ,[naziv7] as 'Naziv materijala 7'      ,[jm7] as 'Jedinica mjere 7'"+
     " ,[kolicina7] as 'Količina 7'      ,[odobrena_kolicina7] as 'Odobrena količina 7' ,[ukupna_cijena7] 'Ukupna cijena 7'  ,[ident_sifra8] as 'Ident šifra 8'  ,[naziv8] as 'Naziv materijala'      ,[jm8] as 'Jedinica mjere 8'      ,[kolicina8] as 'Količina 8'      ,[odobrena_kolicina8] as 'Odobrena količina 8'      ,[ukupna_cijena8] as  'Ukupna cijena 8' "+
    "  ,[ident_sifra9] as 'Ident šifra 9'      ,[naziv9] as 'Naziv materijala 9'      ,[jm9] as 'Jedinica mjere 9' ,[kolicina9] as 'Količina 9' ,[odobrena_kolicina9] as 'Odobrena količina 9'      ,[ukupna_cijena9] 'Ukupna cijena 9'      ,[ident_sifra10] as 'Ident šifra 10'      ,[naziv10] as 'Naziv materijala 10'      ,[jm10] as 'Jedinica mjere 10'"+
     " ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11',[total] as 'Total' from DiReqt where (podnositelj LIKE @pid or podnositelj=@pid  ) or  CAST(id AS NVARCHAR(10)) LIKE @pid or [datum]=@pid  ", connection);

                adapter.SelectCommand.Parameters.AddWithValue("@pid", textBox36.Text);
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;
                DataTable inputTable = dt;
                       DataTable transposedTable = GenerateTransposedTable(inputTable);
                      dataGridView2.DataSource = transposedTable;
                   // dataGridView2.DataSource = dt;

               // }
              /*  if (radioButton4.Checked)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select [id] as 'Broj zahtjeva',[podnositelj] as 'Ime i prezime',[datum] as 'Datum',[naziv_mt] as 'Naziv mjesta troška' " +
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
   " ,[kolicina10] as 'Količina 10',[odobrena_kolicina10] as 'Odobrena količina 10',[ukupna_cijena10] 'Ukupna cijena 10',[ident_sifra11] as 'Ident šifra 11',[naziv11] as 'Naziv materijala 11',[jm11] as 'Jedinica mjere 11'      ,[kolicina11] as 'Količina 11'      ,[odobrena_kolicina11] as 'Odobrena količina 11',[ukupna_cijena11] as 'Ukupna cijena 11',[total] as 'Total' from DiReqt where id=@pid ", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@pid", textBox36.Text);
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;
                   /* DataTable inputTable = dt;
                    DataTable transposedTable = GenerateTransposedTable(inputTable);
                    dataGridView2.DataSource = transposedTable;*/
                }
            
                /*DataTable dta = new DataTable();

                SqlDataAdapter adapter1 = new SqlDataAdapter("Select  * from Zahtjev where id=@iid ", connection);
                adapter1.SelectCommand.Parameters.AddWithValue("@iid", textBox36.Text);
                adapter1.Fill(dta);
                */
                

                // This is the table I shown in Figure 1.1


                // dataGridView2.DataSource = dt;

                // DataTable inputedTable = dta;
                // Table shown in Figure 1.1


                // DataTable transposedTables = GenerateTransposedTable(inputedTable);




                //  if (radioButton4.Checked)
                // { dataGridView2.DataSource = transposedTables; }

          //  }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            
        }


        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }



        private void chckBoxDodatnaPolja_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (((CheckBox)sender).Checked)
            { 
                PlaceCorrectly(tblPanelPocetniNovi, tblPanelDodatnaPolja);

                tblPanelDodatnaPolja.Visible = true;

                if (checkBox2.Checked)
                    tblPanelMinMaxDrugi.Visible = true;
            }
            else
            {
                tblPanelDodatnaPolja.Visible = false;
                if (checkBox2.Checked)
                    tblPanelMinMaxDrugi.Visible = false;
            }


            


            /*
            if (((CheckBox)sender).Checked)
            {
                textBox21.Visible = true;
                textBox2.Visible = true;
                textBox32.Visible = true;
                comboBox2.Visible = true;
                textBox20.Visible = true;
                textBox3.Visible = true;
                textBox31.Visible = true;
                comboBox3.Visible = true;
                textBox19.Visible = true;
                textBox4.Visible = true;
                textBox30.Visible = true;
                comboBox4.Visible = true;
                textBox18.Visible = true;
                textBox5.Visible = true;
                textBox29.Visible = true;
                comboBox5.Visible = true;
                textBox17.Visible = true;
                textBox6.Visible = true;
                textBox28.Visible = true;
                comboBox6.Visible = true;
                textBox16.Visible = true;
                textBox7.Visible = true;
                textBox27.Visible = true;
                comboBox7.Visible = true;
                textBox15.Visible = true;
                textBox8.Visible = true;
                textBox26.Visible = true;
                comboBox8.Visible = true;
                textBox14.Visible = true;
                textBox9.Visible = true;
                textBox25.Visible = true;
                comboBox9.Visible = true;
                textBox13.Visible = true;
                textBox10.Visible = true;
                textBox24.Visible = true;
                comboBox10.Visible = true;
                textBox12.Visible = true;
                textBox11.Visible = true;
                textBox23.Visible = true;
                comboBox11.Visible = true;
                if (checkBox2.Checked == true)
                {
                    textBox51.Visible = true;
                    textBox52.Visible = true;
                    textBox53.Visible = true;
                    textBox54.Visible = true;

                    textBox55.Visible = true;

                    textBox56.Visible = true;

                }


            }
            else
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;

                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                
                textBox23.Visible = false;
                textBox24.Visible = false;
                textBox25.Visible = false;
                textBox26.Visible = false;
                textBox27.Visible = false;
                textBox28.Visible = false;
                textBox29.Visible = false;
                textBox30.Visible = false;
                textBox31.Visible = false;
                textBox32.Visible = false;
                

                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;

                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;

                if (checkBox2.Checked == true)
                {
                    textBox51.Visible = false;
                    textBox52.Visible = false;
                    textBox53.Visible = false;
                    textBox54.Visible = false;

                    textBox55.Visible = false;

                    textBox56.Visible = false;

                }*/
        //}





        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    tblPanelMinMaxPrvi.Visible = true;
                    tblPanelMinMaxDrugi.Visible = true;
                    tblPanelMinMaxDrugi.Location = new System.Drawing.Point(tblPanelDodatnaPolja.Location.X + tblPanelDodatnaPolja.Size.Width, tblPanelDodatnaPolja.Location.Y);
                }
                else
                {
                    tblPanelMinMaxPrvi.Visible = true;
                    tblPanelMinMaxDrugi.Visible = false;
                }
            }
            else
            {
                tblPanelMinMaxPrvi.Visible = false;
                tblPanelMinMaxDrugi.Visible = false;
            }



            


            if (((CheckBox)sender).Checked)
            {


                textBox37.Visible = true;
                textBox38.Visible = true;
                textBox39.Visible = true;

                if(checkBox1.Checked==true)
                {
                textBox51.Visible = true;
                textBox52.Visible = true;
                textBox53.Visible = true;
                textBox54.Visible = true;

                textBox55.Visible = true;

                textBox56.Visible = true;

                }
                
            }

            else
            {
                textBox37.Visible = false;
                textBox38.Visible = false;
                textBox39.Visible = false;
                textBox51.Visible = false;
                textBox52.Visible = false;
                textBox53.Visible = false;
                textBox54.Visible = false;
                textBox55.Visible = false;
                textBox56.Visible = false;
               
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {



            if (checkBox4.Checked)
            {
                comboBox15.Visible = true;
                comboBox13.Visible = true;
                comboBox14.Visible = true;
            }
            else
            {
                comboBox15.Visible = false;
                comboBox14.Visible = false;
                comboBox13.Visible = false;
                comboBox15.Text = "";
                comboBox14.Text = "";
                comboBox13.Text = "";

            }



            /*
            if (((CheckBox)sender).Checked)
            {
                

                label9.Visible = true;
                label13.Visible = true;
                label15.Visible = true;
               // label16.Visible = true;
               // label17.Visible = true;
               // label17.Visible = true


                comboBox13.Visible = true;
                comboBox14.Visible = true;
                comboBox15.Visible = true;
                //comboBox16.Visible = true;
              //  comboBox17.Visible = true;
            }

            else
            {
           
                comboBox13.Text = "";
                comboBox14.Text = "";
                comboBox15.Text = "";
               

                label9.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
               // label16.Visible = false;
                //label17.Visible = false;


                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
               // comboBox16.Visible = false;
              //  comboBox17.Visible = false;
            }*/
        }
        string idbroj = "";


        private void prjez()
        {
            if (Korisnik.Jezik.Equals("Bos"))
            {
                lblIdentSifraNoviZahtjev.Text = "Ident šifra";
                lblNazivMaterijalaNoviZahtjev.Text = "Naziv materijala";
                lblJMNoviZahtjev.Text = "JM";
                lblKolicinaNoviZahtjev.Text = "Količina";
             
                lblStanjeNoviZahtjev.Text = "Stanje";
                lblSkladiste.Text = "Skladište";
                lblNapomena.Text = "Napomena";
                lblTehnickaPriprema.Text = "Tehnička priprema";
                lblMjestoTroskova.Text = "Mjesto troškova";

                checkBox4.Text = "Dodatna mjesta troškova";
                checkBox1.Text = "Dodatna polja";

                btnZahtjevMaterijal.Text = "Zahtjev za materijalom";
                btnModifikacijaZahtjeva.Text = "Modifikacija zahtjeva";
                btnPregledZahtjeva.Text = "Pregled zahtjeva";
                btnPretragaZahtjeva.Text = "Pretraga zahtjeva";

                lblIdZahtjeva.Text = "Id zahtjeva";
                lblPretragaPregledZahtjeva.Text = "Pretraga";
                lblStatusPregled.Text = "Status zahtjeva";
                lblPretragaPretraga.Text = "Pretraga";

                lblIdentSifraEdit.Text = "Ident šifra";
                lblNazivMaterijalaEdit.Text = "Naziv materijala";
                lblJMEdit.Text = "JM";
                lblKolicinaEdit.Text = "Količina";
               
                lblStanjeEdit.Text = "Stanje";
                lblSkladisteEdit.Text = "Skladište";
                lblNapomenaEdit.Text = "Napomena";
                label7.Text = "Tehnička priprema";
                lblMjestoTroskovaEdit.Text = "Mjesto troška";


                lblIdZahtjeva.Text = "Id zahtjeva";
                lblPretragaPregledZahtjeva.Text = "Pretraga";
                lblStatusPregled.Text = "Status zahtjeva";
                lblPretragaPretraga.Text = "Pretraga";





                mMail= " Kopija zahtjeva je proslijeđena putem e-maila! ";  
                mNPIS= " Polje 'Ident šifra' ne može biti prazno! "; 
                mNPMT= " Mjesto troška ne može biti prazno! ";   
                mNPKol= " Količina ne može biti prazna! ";   
                mNPNM= " Naziv materijala ne može biti prazan! ";   
                mNPTP= " Polje 'Tehnička priprema' ne može biti prazno! ";  
                mZahSp= " Vaš zahtjev je spašen. Broj zahtjeva je : ";  
                mZahPP= " Zahtjev je u fazi prikupljanja ponuda ";  
                mZahK= " Zahtjev je u kontrolingu i čeka na odobrenje ! ";  
                mZahOdo= " Zahtjev je odobren i u fazi je naručivanja! ";  
                mZahOdb= " Zahtjev je odbijen! ";  
                mNBr= " Niste upisali broj zahtjeva! ";  
                mSID= " Možete upisati samo broj zahtjeva! ";  
                mSPod= " Samo podnosilac zahtjeva može pregledati zahtjev! ";  
                mZBr= " Unesite broj zahtjeva! ";  
                mZS= " Ovaj zahtjev je već odobren/storniran. Kontakt osoba u slučaju potrebe otključavanja zahtjeva je: ";  
                mZC= " Za ovaj zahtjev su već upisane cijene. Kontakt osoba u slučaju potrebe otključavanja zahtjeva je: ";  
                mNoZah= " Zahtjev ne postoji! "; 
                mNO= " Niste ovlašteni za modifikaciju ovog zahtjeva! ";  
                mA= " Ažurirano ";  
                mNA= " Ažuriranje nije uspjelo ";  
                mZahSp= " Vaš zahtjev je spašen. Broj zahtjeva je : ";  
                mTNO= " Trenutno niste ovlašteni za odobravanje zahtjeva! ";  
                mNOo= " Niste ovlašteni za ovaj odjel! ";  
                mZO= " Zahtjev je odobren! ";  
                mCu= " Cijene su unešene u sistem! ";  
                mCuTo= " Napomena! Cijene su već unešene za ovaj zahtjev! Total iznosi: ";  
                mZNO= " Zahtjev nije dobio odobrenje ";
                mZav = " Zahtjev je završen. Status zahtjeva je: ";
                 mZnU= " Zahtjev nije učitan! ";  
                mCnU= " Cijena nije unešena! ";  
                mZOt= " Zahtjev je otključan! ";  
                mCNU= " Cijene nisu unešene za ovaj zahtjev! ";  
                mOKnu= " Odobrena količina nije unešena! ";  
                mZoZ= " Zahtjev je odbijen. Želite li ga stornirati? ";  
                mZTOpm= " Zahtjev traži posebno odobrenje. Želite li poslati mail sa zahtjevom? ";  
                mKZS= " Kopija zahtjeva je proslijeđena šefu putem e-maila! ";  
                mKZSK= " Kopija zahtjeva je proslijeđena šefu kontrolinga ! ";  
                mZTPOD= " Zahtjev traži posebno odobrenje od direktora. Želite li poslati mail sa zahtjevom? ";  
                mKZPKD= " Kopija zahtjeva je proslijeđena šefu kontrolinga i direktoru putem e-maila! ";  
                mKiCI= " Količina i cijene su izmjenjeni! ";  
                mZSpa= " Zahtjev je spašen ";  
                mOdo= " Odobreno! ";  
                mOdb= " Odbijeno! ";  
                mZPrint= " Zahtjev je na printanju! ";  
                mPPMail= " Poruka proslijeđena putem e-maila! ";  
                mOdgOs= " Odgovorna osoba za odjel " + comboBox1.Text +  " je  ";  
                mUsPro= " Uspješno ste promjenili šifru! ";
                mSnJ = "  Šifre nisu jednake. ";















            }
            else if (Korisnik.Jezik.Equals("Njem"))
            {

                lblIdentSifraNoviZahtjev.Text = "Ident Nr";
                lblNazivMaterijalaNoviZahtjev.Text = "Materialbeschreibung";
                lblJMNoviZahtjev.Text = "ML";
                lblKolicinaNoviZahtjev.Text = "Menge";
                lblMinNoviZahtjev.Text = "Min";
                lblMaxNoviZahtjev.Text = "Max";
                lblStanjeNoviZahtjev.Text = "Zustand";
                lblSkladiste.Text = "Lager";
                lblNapomena.Text = "Bemerkung";
                lblTehnickaPriprema.Text = "Tech. Vorbereitung";
                lblMjestoTroskova.Text = "Kostenstellen";
                checkBox4.Text = "Zusätzliche Kostenstellen";
                checkBox1.Text = "Zusätzliche Felder";

                btnZahtjevMaterijal.Text = "Antrag auf Materialbestellung";
                btnModifikacijaZahtjeva.Text = "Anfrage ändern";
                btnPregledZahtjeva.Text = "Vorschau-Anfrage";
                btnPretragaZahtjeva.Text = "Suchanfrage";

                lblIdZahtjeva.Text = "Ident Nr";
                lblPretragaPregledZahtjeva.Text = "Pretraga";
                lblStatusPregled.Text = "Status zahtjeva";
                lblPretragaPretraga.Text = "Pretraga";

                lblIdentSifraEdit.Text = "Ident šifra";
                lblNazivMaterijalaEdit.Text = "Materialbeschreibung";
                lblJMEdit.Text = "ML";
                lblKolicinaEdit.Text = "Menge";

                lblStanjeEdit.Text = "Zustand";
                lblSkladisteEdit.Text = "Lager";
                lblNapomenaEdit.Text = "Bemerkung";
                label7.Text = "Tech. Vorbereitung";
                lblMjestoTroskovaEdit.Text = "Kostenstellen";

                lblIdZahtjeva.Text = "Antrag ID";
                lblPretragaPregledZahtjeva.Text = "Suchen";
                lblStatusPregled.Text = "Antrag Status";
                lblPretragaPretraga.Text = "Suchen";






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
                mOdgOs = " Die Verantwortliche Person für die Abteilung" + comboBox1.Text +" ist ";
                mUsPro = " Sie haben die Kennnummer erfolgreich geändert! ";
                mSnJ = " Kennnummern sind nicht gleich. ";



            }



        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
           

            SqlConnection connection66 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
           
            jez=Korisnik.Jezik;
            prjez();

            connection66.Open();

           


            comboBox12.Items.Clear();
            comboBox13.Items.Clear();
            comboBox14.Items.Clear();
            comboBox15.Items.Clear();


            string querymt = "SELECT [Naziv_mt] FROM Mjesto_troska ";


            

            SqlCommand sifre = new SqlCommand(querymt, connection66);

            SqlDataReader mtsif = sifre.ExecuteReader();

            while (mtsif.Read())
            {
                comboBox12.Items.Add(mtsif[0]);
                comboBox13.Items.Add(mtsif[0]);
                comboBox14.Items.Add(mtsif[0]);
                comboBox15.Items.Add(mtsif[0]);
                cmbBoxMjestoTroskovaEdit1.Items.Add(mtsif[0]);
                cmbBoxMjestoTroskovaEdit2.Items.Add(mtsif[0]);
                cmbBoxMjestoTroskovaEdit3.Items.Add(mtsif[0]);
                cmbBoxMjestoTroskovaEdit4.Items.Add(mtsif[0]);
            }



            mtsif.Close();
            connection66.Close();


            string username;
            username = Korisnik.korisnicko;

            string ime = "";
            string prezime = "";
            string odjel = "";
            
            SqlConnection connection3 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query3 = "SELECT [ime],[prezime],[odjel],[idbroj] FROM Korisnici WHERE [username] = @usr ";

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
                idbroj = (reader123["idbroj"].ToString());
            }

            else
            {
                reader123.Close();
                connection3.Close();
            }
            lblIme.Text = ime + " " + prezime;
            lblOdjel.Text = odjel;


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
            
        private void button4_Click(object sender, EventArgs e)
        {


            Form3 myForms = new Form3();
            //  this.Hide();
            myForms.ShowDialog();
            //this.Close();


        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            Form5 myForm = new Form5();
            //  this.Hide();
            myForm.ShowDialog();
            //this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string totalstatus = "";
            string kontrstatus = "";
            SqlConnection connection2 = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query2 = "SELECT [total],[status] FROM DiReqt WHERE id = @probids ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command12 = new SqlCommand(query2, connection2);
            connection2.Open();
            command12.Parameters.AddWithValue("@probids", textBox59.Text);

            SqlDataReader reader12 = command12.ExecuteReader();


            if (reader12.Read())
            {


                totalstatus = (reader12["total"].ToString());
                kontrstatus = (reader12["status"].ToString());
            }

            else
            {
                reader12.Close();
                connection2.Close();
            }

            if (string.IsNullOrEmpty(totalstatus)&&string.IsNullOrEmpty(kontrstatus))
            {
                MessageBox.Show(mZahPP);
                
            }
            else if (string.IsNullOrEmpty(kontrstatus))
            {

                MessageBox.Show(mZahK);
                
            }
            else if (kontrstatus.Contains("Odbijeno") == true)
            {
                MessageBox.Show(mZahOdb);
            }
            else if (kontrstatus.Contains("Odobreno") == true)
            {
                MessageBox.Show(mZahOdo);
            }

            textBox59.Text = "";
        }


        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }


        string izvor = "";

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox60.Text))
            { MessageBox.Show(mNBr);
                return;
            }


            int parsedValue;
            if (!int.TryParse(textBox60.Text, out parsedValue))
            {
                MessageBox.Show(mSID);
                return;
            }




            SqlConnection con = GetConnection();


            PDF p = new PDF();
            p.id = textBox2.Text;

            string broj = textBox60.Text;


            string ime = "";
            string datum = "";
            string ident = "";
            string odjel = "";
            string idbroj = "";
            string imnab = "";

            string query3 = "SELECT [podnositelj],[datum],[id],[odjel],[idbroj],[nabavka] FROM DiReqt WHERE [id] = @id ";





            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", textBox60.Text);

            SqlDataReader reader123 = command123.ExecuteReader();



            if (reader123.Read())
            {


                ime = (reader123["podnositelj"].ToString());
                datum = (reader123["datum"].ToString());
                ident = (reader123["id"].ToString());
                odjel = (reader123["odjel"].ToString());
                idbroj = (reader123["idbroj"].ToString());
                imnab = (reader123["nabavka"].ToString());

                reader123.Close();
                con.Close();
            }

            else
            {
                reader123.Close();
                con.Close();
            }


            bool result;
            


            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";




            if (ime.Equals(lblIme.Text) || imnab.Equals(lblIme.Text))
            {

                try
                {

                    result = PDFC.Create_PDF(broj);

                    axAcroPDF1.src = izvor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.Message);
                }
                finally
                {File.Delete(izvor); }
                
            }
            else
            {
                MessageBox.Show(mSPod);
            }
            

            //   axAcroPDF1.src = folderPath2;

            //  File.Delete(folderPath2);


        }


               






        private void button9_Click(object sender, EventArgs e)
        {
         /*   SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [podnositelj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel],[total] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             *
            string ime = "";
            string datum = "";
            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@zid", textBox60.Text);

            SqlDataReader reader1 = command1.ExecuteReader();


            if (reader1.Read())
            {
                ime = (reader1["podnositelj"].ToString());
                 datum = (reader1["datum"].ToString());
                

            }

            else
            {
                reader1.Close();
            }

            connection.Close();

            string folderPath2 = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + textBox60.Text.Trim() + " COPY" + ".pdf";
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


                printProcess.Start();
                // printProcess.Start();
                //  printProcess.Start();
                // printProcess.Start();


                //   printProcess.WaitForInputIdle(); 



                MessageBox.Show("Zahtjev je na printanju!");
               
                textBox60.Text = "";
                axAcroPDF1.src = ("none");
            }*/
            }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 myForm = new Form7();
            //  this.Hide();
            myForm.ShowDialog();
            //this.Close();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelButtoni_Paint(object sender, PaintEventArgs e)
        {

        }


        string provjeraime = "";
        string provjerastok = "";

        private void ListPDF()
        {

            txtIdentSifraEdit1.Text = pdf.ident_sifra;
            txtIdentSifraEdit2.Text = pdf.ident_sifra2;
            txtIdentSifraEdit3.Text = pdf.ident_sifra3;
            txtIdentSifraEdit4.Text = pdf.ident_sifra4;
            txtIdentSifraEdit5.Text = pdf.ident_sifra5;
            txtIdentSifraEdit6.Text = pdf.ident_sifra6;
            txtIdentSifraEdit7.Text = pdf.ident_sifra7;
            txtIdentSifraEdit8.Text = pdf.ident_sifra8;
            txtIdentSifraEdit9.Text = pdf.ident_sifra9;
            txtIdentSifraEdit10.Text = pdf.ident_sifra10;
            txtIdentSifraEdit11.Text = pdf.ident_sifra11;

            txtNazivMaterijalaEdit1.Text = pdf.n;
            txtNazivMaterijalaEdit2.Text = pdf.n2;
            txtNazivMaterijalaEdit3.Text = pdf.n3;
            txtNazivMaterijalaEdit4.Text = pdf.n4;
            txtNazivMaterijalaEdit5.Text = pdf.n5;
            txtNazivMaterijalaEdit6.Text = pdf.n6;
            txtNazivMaterijalaEdit7.Text = pdf.n7;
            txtNazivMaterijalaEdit8.Text = pdf.n8;
            txtNazivMaterijalaEdit9.Text = pdf.n9;
            txtNazivMaterijalaEdit10.Text = pdf.n10;
            txtNazivMaterijalaEdit11.Text = pdf.n11;

            txtJMEdit1.Text = pdf.jm;
            txtJMEdit2.Text = pdf.jm2;
            txtJMEdit3.Text = pdf.jm3;
            txtJMEdit4.Text = pdf.jm4;
            txtJMEdit5.Text = pdf.jm5;
            txtJMEdit6.Text = pdf.jm6;
            txtJMEdit7.Text = pdf.jm7;
            txtJMEdit8.Text = pdf.jm8;
            txtJMEdit9.Text = pdf.jm9;
            txtJMEdit10.Text = pdf.jm10;
            txtJMEdit11.Text = pdf.jm11;


            cmbBoxMjestoTroskovaEdit1.Text = pdf.mt;
            cmbBoxMjestoTroskovaEdit2.Text = pdf.mt2;
            cmbBoxMjestoTroskovaEdit3.Text = pdf.mt3;
            cmbBoxMjestoTroskovaEdit4.Text = pdf.mt4;


            cmbKolicinaEdit1.Text = pdf.k;
            cmbKolicinaEdit2.Text = pdf.k2;
            cmbKolicinaEdit3.Text = pdf.k3;
            cmbKolicinaEdit4.Text = pdf.k4;
            cmbKolicinaEdit5.Text = pdf.k5;
            cmbKolicinaEdit6.Text = pdf.k6;
            cmbKolicinaEdit7.Text = pdf.k7;
            cmbKolicinaEdit8.Text = pdf.k8;
            cmbKolicinaEdit9.Text = pdf.k9;
            cmbKolicinaEdit10.Text = pdf.k10;
            cmbKolicinaEdit11.Text = pdf.k11;

            txtBoxNapomenaEdit.Text = pdf.napo;
            txtBoxSkladisteEdit.Text = pdf.sklad;
            txtTehnickaPripremaEdit.Text = pdf.tehp;

            txtMaxEdit1.Text = pdf.max;
            txtMaxEdit2.Text = pdf.max2;
            txtMaxEdit3.Text = pdf.max3;

            txtMinEdit1.Text = pdf.min;
            txtMinEdit2.Text = pdf.min2;
            txtMinEdit3.Text = pdf.min3;

            txtStanjeEdit1.Text = pdf.stanje;
            txtStanjeEdit2.Text = pdf.stanje2;
            txtStanjeEdit3.Text = pdf.stanje3;




        }

        private void btnLoadEdit_Click(object sender, EventArgs e)
        {



            string nab = "";
            string rukov = "";

            

            SqlConnection con = GetConnection();






            if (string.IsNullOrEmpty(txtBoxLoadEdit.Text))
            {
                MessageBox.Show(mZBr);

            }


            string check = "Select [podnositelj],[stok],[nabavka],[rukovodilac] from DiReqt WHERE [id]=@id ";
            SqlCommand provjera = new SqlCommand(check, con);
            con.Open();
            provjera.Parameters.AddWithValue("@id", txtBoxLoadEdit.Text);
            SqlDataReader readerprovjera = provjera.ExecuteReader();

            if (readerprovjera.Read())

            {

                provjeraime = (readerprovjera["podnositelj"].ToString());
                provjerastok = (readerprovjera["stok"].ToString());
                nab = (readerprovjera["nabavka"].ToString());
                rukov = (readerprovjera["rukovodilac"].ToString());
                con.Close();
                readerprovjera.Close();
            }
            else
            { con.Close();
                readerprovjera.Close();
                return;
                }

            if (string.IsNullOrEmpty(rukov))
            { }
            else
            {
                MessageBox.Show(mZS + rukov);
                return;
            }


            if (string.IsNullOrEmpty(nab))
            { }
            else
            { MessageBox.Show(mZC + nab);
                return;
            }

            if (provjeraime.Equals(lblIme.Text))
            {


                panelModifikacijaZahjeva.Visible = true;
                if (provjerastok.Equals("DA"))
                {

                    lblMaxEdit.Visible = true;
                    lblMinEdit.Visible = true;
                    lblStanjeEdit.Visible = true;

                    txtMinEdit1.Visible = true;
                    txtMaxEdit1.Visible = true;
                    txtStanjeEdit1.Visible = true;
                    txtMinEdit3.Visible = true;
                    txtMaxEdit3.Visible = true;
                    txtStanjeEdit3.Visible = true;

                    txtMinEdit2.Visible = true;
                    txtMaxEdit2.Visible = true;
                    txtStanjeEdit2.Visible = true;


                }

                else
                {
                    lblMaxEdit.Visible = false;
                    lblMinEdit.Visible = false;
                    lblStanjeEdit.Visible = false;

                    txtMinEdit1.Visible = false;
                    txtMaxEdit1.Visible = false;
                    txtStanjeEdit1.Visible = false;
                    txtMinEdit3.Visible = false;
                    txtMaxEdit3.Visible = false;
                    txtStanjeEdit3.Visible = false;

                    txtMinEdit2.Visible = false;
                    txtMaxEdit2.Visible = false;
                    txtStanjeEdit2.Visible = false;

                }


                try
                {
                    
                    pdf = PDFC.GetPDF(txtBoxLoadEdit.Text);
                    if (pdf == null)
                    {
                        MessageBox.Show(mNoZah);
                    }
                    else
                    {
                        this.ListPDF();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.Message);
                }







            }

            else
            {
                MessageBox.Show(mNO);
                txtBoxLoadEdit.Text = "";
                return;

            }

        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (string.IsNullOrEmpty(txtBoxLoadEdit.Text))
                {
                    MessageBox.Show(mNPIS);
                    return;
                }

            }
            if (string.IsNullOrEmpty(cmbBoxMjestoTroskovaEdit1.Text))
            {
                MessageBox.Show(mNPMT);
                return;
            }
            if (string.IsNullOrEmpty(cmbKolicinaEdit1.Text))
            {
                MessageBox.Show(mNPKol);
                return;
            }
            if (string.IsNullOrEmpty(txtNazivMaterijalaEdit1.Text))
            {
                MessageBox.Show(mNPNM);
                return;
            }
            if (string.IsNullOrEmpty(txtTehnickaPripremaEdit.Text))
            {
                MessageBox.Show(mNPTP);
                return;
            }




            SqlConnection con = GetConnection();


            string sit = "";
            string sit2 = "";
            string sit3 = "";
            string sit4 = "";



            string sif1 = "Select [sifra_mt] from Mjesto_troska WHERE [Naziv_mt]=@id ";

            SqlCommand sifre = new SqlCommand(sif1, con);

            con.Open();
            sifre.Parameters.AddWithValue("@id", cmbBoxMjestoTroskovaEdit1.Text);
            SqlDataReader readerprovjera = sifre.ExecuteReader();

            if (readerprovjera.Read())

            {

                sit = (readerprovjera["sifra_mt"].ToString());
                
                con.Close();
                readerprovjera.Close();
            }
            else
            {
                con.Close();
                readerprovjera.Close();
                
            }


          

            SqlCommand sifre2 = new SqlCommand(sif1, con);

            con.Open();
            sifre2.Parameters.AddWithValue("@id", cmbBoxMjestoTroskovaEdit2.Text);
            SqlDataReader readerprovjera2 = sifre2.ExecuteReader();

            if (readerprovjera2.Read())

            {

                sit2 = (readerprovjera2["sifra_mt"].ToString());
               
                con.Close();
                readerprovjera2.Close();
            }
            else
            {
                con.Close();
                readerprovjera2.Close();
                
            }


            string sif3 = "Select [sifra_mt] from Mjesto_troska WHERE [Naziv_mt]=@id ";

            SqlCommand sifre3 = new SqlCommand(sif3, con);

            con.Open();
            sifre3.Parameters.AddWithValue("@id", cmbBoxMjestoTroskovaEdit3.Text);
            SqlDataReader readerprovjera3 = sifre3.ExecuteReader();

            if (readerprovjera3.Read())

            {

                sit3 = (readerprovjera3["sifra_mt"].ToString());
                
                con.Close();
                readerprovjera.Close();
            }
            else
            {
                con.Close();
                readerprovjera.Close();
               
            }


            string sif4 = "Select [sifra_mt] from Mjesto_troska WHERE [Naziv_mt]=@id ";

            SqlCommand sifre4 = new SqlCommand(sif4, con);

            con.Open();
            sifre4.Parameters.AddWithValue("@id", cmbBoxMjestoTroskovaEdit4.Text);
            SqlDataReader readerprovjera4 = sifre4.ExecuteReader();

            if (readerprovjera4.Read())

            {

                sit4 = (readerprovjera4["sifra_mt"].ToString());
               
                con.Close();
                readerprovjera4.Close();
            }
            else
            {
                con.Close();
                readerprovjera4.Close();
               
            }






            try
            {
                PDF updf = new PDF();
                pdf.id = txtBoxLoadEdit.Text;

                updf.ident_sifra = txtIdentSifraEdit1.Text;
                updf.ident_sifra2 = txtIdentSifraEdit2.Text;
                updf.ident_sifra3 = txtIdentSifraEdit3.Text;
                updf.ident_sifra4 = txtIdentSifraEdit4.Text;
                updf.ident_sifra5 = txtIdentSifraEdit5.Text;
                updf.ident_sifra6 = txtIdentSifraEdit6.Text;
                updf.ident_sifra7 = txtIdentSifraEdit7.Text;
                updf.ident_sifra8 = txtIdentSifraEdit8.Text;
                updf.ident_sifra9 = txtIdentSifraEdit9.Text;
                updf.ident_sifra10 = txtIdentSifraEdit10.Text;
                updf.ident_sifra11 = txtIdentSifraEdit11.Text;


                updf.n = txtNazivMaterijalaEdit1.Text;
                updf.n2 = txtNazivMaterijalaEdit2.Text;
                updf.n3 = txtNazivMaterijalaEdit3.Text;
                updf.n4 = txtNazivMaterijalaEdit4.Text;
                updf.n5 = txtNazivMaterijalaEdit5.Text;
                updf.n6 = txtNazivMaterijalaEdit6.Text;
                updf.n7 = txtNazivMaterijalaEdit7.Text;
                updf.n8 = txtNazivMaterijalaEdit8.Text;
                updf.n9 = txtNazivMaterijalaEdit9.Text;
                updf.n10 = txtNazivMaterijalaEdit10.Text;
                updf.n11 = txtNazivMaterijalaEdit11.Text;

                updf.jm = txtJMEdit1.Text;
                updf.jm2 = txtJMEdit2.Text;
                updf.jm3 = txtJMEdit3.Text;
                updf.jm4 = txtJMEdit4.Text;
                updf.jm5 = txtJMEdit5.Text;
                updf.jm6 = txtJMEdit6.Text;
                updf.jm7 = txtJMEdit7.Text;
                updf.jm8 = txtJMEdit8.Text;
                updf.jm9 = txtJMEdit9.Text;
                updf.jm10 = txtJMEdit10.Text;
                updf.jm11 = txtJMEdit11.Text;




                updf.mt = cmbBoxMjestoTroskovaEdit1.Text;
                updf.mt2 = cmbBoxMjestoTroskovaEdit2.Text;
                updf.mt3 = cmbBoxMjestoTroskovaEdit3.Text;
                updf.mt4 = cmbBoxMjestoTroskovaEdit4.Text;


                updf.st = sit;
                updf.st2 = sit2;
                updf.st3 = sit3;
                updf.st4 = sit4;



                updf.k = cmbKolicinaEdit1.Text;
                updf.k2 = cmbKolicinaEdit2.Text;
                updf.k3 = cmbKolicinaEdit3.Text;
                updf.k4 = cmbKolicinaEdit4.Text;
                updf.k5 = cmbKolicinaEdit5.Text;
                updf.k6 = cmbKolicinaEdit6.Text;
                updf.k7 = cmbKolicinaEdit7.Text;
                updf.k8 = cmbKolicinaEdit8.Text;
                updf.k9 = cmbKolicinaEdit9.Text;
                updf.k10 = cmbKolicinaEdit10.Text;
                updf.k11 = cmbKolicinaEdit11.Text;


                updf.napo = txtBoxNapomenaEdit.Text;
                updf.sklad = txtBoxSkladisteEdit.Text;
                updf.tehp = txtTehnickaPripremaEdit.Text;

                updf.max = txtMaxEdit1.Text;
                updf.max2 = txtMaxEdit2.Text;
                updf.max3 = txtMaxEdit3.Text;

                updf.min = txtMinEdit1.Text;
                updf.min2 = txtMinEdit2.Text;
                updf.min3 = txtMinEdit3.Text;

                updf.stanje = txtStanjeEdit1.Text;
                updf.stanje2 = txtStanjeEdit2.Text;
                updf.stanje3 = txtStanjeEdit3.Text;




                bool result;

                result = PDFC.ModifyStudent(pdf, updf);

                if (result)
                {
                    pdf = updf;
                    
                    MessageBox.Show(mA);
                }
                else
                {
                    MessageBox.Show(mNA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            btnSaveEdit.Visible = false;
            btnEmailEdit.Visible = true;







        }

        private void panelModifikacijaZahjeva_Paint(object sender, PaintEventArgs e)
        {

        }



        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }


        
        private void btnEmailEdit_Click(object sender, EventArgs e)
        {






            btnSaveEdit.Visible = true;
            btnEmailEdit.Visible = false;






            PDF p = new PDF();
            p.id = txtBoxLoadEdit.Text;

            string broj = txtBoxLoadEdit.Text ;




            bool result;

            result = PDFC.Create_PDF(broj);


            string izvor = "";

            string idruk = "";
            string ime = "";
            string datum = "";
            string ident = "";


            string query3 = "SELECT [podnositelj],[datum],[id] FROM DiReqt WHERE [id] = @id ";

            SqlConnection con = GetConnection();

            SqlCommand command123 = new SqlCommand(query3, con);
            con.Open();

            command123.Parameters.AddWithValue("@id", txtBoxLoadEdit.Text);

            SqlDataReader reader123 = command123.ExecuteReader();



            if (reader123.Read())
            {


                ime = (reader123["podnositelj"].ToString());
                datum = (reader123["datum"].ToString());
                ident = (reader123["id"].ToString());

                reader123.Close();
                con.Close();

            }

            else
            {
                reader123.Close();
                con.Close();
            }



            izvor = @"C:\Users\Public\Documents\ZZM\" + " " + ime + " " + datum + " No. " + ident.Trim() + ".pdf";



            

            string q = "SELECT [idbroj] FROM Odjeli WHERE [odjel] = @idbr ";

            

            SqlCommand comn = new SqlCommand(q, con);
            con.Open();

            comn.Parameters.AddWithValue("@idbr", lblOdjel.Text);

            SqlDataReader re = comn.ExecuteReader();



            if (re.Read())
            {


                idruk = (re["idbroj"].ToString());


                re.Close();
                con.Close();

            }

            else
            {
                re.Close();
                con.Close();
            }


            string q2 = "SELECT [email] FROM Korisnici WHERE [idbroj] = @idr ";



            SqlCommand comn2 = new SqlCommand(q2, con);
            con.Open();

            comn2.Parameters.AddWithValue("@idr", idruk);

            SqlDataReader red = comn2.ExecuteReader();


            string em = "";

            if (red.Read())
            {


                em = (red["email"].ToString());


                red.Close();
                con.Close();

            }

            else
            {
                red.Close();
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




                message.Subject = "Potrebno odobrenje za zahtjev : " + this.lblIme.Text.Trim() + " " + DateTime.Now.ToShortDateString() + " No. " + txtBoxLoadEdit;




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

            ClearTextBoxes();
            cmbBoxMjestoTroskovaEdit1.Text = "";
            cmbBoxMjestoTroskovaEdit2.Text = "";
            cmbBoxMjestoTroskovaEdit3.Text = "";
            cmbBoxMjestoTroskovaEdit4.Text = "";

            cmbKolicinaEdit1.Text = "";
            cmbKolicinaEdit2.Text = "";
            cmbKolicinaEdit3.Text = "";
            cmbKolicinaEdit4.Text = "";
            cmbKolicinaEdit5.Text = "";
            cmbKolicinaEdit6.Text = "";
            cmbKolicinaEdit7.Text = "";
            cmbKolicinaEdit8.Text = "";
            cmbKolicinaEdit9.Text = "";
            cmbKolicinaEdit10.Text = "";
            cmbKolicinaEdit11.Text = "";

            btnSaveEdit.Visible = true;
            btnEmailEdit.Visible = false;




        }

        private void panelNoviZahtjevPolja_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}


          

