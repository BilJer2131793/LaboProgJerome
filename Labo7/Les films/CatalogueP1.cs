using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_films
{
    partial class Catalogue
    {
        List<Film> listF;

        public void AjouterFilm()
        {
            Film film = new Film();
            listF.Add(film);
        }
        public void SupprimerFilm()
        {
            AfficherFilms();
            Console.WriteLine("Quelle film voulez vous SUPRIMER");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Etez vous sur de vouloir supprimer " + listF[i-1] + "        O/N");
            string choix = Console.ReadLine().ToUpper();
            if(choix == "O")
            {
                listF.RemoveAt(i - 1);
            }
        }
        public void AjouterActeur()
        {
            AfficherFilms();



        }
        public void AfficherFilms()
        {
            int i = 1;
            foreach (Film film in listF)
            {
                Console.WriteLine($"({i}) {film}");
                i++;
            }
        }

    }
}
