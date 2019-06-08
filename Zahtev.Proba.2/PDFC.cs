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
    class PDFC
    {
       

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        public static string GetValues(string id)


        {



            PDF pd = new PDF();







            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [id], [podnositelj],[idbroj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status],[nabavka]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[datum_kontroling],[podobrenje],[dodobrenje],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel],[total],[rukovodilac],[rukodo],[tehp] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab],[pod],[pok]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */
             
            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@zid", id);

            SqlDataReader reader1 = command1.ExecuteReader();


            if (reader1.Read())
            {
                pd.idbroj = (reader1["idbroj"].ToString());
                pd.n = (reader1["naziv"].ToString());
                pd.n2 = (reader1["naziv2"].ToString());
                pd.n3 = (reader1["naziv3"].ToString());
                pd.n4 = (reader1["naziv4"].ToString());
                pd.n5 = (reader1["naziv5"].ToString());
                pd.n6 = (reader1["naziv6"].ToString());
                pd.n7 = (reader1["naziv7"].ToString());
                pd.n8 = (reader1["naziv8"].ToString());
                pd.n9 = (reader1["naziv9"].ToString());
                pd.n10 = (reader1["naziv10"].ToString());
                pd.n11 = (reader1["naziv11"].ToString());

                pd.k = (reader1["kolicina"].ToString());
                pd.k2 = (reader1["kolicina2"].ToString());
                pd.k3 = (reader1["kolicina3"].ToString());
                pd.k4 = (reader1["kolicina4"].ToString());
                pd.k5 = (reader1["kolicina5"].ToString());
                pd.k6 = (reader1["kolicina6"].ToString());
                pd.k7 = (reader1["kolicina7"].ToString());
                pd.k8 = (reader1["kolicina8"].ToString());
                pd.k9 = (reader1["kolicina9"].ToString());
                pd.k10 = (reader1["kolicina10"].ToString());
                pd.k11 = (reader1["kolicina11"].ToString());


                pd.ident_sifra = (reader1["ident_sifra"].ToString());
                pd.ident_sifra2 = (reader1["ident_sifra2"].ToString());
                pd.ident_sifra3 = (reader1["ident_sifra3"].ToString());
                pd.ident_sifra4 = (reader1["ident_sifra4"].ToString());
                pd.ident_sifra5 = (reader1["ident_sifra5"].ToString());
                pd.ident_sifra6 = (reader1["ident_sifra6"].ToString());
                pd.ident_sifra7 = (reader1["ident_sifra7"].ToString());
                pd.ident_sifra8 = (reader1["ident_sifra8"].ToString());
                pd.ident_sifra9 = (reader1["ident_sifra9"].ToString());
                pd.ident_sifra10 = (reader1["ident_sifra10"].ToString());
                pd.ident_sifra11 = (reader1["ident_sifra11"].ToString());

                pd.jm = (reader1["jm"].ToString());
                pd.jm2 = (reader1["jm2"].ToString());
                pd.jm3 = (reader1["jm3"].ToString());
                pd.jm4 = (reader1["jm4"].ToString());
                pd.jm5 = (reader1["jm5"].ToString());
                pd.jm6 = (reader1["jm6"].ToString());
                pd.jm7 = (reader1["jm7"].ToString());
                pd.jm8 = (reader1["jm8"].ToString());
                pd.jm9 = (reader1["jm9"].ToString());
                pd.jm10 = (reader1["jm10"].ToString());
                pd.jm11 = (reader1["jm11"].ToString());
                pd.mt = (reader1["naziv_mt"].ToString());
                pd.mt2 = (reader1["naziv_mt2"].ToString());
                pd.mt3 = (reader1["naziv_mt3"].ToString());
                pd.mt4 = (reader1["naziv_mt4"].ToString());
                pd.st = (reader1["sifra_mt"].ToString());
                pd.st2 = (reader1["sifra_mt2"].ToString());
                pd.st3 = (reader1["sifra_mt3"].ToString());
                pd.st4 = (reader1["sifra_mt4"].ToString());
                pd.ime = (reader1["podnositelj"].ToString());
                pd.datum = (reader1["datum"].ToString());
                pd.datumnab = (reader1["datum_nabavka"].ToString());
                pd.stoks = (reader1["stok"].ToString());
                pd.vrsta = (reader1["vrsta"].ToString());
                pd.min = (reader1["min"].ToString());
                pd.min2 = (reader1["min2"].ToString());
                pd.min3 = (reader1["min3"].ToString());
                pd.max = (reader1["max"].ToString());
                pd.max2 = (reader1["max2"].ToString());
                pd.max3 = (reader1["max3"].ToString());
                pd.stanje = (reader1["stanje"].ToString());
                pd.stanje2 = (reader1["stanje2"].ToString());
                pd.stanje3 = (reader1["stanje3"].ToString());
                pd.sklad = (reader1["sklad"].ToString());
                pd.napo = (reader1["napomena"].ToString());
                pd.napnab = (reader1["napnab"].ToString());
                pd.tehp = (reader1["tehp"].ToString());
                pd.ruko = (reader1["rukovodilac"].ToString());

                pd.ruod = (reader1["rukodo"].ToString());

                pd.nam = (reader1["nabavka"].ToString());

                pd.valuta = (reader1["valuta"].ToString());
                pd.status = (reader1["status"].ToString());

                pd.ok = (reader1["odobrena_kolicina"].ToString());
                pd.ok2 = (reader1["odobrena_kolicina2"].ToString());
                pd.ok3 = (reader1["odobrena_kolicina3"].ToString());
                pd.ok4 = (reader1["odobrena_kolicina4"].ToString());
                pd.ok5 = (reader1["odobrena_kolicina5"].ToString());
                pd.ok6 = (reader1["odobrena_kolicina6"].ToString());
                pd.ok7 = (reader1["odobrena_kolicina7"].ToString());
                pd.ok8 = (reader1["odobrena_kolicina8"].ToString());
                pd.ok9 = (reader1["odobrena_kolicina9"].ToString());
                pd.ok10 = (reader1["odobrena_kolicina10"].ToString());
                pd.ok11 = (reader1["odobrena_kolicina11"].ToString());
                pd.datkon = (reader1["datum_kontroling"].ToString());
                pd.kod = (reader1["podobrenje"].ToString());
                pd.dod = (reader1["dodobrenje"].ToString());
                pd.cij = (reader1["cijena"].ToString());
                pd.cij2 = (reader1["cijena2"].ToString());
                pd.cij3 = (reader1["cijena3"].ToString());
                pd.cij4 = (reader1["cijena4"].ToString());
                pd.cij5 = (reader1["cijena5"].ToString());
                pd.cij6 = (reader1["cijena6"].ToString());
                pd.cij7 = (reader1["cijena7"].ToString());
                pd.cij8 = (reader1["cijena8"].ToString());
                pd.cij9 = (reader1["cijena9"].ToString());
                pd.cij10 = (reader1["cijena10"].ToString());
                pd.cij11 = (reader1["cijena11"].ToString());

                pd.cijeuro = (reader1["cijena_eur"].ToString());
                pd.cijeuro2 = (reader1["cijena_eur2"].ToString());
                pd.cijeuro3 = (reader1["cijena_eur3"].ToString());
                pd.cijeuro4 = (reader1["cijena_eur4"].ToString());
                pd.cijeuro5 = (reader1["cijena_eur5"].ToString());
                pd.cijeuro6 = (reader1["cijena_eur6"].ToString());
                pd.cijeuro7 = (reader1["cijena_eur7"].ToString());
                pd.cijeuro8 = (reader1["cijena_eur8"].ToString());
                pd.cijeuro9 = (reader1["cijena_eur9"].ToString());
                pd.cijeuro10 = (reader1["cijena_eur10"].ToString());
                pd.cijeuro11 = (reader1["cijena_eur11"].ToString());

                pd.odjel = (reader1["odjel"].ToString());
                pd.tot = (reader1["total"].ToString());
                pd.ide = (reader1["id"].ToString());
                pd.pod = (reader1["pod"].ToString());
                pd.pok = (reader1["pok"].ToString());
            }

            else
            {
                reader1.Close();
            }

            connection.Close();

          

            if (string.IsNullOrEmpty(pd.nam))

            {

            }

            else
            {


                SqlConnection connect = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                //string que = "SELECT [inicijali] FROM Korisnici WHERE [ime]+[prezime]=@usr and [odjel]='Nabavka' ";

                string que = "SELECT [inicijali] FROM Korisnici WHERE [[ime] + ' ' + [prezime]=@usr";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */

                SqlCommand comman = new SqlCommand(que, connect);
                connect.Open();
                comman.Parameters.AddWithValue("@usr", pd.nam);

                SqlDataReader re = comman.ExecuteReader();


                if (re.Read())
                {


                    pd.ini = (re["inicijali"].ToString());



                }

                
                else
                {
                    pd.ini = "";
                    re.Close();
                    connect.Close();
                }



            }







            return pd.idbroj;
        }




        public static PDF GetPDF(string id)


        {



            PDF pd = new PDF();







            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [id], [podnositelj],[idbroj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status],[nabavka]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[datum_kontroling],[podobrenje],[dodobrenje],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel],[total],[rukovodilac],[rukodo],[tehp] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab],[pok],[pod]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@zid", id);

            SqlDataReader reader1 = command1.ExecuteReader();


            if (reader1.Read())
            {
                pd.idbroj = (reader1["idbroj"].ToString());
                pd.n = (reader1["naziv"].ToString());
                pd.n2 = (reader1["naziv2"].ToString());
                pd.n3 = (reader1["naziv3"].ToString());
                pd.n4 = (reader1["naziv4"].ToString());
                pd.n5 = (reader1["naziv5"].ToString());
                pd.n6 = (reader1["naziv6"].ToString());
                pd.n7 = (reader1["naziv7"].ToString());
                pd.n8 = (reader1["naziv8"].ToString());
                pd.n9 = (reader1["naziv9"].ToString());
                pd.n10 = (reader1["naziv10"].ToString());
                pd.n11 = (reader1["naziv11"].ToString());

                pd.k = (reader1["kolicina"].ToString());
                pd.k2 = (reader1["kolicina2"].ToString());
                pd.k3 = (reader1["kolicina3"].ToString());
                pd.k4 = (reader1["kolicina4"].ToString());
                pd.k5 = (reader1["kolicina5"].ToString());
                pd.k6 = (reader1["kolicina6"].ToString());
                pd.k7 = (reader1["kolicina7"].ToString());
                pd.k8 = (reader1["kolicina8"].ToString());
                pd.k9 = (reader1["kolicina9"].ToString());
                pd.k10 = (reader1["kolicina10"].ToString());
                pd.k11 = (reader1["kolicina11"].ToString());


                pd.ident_sifra = (reader1["ident_sifra"].ToString());
                pd.ident_sifra2 = (reader1["ident_sifra2"].ToString());
                pd.ident_sifra3 = (reader1["ident_sifra3"].ToString());
                pd.ident_sifra4 = (reader1["ident_sifra4"].ToString());
                pd.ident_sifra5 = (reader1["ident_sifra5"].ToString());
                pd.ident_sifra6 = (reader1["ident_sifra6"].ToString());
                pd.ident_sifra7 = (reader1["ident_sifra7"].ToString());
                pd.ident_sifra8 = (reader1["ident_sifra8"].ToString());
                pd.ident_sifra9 = (reader1["ident_sifra9"].ToString());
                pd.ident_sifra10 = (reader1["ident_sifra10"].ToString());
                pd.ident_sifra11 = (reader1["ident_sifra11"].ToString());

                pd.jm = (reader1["jm"].ToString());
                pd.jm2 = (reader1["jm2"].ToString());
                pd.jm3 = (reader1["jm3"].ToString());
                pd.jm4 = (reader1["jm4"].ToString());
                pd.jm5 = (reader1["jm5"].ToString());
                pd.jm6 = (reader1["jm6"].ToString());
                pd.jm7 = (reader1["jm7"].ToString());
                pd.jm8 = (reader1["jm8"].ToString());
                pd.jm9 = (reader1["jm9"].ToString());
                pd.jm10 = (reader1["jm10"].ToString());
                pd.jm11 = (reader1["jm11"].ToString());
                pd.mt = (reader1["naziv_mt"].ToString());
                pd.mt2 = (reader1["naziv_mt2"].ToString());
                pd.mt3 = (reader1["naziv_mt3"].ToString());
                pd.mt4 = (reader1["naziv_mt4"].ToString());
                pd.st = (reader1["sifra_mt"].ToString());
                pd.st2 = (reader1["sifra_mt2"].ToString());
                pd.st3 = (reader1["sifra_mt3"].ToString());
                pd.st4 = (reader1["sifra_mt4"].ToString());
                pd.ime = (reader1["podnositelj"].ToString());
                pd.datum = (reader1["datum"].ToString());
                pd.datumnab = (reader1["datum_nabavka"].ToString());
                pd.stoks = (reader1["stok"].ToString());
                pd.vrsta = (reader1["vrsta"].ToString());
                pd.min = (reader1["min"].ToString());
                pd.min2 = (reader1["min2"].ToString());
                pd.min3 = (reader1["min3"].ToString());
                pd.max = (reader1["max"].ToString());
                pd.max2 = (reader1["max2"].ToString());
                pd.max3 = (reader1["max3"].ToString());
                pd.stanje = (reader1["stanje"].ToString());
                pd.stanje2 = (reader1["stanje2"].ToString());
                pd.stanje3 = (reader1["stanje3"].ToString());
                pd.sklad = (reader1["sklad"].ToString());
                pd.napo = (reader1["napomena"].ToString());
                pd.napnab = (reader1["napnab"].ToString());
                pd.tehp = (reader1["tehp"].ToString());
                pd.ruko = (reader1["rukovodilac"].ToString());

                pd.ruod = (reader1["rukodo"].ToString());

                pd.nam = (reader1["nabavka"].ToString());

                pd.valuta = (reader1["valuta"].ToString());
                pd.status = (reader1["status"].ToString());

                pd.ok = (reader1["odobrena_kolicina"].ToString());
                pd.ok2 = (reader1["odobrena_kolicina2"].ToString());
                pd.ok3 = (reader1["odobrena_kolicina3"].ToString());
                pd.ok4 = (reader1["odobrena_kolicina4"].ToString());
                pd.ok5 = (reader1["odobrena_kolicina5"].ToString());
                pd.ok6 = (reader1["odobrena_kolicina6"].ToString());
                pd.ok7 = (reader1["odobrena_kolicina7"].ToString());
                pd.ok8 = (reader1["odobrena_kolicina8"].ToString());
                pd.ok9 = (reader1["odobrena_kolicina9"].ToString());
                pd.ok10 = (reader1["odobrena_kolicina10"].ToString());
                pd.ok11 = (reader1["odobrena_kolicina11"].ToString());
                pd.datkon = (reader1["datum_kontroling"].ToString());
                pd.kod = (reader1["podobrenje"].ToString());
                pd.dod = (reader1["dodobrenje"].ToString());
                pd.cij = (reader1["cijena"].ToString());
                pd.cij2 = (reader1["cijena2"].ToString());
                pd.cij3 = (reader1["cijena3"].ToString());
                pd.cij4 = (reader1["cijena4"].ToString());
                pd.cij5 = (reader1["cijena5"].ToString());
                pd.cij6 = (reader1["cijena6"].ToString());
                pd.cij7 = (reader1["cijena7"].ToString());
                pd.cij8 = (reader1["cijena8"].ToString());
                pd.cij9 = (reader1["cijena9"].ToString());
                pd.cij10 = (reader1["cijena10"].ToString());
                pd.cij11 = (reader1["cijena11"].ToString());

                pd.cijeuro = (reader1["cijena_eur"].ToString());
                pd.cijeuro2 = (reader1["cijena_eur2"].ToString());
                pd.cijeuro3 = (reader1["cijena_eur3"].ToString());
                pd.cijeuro4 = (reader1["cijena_eur4"].ToString());
                pd.cijeuro5 = (reader1["cijena_eur5"].ToString());
                pd.cijeuro6 = (reader1["cijena_eur6"].ToString());
                pd.cijeuro7 = (reader1["cijena_eur7"].ToString());
                pd.cijeuro8 = (reader1["cijena_eur8"].ToString());
                pd.cijeuro9 = (reader1["cijena_eur9"].ToString());
                pd.cijeuro10 = (reader1["cijena_eur10"].ToString());
                pd.cijeuro11 = (reader1["cijena_eur11"].ToString());

                pd.odjel = (reader1["odjel"].ToString());
                pd.tot = (reader1["total"].ToString());
                pd.ide = (reader1["id"].ToString());
                pd.pok= (reader1["pok"].ToString());
                pd.pod = (reader1["pod"].ToString());


            }

            else
            {
                reader1.Close();
            }

            connection.Close();


            /*
            if (string.IsNullOrEmpty(pd.nam))

            {

            }

            else
            {


                SqlConnection connect = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                //string que = "SELECT [inicijali] FROM Korisnici WHERE [ime]+[prezime]=@usr and [odjel]='Nabavka' ";

                string que = "SELECT [inicijali] FROM Korisnici WHERE [[ime] + ' ' + [prezime]=@usr";

                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */
                 /*
                SqlCommand comman = new SqlCommand(que, connect);
                connect.Open();
                comman.Parameters.AddWithValue("@usr", pd.nam);

                SqlDataReader re = comman.ExecuteReader();


                if (re.Read())
                {


                    pd.ini = (re["inicijali"].ToString());



                }


                else
                {
                    pd.ini = "";
                    re.Close();
                    connect.Close();
                }

            

            }

            */





            return pd;
        }


        public static bool ModifyStudent(PDF currZah, PDF mZah)
        {
            SqlConnection con = GetConnection();
            try
            {

                SqlCommand update = new SqlCommand("Update DiReqt set naziv=@na,naziv2=@na2,naziv3=@na3,naziv4=@na4,naziv5=@na5,naziv6=@na6,naziv7=@na7,naziv8=@na8,naziv9=@na9,naziv10=@na10,naziv11=@na11,"
                    + " ident_sifra=@is,ident_sifra2=@is2,ident_sifra3=@is3,ident_sifra4=@is4,ident_sifra5=@is5,ident_sifra6=@is6,ident_sifra7=@is7,ident_sifra8=@is8,ident_sifra9=@is9,ident_sifra10=@is10,ident_sifra11=@is11, "
                    + " jm=@j,jm2=@j2,jm3=@j3,jm4=@j4,jm5=@j5,jm6=@j6,jm7=@j7,jm8=@j8,jm9=@j9,jm10=@j10,jm11=@j11, "
                    + " kolicina=@k, kolicina2=@k2, kolicina3=@k3, kolicina4=@k4, kolicina5=@k5, kolicina6=@k6, kolicina7=@k7, kolicina8=@k8, kolicina9=@k9, kolicina10=@k10, kolicina11=@k11,  "
                    + " naziv_mt=@mt, sifra_mt=@st ,naziv_mt2=@mt2, sifra_mt2=@st2 ,naziv_mt3=@mt3, sifra_mt3=@st3 ,naziv_mt4=@mt4, sifra_mt4=@st4 , "
                    + " min=@mi,max=@ma, stanje=@sta,min2=@mi2,max2=@ma2, stanje2=@sta2,min3=@mi3,max3=@ma3, stanje3=@sta3,tehp=@tp, napomena=@napo,sklad=@skl"
                    + "  where id=@zid", con);



                update.Parameters.AddWithValue("@na", mZah.n);
                update.Parameters.AddWithValue("@na2", mZah.n2);
                update.Parameters.AddWithValue("@na3", mZah.n3);
                update.Parameters.AddWithValue("@na4", mZah.n4);
                update.Parameters.AddWithValue("@na5", mZah.n5);
                update.Parameters.AddWithValue("@na6", mZah.n6);
                update.Parameters.AddWithValue("@na7", mZah.n7);
                update.Parameters.AddWithValue("@na8", mZah.n8);
                update.Parameters.AddWithValue("@na9", mZah.n9);
                update.Parameters.AddWithValue("@na10", mZah.n10);
                update.Parameters.AddWithValue("@na11", mZah.n11);

                update.Parameters.AddWithValue("@is", mZah.ident_sifra);
                update.Parameters.AddWithValue("@is2", mZah.ident_sifra2);
                update.Parameters.AddWithValue("@is3", mZah.ident_sifra3);
                update.Parameters.AddWithValue("@is4", mZah.ident_sifra4);
                update.Parameters.AddWithValue("@is5", mZah.ident_sifra5);
                update.Parameters.AddWithValue("@is6", mZah.ident_sifra6);
                update.Parameters.AddWithValue("@is7", mZah.ident_sifra7);
                update.Parameters.AddWithValue("@is8", mZah.ident_sifra8);
                update.Parameters.AddWithValue("@is9", mZah.ident_sifra9);
                update.Parameters.AddWithValue("@is10", mZah.ident_sifra10);
                update.Parameters.AddWithValue("@is11", mZah.ident_sifra11);

                update.Parameters.AddWithValue("@j", mZah.jm);
                update.Parameters.AddWithValue("@j2", mZah.jm2);
                update.Parameters.AddWithValue("@j3", mZah.jm3);
                update.Parameters.AddWithValue("@j4", mZah.jm4);
                update.Parameters.AddWithValue("@j5", mZah.jm5);
                update.Parameters.AddWithValue("@j6", mZah.jm6);
                update.Parameters.AddWithValue("@j7", mZah.jm7);
                update.Parameters.AddWithValue("@j8", mZah.jm8);
                update.Parameters.AddWithValue("@j9", mZah.jm9);
                update.Parameters.AddWithValue("@j10", mZah.jm10);
                update.Parameters.AddWithValue("@j11", mZah.jm11);

                update.Parameters.AddWithValue("@k", mZah.k);
                update.Parameters.AddWithValue("@k2", mZah.k2);
                update.Parameters.AddWithValue("@k3", mZah.k3);
                update.Parameters.AddWithValue("@k4", mZah.k4);
                update.Parameters.AddWithValue("@k5", mZah.k5);
                update.Parameters.AddWithValue("@k6", mZah.k6);
                update.Parameters.AddWithValue("@k7", mZah.k7);
                update.Parameters.AddWithValue("@k8", mZah.k8);
                update.Parameters.AddWithValue("@k9", mZah.k9);
                update.Parameters.AddWithValue("@k10", mZah.k10);
                update.Parameters.AddWithValue("@k11", mZah.k11);

                update.Parameters.AddWithValue("@mt", mZah.mt);
                update.Parameters.AddWithValue("@st", mZah.st);
                update.Parameters.AddWithValue("@mt2", mZah.mt2);
                update.Parameters.AddWithValue("@st2", mZah.st2);
                update.Parameters.AddWithValue("@mt3", mZah.mt3);
                update.Parameters.AddWithValue("@st3", mZah.st3);
                update.Parameters.AddWithValue("@mt4", mZah.mt4);
                update.Parameters.AddWithValue("@st4", mZah.st4);

                update.Parameters.AddWithValue("@mi", mZah.min);
                update.Parameters.AddWithValue("@ma", mZah.max);
                update.Parameters.AddWithValue("@sta", mZah.stanje);
                update.Parameters.AddWithValue("@mi2", mZah.min2);
                update.Parameters.AddWithValue("@ma2", mZah.max2);
                update.Parameters.AddWithValue("@sta2", mZah.stanje2);
                update.Parameters.AddWithValue("@mi3", mZah.min3);
                update.Parameters.AddWithValue("@ma3", mZah.max3);
                update.Parameters.AddWithValue("@sta3", mZah.stanje3);

                update.Parameters.AddWithValue("@tp", mZah.tehp);
                update.Parameters.AddWithValue("@napo", mZah.napo);
                update.Parameters.AddWithValue("@skl", mZah.sklad);

                update.Parameters.AddWithValue("@zid", currZah.id);

                con.Open();
                update.ExecuteNonQuery();
                return true;
            }
            finally
            {
                con.Close();
            }


        }


        public static bool Create_PDF(string id)
        {


            PDF pd = new PDF();







            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            string query = "SELECT [id], [podnositelj],[idbroj],[datum],[ident_sifra],[naziv],[jm],[kolicina],[ident_sifra2],[naziv2],[jm2],[kolicina2],[datum_nabavka]" +
                                                     ",[ident_sifra3],[naziv3],[jm3],[kolicina3] ,[ident_sifra4],[naziv4],[jm4],[kolicina4] ,[ident_sifra5],[naziv5],[jm5],[kolicina5]" +
                                                     ",[ident_sifra6],[naziv6],[jm6],[kolicina6],[ident_sifra7],[naziv7],[jm7],[kolicina7] ,[ident_sifra8],[naziv8],[jm8],[kolicina8]" +
                                                     ",[naziv_mt],[naziv_mt2],[naziv_mt3],[naziv_mt4],[sifra_mt],[sifra_mt2],[sifra_mt3],[sifra_mt4],[kontroling],[datum_kontroling],[status],[nabavka]" +
                                                     ",[min],[min2],[min3],[max],[max2],[max3],[stanje],[stanje2],[stanje3],[odobrena_kolicina],[odobrena_kolicina2],[odobrena_kolicina3],[odobrena_kolicina4]" +
                                                     ",[sklad],[datum_kontroling],[podobrenje],[dodobrenje],[napomena],[stok],[vrsta],[valuta],[odobrena_kolicina5],[odobrena_kolicina6],[odobrena_kolicina7],[odobrena_kolicina8],[odobrena_kolicina9],[odobrena_kolicina10],[odobrena_kolicina11]" +
                                                     ",[ident_sifra9],[naziv9],[jm9],[kolicina9] ,[ident_sifra10],[naziv10],[jm10],[kolicina10] ,[ident_sifra11],[naziv11],[jm11],[kolicina11]" +
                                                     ",[cijena],[cijena2],[cijena3],[cijena4],[cijena5],[cijena6],[cijena7],[cijena8],[cijena9],[cijena10],[cijena11],[odjel],[total],[rukovodilac],[rukodo],[tehp] " +
                                                     ",[cijena_eur],[cijena_eur2],[cijena_eur3],[cijena_eur4],[cijena_eur5],[cijena_eur6],[cijena_eur7],[cijena_eur8],[cijena_eur9],[cijena_eur10],[cijena_eur11],[napnab],[pok],[pod]" +

                                                     "FROM DiReqt WHERE id = @zid ";

            /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
             string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

             */

            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            command1.Parameters.AddWithValue("@zid", id);

            SqlDataReader reader1 = command1.ExecuteReader();


            if (reader1.Read())
            {
                pd.idbroj = (reader1["idbroj"].ToString());
                pd.n = (reader1["naziv"].ToString());
                pd.n2 = (reader1["naziv2"].ToString());
                pd.n3 = (reader1["naziv3"].ToString());
                pd.n4 = (reader1["naziv4"].ToString());
                pd.n5 = (reader1["naziv5"].ToString());
                pd.n6 = (reader1["naziv6"].ToString());
                pd.n7 = (reader1["naziv7"].ToString());
                pd.n8 = (reader1["naziv8"].ToString());
                pd.n9 = (reader1["naziv9"].ToString());
                pd.n10 = (reader1["naziv10"].ToString());
                pd.n11 = (reader1["naziv11"].ToString());

                pd.k = (reader1["kolicina"].ToString());
                pd.k2 = (reader1["kolicina2"].ToString());
                pd.k3 = (reader1["kolicina3"].ToString());
                pd.k4 = (reader1["kolicina4"].ToString());
                pd.k5 = (reader1["kolicina5"].ToString());
                pd.k6 = (reader1["kolicina6"].ToString());
                pd.k7 = (reader1["kolicina7"].ToString());
                pd.k8 = (reader1["kolicina8"].ToString());
                pd.k9 = (reader1["kolicina9"].ToString());
                pd.k10 = (reader1["kolicina10"].ToString());
                pd.k11 = (reader1["kolicina11"].ToString());


                pd.ident_sifra = (reader1["ident_sifra"].ToString());
                pd.ident_sifra2 = (reader1["ident_sifra2"].ToString());
                pd.ident_sifra3 = (reader1["ident_sifra3"].ToString());
                pd.ident_sifra4 = (reader1["ident_sifra4"].ToString());
                pd.ident_sifra5 = (reader1["ident_sifra5"].ToString());
                pd.ident_sifra6 = (reader1["ident_sifra6"].ToString());
                pd.ident_sifra7 = (reader1["ident_sifra7"].ToString());
                pd.ident_sifra8 = (reader1["ident_sifra8"].ToString());
                pd.ident_sifra9 = (reader1["ident_sifra9"].ToString());
                pd.ident_sifra10 = (reader1["ident_sifra10"].ToString());
                pd.ident_sifra11 = (reader1["ident_sifra11"].ToString());

                pd.jm = (reader1["jm"].ToString());
                pd.jm2 = (reader1["jm2"].ToString());
                pd.jm3 = (reader1["jm3"].ToString());
                pd.jm4 = (reader1["jm4"].ToString());
                pd.jm5 = (reader1["jm5"].ToString());
                pd.jm6 = (reader1["jm6"].ToString());
                pd.jm7 = (reader1["jm7"].ToString());
                pd.jm8 = (reader1["jm8"].ToString());
                pd.jm9 = (reader1["jm9"].ToString());
                pd.jm10 = (reader1["jm10"].ToString());
                pd.jm11 = (reader1["jm11"].ToString());
                pd.mt = (reader1["naziv_mt"].ToString());
                pd.mt2 = (reader1["naziv_mt2"].ToString());
                pd.mt3 = (reader1["naziv_mt3"].ToString());
                pd.mt4 = (reader1["naziv_mt4"].ToString());
                pd.st = (reader1["sifra_mt"].ToString());
                pd.st2 = (reader1["sifra_mt2"].ToString());
                pd.st3 = (reader1["sifra_mt3"].ToString());
                pd.st4 = (reader1["sifra_mt4"].ToString());
                pd.ime = (reader1["podnositelj"].ToString());
                pd.datum = (reader1["datum"].ToString());
                pd.datumnab = (reader1["datum_nabavka"].ToString());
                pd.stoks = (reader1["stok"].ToString());
                pd.vrsta = (reader1["vrsta"].ToString());
                pd.min = (reader1["min"].ToString());
                pd.min2 = (reader1["min2"].ToString());
                pd.min3 = (reader1["min3"].ToString());
                pd.max = (reader1["max"].ToString());
                pd.max2 = (reader1["max2"].ToString());
                pd.max3 = (reader1["max3"].ToString());
                pd.stanje = (reader1["stanje"].ToString());
                pd.stanje2 = (reader1["stanje2"].ToString());
                pd.stanje3 = (reader1["stanje3"].ToString());
                pd.sklad = (reader1["sklad"].ToString());
                pd.napo = (reader1["napomena"].ToString());
                pd.napnab = (reader1["napnab"].ToString());
                pd.tehp = (reader1["tehp"].ToString());
                pd.ruko = (reader1["rukovodilac"].ToString());

                pd.ruod = (reader1["rukodo"].ToString());

                pd.nam = (reader1["nabavka"].ToString());

                pd.valuta = (reader1["valuta"].ToString());
                pd.status = (reader1["status"].ToString());

                pd.ok = (reader1["odobrena_kolicina"].ToString());
                pd.ok2 = (reader1["odobrena_kolicina2"].ToString());
                pd.ok3 = (reader1["odobrena_kolicina3"].ToString());
                pd.ok4 = (reader1["odobrena_kolicina4"].ToString());
                pd.ok5 = (reader1["odobrena_kolicina5"].ToString());
                pd.ok6 = (reader1["odobrena_kolicina6"].ToString());
                pd.ok7 = (reader1["odobrena_kolicina7"].ToString());
                pd.ok8 = (reader1["odobrena_kolicina8"].ToString());
                pd.ok9 = (reader1["odobrena_kolicina9"].ToString());
                pd.ok10 = (reader1["odobrena_kolicina10"].ToString());
                pd.ok11 = (reader1["odobrena_kolicina11"].ToString());
                pd.datkon = (reader1["datum_kontroling"].ToString());
                pd.kod = (reader1["podobrenje"].ToString());
                pd.dod = (reader1["dodobrenje"].ToString());
                pd.cij = (reader1["cijena"].ToString());
                pd.cij2 = (reader1["cijena2"].ToString());
                pd.cij3 = (reader1["cijena3"].ToString());
                pd.cij4 = (reader1["cijena4"].ToString());
                pd.cij5 = (reader1["cijena5"].ToString());
                pd.cij6 = (reader1["cijena6"].ToString());
                pd.cij7 = (reader1["cijena7"].ToString());
                pd.cij8 = (reader1["cijena8"].ToString());
                pd.cij9 = (reader1["cijena9"].ToString());
                pd.cij10 = (reader1["cijena10"].ToString());
                pd.cij11 = (reader1["cijena11"].ToString());

                pd.cijeuro = (reader1["cijena_eur"].ToString());
                pd.cijeuro2 = (reader1["cijena_eur2"].ToString());
                pd.cijeuro3 = (reader1["cijena_eur3"].ToString());
                pd.cijeuro4 = (reader1["cijena_eur4"].ToString());
                pd.cijeuro5 = (reader1["cijena_eur5"].ToString());
                pd.cijeuro6 = (reader1["cijena_eur6"].ToString());
                pd.cijeuro7 = (reader1["cijena_eur7"].ToString());
                pd.cijeuro8 = (reader1["cijena_eur8"].ToString());
                pd.cijeuro9 = (reader1["cijena_eur9"].ToString());
                pd.cijeuro10 = (reader1["cijena_eur10"].ToString());
                pd.cijeuro11 = (reader1["cijena_eur11"].ToString());

                pd.odjel = (reader1["odjel"].ToString());
                pd.tot = (reader1["total"].ToString());
                pd.ide = (reader1["id"].ToString());
                pd.pok=(reader1["pok"].ToString());
                pd.pod=(reader1["pod"].ToString());

            }

            else
            {
                reader1.Close();
            }

            connection.Close();

           

            if (string.IsNullOrEmpty(pd.nam))

            {

            }

            else
            {


                SqlConnection connect = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                // string que = "SELECT [inicijali] FROM Korisnici WHERE [ime] LIKE @usr and [odjel]='Nabavka' ";
                string que = "SELECT [inicijali] FROM Korisnici WHERE  [ime] + ' ' + [prezime]=@usr";
                /* SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
                 string query = "SELECT [naziv] FROM DiReqt WHERE id = @zid ";

                 */

                SqlCommand comman = new SqlCommand(que, connect);
                connect.Open();
                comman.Parameters.AddWithValue("@usr", pd.nam);

                SqlDataReader re = comman.ExecuteReader();


                if (re.Read())
                {


                    pd.ini = (re["inicijali"].ToString());



                }

                else
                {
                    pd.ini = "";
                    re.Close();
                    connect.Close();
                }



            }


            if (string.IsNullOrEmpty(pd.valuta))
            {
                pd.ci = "";

                pd.ci2 = "";
                pd.ci3 = "";
                pd.ci4 = "";
                pd.ci5 = "";
                pd.ci6 = "";
                pd.ci7 = "";
                pd.ci8 = "";
                pd.ci9 = "";
                pd.ci10 = "";
                pd.ci11 = "";
            }
            else
            {



                if (pd.valuta.Equals("KM") == true)
                {
                    pd.ci = pd.cij;

                    pd.ci2 = pd.cij2;
                    pd.ci3 = pd.cij3;
                    pd.ci4 = pd.cij4;
                    pd.ci5 = pd.cij5;
                    pd.ci6 = pd.cij6;
                    pd.ci7 = pd.cij7;
                    pd.ci8 = pd.cij8;
                    pd.ci9 = pd.cij9;
                    pd.ci10 = pd.cij10;
                    pd.ci11 = pd.cij11;



                    if (string.IsNullOrEmpty(pd.status))

                    {


                        if (string.IsNullOrEmpty(pd.ci))
                        {

                        }
                        else
                        {
                            pd.ckm = double.Parse(pd.ci);
                            pd.koc = Int32.Parse(pd.k);
                            pd.uc = pd.ckm * pd.koc;
                            pd.uci = Convert.ToString(pd.uc);
                        }

                        if (string.IsNullOrEmpty(pd.ci2))
                        {
                        }
                        else
                        {
                            pd.ckm2 = double.Parse(pd.cij2);
                            pd.koc2 = Int32.Parse(pd.k2);
                            pd.uc2 = pd.ckm2 * pd.koc2;
                            pd.uci2 = Convert.ToString(pd.uc2);

                        }
                        if (string.IsNullOrEmpty(pd.ci3))
                        {
                        }
                        else
                        {
                            pd.ckm3 = double.Parse(pd.cij3);
                            pd.koc3 = Int32.Parse(pd.k3);
                            pd.uc3 = pd.ckm3 * pd.koc3;
                            pd.uci3 = Convert.ToString(pd.uc3);
                        }
                        if (string.IsNullOrEmpty(pd.ci4))
                        {
                        }
                        else
                        {


                            pd.ckm4 = double.Parse(pd.cij4);
                            pd.koc4 = Int32.Parse(pd.k4);
                            pd.uc4 = pd.ckm4 * pd.koc4;
                            pd.uci4 = Convert.ToString(pd.uc4);
                        }
                        if (string.IsNullOrEmpty(pd.ci5))
                        {
                        }
                        else
                        {
                            pd.ckm5 = double.Parse(pd.cij5);
                            pd.koc5 = Int32.Parse(pd.k5);
                            pd.uc5 = pd.ckm5 * pd.koc5;
                            pd.uci5 = Convert.ToString(pd.uc5);
                        }
                        if (string.IsNullOrEmpty(pd.ci6))
                        {
                        }
                        else
                        {
                            pd.ckm6 = double.Parse(pd.cij6);
                            pd.koc6 = Int32.Parse(pd.k6);
                            pd.uc6 = pd.ckm6 * pd.koc6;
                            pd.uci6 = Convert.ToString(pd.uc6);

                        }
                        if (string.IsNullOrEmpty(pd.ci7))
                        {
                        }
                        else
                        {
                            pd.ckm7 = double.Parse(pd.cij7);
                            pd.koc7 = Int32.Parse(pd.k7);
                            pd.uc7 = pd.ckm7 * pd.koc7;
                            pd.uci7 = Convert.ToString(pd.uc7);


                        }
                        if (string.IsNullOrEmpty(pd.ci8))
                        {
                        }
                        else
                        {
                            pd.ckm8 = double.Parse(pd.cij8);
                            pd.koc8 = Int32.Parse(pd.k8);
                            pd.uc8 = pd.ckm8 * pd.koc8;
                            pd.uci8 = Convert.ToString(pd.uc8);

                        }
                        if (string.IsNullOrEmpty(pd.ci9))
                        {
                        }
                        else
                        {
                            pd.ckm9 = double.Parse(pd.cij9);
                            pd.koc9 = Int32.Parse(pd.k9);
                            pd.uc9 = pd.ckm9 * pd.koc9;
                            pd.uci9 = Convert.ToString(pd.uc9);
                        }
                        if (string.IsNullOrEmpty(pd.ci10))
                        {
                        }
                        else
                        {
                            pd.ckm10 = double.Parse(pd.cij10);
                            pd.koc10 = Int32.Parse(pd.k10);

                            pd.uc10 = pd.ckm10 * pd.koc10;

                            pd.uci10 = Convert.ToString(pd.uc10);
                        }
                        if (string.IsNullOrEmpty(pd.ci11))
                        {
                        }
                        else
                        {
                            pd.ckm11 = double.Parse(pd.cij11);
                            pd.koc11 = Int32.Parse(pd.k11);
                            pd.uc11 = pd.ckm11 * pd.koc11;
                            pd.uci11 = Convert.ToString(pd.uc11);
                        }





                    }

                    else
                    {

                        if (string.IsNullOrEmpty(pd.ci))
                        {

                        }
                        else
                        {
                            pd.ckm = double.Parse(pd.ci);
                            pd.koc = Int32.Parse(pd.ok);
                            pd.uc = pd.ckm * pd.koc;
                            pd.uci = Convert.ToString(pd.uc);
                        }

                        if (string.IsNullOrEmpty(pd.ci2))
                        {
                        }
                        else
                        {
                            pd.ckm2 = double.Parse(pd.cij2);
                            pd.koc2 = Int32.Parse(pd.ok2);
                            pd.uc2 = pd.ckm2 * pd.koc2;
                            pd.uci2 = Convert.ToString(pd.uc2);

                        }
                        if (string.IsNullOrEmpty(pd.ci3))
                        {
                        }
                        else
                        {
                            pd.ckm3 = double.Parse(pd.cij3);
                            pd.koc3 = Int32.Parse(pd.ok3);
                            pd.uc3 = pd.ckm3 * pd.koc3;
                            pd.uci3 = Convert.ToString(pd.uc3);
                        }
                        if (string.IsNullOrEmpty(pd.ci4))
                        {
                        }
                        else
                        {


                            pd.ckm4 = double.Parse(pd.cij4);
                            pd.koc4 = Int32.Parse(pd.ok4);
                            pd.uc4 = pd.ckm4 * pd.koc4;
                            pd.uci4 = Convert.ToString(pd.uc4);
                        }
                        if (string.IsNullOrEmpty(pd.ci5))
                        {
                        }
                        else
                        {
                            pd.ckm5 = double.Parse(pd.cij5);
                            pd.koc5 = Int32.Parse(pd.ok5);
                            pd.uc5 = pd.ckm5 * pd.koc5;
                            pd.uci5 = Convert.ToString(pd.uc5);
                        }
                        if (string.IsNullOrEmpty(pd.ci6))
                        {
                        }
                        else
                        {
                            pd.ckm6 = double.Parse(pd.cij6);
                            pd.koc6 = Int32.Parse(pd.ok6);
                            pd.uc6 = pd.ckm6 * pd.koc6;
                            pd.uci6 = Convert.ToString(pd.uc6);

                        }
                        if (string.IsNullOrEmpty(pd.ci7))
                        {
                        }
                        else
                        {
                            pd.ckm7 = double.Parse(pd.cij7);
                            pd.koc7 = Int32.Parse(pd.ok7);
                            pd.uc7 = pd.ckm7 * pd.koc7;
                            pd.uci7 = Convert.ToString(pd.uc7);


                        }
                        if (string.IsNullOrEmpty(pd.ci8))
                        {
                        }
                        else
                        {
                            pd.ckm8 = double.Parse(pd.cij8);
                            pd.koc8 = Int32.Parse(pd.ok8);
                            pd.uc8 = pd.ckm8 * pd.koc8;
                            pd.uci8 = Convert.ToString(pd.uc8);

                        }
                        if (string.IsNullOrEmpty(pd.ci9))
                        {
                        }
                        else
                        {
                            pd.ckm9 = double.Parse(pd.cij9);
                            pd.koc9 = Int32.Parse(pd.ok9);
                            pd.uc9 = pd.ckm9 * pd.koc9;
                            pd.uci9 = Convert.ToString(pd.uc9);
                        }
                        if (string.IsNullOrEmpty(pd.ci10))
                        {
                        }
                        else
                        {
                            pd.ckm10 = double.Parse(pd.cij10);
                            pd.koc10 = Int32.Parse(pd.ok10);

                            pd.uc10 = pd.ckm10 * pd.koc10;

                            pd.uci10 = Convert.ToString(pd.uc10);
                        }
                        if (string.IsNullOrEmpty(pd.ci11))
                        {
                        }
                        else
                        {
                            pd.ckm11 = double.Parse(pd.cij11);
                            pd.koc11 = Int32.Parse(pd.ok11);
                            pd.uc11 = pd.ckm11 * pd.koc11;
                            pd.uci11 = Convert.ToString(pd.uc11);
                        }




                    }









                }

                else if (pd.valuta.Equals("EUR") == true)
                {
                    pd.ci = pd.cijeuro;
                    pd.ci2 = pd.cijeuro2;
                    pd.ci3 = pd.cijeuro3;
                    pd.ci4 = pd.cijeuro4;
                    pd.ci5 = pd.cijeuro5;
                    pd.ci6 = pd.cijeuro6;
                    pd.ci7 = pd.cijeuro7;
                    pd.ci8 = pd.cijeuro8;
                    pd.ci9 = pd.cijeuro9;
                    pd.ci10 = pd.cijeuro10;
                    pd.ci11 = pd.cijeuro11;


                    if (string.IsNullOrEmpty(pd.status))

                    {


                        if (string.IsNullOrEmpty(pd.ci))
                        {

                        }
                        else
                        {
                            pd.ckm = double.Parse(pd.ci);
                            pd.koc = Int32.Parse(pd.k);
                            pd.uc = pd.ckm * pd.koc;
                            pd.uci = Convert.ToString(pd.uc);
                        }

                        if (string.IsNullOrEmpty(pd.ci2))
                        {
                        }
                        else
                        {
                            pd.ckm2 = double.Parse(pd.cij2);
                            pd.koc2 = Int32.Parse(pd.k2);
                            pd.uc2 = pd.ckm2 * pd.koc2;
                            pd.uci2 = Convert.ToString(pd.uc2);

                        }
                        if (string.IsNullOrEmpty(pd.ci3))
                        {
                        }
                        else
                        {
                            pd.ckm3 = double.Parse(pd.cij3);
                            pd.koc3 = Int32.Parse(pd.k3);
                            pd.uc3 = pd.ckm3 * pd.koc3;
                            pd.uci3 = Convert.ToString(pd.uc3);
                        }
                        if (string.IsNullOrEmpty(pd.ci4))
                        {
                        }
                        else
                        {


                            pd.ckm4 = double.Parse(pd.cij4);
                            pd.koc4 = Int32.Parse(pd.k4);
                            pd.uc4 = pd.ckm4 * pd.koc4;
                            pd.uci4 = Convert.ToString(pd.uc4);
                        }
                        if (string.IsNullOrEmpty(pd.ci5))
                        {
                        }
                        else
                        {
                            pd.ckm5 = double.Parse(pd.cij5);
                            pd.koc5 = Int32.Parse(pd.k5);
                            pd.uc5 = pd.ckm5 * pd.koc5;
                            pd.uci5 = Convert.ToString(pd.uc5);
                        }
                        if (string.IsNullOrEmpty(pd.ci6))
                        {
                        }
                        else
                        {
                            pd.ckm6 = double.Parse(pd.cij6);
                            pd.koc6 = Int32.Parse(pd.k6);
                            pd.uc6 = pd.ckm6 * pd.koc6;
                            pd.uci6 = Convert.ToString(pd.uc6);

                        }
                        if (string.IsNullOrEmpty(pd.ci7))
                        {
                        }
                        else
                        {
                            pd.ckm7 = double.Parse(pd.cij7);
                            pd.koc7 = Int32.Parse(pd.k7);
                            pd.uc7 = pd.ckm7 * pd.koc7;
                            pd.uci7 = Convert.ToString(pd.uc7);


                        }
                        if (string.IsNullOrEmpty(pd.ci8))
                        {
                        }
                        else
                        {
                            pd.ckm8 = double.Parse(pd.cij8);
                            pd.koc8 = Int32.Parse(pd.k8);
                            pd.uc8 = pd.ckm8 * pd.koc8;
                            pd.uci8 = Convert.ToString(pd.uc8);

                        }
                        if (string.IsNullOrEmpty(pd.ci9))
                        {
                        }
                        else
                        {
                            pd.ckm9 = double.Parse(pd.cij9);
                            pd.koc9 = Int32.Parse(pd.k9);
                            pd.uc9 = pd.ckm9 * pd.koc9;
                            pd.uci9 = Convert.ToString(pd.uc9);
                        }
                        if (string.IsNullOrEmpty(pd.ci10))
                        {
                        }
                        else
                        {
                            pd.ckm10 = double.Parse(pd.cij10);
                            pd.koc10 = Int32.Parse(pd.k10);

                            pd.uc10 = pd.ckm10 * pd.koc10;

                            pd.uci10 = Convert.ToString(pd.uc10);
                        }
                        if (string.IsNullOrEmpty(pd.ci11))
                        {
                        }
                        else
                        {
                            pd.ckm11 = double.Parse(pd.cij11);
                            pd.koc11 = Int32.Parse(pd.k11);
                            pd.uc11 = pd.ckm11 * pd.koc11;
                            pd.uci11 = Convert.ToString(pd.uc11);
                        }





                    }

                    else
                    {

                        if (string.IsNullOrEmpty(pd.ci))
                        {

                        }
                        else
                        {
                            pd.ckm = double.Parse(pd.ci);
                            pd.koc = Int32.Parse(pd.ok);
                            pd.uc = pd.ckm * pd.koc;
                            pd.uci = Convert.ToString(pd.uc);
                        }

                        if (string.IsNullOrEmpty(pd.ci2))
                        {
                        }
                        else
                        {
                            pd.ckm2 = double.Parse(pd.cij2);
                            pd.koc2 = Int32.Parse(pd.ok2);
                            pd.uc2 = pd.ckm2 * pd.koc2;
                            pd.uci2 = Convert.ToString(pd.uc2);

                        }
                        if (string.IsNullOrEmpty(pd.ci3))
                        {
                        }
                        else
                        {
                            pd.ckm3 = double.Parse(pd.cij3);
                            pd.koc3 = Int32.Parse(pd.ok3);
                            pd.uc3 = pd.ckm3 * pd.koc3;
                            pd.uci3 = Convert.ToString(pd.uc3);
                        }
                        if (string.IsNullOrEmpty(pd.ci4))
                        {
                        }
                        else
                        {


                            pd.ckm4 = double.Parse(pd.cij4);
                            pd.koc4 = Int32.Parse(pd.ok4);
                            pd.uc4 = pd.ckm4 * pd.koc4;
                            pd.uci4 = Convert.ToString(pd.uc4);
                        }
                        if (string.IsNullOrEmpty(pd.ci5))
                        {
                        }
                        else
                        {
                            pd.ckm5 = double.Parse(pd.cij5);
                            pd.koc5 = Int32.Parse(pd.ok5);
                            pd.uc5 = pd.ckm5 * pd.koc5;
                            pd.uci5 = Convert.ToString(pd.uc5);
                        }
                        if (string.IsNullOrEmpty(pd.ci6))
                        {
                        }
                        else
                        {
                            pd.ckm6 = double.Parse(pd.cij6);
                            pd.koc6 = Int32.Parse(pd.ok6);
                            pd.uc6 = pd.ckm6 * pd.koc6;
                            pd.uci6 = Convert.ToString(pd.uc6);

                        }
                        if (string.IsNullOrEmpty(pd.ci7))
                        {
                        }
                        else
                        {
                            pd.ckm7 = double.Parse(pd.cij7);
                            pd.koc7 = Int32.Parse(pd.ok7);
                            pd.uc7 = pd.ckm7 * pd.koc7;
                            pd.uci7 = Convert.ToString(pd.uc7);


                        }
                        if (string.IsNullOrEmpty(pd.ci8))
                        {
                        }
                        else
                        {
                            pd.ckm8 = double.Parse(pd.cij8);
                            pd.koc8 = Int32.Parse(pd.ok8);
                            pd.uc8 = pd.ckm8 * pd.koc8;
                            pd.uci8 = Convert.ToString(pd.uc8);

                        }
                        if (string.IsNullOrEmpty(pd.ci9))
                        {
                        }
                        else
                        {
                            pd.ckm9 = double.Parse(pd.cij9);
                            pd.koc9 = Int32.Parse(pd.ok9);
                            pd.uc9 = pd.ckm9 * pd.koc9;
                            pd.uci9 = Convert.ToString(pd.uc9);
                        }
                        if (string.IsNullOrEmpty(pd.ci10))
                        {
                        }
                        else
                        {
                            pd.ckm10 = double.Parse(pd.cij10);
                            pd.koc10 = Int32.Parse(pd.ok10);

                            pd.uc10 = pd.ckm10 * pd.koc10;

                            pd.uci10 = Convert.ToString(pd.uc10);
                        }
                        if (string.IsNullOrEmpty(pd.ci11))
                        {
                        }
                        else
                        {
                            pd.ckm11 = double.Parse(pd.cij11);
                            pd.koc11 = Int32.Parse(pd.ok11);
                            pd.uc11 = pd.ckm11 * pd.koc11;
                            pd.uci11 = Convert.ToString(pd.uc11);
                        }




                    }

                }

                else

                {

                }



            }



            PdfPTable infotable = new PdfPTable(6);
            infotable.TotalWidth = 700f;
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 14, 0, Color.BLACK);
            PdfPCell ppolje = new PdfPCell(new Phrase(" ", new Font(fntColumnHeader)));
            ppolje.HorizontalAlignment = 1;
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



            PdfPCell bwa = new PdfPCell(new Phrase("Zahtjev podnosi", new Font(fnt2ColumnHeader)));
            bwa.HorizontalAlignment = 1;
            bwa.VerticalAlignment = Element.ALIGN_MIDDLE;
            bwa.Colspan = 2;
            infotable.AddCell(bwa);

            /*PdfPCell dtm = new PdfPCell(new Phrase("Datum", new Font(fnt2ColumnHeader)));
            dtm.HorizontalAlignment = 1;
            dtm.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dtm);*/

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
            PdfPCell poz = new PdfPCell(new Phrase(pd.ime, new Font(fnt2ColumnHeader)));

            poz.HorizontalAlignment = 1;
            poz.VerticalAlignment = Element.ALIGN_MIDDLE;
            poz.Colspan = 2;
            infotable.AddCell(poz);

            /*
            PdfPCell dat = new PdfPCell(new Phrase(/*DateTime.Now.ToShortDateString()" ", new Font(fnt2ColumnHeader)));

            dat.HorizontalAlignment = 1;
            dat.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dat);
         
            //string mt = "";
            */
            PdfPCell tp = new PdfPCell(new Phrase(pd.tehp, new Font(fnt2ColumnHeader)));

            tp.HorizontalAlignment = 1;
            tp.VerticalAlignment = Element.ALIGN_MIDDLE;
            
            infotable.AddCell(tp);

            string zz = "";
            string zz2 = "";
            string zz3 = "";

            if (pd.st2 != "")
            {
                zz = ", ";
            }
            else { }
            if (pd.st3 != "")
            {
                zz2 = ", ";
            }
            if (pd.st4 != "")
            {
                zz3 = ", ";
            }


            PdfPCell msif = new PdfPCell(new Phrase(pd.st +zz+ pd.st2+zz2 + pd.st3+zz3 + pd.st4, new Font(fnt2ColumnHeader)));

            msif.HorizontalAlignment = 1;
            msif.VerticalAlignment = Element.ALIGN_MIDDLE;
            string zarez = "";
            string zarez2 = "";
            string zarez3 = "";



            if (pd.mt2 != "")
            {
                zarez = ", ";
            }
            else { }
            if (pd.mt3 != "")
            {
                zarez2 = ", ";
            }
            if (pd.mt4 != "")
            {
                zarez3 = ", ";
            }




            infotable.AddCell(msif);

            PdfPCell mjesto = new PdfPCell(new Phrase(pd.mt + zarez + pd.mt2 + zarez2 + pd.mt3 + zarez3 + pd.mt4, new Font(fnt2ColumnHeader)));
            mjesto.HorizontalAlignment = 1;
            mjesto.VerticalAlignment = Element.ALIGN_MIDDLE;



            infotable.AddCell(mjesto);


            PdfPCell dat2 = new PdfPCell(new Phrase(pd.datum, new Font(fnt2ColumnHeader)));
            dat2.HorizontalAlignment = 1;
            dat2.VerticalAlignment = Element.ALIGN_MIDDLE;
            infotable.AddCell(dat2);

            infotable.LockedWidth = true;


            PdfPTable table = new PdfPTable(7);
            table.TotalWidth = 700f;

            float[] columnWidthts = new float[] { 10f, 30f, 5f, 10f, 10f, 10f, 10f };
            table.SetWidths(columnWidthts);
            table.LockedWidth = true;

            table.AddCell(ppolje);
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

            table.AddCell(nmat);




            //table.AddCell("JM");
            PdfPCell jmj = new PdfPCell(new Phrase("JM\nML", new Font(fnt2ColumnHeader)));
            jmj.HorizontalAlignment = 1;
            jmj.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(jmj);

            //table.AddCell("Količina");
            PdfPCell koli = new PdfPCell(new Phrase("Količina \nMenge", new Font(fnt2ColumnHeader)));
            koli.HorizontalAlignment = 1;
            koli.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(koli);

            PdfPCell kolic = new PdfPCell(new Phrase("Odobrena količina \nGenehmigte menge", new Font(fnt2ColumnHeader)));
            kolic.HorizontalAlignment = 1;
            kolic.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(kolic);
            //table.AddCell("Cijena");

            if (string.IsNullOrEmpty(pd.valuta))

            {
                PdfPCell cijena = new PdfPCell(new Phrase("Cijena/JM" + "\nPreis/ML", new Font(fnt2ColumnHeader)));
                cijena.HorizontalAlignment = 1;
                cijena.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cijena);
            }
            else
            {


                if (pd.valuta.Equals("KM") == true)
                {
                    PdfPCell cijena = new PdfPCell(new Phrase("Cijena/JM (KM)" + "\nPreis/ML", new Font(fnt2ColumnHeader)));
                    cijena.HorizontalAlignment = 1;
                    cijena.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cijena);
                }
                else if (pd.valuta.Equals("EUR") == true)
                {
                    PdfPCell cijena = new PdfPCell(new Phrase("Cijena/JM (EUR)" + "\nPreis/ML", new Font(fnt2ColumnHeader)));
                    cijena.HorizontalAlignment = 1;
                    cijena.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cijena);
                }
                else
                {
                    PdfPCell cijena = new PdfPCell(new Phrase("Cijena/JM" + "\nPreis/ML", new Font(fnt2ColumnHeader)));
                    cijena.HorizontalAlignment = 1;
                    cijena.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cijena);
                }
            }

            //table.AddCell("Konto");

            PdfPCell konto = new PdfPCell(new Phrase("Ukupna cijena" + "\nSumme", new Font(fnt2ColumnHeader)));
            konto.HorizontalAlignment = 1;
            konto.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(konto);

            if (string.IsNullOrEmpty(pd.n))
            {

            }
            else
            {
                PdfPCell is1 = new PdfPCell(new Phrase(pd.ident_sifra, new Font(fnt4ColumnHeader)));
                is1.HorizontalAlignment = 1;
                is1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is1);

                PdfPCell nm1 = new PdfPCell(new Phrase(pd.n, new Font(fnt4ColumnHeader)));
                nm1.HorizontalAlignment = 0;
                nm1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm1);

                PdfPCell jm1 = new PdfPCell(new Phrase(pd.jm, new Font(fnt4ColumnHeader)));
                jm1.HorizontalAlignment = 1;
                jm1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jm1);

                PdfPCell kol1 = new PdfPCell(new Phrase(pd.k, new Font(fnt4ColumnHeader)));
                kol1.HorizontalAlignment = 1;
                kol1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol1);

                PdfPCell odk = new PdfPCell(new Phrase(pd.ok, new Font(fnt4ColumnHeader)));
                odk.HorizontalAlignment = 1;
                odk.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk);

                PdfPCell cije = new PdfPCell(new Phrase(pd.ci, new Font(fnt4ColumnHeader)));
                cije.HorizontalAlignment = 1;
                cije.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije);

                PdfPCell ucije = new PdfPCell(new Phrase(pd.uci, new Font(fnt4ColumnHeader)));
                ucije.HorizontalAlignment = 1;
                ucije.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije);
            }


            if (string.IsNullOrEmpty(pd.n2))
            {
            }
            else
            {
                PdfPCell is2 = new PdfPCell(new Phrase(pd.ident_sifra2, new Font(fnt4ColumnHeader)));
                is2.HorizontalAlignment = 1;
                is2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is2);
                PdfPCell nm2 = new PdfPCell(new Phrase(pd.n2, new Font(fnt4ColumnHeader)));
                nm2.HorizontalAlignment = 0;
                nm2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm2);

                PdfPCell jem2 = new PdfPCell(new Phrase(pd.jm2, new Font(fnt4ColumnHeader)));
                jem2.HorizontalAlignment = 1;
                jem2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem2);

                PdfPCell kol2 = new PdfPCell(new Phrase(pd.k2, new Font(fnt4ColumnHeader)));
                kol2.HorizontalAlignment = 1;
                kol2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol2);

                PdfPCell odk2 = new PdfPCell(new Phrase(pd.ok2, new Font(fnt4ColumnHeader)));
                odk2.HorizontalAlignment = 1;
                odk2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk2);

                PdfPCell cije2 = new PdfPCell(new Phrase(pd.ci2, new Font(fnt4ColumnHeader)));
                cije2.HorizontalAlignment = 1;
                cije2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije2);

                PdfPCell ucije2 = new PdfPCell(new Phrase(pd.uci2, new Font(fnt4ColumnHeader)));
                ucije2.HorizontalAlignment = 1;
                ucije2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije2);
            }


            if (string.IsNullOrEmpty(pd.n3))
            {
            }

            else
            {
                PdfPCell is3 = new PdfPCell(new Phrase(pd.ident_sifra3, new Font(fnt4ColumnHeader)));
                is3.HorizontalAlignment = 1;
                is3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is3);
                PdfPCell nm3 = new PdfPCell(new Phrase(pd.n3, new Font(fnt4ColumnHeader)));
                nm3.HorizontalAlignment = 0;
                nm3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm3);

                PdfPCell jem3 = new PdfPCell(new Phrase(pd.jm3, new Font(fnt4ColumnHeader)));
                jem3.HorizontalAlignment = 1;
                jem3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem3);

                PdfPCell kol3 = new PdfPCell(new Phrase(pd.k3, new Font(fnt4ColumnHeader)));
                kol3.HorizontalAlignment = 1;
                kol3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol3);

                PdfPCell odk3 = new PdfPCell(new Phrase(pd.ok3, new Font(fnt4ColumnHeader)));
                odk3.HorizontalAlignment = 1;
                odk3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk3);

                PdfPCell cije3 = new PdfPCell(new Phrase(pd.ci3, new Font(fnt4ColumnHeader)));
                cije3.HorizontalAlignment = 1;
                cije3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije3);

                PdfPCell ucije3 = new PdfPCell(new Phrase(pd.uci3, new Font(fnt4ColumnHeader)));
                ucije3.HorizontalAlignment = 1;
                ucije3.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije3);
            }


            if (string.IsNullOrEmpty(pd.n4))
            {
            }
            else
            {
                PdfPCell is4 = new PdfPCell(new Phrase(pd.ident_sifra4, new Font(fnt4ColumnHeader)));
                is4.HorizontalAlignment = 1;
                is4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is4);

                PdfPCell nm4 = new PdfPCell(new Phrase(pd.n4, new Font(fnt4ColumnHeader)));
                nm4.HorizontalAlignment = 0;
                nm4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm4);

                PdfPCell jem4 = new PdfPCell(new Phrase(pd.jm4, new Font(fnt4ColumnHeader)));
                jem4.HorizontalAlignment = 1;
                jem4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem4);

                PdfPCell kol4 = new PdfPCell(new Phrase(pd.k4, new Font(fnt4ColumnHeader)));
                kol4.HorizontalAlignment = 1;
                kol4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol4);
                PdfPCell odk4 = new PdfPCell(new Phrase(pd.ok4, new Font(fnt4ColumnHeader)));
                odk4.HorizontalAlignment = 1;
                odk4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk4);

                PdfPCell cije4 = new PdfPCell(new Phrase(pd.ci4, new Font(fnt4ColumnHeader)));
                cije4.HorizontalAlignment = 1;
                cije4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije4);

                PdfPCell ucije4 = new PdfPCell(new Phrase(pd.uci4, new Font(fnt4ColumnHeader)));
                ucije4.HorizontalAlignment = 1;
                ucije4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije4);
            }



            if (string.IsNullOrEmpty(pd.n5))
            {
            }
            else
            {
                PdfPCell is5 = new PdfPCell(new Phrase(pd.ident_sifra5, new Font(fnt4ColumnHeader)));
                is5.HorizontalAlignment = 1;
                is5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is5);

                PdfPCell nm5 = new PdfPCell(new Phrase(pd.n5, new Font(fnt4ColumnHeader)));
                nm5.HorizontalAlignment = 0;
                nm5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm5);

                PdfPCell jem5 = new PdfPCell(new Phrase(pd.jm5, new Font(fnt4ColumnHeader)));
                jem5.HorizontalAlignment = 1;
                jem5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem5);

                PdfPCell kol5 = new PdfPCell(new Phrase(pd.k5, new Font(fnt4ColumnHeader)));
                kol5.HorizontalAlignment = 1;
                kol5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol5);

                PdfPCell odk5 = new PdfPCell(new Phrase(pd.ok5, new Font(fnt4ColumnHeader)));
                odk5.HorizontalAlignment = 1;
                odk5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk5);

                PdfPCell cije5 = new PdfPCell(new Phrase(pd.ci5, new Font(fnt4ColumnHeader)));
                cije5.HorizontalAlignment = 1;
                cije5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije5);

                PdfPCell ucije5 = new PdfPCell(new Phrase(pd.uci5, new Font(fnt4ColumnHeader)));
                ucije5.HorizontalAlignment = 1;
                ucije5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije5);
            }


            if (string.IsNullOrEmpty(pd.n6))
            {
            }
            else
            {
                PdfPCell is6 = new PdfPCell(new Phrase(pd.ident_sifra6, new Font(fnt4ColumnHeader)));
                is6.HorizontalAlignment = 1;
                is6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is6);

                PdfPCell nm6 = new PdfPCell(new Phrase(pd.n6, new Font(fnt4ColumnHeader)));
                nm6.HorizontalAlignment = 0;
                nm6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm6);

                PdfPCell jem6 = new PdfPCell(new Phrase(pd.jm6, new Font(fnt4ColumnHeader)));
                jem6.HorizontalAlignment = 1;
                jem6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem6);

                PdfPCell kol6 = new PdfPCell(new Phrase(pd.k6, new Font(fnt4ColumnHeader)));
                kol6.HorizontalAlignment = 1;
                kol6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol6);
                PdfPCell odk6 = new PdfPCell(new Phrase(pd.ok6, new Font(fnt4ColumnHeader)));
                odk6.HorizontalAlignment = 1;
                odk6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk6);

                PdfPCell cije6 = new PdfPCell(new Phrase(pd.ci6, new Font(fnt4ColumnHeader)));
                cije6.HorizontalAlignment = 1;
                cije6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije6);

                PdfPCell ucije6 = new PdfPCell(new Phrase(pd.uci6, new Font(fnt4ColumnHeader)));
                ucije6.HorizontalAlignment = 1;
                ucije6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije6);
            }


            if (string.IsNullOrEmpty(pd.n7))
            {
            }
            else
            {

                PdfPCell is7 = new PdfPCell(new Phrase(pd.ident_sifra7, new Font(fnt4ColumnHeader)));
                is7.HorizontalAlignment = 1;
                is7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is7);

                PdfPCell nm7 = new PdfPCell(new Phrase(pd.n7, new Font(fnt4ColumnHeader)));
                nm7.HorizontalAlignment = 0;
                nm7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm7);

                PdfPCell jem7 = new PdfPCell(new Phrase(pd.jm7, new Font(fnt4ColumnHeader)));
                jem7.HorizontalAlignment = 1;
                jem7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem7);

                PdfPCell kol7 = new PdfPCell(new Phrase(pd.k7, new Font(fnt4ColumnHeader)));
                kol7.HorizontalAlignment = 1;
                kol7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol7);

                PdfPCell odk7 = new PdfPCell(new Phrase(pd.ok7, new Font(fnt4ColumnHeader)));
                odk7.HorizontalAlignment = 1;
                odk7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk7);

                PdfPCell cije7 = new PdfPCell(new Phrase(pd.ci7, new Font(fnt4ColumnHeader)));
                cije7.HorizontalAlignment = 1;
                cije7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije7);

                PdfPCell ucije7 = new PdfPCell(new Phrase(pd.uci7, new Font(fnt4ColumnHeader)));
                ucije7.HorizontalAlignment = 1;
                ucije7.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije7);
            }


            if (string.IsNullOrEmpty(pd.n8))
            {
            }
            else
            {
                PdfPCell is8 = new PdfPCell(new Phrase(pd.ident_sifra8, new Font(fnt4ColumnHeader)));
                is8.HorizontalAlignment = 1;
                is8.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(is8);

                PdfPCell nm8 = new PdfPCell(new Phrase(pd.n8, new Font(fnt4ColumnHeader)));
                nm8.HorizontalAlignment = 0;
                nm8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm8);

                PdfPCell jem8 = new PdfPCell(new Phrase(pd.jm8, new Font(fnt4ColumnHeader)));
                jem8.HorizontalAlignment = 1;
                jem8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem8);

                PdfPCell kol8 = new PdfPCell(new Phrase(pd.k8, new Font(fnt4ColumnHeader)));
                kol8.HorizontalAlignment = 1;
                kol8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol8);

                PdfPCell odk8 = new PdfPCell(new Phrase(pd.ok8, new Font(fnt4ColumnHeader)));
                odk8.HorizontalAlignment = 1;
                odk8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk8);

                PdfPCell cije8 = new PdfPCell(new Phrase(pd.ci8, new Font(fnt4ColumnHeader)));
                cije8.HorizontalAlignment = 1;
                cije8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije8);

                PdfPCell ucije8 = new PdfPCell(new Phrase(pd.uci8, new Font(fnt4ColumnHeader)));
                ucije8.HorizontalAlignment = 1;
                ucije8.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije8);
            }


            if (string.IsNullOrEmpty(pd.n9))
            {
            }
            else
            {
                PdfPCell is9 = new PdfPCell(new Phrase(pd.ident_sifra9, new Font(fnt4ColumnHeader)));
                is9.HorizontalAlignment = 1;
                is9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is9);

                PdfPCell nm9 = new PdfPCell(new Phrase(pd.n9, new Font(fnt4ColumnHeader)));
                nm9.HorizontalAlignment = 0;
                nm9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm9);

                PdfPCell jem9 = new PdfPCell(new Phrase(pd.jm9, new Font(fnt4ColumnHeader)));
                jem9.HorizontalAlignment = 1;
                jem9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem9);

                PdfPCell kol9 = new PdfPCell(new Phrase(pd.k9, new Font(fnt4ColumnHeader)));
                kol9.HorizontalAlignment = 1;
                kol9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol9);
                PdfPCell odk9 = new PdfPCell(new Phrase(pd.ok9, new Font(fnt4ColumnHeader)));
                odk9.HorizontalAlignment = 1;
                odk9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk9);

                PdfPCell cije9 = new PdfPCell(new Phrase(pd.ci9, new Font(fnt4ColumnHeader)));
                cije9.HorizontalAlignment = 1;
                cije9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije9);

                PdfPCell ucije9 = new PdfPCell(new Phrase(pd.uci9, new Font(fnt4ColumnHeader)));
                ucije9.HorizontalAlignment = 1;
                ucije9.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije9);
            }


            if (string.IsNullOrEmpty(pd.n10))
            {
            }

            else
            {
                PdfPCell is10 = new PdfPCell(new Phrase(pd.ident_sifra10, new Font(fnt4ColumnHeader)));
                is10.HorizontalAlignment = 1;
                is10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is10);

                PdfPCell nm10 = new PdfPCell(new Phrase(pd.n10, new Font(fnt4ColumnHeader)));
                nm10.HorizontalAlignment = 0;
                nm10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm10);

                PdfPCell jem10 = new PdfPCell(new Phrase(pd.jm10, new Font(fnt4ColumnHeader)));
                jem10.HorizontalAlignment = 1;
                jem10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem10);

                PdfPCell kol10 = new PdfPCell(new Phrase(pd.k10, new Font(fnt4ColumnHeader)));
                kol10.HorizontalAlignment = 1;
                kol10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol10);
                PdfPCell odk10 = new PdfPCell(new Phrase(pd.ok10, new Font(fnt4ColumnHeader)));
                odk10.HorizontalAlignment = 1;
                odk10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk10);
                PdfPCell cije10 = new PdfPCell(new Phrase(pd.ci10, new Font(fnt4ColumnHeader)));
                cije10.HorizontalAlignment = 1;
                cije10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije10);

                PdfPCell ucije10 = new PdfPCell(new Phrase(pd.uci10, new Font(fnt4ColumnHeader)));
                ucije10.HorizontalAlignment = 1;
                ucije10.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije10);
            }


            if (string.IsNullOrEmpty(pd.n11))
            {
            }
            else
            {
                PdfPCell is11 = new PdfPCell(new Phrase(pd.ident_sifra11, new Font(fnt4ColumnHeader)));
                is11.HorizontalAlignment = 1;
                is11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(is11);

                PdfPCell nm11 = new PdfPCell(new Phrase(pd.n11, new Font(fnt4ColumnHeader)));
                nm11.HorizontalAlignment = 0;
                nm11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(nm11);

                PdfPCell jem11 = new PdfPCell(new Phrase(pd.jm11, new Font(fnt4ColumnHeader)));
                jem11.HorizontalAlignment = 1;
                jem11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(jem11);

                PdfPCell kol11 = new PdfPCell(new Phrase(pd.k11, new Font(fnt4ColumnHeader)));
                kol11.HorizontalAlignment = 1;
                kol11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(kol11);
                PdfPCell odk11 = new PdfPCell(new Phrase(pd.ok11, new Font(fnt4ColumnHeader)));
                odk11.HorizontalAlignment = 1;
                odk11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(odk11);
                PdfPCell cije11 = new PdfPCell(new Phrase(pd.ci11, new Font(fnt4ColumnHeader)));
                cije11.HorizontalAlignment = 1;
                cije11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cije11);

                PdfPCell ucije11 = new PdfPCell(new Phrase(pd.uci11, new Font(fnt4ColumnHeader)));
                ucije11.HorizontalAlignment = 1;
                ucije11.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(ucije11);
            }


            PdfPCell kcij = new PdfPCell(new Phrase(" "));

            kcij.Colspan = 4;
            table.AddCell(kcij);


            PdfPCell kona = new PdfPCell(new Phrase("Total: ", fnt4ColumnHeader));
            kona.HorizontalAlignment = 0;
            kona.VerticalAlignment = Element.ALIGN_MIDDLE;
            //kona.Colspan = 2;
            //table.AddCell(kona);
            //  table.AddCell(" ");



            PdfPCell total = new PdfPCell(new Phrase(pd.tot + " " + pd.valuta, fnt4ColumnHeader));
            total.HorizontalAlignment = 1;
            total.VerticalAlignment = Element.ALIGN_MIDDLE;
            total.Colspan = 2;

            //kona.Colspan = 2;
            table.AddCell(kona);
            table.AddCell(total);
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
            PdfPCell datums = new PdfPCell(new Phrase("Datum ", fnt2ColumnHeader));
            datums.HorizontalAlignment = 1;
            datums.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(date);
            PdfPCell ovjerio = new PdfPCell(new Phrase("Ovjerio \nGenehmigt", fnt2ColumnHeader));
            ovjerio.Colspan = 2;
            ovjerio.HorizontalAlignment = 1;
            ovjerio.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(ovjerio);





            if (string.IsNullOrEmpty(pd.ime))
            {
                dtable.AddCell(" \n ");
               

            }


            else
            {
                iTextSharp.text.Image myImageSKL = iTextSharp.text.Image.GetInstance("\\Vw_nas\\DIREQT" + "\\Resources\\" + pd.ime + " LOGO.png ");
                myImageSKL.ScalePercent(15f);
                PdfPCell odjelslika = new PdfPCell(myImageSKL);
                odjelslika.HorizontalAlignment = 1;
                dtable.AddCell(odjelslika);
            }



            if (string.IsNullOrEmpty(pd.ruko))
            {
                dtable.AddCell(" \n ");


            }
            
            else
            {
                if (pd.ruod.Equals("Odobreno"))
                {
                    iTextSharp.text.Image myImageod = iTextSharp.text.Image.GetInstance("\\Vw_nas\\DIREQT" + "\\Resources\\" + pd.ruko + " LOGO.png ");
                    myImageod.ScalePercent(15f);
                    PdfPCell odjelodob = new PdfPCell(myImageod);
                    odjelodob.HorizontalAlignment = 1;
                    dtable.AddCell(odjelodob);
                }

                else
                {
                    dtable.AddCell(" \n ");
                }
            }
            if (string.IsNullOrEmpty(pd.nam))
            { dtable.AddCell(" \n "); }

            else
            {
                // string folder = Application.StartupPath;
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance("\\Vw_nas\\DIREQT" + "\\Resources\\" + "NABAVKA" + " LOGO.png ");
                myImage.ScalePercent(15f);
                PdfPCell nabavka = new PdfPCell(myImage);
                nabavka.HorizontalAlignment = 1;
                dtable.AddCell(nabavka);
            }
            PdfPCell dats2 = new PdfPCell(new Phrase(pd.datumnab, new Font(fnt2ColumnHeader)));
            dats2.HorizontalAlignment = 1;
            dats2.VerticalAlignment = Element.ALIGN_MIDDLE;
            dtable.AddCell(dats2);

            if (string.IsNullOrEmpty(pd.status))

            { dtable.AddCell(" \n "); }
            else
            {
                if (pd.status.Equals("Odobreno"))
                {
                    iTextSharp.text.Image myImageod2 = iTextSharp.text.Image.GetInstance/*(folder+"\\nabavka.bmp");*/(Directory.GetCurrentDirectory() + "\\Resources\\KONTROLING LOGO.png ");
                    myImageod2.ScalePercent(15f);
                    PdfPCell kontrodob = new PdfPCell(myImageod2);
                    kontrodob.HorizontalAlignment = 1;
                    dtable.AddCell(kontrodob);
                }
                else
                { dtable.AddCell(" \n "); }

            }



            PdfPCell dats3 = new PdfPCell(new Phrase(pd.datkon, new Font(fnt2ColumnHeader)));
            dats3.HorizontalAlignment = 1;
            dats3.VerticalAlignment = Element.ALIGN_MIDDLE; ;
            dtable.AddCell(dats3);

            if (string.IsNullOrEmpty(pd.pok))
            { dtable.AddCell(" \n "); }
            else
            {
                if (pd.kod.Equals("Odobreno") == true)
                {
                    iTextSharp.text.Image myImageEMI = iTextSharp.text.Image.GetInstance("\\Vw_nas\\DIREQT" + "\\Resources\\" + pd.pok + " LOGO.png ");
                    myImageEMI.ScalePercent(15f);
                    PdfPCell emina = new PdfPCell(myImageEMI);
                    emina.HorizontalAlignment = 1;
                    dtable.AddCell(emina);



                }
                else
                { dtable.AddCell(" \n "); }
            }

            if (string.IsNullOrEmpty(pd.pod))
            { dtable.AddCell(" \n "); }
            else
            {
                if (pd.dod.Equals("Odobreno") == true)
                {

                    iTextSharp.text.Image myImagedir = iTextSharp.text.Image.GetInstance("\\Vw_nas\\DIREQT" + "\\Resources\\" + pd.pod + " LOGO.png ");

                   
                    myImagedir.ScalePercent(15f);
                    PdfPCell direktor = new PdfPCell(myImagedir);
                    direktor.HorizontalAlignment = 1;
                    dtable.AddCell(direktor);
                }
                else
                { dtable.AddCell(" \n "); }
            }

            // dtable.AddCell("Sklad");
            PdfPCell skladi = new PdfPCell(new Phrase("Sklad-Lager\n", fnt2ColumnHeader));
            skladi.HorizontalAlignment = 0;
            skladi.VerticalAlignment = 1;
            dtable.AddCell(skladi);

            PdfPCell skladi1 = new PdfPCell(new Phrase(pd.sklad, fnt4ColumnHeader));
            skladi1.HorizontalAlignment = 1;
            skladi1.VerticalAlignment = 1;
            dtable.AddCell(skladi1);

            PdfPCell refe = new PdfPCell(new Phrase(pd.ini, fnt2ColumnHeader));
            refe.HorizontalAlignment = 1;
            refe.VerticalAlignment = 1;
            dtable.AddCell(refe);

            PdfPCell stat1 = new PdfPCell(new Phrase("Status: ", fnt4ColumnHeader));
            stat1.HorizontalAlignment = 1;
            stat1.VerticalAlignment = 1;
            dtable.AddCell(stat1);

            PdfPCell stat = new PdfPCell(new Phrase(pd.status, fnt4ColumnHeader));
            stat.HorizontalAlignment = 1;
            stat.VerticalAlignment = 1;
            dtable.AddCell(stat);

            PdfPCell prazno2 = new PdfPCell(new Phrase("  "));
            prazno2.Colspan = 3;
            dtable.AddCell(prazno2);

            PdfPCell napomena = new PdfPCell(new Phrase("Napomena-Bemerkung : ", fnt2ColumnHeader));

            napomena.HorizontalAlignment = 0;
            napomena.HorizontalAlignment = Element.ALIGN_MIDDLE;

            dtable.AddCell(napomena);

            PdfPCell napomena1 = new PdfPCell(new Phrase(pd.napo, fnt2ColumnHeader));

            napomena1.Colspan = 4;
            napomena1.VerticalAlignment = Element.ALIGN_MIDDLE;

            dtable.AddCell(napomena1);
            PdfPCell napomena2 = new PdfPCell(new Phrase(pd.napnab, fnt2ColumnHeader));

            napomena2.Colspan = 3;
            napomena2.VerticalAlignment = Element.ALIGN_MIDDLE;

            dtable.AddCell(napomena2);

            PdfPTable idtable = new PdfPTable(3);
            idtable.TotalWidth = 700f;
            idtable.HorizontalAlignment = Element.ALIGN_CENTER;

            float[] idcolumnWidthts = new float[] { 10f, 20f, 10f};
            idtable.SetWidths(idcolumnWidthts);
            idtable.LockedWidth = true;

            /* PdfPCell zahpo = new PdfPCell(new Phrase("Zahtjev podnosi: ", new Font(fntColumnHeader)));
             zahpo.HorizontalAlignment = 2;
             zahpo.VerticalAlignment = 1;
             zahpo.Border = 0;
             idtable.AddCell(zahpo);
             PdfPCell zahpo2 = new PdfPCell(new Phrase(pd.ime, new Font(fntColumnHeader)));
             zahpo2.HorizontalAlignment = 1;
             zahpo2.VerticalAlignment = 1;
             idtable.AddCell(zahpo2);*/
            PdfPCell zahpo = new PdfPCell(new Phrase(" ", new Font(fntColumnHeader)));
            zahpo.HorizontalAlignment = 2;
            zahpo.VerticalAlignment = 1;
           zahpo.Border = 0;
            idtable.AddCell(zahpo);



            if (string.IsNullOrEmpty(pd.vrsta))
            {
                PdfPCell zahm = new PdfPCell(new Phrase("Zahtjev za materijalom", new Font(fnt1ColumnHeader)));
                zahm.HorizontalAlignment = 1;
                zahm.Border = 0;
               // zahm.Colspan = 4;
                idtable.AddCell(zahm);
            }
            else
            {
                if (pd.vrsta.Equals("MATERIJAL") == true)
                {
                    PdfPCell zahm = new PdfPCell(new Phrase("Zahtjev za materijalom", new Font(fnt1ColumnHeader)));
                    zahm.HorizontalAlignment = 1;
                    zahm.Border = 0;
                   // zahm.Colspan = 4;
                    idtable.AddCell(zahm);
                }
                else if (pd.vrsta.Equals("PONUDA") == true)
                {
                    PdfPCell zahp = new PdfPCell(new Phrase("Zahtjev za ponudom", new Font(fnt1ColumnHeader)));
                    zahp.HorizontalAlignment = 1;
                    zahp.Border = 0;
                    zahp.Colspan = 2;
                    idtable.AddCell(zahp);
                }
            }

            PdfPCell idbroj = new PdfPCell(new Phrase("No: "+ pd.ide, new Font(fnt4ColumnHeader)));
            idbroj.HorizontalAlignment = 2;
            idbroj.VerticalAlignment = Element.ALIGN_MIDDLE;
            idbroj.Border =0;
            idtable.AddCell(idbroj);

            /*
            PdfPCell idbroj2 = new PdfPCell(new Phrase(pd.ide, new Font(fnt4ColumnHeader)));
            idbroj2.HorizontalAlignment = 1;
            idbroj2.VerticalAlignment = Element.ALIGN_MIDDLE;
            idtable.AddCell(idbroj2);
            PdfPCell blank = new PdfPCell(new Phrase(" ", new Font(fnt1ColumnHeader)));
            blank.HorizontalAlignment = 1;
            blank.Border = 0;
            blank.Colspan = 6;
            idtable.AddCell(blank);*/



            PdfPTable mimax = new PdfPTable(3);
            mimax.TotalWidth = 700f;
            PdfPCell misif = new PdfPCell(new Phrase(pd.ident_sifra, new Font(fntColumnHeader)));
            misif.HorizontalAlignment = 1;
            misif.VerticalAlignment = Element.ALIGN_MIDDLE;
            // mimax.AddCell(misif);
            PdfPCell misif1 = new PdfPCell(new Phrase(pd.ident_sifra2, new Font(fntColumnHeader)));
            misif1.HorizontalAlignment = 1;
            misif1.VerticalAlignment = Element.ALIGN_MIDDLE;
            //   mimax.AddCell(misif1);
            PdfPCell misif2 = new PdfPCell(new Phrase(pd.ident_sifra3, new Font(fntColumnHeader)));
            misif2.HorizontalAlignment = 1;
            misif2.VerticalAlignment = Element.ALIGN_MIDDLE;
            //  mimax.AddCell(misif2);


            //  mimax.AddCell(misif2);
            mimax.AddCell(ppolje);
            mimax.AddCell(ppolje);
            mimax.AddCell(ppolje);

            PdfPCell mimax1 = new PdfPCell(new Phrase("MIN: " + pd.min + " " + pd.jm + "\nMAX: " + pd.max + " " + pd.jm + "\nSTANJE: " + pd.stanje + " " + pd.jm, new Font(fntColumnHeader)));
            mimax1.HorizontalAlignment = 1;
            mimax1.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (pd.min != "" && pd.min2 == "" && pd.min3 == "")
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
            PdfPCell mimax2 = new PdfPCell(new Phrase("MIN: " + pd.min2 + " " + pd.jm2 + "\nMAX: " + pd.max2 + " " + pd.jm2 + "\nSTANJE: " + pd.stanje2 + " " + pd.jm2, new Font(fntColumnHeader)));
            mimax2.HorizontalAlignment = 1;
            mimax2.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (pd.min != "" && pd.min3 == "" && pd.min2 != "")
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

            if (pd.min != "" && pd.min2 != "" && pd.min3 != "")
            {
                PdfPCell mimax3 = new PdfPCell(new Phrase("MIN: " + pd.min3 + " " + pd.jm3 + "\nMAX: " + pd.max3 + " " + pd.jm3 + "\nSTANJE: " + pd.stanje3 + " " + pd.jm3, new Font(fntColumnHeader)));
                mimax3.HorizontalAlignment = 1;
                mimax3.VerticalAlignment = Element.ALIGN_MIDDLE;
                mimax.AddCell(misif);
                mimax.AddCell(misif1);
                mimax.AddCell(misif2);
                mimax.AddCell(mimax1);
                mimax.AddCell(mimax2);
                mimax.AddCell(mimax3);
            }






            PdfPTable stokhitno = new PdfPTable(3);
            stokhitno.TotalWidth = 700f;
            stokhitno.HorizontalAlignment = Element.ALIGN_CENTER;

            float[] shWidthts = new float[] { 20f, 20f, 20f };
            stokhitno.SetWidths(shWidthts);
            stokhitno.LockedWidth = true;
            PdfPCell stok = new PdfPCell(new Phrase(" ŠTOK ", new Font(fnt3ColumnHeader)));
            stok.HorizontalAlignment = 1;
            stok.Border = 0;




            PdfPCell ppolje1 = new PdfPCell(new Phrase(" ", new Font(fnt3ColumnHeader)));
            ppolje1.HorizontalAlignment = 1;
            ppolje1.Border = 0;

            if (string.IsNullOrEmpty(pd.stoks))

            { }
            else
            {
                if (pd.stoks.Equals("DA") == true)
                {
                    stokhitno.AddCell(ppolje1);
                    stokhitno.AddCell(stok);
                    stokhitno.AddCell(ppolje1);
                }

                else
                {

                }
            }
            string folderPath = @"C:\Users\Public\Documents\ZZM\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Paragraph razmak = new Paragraph();
            razmak.Alignment = Element.ALIGN_CENTER;





            razmak.Add(new Chunk("\n "));


            using (FileStream stream = new FileStream(folderPath + " " + pd.ime + " " + pd.datum + " No. " + pd.ide.Trim() +  ".pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4.Rotate());
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();


               

                pd.folderPath2 = @"C:\Users\Public\Documents\ZZM\" + " " + pd.ime + " " + pd.datum + " No. " + pd.ide.Trim() +  ".pdf";
                pdfDoc.Add(idtable);

                pdfDoc.Add(stokhitno);
                pdfDoc.Add(infotable);
                //pdfDoc.Add(razmak);
                pdfDoc.Add(table);
                // pdfDoc.Add(razmak);
                pdfDoc.Add(dtable);

                if (pd.min != "")
                {
                    pdfDoc.Add(mimax);
                }



                pdfDoc.Close();
                stream.Close();

               // axAcroPDF1.src = folderPath2;




               // File.Delete(folderPath2);


            }

            

            return true;
        }



        public static void BindGridDataSource(DataGridView grid)
        {
            // Bind grid to data source
        }
       




    }

}
