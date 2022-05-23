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
