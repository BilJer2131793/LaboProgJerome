using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Agence
{
    partial class Mission
    {
        public void CompleterMission()
        {
            Statut = Statut.terminee;
            Destination.Explore = true;
            Console.WriteLine($"La mission {Nom} a ete terminée\n" +
                $"date de debut: {DateDepart}\n" +
                $"date de completion Prevu: {DatePrevu}\n" +
                $"{Destination}\n");
        }

    }
}
