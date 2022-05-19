using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Linq;

using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using SteamworksSharp;
using SteamworksSharp.Native;
using System.Threading.Tasks;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Utilisateur u1 = new Utilisateur("Axlr",45678905);

            Jeu j1 = new Jeu(
                "Vampire Survivors est un Rogue Light.",
                new Jeu.PatchNote(0, 5, 2, "De nombreux changements sont apparus."));

            HashSet<ArmePassive> ap1 = new HashSet<ArmePassive>();
            HashSet<ArmeActive> aa1 = new HashSet<ArmeActive>();
            HashSet<Amelioration> am1 = new HashSet<Amelioration>();
            HashSet<Personnage> p1 = new HashSet<Personnage>();
            HashSet<Ennemie> e1 = new HashSet<Ennemie>();
            HashSet<Carte> c1 = new HashSet<Carte>();

            AjoutCollection(ap1,
                new ArmePassive("Passive 3"),
                new ArmePassive("Passive 1"),
                new ArmePassive("Passive 2")
                );

            AjoutCollection(aa1,
                new ArmeActive("Active 3"),
                new ArmeActive("Active 1"),
                new ArmeActive("Active 2")
                );

            AjoutCollection(am1,
                new Amelioration("Amelioration 3"),
                new Amelioration("Amelioration 1"),
                new Amelioration("Amelioration 2")
                );

            AjoutCollection(p1,
                new Personnage("Personnage 3", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Personnage("Personnage 1", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Personnage("Personnage 2", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20)))
                );

            AjoutCollection(e1,
                new Ennemie("Ennemie 3", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Ennemie("Ennemie 1", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Ennemie("Ennemie 2", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20)))
                );

            AjoutCollection(c1,
                new Carte("Carte 3", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList()),
                new Carte("Carte 1", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList()),
                new Carte("Carte 2", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList())
                );

            AffichList(ap1);
            AffichList(aa1);
            AffichList(am1);
            AffichList(p1);
            AffichList(e1);
            AffichList(c1);

            ap1 = TriNom(ap1);
            AffichList(ap1);


            //// STEAM API

            ulong userId = InitializeSteam();

            
            
            // Web API (différente)

            var webInterfaceFactory = new SteamWebInterfaceFactory("A44E58E08ACF6F1C2AA345462C1E6FBE"); // on initialize notre créateur d'interface entre steam et l'application avec la clé d'authentification steam partner

            // Succés

            var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(); // on créer une interface UserStats

            var ach = await steamUserInterface.GetPlayerAchievementsAsync(1794680, userId); // on récupere les succés de l'utilisateur sur Vampire Survivors

            IEnumerator<Steam.Models.SteamPlayer.PlayerAchievementModel> res = ach.Data.Achievements.GetEnumerator(); // création d'un iterateur pour parcourir la liste des succés
            res.MoveNext(); // on avance une première fois l'itérateur car il se trouve sur une valeur null au début

            while (res.MoveNext()) // tant que l'iterateur n'est pas null afficher Nom + desc + validation
            {
                Console.WriteLine("Achievement name : "+res.Current.Name);
                Console.WriteLine("Achievement descirption : "+ res.Current.Description);
                Console.WriteLine("Achieved ? (1=yes / 0=no) : "+res.Current.Achieved);
                res.MoveNext();
            }

            
            // News (en test)
            /*
            var steamNewsInterface = webInterfaceFactory.CreateSteamWebInterface<SteamNews>(new System.Net.Http.HttpClient());
            var news = await steamNewsInterface.GetNewsForAppAsync(1794680);
            
            IEnumerator<Steam.Models.NewsItemModel> resNews = news.Data.NewsItems.GetEnumerator(); // création d'un iterateur pour parcourir la liste des succés
            resNews.MoveNext();
            Console.WriteLine(resNews.Current.Title);
            Console.WriteLine("\n"+resNews.Current.Contents+"\n");
            Console.WriteLine(resNews.Current.Author);
            */
            
        }
        static void AffichList(IEnumerable<Element> liste)
        {
            foreach (Element ele in liste)
            {
                Console.WriteLine(ele.Nom);
            }
        }

        static HashSet<T> TriNom<T>(HashSet<T> liste) where T : Element
        {
            var res = liste.OrderBy(a => a.Nom);
            return res.ToHashSet();
        }

        static void AjoutCollection<T>(HashSet<T> list, params T[] liste) where T : Element
        {
            list.UnionWith(liste);
        }
        static List<Stat> ConstructionParticularite(params Stat[] liste)
        {
            List<Stat> res = new List<Stat>();
            res.AddRange(liste);
            return res;
        }

        static ulong InitializeSteam()
        { 
            // Native API 

            // Lancer steam
            SteamNative.Initialize(); // initialisation de Steam Native (permet de détecter le lancement de steam sur la machine)
            var result = SteamApi.IsSteamRunning(); // verifie si steam est lancer
            if (!result) Console.WriteLine("Veuillez lancé steam !"); // si il n'est pas lancé, affiche un message pour demander de laner
            while (!result) // tant que steam n'est pas lancer réessayer
            {
                result = SteamApi.IsSteamRunning();
            }
            Console.WriteLine("Steam c'est bien lancé"); // une fois lancer on envoie un message pour le dire
            SteamApi.Initialize(1794680); // on initialise l'api sur Vampire Survivors
            
            // Récupération des infos de l'utilisateur

            string userName = SteamApi.SteamFriends.GetPersonaName(); // on récupère le nom de l'utilisateur
            Console.WriteLine($"Logged in as: {userName}"); // on écrit le nom de l'utilisateur

            var userId = SteamApi.SteamUser.GetSteamID(); // on récupère l'identifiant de l'utilisateur

            return userId;
        }
    }
}
