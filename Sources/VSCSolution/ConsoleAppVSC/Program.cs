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
       
            Ennemie e = new Ennemie("Axel", statFel);
            Ennemie e1 = new Ennemie("Felix", statFel);

            List<Ennemie> lesE = new List<Ennemie>();
            lesE.Add(e);
            lesE.Add(e1);


            ArmePassive a = new ArmePassive("spinach");
            ArmePassive a1 = new ArmePassive("luckClover");

            List<ArmePassive> objetCacher = new List<ArmePassive>();
            objetCacher.Add(a);
            objetCacher.Add(a1);

            Carte c = new Carte(lesE, objetCacher);
            c.affichArmePassive();
            c.affichEnnemie();
        }
    }
}
