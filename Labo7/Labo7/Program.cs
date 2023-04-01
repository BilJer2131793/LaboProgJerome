using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculateur calc = new Calculateur();

            Console.WriteLine("Division");
            Console.WriteLine("premier chiffre");
            double i = RentreNombre();
            Console.WriteLine("deuxieme chiffre");
            double n = RentreNombre();

            Console.WriteLine(calc.Diviser(i, n));

            Console.WriteLine("Multiplication");
            Console.WriteLine("premier chiffre");
            double x = RentreNombre();
            Console.WriteLine("deuxieme chiffre");
            double y = RentreNombre();

            Console.WriteLine(calc.Multiplier(x, y));

            Console.ReadLine();
        }


        static public double RentreNombre()
        {
            double i = 0;
            try
            {
                i = Convert.ToDouble(Console.ReadLine());
                if (i > 1000000000)
                    throw new Exception("Le chiffre rentré est tros grand");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
                i = RentreNombre();
            }

            return i;
        }

    }
}
