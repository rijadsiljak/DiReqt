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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiReqt
{
    class NabavkaDB
    {
/*
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = SERVER2008\\SAFEQ4SQL; Initial Catalog = Zahtjev_za_materijalom; Integrated Security = True");
            SqlCommand command = new SqlCommand();

            return connection;
        }

        /*  public static Zahtjev GetZahtjev(int LibraryID)
          { 

          SqlConnection conn = GetConnection();

          SqlCommand selectCommand = new SqlCommand("Select * from DiReqt where id=@Number", conn);
          selectCommand.Parameters.AddWithValue("@Number", LibraryID);

              try
              {
                  conn.Open();
                  SqlDataReader reader = selectCommand.ExecuteReader();
                  if (reader.Read())
                  {
                      Zahtjev st = new Zahtjev();
          st.LibraryID = Convert.ToInt32(reader["LibraryID"]);
                      st.fName = reader["Fname"].ToString();
          st.lName = reader["Lname"].ToString();
          st.BooksInPossesion = Convert.ToInt32(reader["BooksInPossesion"]);
                      st.bDate = reader["BDate"].ToString();
          st.Faculty = reader["Faculty"].ToString();
          st.City = reader["City"].ToString();
          st.Street = reader["Street"].ToString();
          st.StaffID = Convert.ToInt32(reader["StaffID"]);
                      st.Phone = reader["Phone"].ToString();
          st.ZIP = Convert.ToInt32(reader["ZIP"]);

                      return st;
                  }
                  else
                  {
                      return null;
                  }


              }

              catch (SqlException ex)
              {
                  throw ex;
              }
              finally
              {
                  conn.Close();
              }


      }*/
    }
}