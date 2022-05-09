using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : Element , IStatAffichable
    {
        public Entite(string nom, List<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom, desc, image)
        {
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 0));
            stats.Add(new Stat(Stat.NomStat.MoveSpeed, 0));
        }

        protected List<Stat> stats=new List<Stat>();

        protected void AjoutParticularite(List<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                for (int i = 0; i < stats.Count; i++)
                {
                    if (stat.Equals(stats[i]))
                    {
                        stats[i] += stat;
                        break;
                    }
                }
            }
        }

        public void AffichStats() 
        {
            foreach (Stat stat in stats)
            {                
                Console.WriteLine(stat);
            }
        }
    }
}
