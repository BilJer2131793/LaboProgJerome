using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Agence
{
    enum Statut
    {
        planifiee,
        en_cours,
        terminee
    }
    partial class Mission
    {
        static int Count = 0;
        public string Nom { get; set; }
        public int ID { get; set; }
        public Planete Destination { get; set; }
        public int Distance { get; set; }
        public string DateDepart { get; set; }
        public string DatePrevu { get; set; }
        public Statut Statut { get; set; }
        public Mission(string nom, Planete destination)
        {
            Nom = nom;
            Destination = destination;
            Distance = destination.Distance;
            Statut = Statut.planifiee;
            ID = Count;
            Count++;
        }
    }
}
