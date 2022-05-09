using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Utilisateur
    {
        public Utilisateur(string nom)
        {
            Nom = nom;
            Notes = new Dictionary<Element, string>();
        }

        public string Nom{get;set;}

        public Dictionary<Element,string> Notes { get; set; }

        public void ajouterNotes(Element e, string note) 
        {
            Notes.Add(e,note);
        }

        public void afficherNotes()
        {
            Console.WriteLine("\n---\n");
            foreach(KeyValuePair<Element,string> kvp in this.Notes)
            {
                Console.WriteLine("Element : " + kvp.Key.Nom + "\nNotes : " + kvp.Value+"\n");
            }
            Console.WriteLine("\n---\n");
        }

        public void afficherNote(Element e)
        {
            foreach (KeyValuePair < Element,string> kvp in Notes)
            {
                if (kvp.Key == e)
                {
                    Console.WriteLine("\n---\n");
                    Console.WriteLine("Element : " + kvp.Key.Nom + "\nNotes : " + kvp.Value); 
                    Console.WriteLine("\n---\n");
                    break;
                }
            }
        }

        public void modifNote(Element e, string nouvelleNote)
        {
            foreach (KeyValuePair<Element, string> kvp in Notes)
            {
                if (kvp.Key == e)
                {
                    kvp.Value = nouvelleNote;
                    break;
                }
            }
        }

    }
}
