using Generics_DAL;
using Generics_DAL.Data;
using Generics_DAL.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Voorbeeld1();
            Console.ReadLine();

            Voorbeeld2();
            Console.ReadLine();
        }

        private static void Voorbeeld1()
        {
            int getal1 = 1;
            int getal2 = 2;

            Afdrukken("Voor", getal1, getal2);
            Omwisselen(ref getal1, ref getal2);
            Afdrukken("Na omwisselen", getal1, getal2);

            string waarde1 = "a";
            string waarde2 = "b";

            Afdrukken("Voor", waarde1, waarde2);
            Omwisselen(ref waarde1, ref waarde2);
            Afdrukken("Na omwisselen", waarde1, waarde2);
        }


        private static void Omwisselen<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;

        }
        private static void Afdrukken<T>(string titel, T x, T y)
        {
            Console.WriteLine(titel);
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        //private static void Omwisselen(ref string x, ref string y)
        //{
        //    string temp = x;
        //    x = y;
        //    y = temp;

        //}
        //private static void Omwisselen(ref int x, ref int y)
        //{
        //    int temp = x;
        //    x = y;
        //    y = temp;

        //}
        //private static void Afdrukken(string titel, int x, int y)
        //{
        //    Console.WriteLine(titel);
        //    Console.WriteLine(x);
        //    Console.WriteLine(y);
        //}

        //private static void Afdrukken(string titel, string x, string y)
        //{
        //    Console.WriteLine(titel);
        //    Console.WriteLine(x);
        //    Console.WriteLine(y);
        //}

        private static void Voorbeeld2()
        {
            VerkoopBeheerEntities verkoopBeheerEntities = new VerkoopBeheerEntities();
            //opvullen van lijsten
            List<Product> producten = DatabaseOperations.OphalenProducten();
            List<Klant> klanten = DatabaseOperations.OphalenKlanten();

            //Afdrukken van lijsten
            AfdrukkenLijst(producten);
            AfdrukkenLijst(klanten);

        }



        //private static void AfdrukkenLijst(List<Product> lijst)
        //{
        //    //headers
        //    foreach (var props in typeof(Product).GetProperties())
        //    {
        //        Console.Write(props.Name + ";") ;
        //    }
        //    Console.WriteLine();
        //    //values
        //    foreach (var item in lijst)
        //    {
        //        foreach (var props in typeof(Product).GetProperties())
        //        {
        //            Console.Write(props.GetValue(item)+";");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //private static void AfdrukkenLijst(List<Klant> lijst)
        //{
        //    //headers
        //    foreach (var props in typeof(Klant).GetProperties())
        //    {
        //        Console.Write(props.Name + ";");
        //    }
        //    Console.WriteLine();
        //    //values
        //    foreach (var item in lijst)
        //    {
        //        foreach (var props in typeof(Klant).GetProperties())
        //        {
        //            Console.Write(props.GetValue(item)+";");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        private static void AfdrukkenLijst<T>(List<T> lijst)
        {
            //headers
            foreach (var props in typeof(T).GetProperties())
            {
                Console.Write(props.Name + ";");
            }
            Console.WriteLine();
            //values
            foreach (var item in lijst)
            {
                foreach (var props in typeof(T).GetProperties())
                {
                    Console.Write(props.GetValue(item) + ";");
                }
                Console.WriteLine();
            }
        }
    }
}
