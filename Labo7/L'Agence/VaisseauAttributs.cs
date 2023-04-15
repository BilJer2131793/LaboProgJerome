using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Agence
{
    partial class Vaisseau
    {
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public int VitesseAct { get; set; }
        public int VitesseMax { get; set; }
        public int Mission{ get; set; }
        public int Prix { get; set; }
        public bool EnOrbite { get; set; }
        public Vaisseau()
        {

        }
        public Vaisseau(string nom, int capacite, int vitesseMax, int prix = 0)
        {
            Nom = nom;
            Capacite = capacite;
            VitesseAct = 0;
            VitesseMax = vitesseMax;
            EnOrbite = false;
            Prix = prix;
        }
        public override string ToString()
        {
            return $"Nom: {Nom}, Vitesse Maximum: {VitesseMax}";
        }

    }
}
