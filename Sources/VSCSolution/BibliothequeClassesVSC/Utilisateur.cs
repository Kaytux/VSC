using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Utilisateur
    {
        public class Note
        {
            public Element Element { get; set; }
            public string Contenu { get; set; }
            public Note(Element element, string contenu)
            {
                Element = element;
                Contenu = contenu;
            }

            //public void afficherNote(Element e)
            //{
            //    foreach (KeyValuePair<Element, string> kvp in Notes)
            //    {
            //        if (kvp.Key == e)
            //        {
            //            Console.WriteLine("\n---\n");
            //            Console.WriteLine("Element : " + kvp.Key.Nom + "\nNotes : " + kvp.Value);
            //            Console.WriteLine("\n---\n");
            //            break;
            //        }
            //    }
            //}
        }
        public Utilisateur(string nom)
        {
            Nom = nom;
            Notes = new HashSet<Note>();
        }

        public string Nom{get;set;}
        public HashSet<Note> Notes { get; set; }

        public void ajouterNotes(Element e, string note) 
        {
            Notes.Add(new Note(e,note));
        }

        public void afficherNotes()
        {
            foreach(Note n in Notes)
            {
                Console.WriteLine(n.ToString());
            }
        }

        public void modifNote(Element e, string nouvelleNote)
        {
            /*foreach (KeyValuePair<Element, string> kvp in Notes)
            {
                if (kvp.Key == e)
                {
                    kvp.Value = nouvelleNote;
                    break;
                }
            }*/
        }

    }
}
