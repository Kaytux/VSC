using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class PossedeStats : Element
    {
        protected PossedeStats(string nom, string desc, string image, HashSet<Stat> particularites) 
            : base(nom, desc, image) 
        {
            this.particularites = particularites;
        }

        public SortedSet<Stat> stats = new SortedSet<Stat>();
        public HashSet<Stat> particularites = new HashSet<Stat>();

        protected void AjoutStats(HashSet<Stat> lesStats)
        {
            foreach (Stat stat in lesStats)
            {
                foreach (Stat stat2 in stats)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur += stat.Valeur;
                        break;
                    }
                }
            }
        }

        protected void EnleverStats(HashSet<Stat> lesStats)
        {
            foreach (Stat stat in lesStats)
            {
                foreach (Stat stat2 in stats)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur -= stat.Valeur;
                        break;
                    }
                }
            }
        }
    }
}
