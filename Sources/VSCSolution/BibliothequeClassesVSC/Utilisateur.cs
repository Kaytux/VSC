using System.Collections.Generic;
using System.Linq;

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
            string Element { get; }
            string Contenu { get; }
        }
        /// <summary>
        /// Classe représentant une note.
        /// </summary>
        public class Note : INote
        {
            public string Element { get; set; }
            public string Contenu { get; set; }
            public Note(string element, string contenu)
            {
                Element = element;
                Contenu = contenu;
            }

            public override string ToString()
            {
                return Element.ToString() + " : " + Contenu;
            }
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

        /// <summary>
        /// declaration de l'attribut Nom avec son getter et setter
        /// </summary>
        public string Nom { get; set; }
        public IEnumerable<INote> LesNotes => lesNotes.Where(note => note.Contenu.Length > 0);
        public HashSet<Note> lesNotes = new HashSet<Note>();
        /// <summary>
        /// classe interne à Utilisateur, créant un succès composé de 3 attributs (nom, desc, reussi)
        /// </summary>
        public class Achievements
        {
            /// <summary>
            /// constructeur d'un achivement
            /// </summary>
            /// <param name="nom"></param>
            /// <param name="desc"></param>
            /// <param name="reussis"></param>
            public Achievements(string nom, string desc, string reussis)
            {
                Nom = nom;
                Desc = desc;
                Reussis = reussis;
            }
            /// <summary>
            /// déclaration de l'attribut Nom de l'achievement
            /// </summary>
            public string Nom { get; set; }
            /// <summary>
            /// déclaration de l'attribut Description de l'achievement
            /// </summary>
            public string Desc { get; set; }
            /// <summary>
            /// déclaration de l'attribut Reussis de l'achievement (prend la valeur "Oui" si le succés est compléter par le joueur, prend la valeur "Non" si le succès n'est pas complété.
            /// </summary>
            public string Reussis { get; set; }
        }
        /// <summary>
        /// déclaration de l'attribut liste d'Achievement pour l'utilisateur
        /// </summary>
        public List<Achievements> achievements { get; set; } = new List<Achievements>();
        /// <summary>
        /// déclaration de l'attribut Id de l'utilisateur (il s'agit de son identifiant Steam récupéré par l'API)
        /// </summary>
        public ulong Id { get; set; }
    }
}
