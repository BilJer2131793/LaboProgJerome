using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Agence
{
    class Planete
    {
        public string Nom { get; set; }
        public int Taille { get; set; }
        public int Distance { get; set; }
        public bool Atmosphere { get; set; }
        public bool Explore { get; set; }
        public Planete()
        {

        }
        public Planete(string nom, int taille, int distance, bool atmosphere)
        {
            Nom = nom;
            Taille = taille;
            Distance = distance;
            Atmosphere = atmosphere;
            Explore = false;
        }
        public void VerifieExplore()
        {
            try
            {
                if (Explore)
                    throw new Exception("Cette planete a deja ete exploré");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            string atmo;
            if (Atmosphere)
                atmo = "a une atmosphere habitable";
            else
                atmo = "a une atmosphere inhabitable";



            return $"La planete {Nom} {atmo}";
        }
    }
}
