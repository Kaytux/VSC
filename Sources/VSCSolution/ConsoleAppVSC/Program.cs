using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*List<Stat> statFel = new List<Stat>();
            statFel.Add(new Stat(Stat.NomStat.MaxHealth, 40));
            statFel.Add(new Stat(Stat.NomStat.MoveSpeed, -20));
            Personnage p1 = new Personnage("Félix Mielcarek", statFel);
            p1.AffichStats();

            string descr = "Vampire Survivors est le meilleur jeu du monde";
            string descri = "Le dernier patch note est le meilleur que la Terre est jamais pu supportée !!!!!!!!!!!!!!!!!!!";
            Jeu j1 = new Jeu(descr, new Jeu.PatchNote(1,30,descri));
            Console.WriteLine(j1);
       
            Ennemie e = new Ennemie("Axel", statFel);
            Ennemie e1 = new Ennemie("Felix", statFel);

            List<Ennemie> lesE = new List<Ennemie>();
            lesE.Add(e);
            lesE.Add(e1);*/


            ArmeActive a1 = new ArmeActive("abcazeafv");
            ArmeActive a2 = new ArmeActive("abcazeafv");
            List<Arme> objets = new List<Arme>();
            objets.Add(new ArmePassive("abcazeafv"));
            objets.Add(new ArmePassive("def"));
            objets.Add(new ArmePassive("zae"));
            objets.Add(new ArmePassive("sfgh"));
            objets.Add(new ArmePassive("dnfgr"));
            objets.Add(new ArmePassive("shrthzr"));
            objets.Add(new ArmePassive("oimumy"));
            objets.Add(new ArmePassive("xcvbfds"));
            objets.Add(a1);
            objets.Add(a2);
            objets.Add(new ArmeActive("abcazeafv"));
            objets.Add(new ArmeActive("abcazeafv"));
            objets.Add(new ArmeActive("abcazeafv"));


            // TESTS LINQ

            var listTrié = TriTailleNom(objets);
            AffichList(listTrié);
            Console.Write("\n");
            listTrié = TriNom(objets);
            AffichList(listTrié);
            Console.Write("\n");
            var armesActives=objets.Where(a => a is ArmeActive);
            AffichList(armesActives);
            var armesPassives = objets.Where(a => a is ArmePassive);
            AffichList(armesPassives);

            // TESTS COMPARER ELEMENT

            Console.Write("\n");
            //doit afficher vrai
            Console.WriteLine(a1 == a2);    //False
            Console.WriteLine(a1.Equals(a2));   //False
            Console.WriteLine(Element.FullEqComparer.Equals(a1, a2));   //True

            /*Carte c = new Carte("Map",lesE, objetCacher) ;
            c.affichArmePassive();
            c.affichEnnemie();

            Console.WriteLine("\n---Test Utilisateur notes---\n");
            Utilisateur Vincent = new Utilisateur("Vincou");

            Vincent.ajouterNotes(a, "Cette arme est super");
            Vincent.afficherNote(a);
            Vincent.Notes.Add(c, "Cette map est super");
            Vincent.afficherNotes();*/
        }

        static void AffichList(IEnumerable<Element> liste)
        {
            foreach (Element ele in liste)
            {
                Console.WriteLine(ele.Nom.ToString());
            }
        }

        static IEnumerable<Element> TriTailleNom(IEnumerable<Element> liste) => liste.OrderBy(a => a.Nom.Length);
        static IEnumerable<Element> TriNom(IEnumerable<Element> liste) => liste.OrderBy(a => a.Nom);


    }
}
