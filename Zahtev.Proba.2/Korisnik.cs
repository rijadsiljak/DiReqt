using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiReqt
{
    class Korisnik
    {
        static string korisnicko_ime;
        static string pime;
        static string brz;
        static string jezik;

       public static string korisnicko
        {
            get
            { return korisnicko_ime; }
            set
            { korisnicko_ime = value; }
        }


        public static string Pime
        {
            get
            {

                return pime;

            }

            set
            {
                pime = value;
            }

        }
             public static string Brz
        {
            get
            {

                return brz;

            }

            set
            {
                brz = value;
            }
        }
        public static string Jezik
        {
            get
            { return jezik; }

            set
            {  jezik=value; }

        }

    }
    
}
