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
            List<Element> objets = new List<Element>();
            objets = AjoutCollection(a1, a2);
            objets = AjoutCollection(
                a1,
                a2,
                new ArmePassive("oui"),
                new ArmePassive("non"),
                new ArmePassive("zae"),
                new ArmePassive("sfgh"),
                new ArmePassive("dnfgr"),
                new ArmePassive("shrthzr"),
                new ArmePassive("oimumy"),
                new ArmePassive("xcvbfds"),
                new ArmeActive("abcazeafv"),
                new ArmeActive("abcazeafv"),
                new ArmeActive("abcazeafv"));

            Console.WriteLine("AFFICHAGE DE LA LISTE :\n");
            AffichList(objets);
            Console.WriteLine();

            // TESTS LINQ

            var listTrié = TriTailleNom(objets);

            Console.WriteLine("TRI DE LA LISTE :\n");
            AffichList(listTrié);
            Console.WriteLine();

            listTrié = TriNom(objets);

            Console.WriteLine("AUTRE TRI DE LA LISTE :\n");
            AffichList(listTrié);
            Console.WriteLine();

            var armesActives=objets.Where(a => a is ArmeActive);

            Console.WriteLine("SELECTION DANS LA LISTE :\n");
            AffichList(armesActives);
            Console.WriteLine();

            var armesPassives = objets.Where(a => a is ArmePassive);

            Console.WriteLine("AUTRE SELECTION DANS LA LISTE :\n");
            AffichList(armesPassives);
            Console.WriteLine();

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

        // ATTENTION : écrase la liste de réception
        static List<Element> AjoutCollection(params Element[] liste)
        {
            List<Element> list = new List<Element>();
            list.AddRange(liste);
            return list;
        }

    }
}
