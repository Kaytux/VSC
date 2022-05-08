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
            Personnage p1 = new Personnage("Félix Mielcarek", statFel);
            p1.AffichStats();
        }
    }
}
