using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Utilisateur
    {
        /// <summary>
        /// Interface permettant l'encapsulation profonde de la collection de Note.
        /// Permet de l'afficher en lecture seule.
        /// </summary>
        public interface INote
        {
            string Contenu { get; }
        }
        /// <summary>
        /// Classe représentant une note.
        /// </summary>
        public class Note : INote
        {
            public Element Element { get; set; }
            public string Contenu { get; set; }
            public Note(Element element, string contenu)
            {
                Element = element;
                Contenu = contenu;
            }

            public override string ToString()
            {
                return Element.ToString() + " : " + Contenu;
            }
        }

        public class AchievementMinimal
        {
            public AchievementMinimal(string nom, string desc, string reussis)
            {
                Nom = nom;
                Desc = desc;
                Reussis = reussis;
            }
            public string Nom { get; set; }
            public string Desc { get; set; }
            public string Reussis { get; set; }
        }

        /// <summary>
        /// Classe représentant un utilisateur
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="id">Identifiant récupéré par l'utilisateur</param>
        public Utilisateur(string nom, ulong id)
        {
            Nom = nom;
            Id = id;
        }

        public string Nom{get;set;}
        public IEnumerable<INote> LesNotes => lesNotes;
        public HashSet<Note> lesNotes = new HashSet<Note>();
        //public List<Steam.Models.SteamPlayer.PlayerAchievementModel> achievement { get; set; } = new List<Steam.Models.SteamPlayer.PlayerAchievementModel>();
        public List<AchievementMinimal> achievementMinimals { get; set; } = new List<AchievementMinimal>();
        public ulong Id { get; set; }

        public void ajouterNotes(Element e, string note) 
        {
            lesNotes.Add(new Note(e,note));
        }
        public void modifNote() { }
    }
}
