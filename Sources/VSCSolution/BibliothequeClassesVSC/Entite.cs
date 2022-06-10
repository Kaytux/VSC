using System.Collections.Generic;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : PossedeStats
    {
        /// <summary>
        /// constructeur de la classe Entite
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="particularite"></param>
        public Entite(string nom, string desc, string image, HashSet<Stat> particularite) : base(nom, desc, image, particularite)
        {
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 0));
            stats.Add(new Stat(Stat.NomStat.MoveSpeed, 0));
            stats.Add(new Stat(Stat.NomStat.Might, 0));
        }
    }
}
