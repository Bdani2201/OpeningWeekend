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
            Beolvas();
            //-- 3. feladat
            Console.WriteLine("\n3. feladat:");
            Console.WriteLine($"\tFilmek száma az állományban: {Filmek.Count} db");
            Console.WriteLine("\n4. feladat:");
            Console.WriteLine($"\tUIP Duna Film forgalmazó 1. hetes bevételeinek összege: {Feladat04().ToString("C0")}");
            Console.WriteLine("\n5. feladat:");
            string ezresFormat = "#,##0";
            Film legtobb = Feladat05();
            Console.WriteLine($"\tEredeti cím:\t {legtobb.EredetiCim}");
            Console.WriteLine($"\tMagyar cím:\t {legtobb.MagyarCim}");
            Console.WriteLine($"\tForgalmazó:\t {legtobb.Forgalmazo}");
            Console.WriteLine($"\tBevétel az első héten:\t {legtobb.Bevetel.ToString("C0")}");
            Console.WriteLine($"\tLátogatók száma:\t {legtobb.Latogato.ToString(ezresFormat)}");

            Console.WriteLine("\n6. feladat:");
            if (Feladat06())
            {
                Console.WriteLine("\tIlyen film volt!");
            }
            else
            {
                Console.WriteLine("\tIlyen film NEM volt! ");
            }
            Console.WriteLine("\n7. feladat:");
            Feladat07();

            Console.WriteLine("\n6. feladat:");
            Console.WriteLine($"\tA leghosszabb időszak két InterCom-os bemutató között: {Feladat08()} nap");
            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
        }
   
        // 2. 
        static void Beolvas()
        {
            string fajl = @"..\..\nyitohetvege.txt";
            StreamReader sr = null;
            try
            {
                using (sr=new StreamReader(fajl))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        Filmek.Add(
                            new Film(
                                sor[0],
                                sor[1],
                                DateTime.Parse(sor[2]),
                                sor[3],
                                double.Parse(sor[4]),
                                int.Parse(sor[5]))
                            );
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (sr!=null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
        }
       
       // 4. 
        static double Feladat04()
        {
            return Filmek.FindAll(x => x.Forgalmazo.Equals("UIP")).Sum(y => y.Bevetel);
        }

        static Film Feladat05()
        {
            double max = Filmek.Max(x => x.Latogato);
            return Filmek.Find(y => y.Latogato == max);
        }
    }
}
