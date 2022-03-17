using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OpeningWeekend
{
    class Film
    {
        public string EredetiCim;
        public string MagyarCim;
        public DateTime Bemutato;
        public string Forgalmazo;
        public double Bevetel;
        public int Latogato;

        public Film(string eredetiCim, string magyarCim, DateTime bemutato, string forgalmazo, double bevetel, int latogato)
        {
            EredetiCim = eredetiCim;
            MagyarCim = magyarCim;
            Bemutato = bemutato;
            Forgalmazo = forgalmazo;
            Bevetel = bevetel;
            Latogato = latogato;
        }
    }
    class Program
    {
        static List<Film> Filmek = new List<Film>();
        static void Main(string[] args)
        {

        }
    }
}

