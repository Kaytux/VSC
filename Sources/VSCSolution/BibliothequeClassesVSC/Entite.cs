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
            stats.Add(new Stat(Stat.NomStat.MoveSpeed, 0));
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
    }
}
