using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Agence
{
    partial class Vaisseau
    {
        public void Decollage()
        {
            try
            {
                if (EnOrbite)
                    throw new Exception("Le vaisseau est deja en orbit");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangerVitesse()
        {
            Console.WriteLine("Rentrez la nouvelle vitesse");
            int choix = CheckChoix(VitesseMax);
            try
            {
                if (choix > VitesseMax)
                    throw new Exception("La vitesse demandée dépasse la vitesse maximale du vaisseau");

                VitesseAct = choix;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ChangerVitesse();
            }
        }
        public int CheckChoix(int max)
        {
            int choix = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (choix > max || choix < 0)
                {
                    throw new Exception("Le chiffre rentre est incorrect");
                }
                return choix;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                choix = CheckChoix(max);
                return choix;
            }

        }

    }
}
