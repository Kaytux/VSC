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

        public string Nom{get;set;}
        public IEnumerable<INote> LesNotes => lesNotes.Where(note => note.Contenu.Length >0);
        public HashSet<Note> lesNotes = new HashSet<Note>();

        public class Achievements
        {
            public Achievements(string nom, string desc, string reussis)
            {
                Nom = nom;
                Desc = desc;
                Reussis = reussis;
            }

            public string Nom { get; set; }
            public string Desc { get; set; }
            public string Reussis { get; set; }
        }

        public List<Achievements> achievements { get; set; } = new List<Achievements>();
        public ulong Id { get; set; }
    }
}
