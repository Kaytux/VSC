using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using SteamworksSharp;
using SteamworksSharp.Native;

namespace BibliothequeClassesVSC
{
    public class Manager : INotifyPropertyChanged
    {
        public IPersistanceManager Persistance { get; /*private*/ set; }
        public ReadOnlyCollection<ArmePassive> LesArmesPassives { get; private set; }

        private HashSet<ArmePassive> lesArmesPassives = new HashSet<ArmePassive>();
        public ReadOnlyCollection<ArmeActive> LesArmesActives { get; private set; }

        private HashSet<ArmeActive> lesArmesActives = new HashSet<ArmeActive>();
        public ReadOnlyCollection<Amelioration> LesAmeliorations { get; private set; }
        private HashSet<Amelioration> lesAmeliorations = new HashSet<Amelioration>();

        public ReadOnlyCollection<Personnage> LesPersonnages { get; private set; }
        private HashSet<Personnage> lesPersonnages = new HashSet<Personnage>();

        public ReadOnlyCollection<Ennemie> LesEnnemies { get; private set; }
        private HashSet<Ennemie> lesEnnemies = new HashSet<Ennemie>();

        public ReadOnlyCollection<Carte> LesCartes { get; private set; }
        private HashSet<Carte> lesCartes = new HashSet<Carte>();

        public Utilisateur utilisateur { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Arme ArmeSélectionné
        {
            get => armeSélectionné; 
            set
            {
                if(ArmeSélectionné != value)
                {
                    armeSélectionné = value;
                    OnPropertyChanged(nameof(ArmeSélectionné));
                }
            }
        }
        private Arme armeSélectionné; 
        
        public Personnage PersonnageSelectionne
        {
            get => personnageSelectionne;
            set
            {
                if (PersonnageSelectionne != value)
                {
                    personnageSelectionne = value;
                    OnPropertyChanged(nameof(PersonnageSelectionne));
                }
            }
        }
        private Personnage personnageSelectionne;

        public Ennemie EnnemieSelectionne
        {
            get => ennemieSelectionne;
            set
            {
                if (EnnemieSelectionne != value)
                {
                    ennemieSelectionne = value;
                    OnPropertyChanged(nameof(EnnemieSelectionne));
                }
            }
        }

        private Ennemie ennemieSelectionne;

        public List<Stat> StatsSelectionne
        {
            get => statsSelectionne;
            set
            {
                if (StatsSelectionne != value)
                {
                    statsSelectionne = value;
                    OnPropertyChanged(nameof(StatsSelectionne));
                }
            }
        }
        private List<Stat> statsSelectionne;

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ChargeDonnées()
        {
            var données = Persistance.ChargeDonnées();
            foreach (var donn in données.lesArmesPassives)
            {
                lesArmesPassives.Add(donn);
            }
            foreach (var donn in données.lesArmesActives)
            {
                lesArmesActives.Add(donn);
            }
            foreach (var donn in données.lesAmeliorations)
            {
                lesAmeliorations.Add(donn);
            }
            foreach (var donn in données.lesPersonnages)
            {
                lesPersonnages.Add(donn);
            }
            foreach (var donn in données.lesEnnemies)
            {
                lesEnnemies.Add(donn);
            }
            foreach (var donn in données.lesCartes)
            {
                lesCartes.Add(donn);
            }
            LesArmesPassives = new ReadOnlyCollection<ArmePassive>(new List<ArmePassive>(lesArmesPassives));
            LesArmesActives = new ReadOnlyCollection<ArmeActive>(new List<ArmeActive>(lesArmesActives));
            LesAmeliorations = new ReadOnlyCollection<Amelioration>(new List<Amelioration>(lesAmeliorations));
            LesPersonnages = new ReadOnlyCollection<Personnage>(new List<Personnage>(lesPersonnages));
            LesEnnemies = new ReadOnlyCollection<Ennemie>(new List<Ennemie>(lesEnnemies));
            LesCartes = new ReadOnlyCollection<Carte>(new List<Carte>(lesCartes));

            ArmeSélectionné = LesArmesActives[0];
            PersonnageSelectionne = LesPersonnages[0];
            EnnemieSelectionne = LesEnnemies[0];
        }

        public void SauvegardeDonnées()
        {
            Persistance.SauvegardeDonnées(lesArmesPassives,
                                          lesArmesActives,
                                          lesAmeliorations,
                                          lesPersonnages,
                                          lesEnnemies,
                                          lesCartes);
        }

        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
        }

