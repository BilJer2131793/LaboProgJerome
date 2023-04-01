using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo7
{
    internal class Calculateur
    {

        public double Diviser(double x, double y)
        {
            double reponse = 0;
            try
            {
                reponse = x / y;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }

        public double Multiplier(double x, double y)
        {
            double reponse = 0;
            try
            {
                reponse = x * y;
            }
            catch(OverflowException ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }

        public long Multiplier(long x, long y)
        {
            long reponse = x * y;
            try
            {
                reponse = x * y;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }



    }
}
