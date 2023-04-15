using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_films
{
    partial class Catalogue
    {
        public void RechercheParTitre(string titre)
        {
            bool trouve = false;

            for(int i = 0; i < listF.Count() && !trouve; i++)
            {
                if(titre == listF[i].Titre)
                {
                    trouve = true;
                    Console.WriteLine(listF[i]);
                    listF[i].AfficherGenre();
                    listF[i].AfficherActeur();
                }
            }
            if (!trouve)
            {
                Console.WriteLine("Aucun film avec ce titre a ete trouver");
            }
        }
        public void RechercheParActeur()
        {
            bool trouve = false;



            if (!trouve)
            {
                Console.WriteLine("Aucun film avec ce titre a ete trouver");
            }
        }


    }
}
