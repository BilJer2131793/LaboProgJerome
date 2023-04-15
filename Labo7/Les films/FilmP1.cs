using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_films
{
    partial class Film
    {
        public string Titre { get; set; }
        public string Directeur { get; set; }
        public int Annee { get; set; }
        List<string> Acteurs { get; set; }


        public Film(string titre, string directeur, int annee)
        {
            this.Titre = titre;
            this.Directeur = directeur;
            this.Annee = annee;
        }
        public Film()
        {
            Console.WriteLine("Titre de film");
            Titre = Console.ReadLine();
            Console.WriteLine("Nom du directeur");
            Directeur = Console.ReadLine();
            Console.WriteLine("Annee de creation");
            Annee = Convert.ToInt32(Console.ReadLine());
        }
    }
}
