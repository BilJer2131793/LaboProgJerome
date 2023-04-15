using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_films
{
    partial class Film
    {
        string Synopsis { get; set; }
        List<string> Genres { get; set; }


        public void AfficherActeur()
        {
            Console.WriteLine("Liste des Acteurs: ");
            foreach(string acteur in Acteurs)
            {
                Console.WriteLine(acteur);
            }
        }
        public void AfficherGenre()
        {
            Console.WriteLine("Liste des genres: ");
            foreach (string genre in Genres)
            {
                Console.WriteLine(genre);
            }
        }
        public override string ToString()
        {
            return $"Titre: {Titre}, Realisateur: {Directeur}, Annee de sortie: {Annee}";
        }

    }
}
