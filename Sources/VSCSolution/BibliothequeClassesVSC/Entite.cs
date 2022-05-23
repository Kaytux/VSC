using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : Element , IStatAffichable
    {
        public Entite(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom, desc, image)
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
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 0));
            stats.Add(new Stat(Stat.NomStat.Knockback, 0));
            stats.Add(new Stat(Stat.NomStat.Rarity, 0));
            stats.Add(new Stat(Stat.NomStat.CritRate, 0));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 0));
        }

        public SortedSet<Stat> stats=new SortedSet<Stat>();

        protected void AjoutParticularite(HashSet<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                foreach(Stat stat2 in stats)
                {
                    if (Stat.FullEqComparer.Equals(stat,stat2))
                    {
                        stat2.Valeur += stat.Valeur;
                        break;
                    }
                }
            }
            this.AffichStats();
        }

        public void AffichStats() 
        {
            Console.WriteLine("Statistiques de " + Nom+" :\n");
            foreach (Stat stat in stats)
            {                
                Console.WriteLine(stat);
            }
        }

        public override string ToString()
        {
            return Nom.ToString();
        }
    }
}
