using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Stat> statFel = new List<Stat>();
            statFel.Add(new Stat(Stat.NomStat.MaxHealth, 40));
            statFel.Add(new Stat(Stat.NomStat.MoveSpeed, -20));
            Personnage p1 = new Personnage("Félix Mielcarek", statFel);
            p1.AffichStats();

            string descr = "Vampire Survivors est le meilleur jeu du monde";
            string descri = "Le dernier patch note est le meilleur que la Terre est jamais pu supportée !!!!!!!!!!!!!!!!!!!";
            Jeu j1 = new Jeu(descr, new Jeu.PatchNote(1,30,descri));
            Console.WriteLine(j1);
        }
    }
}
