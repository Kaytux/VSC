using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : PossedeStats
    {
        public Entite(string nom, string desc, string image, HashSet<Stat> particularite) : base(nom, desc, image, particularite)
        {
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 0));
            stats.Add(new Stat(Stat.NomStat.Recovery, 0));
            stats.Add(new Stat(Stat.NomStat.Armor, 0));
            stats.Add(new Stat(Stat.NomStat.MoveSpeed, 0));
            stats.Add(new Stat(Stat.NomStat.Might, 0));
            stats.Add(new Stat(Stat.NomStat.Area, 0));
            stats.Add(new Stat(Stat.NomStat.Speed, 0));
            stats.Add(new Stat(Stat.NomStat.Duration , 0));
            stats.Add(new Stat(Stat.NomStat.Amount, 0));
            stats.Add(new Stat(Stat.NomStat.Cooldown, 0));
            stats.Add(new Stat(Stat.NomStat.Luck, 0));
            stats.Add(new Stat(Stat.NomStat.Growth, 0));
            stats.Add(new Stat(Stat.NomStat.Greed, 0));
            stats.Add(new Stat(Stat.NomStat.Magnet, 0));
            stats.Add(new Stat(Stat.NomStat.XpGiven, 0));
            stats.Add(new Stat(Stat.NomStat.KnockbackReceive, 0));
        }
    }
}
