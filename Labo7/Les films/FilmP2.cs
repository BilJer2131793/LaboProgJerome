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
        List<string> Genre { get; set; }




        public override string ToString()
        {
            return $"Titre: {Titre}, Realisateur: {Directeur}, Annee de sortie: {Annee}";
        }

    }
}
