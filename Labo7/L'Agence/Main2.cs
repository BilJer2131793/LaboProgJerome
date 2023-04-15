using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace L_Agence
{
    internal class Main2
    {
        List<Planete> listP;
        List<Mission> listM;
        List<Vaisseau> listV;
        List<Vaisseau> listVMag;
        int dateAdd;
        int Argent;

        public Main2()
        {
            listP = new List<Planete>();
            CreationPlanete();
            listM = new List<Mission>();
            CreationMission();
            listV = new List<Vaisseau>();
            listV.Add(new Vaisseau("Apollo V", 4, 1000));
            listVMag = new List<Vaisseau>();
            CreationVaisseau();
            dateAdd = 0;
            Argent = 100000000;
        }
        public void Start()
        {
            bool fini = false;
            while (!fini)
            {
                Menu();
                AvancementTour();
                CheckFini();
            }
        }
        public void Menu()
        {
            string date = DateTime.UtcNow.AddYears(dateAdd).ToString("dd-MM-yyyy");
            Console.WriteLine("Date: " + date);
            Console.WriteLine("Argent: " + Argent);

            Console.WriteLine("\n\n(1)  Lancer une fusee\n" +
                "(2)  Changer Vitesse\n" +
                "(3)  Magasin\n" +
                "(4)  Attendre\n");
            int choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    ChoisirMission();
                    break;
                case 2:
                    ChangerVitesse();
                    break;
                case 3:
                    Magasin();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
        public void ChoisirMission()
        {
            int i = 1;
            List<Mission> listMC = new List<Mission>();
            Console.WriteLine("Choisisez la mission:");
            foreach (Mission mission in listM)
            {
                if (mission.Statut == Statut.planifiee)
                {
                    listMC.Add(mission);
                    Console.WriteLine($"({i}). {mission.Nom}, Distance: {mission.Distance}");
                    i++;
                }
            }
            Console.WriteLine($"({i}). Retour");
            int choix = CheckChoix(i);
            if (choix == i)
            {
                Menu();
            }
            else
            {
                Choisirfusee(listMC[choix - 1]);
            }

        }
        public void Choisirfusee(Mission mChoisi)
        {
            int i = 1;
            List<Vaisseau> listVC = new List<Vaisseau>();
            foreach (Vaisseau vaisseau in listV)
            {
                if (!vaisseau.EnOrbite)
                {
                    listVC.Add(vaisseau);
                    Console.WriteLine($"({i}). {vaisseau}");
                    i++;
                }
            }
            Console.WriteLine($"({i}). Retour");
            int choix = CheckChoix(i);
            if (choix == i)
            {
                Menu();
            }
            else
            {
                int numM = TrouverMission(mChoisi);
                int numV = TrouverVaisseau(listV, listVC[choix - 1]);
                listV[numV].EnOrbite = true;
                listV[numV].Mission = listM[numM].ID;
                listM[numM].DatePrevu = DateTime.UtcNow.AddYears(dateAdd + (listM[numM].Destination.Distance / listVC[choix - 1].VitesseMax)).ToString("dd-MM-yyyy");
            }
        }

        public void ChangerVitesse()
        {
            int i = 1;
            List<Vaisseau> listVC = new List<Vaisseau>();
            Console.WriteLine("Quele vitesse voulez vous changer:");
            foreach (Vaisseau vaisseau in listV)
            {
                if (vaisseau.EnOrbite)
                {
                    listVC.Add(vaisseau);
                    Console.WriteLine($"({i}). {vaisseau}   Vitesse Actuel: {vaisseau.VitesseAct}   Vitesse Max: {vaisseau.VitesseMax}");
                    i++;
                }
            }
            Console.WriteLine($"({i}). Retour");
            int choix = CheckChoix(i);
            if (choix == i)
            {
                Menu();
            }
            else
            {
                int numV = TrouverVaisseau(listV, listVC[choix - 1]);
                listV[numV].ChangerVitesse();
            }
        }
        public void Magasin()
        {
            Console.WriteLine($"(1). Augmenter Vitesse Max\n" +
                $"(2). Acheter un nouveau Vaisseau\n" +
                $"(3). Retour\n");
            int choix = CheckChoix(3);
            switch (choix)
            {
                case 1:
                    MagAugmentation();
                    break;
                case 2:
                    MagVaisseau();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        public void MagAugmentation()
        {
            Console.WriteLine($"(1). Augmenter Vitesse de 500       (1000$)\n" +
                            $"(2). Augmenter Vitesse de 1000       (1900$)\n" +
                            $"(3). Augmenter Vitesse de 1500       (2700$)\n" +
                            $"(4). Augmenter Vitesse de 2000       (3500$)\n" +
                            $"(5). Retour\n");
            int choix = CheckChoix(5);
            if (choix == 5)
            {
                Magasin();
            }
            else
            {
                if (choix == 1 && CheckArgent(1000))
                    AugmenterVaisseau(500);
                else if (choix == 2 && CheckArgent(1900))
                    AugmenterVaisseau(1000);
                else if (choix == 3 && CheckArgent(2700))
                    AugmenterVaisseau(1500);
                else if (choix == 4 && CheckArgent(3500))
                    AugmenterVaisseau(2000);
            }
        }
        public void MagVaisseau()
        {
            int i = 1;
            List<Vaisseau> listVC = new List<Vaisseau>();
            Console.WriteLine("Quel Vaisseau voulez vous achetez? ");
            foreach (Vaisseau v in listVMag)
            {
                if (v.Prix != 0)
                {
                    listVC.Add(v);
                    Console.WriteLine($"({i}). {v.Nom}   Vitesse Max: {v.VitesseMax}   Prix: {v.Prix}");
                    i++;
                }
            }
            Console.WriteLine($"({i}). Retour");
            int choix = CheckChoix(i);
            if (choix == i)
            {
                Magasin();
            }
            else
            {
                int numV = TrouverVaisseau(listVMag, listVC[choix - 1]);
                if (CheckArgent(listVMag[numV].Prix))
                {
                    listVMag[numV].Prix = 0;
                    listV.Add(listVMag[numV]);
                    Console.WriteLine("Les fonds ont ete retirer de votre compte\n");
                }
            }
        }

        public void AugmenterVaisseau(int augmentation)
        {
            int i = 1;
            Console.WriteLine("Quelle vaisseaux voulez vous augmenter");
            foreach (Vaisseau vaisseau in listV)
            {
                Console.WriteLine($"({i}). {vaisseau}       Vitesse Max. {vaisseau.VitesseMax}");
                i++;
            }
            Console.WriteLine($"({i}). Retour");
            int choix = CheckChoix(i);
            if (choix == i)
            {
                Menu();
            }
            else
            {
                listV[choix - 1].VitesseMax += augmentation;
            }

        }
        public void AvancementTour()
        {
            foreach (Vaisseau v in listV)
            {
                if (v.EnOrbite)
                {
                    if (v.VitesseAct > 0)
                        Argent += 400;

                    listM[v.Mission].Distance -= v.VitesseAct;
                    if (listM[v.Mission].Distance <= 0)
                    {
                        v.EnOrbite = false;
                        v.VitesseAct = 0;
                        listM[v.Mission].CompleterMission();
                        Argent += listM[v.Mission].Destination.Distance;
                    }
                }
            }
            dateAdd++;
        }
        public bool CheckFini()
        {
            foreach (Mission m in listM)
            {
                if (m.Statut != Statut.terminee)
                    return false;
            }
            return true;
        }
        public void CreationPlanete()
        {
            listP.Add(new Planete("Mars", 2000, 3000, true));
            listP.Add(new Planete("Pluto", 300, 9000, false));
            listP.Add(new Planete("Terrra", 4000, 10000, true));
            listP.Add(new Planete("Farzar", 100, 100000000, false));
            listP.Add(new Planete("Louis", 400000, 2000000, true));
        }
        public void CreationMission()
        {
            foreach (Planete planete in listP)
            {
                listM.Add(new Mission($"Operation {planete.Nom}", planete));
            }
        }
        public void CreationVaisseau()
        {
            listVMag.Add(new Vaisseau("Artemis XII", 7, 2000, 5000));
            listVMag.Add(new Vaisseau("Galactica", 15, 2500, 7000));
            listVMag.Add(new Vaisseau("Avadora", 12, 7000, 15000));
            listVMag.Add(new Vaisseau("STS Vincent", 12, 20000, 30000));
        }
        public int CheckChoix(int max)
        {
            int choix = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (choix > max || choix < 0)
                {
                    throw new Exception("Le chiffre rentre est trop grand");
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
        public int TrouverMission(Mission mChoisi)
        {
            bool check = false;
            for (int k = 0; !check; k++)
            {
                if (listM[k] == mChoisi)
                {
                    listM[k].Statut = Statut.en_cours;
                    listM[k].DateDepart = DateTime.UtcNow.AddYears(dateAdd).ToString("dd-MM-yyyy");
                    return k;
                }
            }
            return 0;
        }
        public int TrouverVaisseau(List<Vaisseau> list, Vaisseau v)
        {
            for (int k = 0; k < list.Count; k++)
            {
                if (list[k] == v)
                {
                    return k;
                }
            }
            return 0;
        }
        public bool CheckArgent(int cout)
        {
            try
            {
                if (Argent < cout)
                    throw (new Exception("Vous avez pas assez d'argent"));
                Argent -= cout;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
