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

        public Utilisateur Utilisateur { get; set; }

        public Dictionary<ulong, Dictionary<string,string>> lesNotes=new Dictionary<ulong, Dictionary<string,string>>();

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

        public Carte CarteSelectionne
        {
            get => carteSelectionne;
            set
            {
                if (CarteSelectionne != value)
                {
                    carteSelectionne = value;
                    OnPropertyChanged(nameof(CarteSelectionne));
                }
            }
        }
        private Carte carteSelectionne;

        public List<ArmePassive> ApCarteSelectionne
        {
            get => apCarteSelectionne;
            set
            {
                if (ApCarteSelectionne != value)
                {
                    apCarteSelectionne = value;
                    OnPropertyChanged(nameof(ApCarteSelectionne));
                }
            }
        }
        private List<ArmePassive> apCarteSelectionne;

        public List<Ennemie> EnnCarteSelectionne
        {
            get => ennCarteSelectionne;
            set
            {
                if (EnnCarteSelectionne != value)
                {
                    ennCarteSelectionne = value;
                    OnPropertyChanged(nameof(EnnCarteSelectionne));
                }
            }
        }
        private List<Ennemie> ennCarteSelectionne;

        public Utilisateur.Note NoteSelectionne
        {
            get => noteSelectionne;
            set
            {
                if (NoteSelectionne != value)
                {
                    noteSelectionne = value;
                    OnPropertyChanged(nameof(NoteSelectionne));
                }
            }
        }
        private Utilisateur.Note noteSelectionne;

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        /// <summary>
        /// Fonction permettant de charger les données.
        /// </summary>
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
            foreach(var donn in données.lesNotes)
            {
                lesNotes.Add(donn.Key,donn.Value);
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
            CarteSelectionne = LesCartes[0];
            ApCarteSelectionne = CarteSelectionne.LesObjetsCaches;
            EnnCarteSelectionne = CarteSelectionne.LesEnnemies;
        }
        /// <summary>
        /// Méthode de Manager permettant la sauvegarde des données en appellant la méthode "SauvegardeDonnées" de la persistance
        /// </summary>
        public void SauvegardeDonnées()
        {
            bool exist = false;
            if(Utilisateur!=default)
            {
                foreach(var user in lesNotes)
                {
                    if(user.Key == Utilisateur.Id)
                    {
                        exist = true;
                        user.Value.Clear();
                        foreach(var note in Utilisateur.lesNotes)
                        {
                            user.Value.Add(note.Element, note.Contenu);
                        }
                        break;
                    }
                }
                if(!exist)
                {
                    lesNotes.Add(Utilisateur.Id,new Dictionary<string, string>());
                    foreach(var note in Utilisateur.lesNotes)
                    {
                        lesNotes[Utilisateur.Id].Add(note.Element, note.Contenu);
                    }
                }
            }
             Persistance.SauvegardeDonnées(lesArmesPassives,
                                          lesArmesActives,
                                          lesAmeliorations,
                                          lesPersonnages,
                                          lesEnnemies,
                                          lesCartes,
                                          lesNotes);
        }
        /// <summary>
        /// Constructeur du Manager
        /// </summary>
        /// <param name="persistance"></param>
        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
        }

        ~Manager()
        {
            Debug.WriteLine("testDestruct");
            SauvegardeDonnées();
        }
        /// <summary>
        /// Fonction pour initialiser l'API Steam.
        /// </summary>
        public void InitSteamAPI()
        {
            SteamNative.Initialize();
        }
        /// <summary>
        /// Fonction utilisant l'API Steam, afin de récupérer l'identifiant de l'utilisateur, dans le cas ou Steam est bien lancé.
        /// </summary>
        /// <returns></returns>
        public int ChargeSteamAPI()
        {
            // Lancer steam
            // initialisation de Steam Native (permet de détecter le lancement de steam sur la machine)
            var result = SteamApi.IsSteamRunning(); // verifie si steam est lancer
            if (!result)
            {
                Debug.WriteLine("Veuillez lancer steam !"); // si il n'est pas lancé, affiche un message pour demander de laner
                return 1;
            }
            else
            {
                Debug.WriteLine("Steam c'est bien lancé"); // une fois lancer on envoie un message pour le dire
                
                bool test = SteamApi.Initialize(1794680); // on initialise l'api sur Vampire Survivors

                if (!test)
                {
                    return 2;
                }
                else
                {
                    // Récupération des infos de l'utilisateur

                    string userName = SteamApi.SteamFriends.GetPersonaName(); // on récupère le nom de l'utilisateur
                    Debug.WriteLine($"Logged in as: {userName}"); // on écrit le nom de l'utilisateur

                    var userId = SteamApi.SteamUser.GetSteamID(); // on récupère l'identifiant de l'utilisateur

                    Utilisateur = new Utilisateur(userName, userId);

                    foreach(var user in lesNotes)
                    {
                        if(user.Key == Utilisateur.Id)
                        {
                            foreach(var note in user.Value)
                            {
                                Utilisateur.lesNotes.Add(new Utilisateur.Note(note.Key,note.Value));
                            }
                            break;
                        }
                    }
                    return 0;
                }
            }
        }
        /// <summary>
        /// Fonction utilisant l'API Steam afin de récupérer les succès d'un joueur en fonction de son Id
        /// Cette fonctione effectue des requêtes http, à tracvers l'API. Il faut donc qu'elle soit asynchrone.
        /// </summary>
        /// <returns></returns>
        public async Task GetSuccesJoueur()
        {
            //Web API(différente)

            var webInterfaceFactory = new SteamWebInterfaceFactory("A44E58E08ACF6F1C2AA345462C1E6FBE"); // on initialize notre créateur d'interface entre steam et l'application avec la clé d'authentification steam partner

            //Succés

             var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(); // on créer une interface UserStats

            var ach = await steamUserInterface.GetPlayerAchievementsAsync(1794680, Utilisateur.Id); // on récupere les succés de l'utilisateur sur Vampire Survivors

            IEnumerator<Steam.Models.SteamPlayer.PlayerAchievementModel> res = ach.Data.Achievements.GetEnumerator(); // création d'un iterateur pour parcourir la liste des succés
            res.MoveNext(); // on avance une première fois l'itérateur car il se trouve sur une valeur null au début
            while (res.MoveNext()) // tant que l'iterateur n'est pas null afficher Nom + desc + validation
            {
                if (res.Current.Achieved == 1)
                {
                    Utilisateur.achievements.Add(new Utilisateur.Achievements(res.Current.Name, res.Current.Description, "Oui"));
                }
                else if(res.Current.Achieved == 0){
                    Utilisateur.achievements.Add( new Utilisateur.Achievements(res.Current.Name, res.Current.Description, "Non"));
                }
                Debug.WriteLine("Achievement name : " + res.Current.Name);
                Debug.WriteLine("Achievement descirption : " + res.Current.Description);
                Debug.WriteLine("Achieved ? (1=yes / 0=no) : " + res.Current.Achieved);
                res.MoveNext();
            }
        }
    }
}