        public void AffichList(IEnumerable<Element> liste)
        {
            foreach (Element ele in liste)
            {
                Console.WriteLine(ele.Nom);
            }
        }

        public HashSet<T> TriNom<T>(IEnumerable<T> liste) where T : Element
        {
            if(!liste.Any()) return null;
            var res = liste.OrderBy(a => a.Nom);

            switch(liste.GetType())
            {
                case IEnumerable<ArmePassive>:
                    LesArmesPassives = new ReadOnlyCollection<ArmePassive>(new List<ArmePassive>(lesArmesPassives));
                    break;
                case IEnumerable<ArmeActive>:
                    LesArmesActives = new ReadOnlyCollection<ArmeActive>(new List<ArmeActive>(lesArmesActives));
                    break;
                case IEnumerable<Amelioration>:
                    LesAmeliorations = new ReadOnlyCollection<Amelioration>(new List<Amelioration>(lesAmeliorations));
                    break;
                case IEnumerable<Personnage>:
                    LesPersonnages = new ReadOnlyCollection<Personnage>(new List<Personnage>(lesPersonnages));
                    break;
                case IEnumerable<Ennemie>:
                    LesEnnemies = new ReadOnlyCollection<Ennemie>(new List<Ennemie>(lesEnnemies));
                    break;
                case IEnumerable<Carte>:
                    LesCartes = new ReadOnlyCollection<Carte>(new List<Carte>(lesCartes));
                    break;
            }
            return res.ToHashSet();
        }
        public void InitSteamAPI()
        {
            SteamNative.Initialize();
        }
        public bool ChargeSteamAPI()
        {
            // Lancer steam
            // initialisation de Steam Native (permet de détecter le lancement de steam sur la machine)
            var result = SteamApi.IsSteamRunning(); // verifie si steam est lancer
            if (!result)
            {
                Debug.WriteLine("Veuillez lancé steam !"); // si il n'est pas lancé, affiche un message pour demander de laner
                return false;
            }
            else
            {
                Debug.WriteLine("Steam c'est bien lancé"); // une fois lancer on envoie un message pour le dire
                SteamApi.Initialize(1794680); // on initialise l'api sur Vampire Survivors

                // Récupération des infos de l'utilisateur

                string userName = SteamApi.SteamFriends.GetPersonaName(); // on récupère le nom de l'utilisateur
                Debug.WriteLine($"Logged in as: {userName}"); // on écrit le nom de l'utilisateur

                var userId = SteamApi.SteamUser.GetSteamID(); // on récupère l'identifiant de l'utilisateur

                utilisateur = new Utilisateur(userName, userId);

                //Task task = GetSuccesJoueur(utilisateur);

                return true;
            }
        }

        //public async Task GetSuccesJoueur(Utilisateur utilisateur)
        //{
        //    ulong userId = ChargeSteamAPI();

        //    Web API(différente)

        //    var webInterfaceFactory = new SteamWebInterfaceFactory("A44E58E08ACF6F1C2AA345462C1E6FBE"); // on initialize notre créateur d'interface entre steam et l'application avec la clé d'authentification steam partner

        //    Succés

        //   var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(); // on créer une interface UserStats

        //    var ach = await steamUserInterface.GetPlayerAchievementsAsync(1794680, utilisateur.Id); // on récupere les succés de l'utilisateur sur Vampire Survivors

        //    IEnumerator<Steam.Models.SteamPlayer.PlayerAchievementModel> res = ach.Data.Achievements.GetEnumerator(); // création d'un iterateur pour parcourir la liste des succés
        //    res.MoveNext(); // on avance une première fois l'itérateur car il se trouve sur une valeur null au début

        //    while (res.MoveNext()) // tant que l'iterateur n'est pas null afficher Nom + desc + validation
        //    {
        //        utilisateur.achievement.Add(res.Current);
        //        Debug.WriteLine("Achievement name : " + res.Current.Name);
        //        Debug.WriteLine("Achievement descirption : " + res.Current.Description);
        //        Debug.WriteLine("Achieved ? (1=yes / 0=no) : " + res.Current.Achieved);
        //        res.MoveNext();
        //    }
        //}
    }
}
